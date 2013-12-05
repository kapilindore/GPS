using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormAlarmList : FormUntitle
    {
        private List<AlarmPosition> posList;
        private AlarmPosition selPos;

        private FormMain mainFrm;

        public delegate void ShowPosDelegate(AlarmPosition apos);
        public event ShowPosDelegate OnShowPos;

        public FormAlarmList()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, true, true);
        }

        public void ShowList(FormMain frm)
        {
            mainFrm = frm;
            this.Show();
        }

        private void FormAlarmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void RefreshList(List<AlarmPosition> list)
        {
            posList = list;
            listView1.Items.Clear();
            selPos = null;
            foreach(AlarmPosition apos in posList)
            {
                if(apos.Car == FormMain.alarmHandleCar)
                    continue;
                bool hasIn = false;
                foreach(ListViewItem it in listView1.Items)
                {
                    AlarmPosition prePos = it.Tag as AlarmPosition;
                    if(prePos.Car == apos.Car)
                    {
                        try
                        {
                            if(Pub.DateDiff(DateTime.Parse(prePos.GpsTime), DateTime.Parse(apos.GpsTime)) > 0)
                            {
                                it.SubItems[1].Text = apos.Car.CarNO;
                                it.SubItems[2].Text = apos.Car.Team.TeamName;
                                it.SubItems[3].Text = apos.GpsTime;
                                it.SubItems[4].Text = apos.Status;
                                it.SubItems[5].Text = apos.Alarm;
                                //it.SubItems[6].Text = Position.ALARM_HANDLE[apos.AlarmHandle];
                            }
                        }
                        catch { }
                        hasIn = true;
                        break;
                    }
                }
                if(hasIn)
                    continue;
                ListViewItem item = new ListViewItem(apos.Id.ToString());
                listView1.Items.Add(item);
                item.SubItems.Add(apos.Car.CarNO);
                item.SubItems.Add(apos.Car.Team.TeamName);
                item.SubItems.Add(apos.GpsTime);
                item.SubItems.Add(apos.Status);
                item.SubItems.Add(apos.Alarm);
                //item.SubItems.Add(Position.ALARM_HANDLE[apos.AlarmHandle]);
                item.Tag = apos;
            }
            labelCount.Text = listView1.Items.Count.ToString();
            if(posList.Count == 0)
                this.Hide();
            else button1.Enabled = true;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if(item != null || selPos != (item.Tag as AlarmPosition))
                selPos = item.Tag as AlarmPosition;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if(item != null)
                OnShowPos(item.Tag as AlarmPosition);
        }

        public void HandleAlarmResponse()
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selPos != null)
            {
                this.Hide();
                if(FormMain.dataSocket.Connected && !FormMain.inAlarmHandle)
                {
                    FormMain.C_Alarm_Handle(selPos.Car, true);
                }
            }
        }

        void frm_OnShowPos(AlarmPosition apos)
        {
            OnShowPos(apos);
        }
    }
}