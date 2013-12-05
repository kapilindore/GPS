using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormHisPos : FormUntitle
    {
        private String fileName;

        public FormHisPos()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, true, true);
        }

        private void FormHisPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listViewHisPos.Items.Count == 0)
            {
                MessageBox.Show(this, "没有任何项目");
                return;
            }
            DataTable dt = new DataTable();
            foreach(ColumnHeader ch in listViewHisPos.Columns)
                dt.Columns.Add(ch.Text);
            foreach(ListViewItem item in listViewHisPos.Items)
            {
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, 
                    item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                    item.SubItems[7].Text,item.SubItems[8].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void RefreshInfo(String carNO, DateTime sTime, DateTime eTime)
        {
            labelInfo.Text = carNO + ",时间从" + sTime.ToString("yyyy-MM-dd HH:mm") + "到" + eTime.ToString("yyyy-MM-dd HH:mm");
            fileName = Config.APP_PATH + carNO + "轨迹列表[" + sTime.ToString("yyyy_MM_dd_HH_mm") + "-" + eTime.ToString("yyyy_MM_dd_HH_mm") + "].xls";
        }

        public void RefreshList()
        {
            labelCount.Text = FormMain.hisPosList.Count.ToString();
            listViewHisPos.Items.Clear();
            foreach(Position pos in FormMain.hisPosList)
            {
                ListViewItem item = new ListViewItem(pos.GpsTime);
                listViewHisPos.Items.Add(item);
                item.SubItems.Add(Position.POINTED[pos.Pointed]);
                item.SubItems.Add(Position.DIR[pos.Direction]);
                item.SubItems.Add(pos.Speed.ToString());
                item.SubItems.Add(pos.Lo.ToString());
                item.SubItems.Add(pos.La.ToString());
                item.SubItems.Add(pos.Status);
                item.SubItems.Add(pos.Alarm);
                item.SubItems.Add(Position.ALARM_HANDLE[pos.AlarmHandle]);
                item.Tag = pos;
            }
        }

        private void FormHisPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
    }
}