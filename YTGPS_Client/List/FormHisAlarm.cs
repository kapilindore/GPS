using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormHisAlarm : FormUntitle
    {
        private String fileName;

        public FormHisAlarm()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, true, true);
        }

        private void FormHisAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listViewHisAlarm.Items.Count == 0)
            {
                MessageBox.Show(this, "没有任何项目");
                return;
            }
            DataTable dt = new DataTable();
            foreach(ColumnHeader ch in listViewHisAlarm.Columns)
                dt.Columns.Add(ch.Text);
            foreach(ListViewItem item in listViewHisAlarm.Items)
            {
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, 
                    item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                    item.SubItems[7].Text,item.SubItems[8].Text,item.SubItems[9].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void RefreshInfo(DateTime sTime, DateTime eTime)
        {
            labelInfo.Text = "时间从" + sTime.ToString("yyyy-MM-dd HH:mm") + "到" + eTime.ToString("yyyy-MM-dd HH:mm");
            fileName = Config.APP_PATH + "报警列表[" + sTime.ToString("yyyy_MM_dd_HH_mm") + "-" + eTime.ToString("yyyy_MM_dd_HH_mm") + "].xls";
        }

        public void RefreshList()
        {
            textBox1.Text = "";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("全部");
            comboBox1.SelectedIndex = 0;
            foreach(HisAlarmPosition pos in FormMain.hisAlarmList)
                if(!comboBox1.Items.Contains(pos.Alarm))
                    comboBox1.Items.Add(pos.Alarm);
            comboBox1.SelectedIndex = 0;
            buttonX4.PerformClick();
        }

        private void FormHisAlarm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            listViewHisAlarm.Items.Clear();
            int count = 0;
            if(comboBox1.SelectedIndex == 0)
            {
                if(textBox1.Text == "")
                {
                    foreach(HisAlarmPosition pos in FormMain.hisAlarmList)
                    {
                        ListViewItem item = new ListViewItem(pos.Car.CarNO);
                        listViewHisAlarm.Items.Add(item);
                        item.SubItems.Add(pos.GpsTime);
                        item.SubItems.Add(Position.POINTED[pos.Pointed]);
                        item.SubItems.Add(Position.DIR[pos.Direction]);
                        item.SubItems.Add(pos.Speed.ToString());
                        item.SubItems.Add(pos.Lo.ToString());
                        item.SubItems.Add(pos.La.ToString());
                        item.SubItems.Add(pos.Status);
                        item.SubItems.Add(pos.Alarm);
                        item.SubItems.Add(Position.ALARM_HANDLE[pos.AlarmHandle]);
                        item.SubItems.Add(pos.Remark);
                        item.Tag = pos;
                        count++;
                    }
                }
                else
                {
                    foreach(HisAlarmPosition pos in FormMain.hisAlarmList)
                    {
                        if(pos.Car.CarNO.IndexOf(textBox1.Text) >= 0)
                        {
                            ListViewItem item = new ListViewItem(pos.Car.CarNO);
                            listViewHisAlarm.Items.Add(item);
                            item.SubItems.Add(pos.GpsTime);
                            item.SubItems.Add(Position.POINTED[pos.Pointed]);
                            item.SubItems.Add(Position.DIR[pos.Direction]);
                            item.SubItems.Add(pos.Speed.ToString());
                            item.SubItems.Add(pos.Lo.ToString());
                            item.SubItems.Add(pos.La.ToString());
                            item.SubItems.Add(pos.Status);
                            item.SubItems.Add(pos.Alarm);
                            item.SubItems.Add(Position.ALARM_HANDLE[pos.AlarmHandle]);
                            item.SubItems.Add(pos.Remark);
                            item.Tag = pos;
                            count++;
                        }
                    }
                }
            }
            else
            {
                if(textBox1.Text == "")
                {
                    foreach(HisAlarmPosition pos in FormMain.hisAlarmList)
                    {
                        if(pos.Alarm == (String)comboBox1.SelectedItem)
                        {
                            ListViewItem item = new ListViewItem(pos.Car.CarNO);
                            listViewHisAlarm.Items.Add(item);
                            item.SubItems.Add(pos.GpsTime);
                            item.SubItems.Add(Position.POINTED[pos.Pointed]);
                            item.SubItems.Add(Position.DIR[pos.Direction]);
                            item.SubItems.Add(pos.Speed.ToString());
                            item.SubItems.Add(pos.Lo.ToString());
                            item.SubItems.Add(pos.La.ToString());
                            item.SubItems.Add(pos.Status);
                            item.SubItems.Add(pos.Alarm);
                            item.SubItems.Add(Position.ALARM_HANDLE[pos.AlarmHandle]);
                            item.SubItems.Add(pos.Remark);
                            item.Tag = pos;
                            count++;
                        }
                    }
                }
                else
                {
                    foreach(HisAlarmPosition pos in FormMain.hisAlarmList)
                    {
                        if(pos.Alarm == (String)comboBox1.SelectedItem && pos.Car.CarNO.IndexOf(textBox1.Text) >= 0)
                        {
                            ListViewItem item = new ListViewItem(pos.Car.CarNO);
                            listViewHisAlarm.Items.Add(item);
                            item.SubItems.Add(pos.GpsTime);
                            item.SubItems.Add(Position.POINTED[pos.Pointed]);
                            item.SubItems.Add(Position.DIR[pos.Direction]);
                            item.SubItems.Add(pos.Speed.ToString());
                            item.SubItems.Add(pos.Lo.ToString());
                            item.SubItems.Add(pos.La.ToString());
                            item.SubItems.Add(pos.Status);
                            item.SubItems.Add(pos.Alarm);
                            item.SubItems.Add(Position.ALARM_HANDLE[pos.AlarmHandle]);
                            item.SubItems.Add(pos.Remark);
                            item.Tag = pos;
                            count++;
                        }
                    }
                }
            }
            labelCount.Text = count.ToString();
        }
    }
}