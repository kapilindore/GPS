using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormOperationHis : FormUntitle
    {
        public FormOperationHis()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, true, true);
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }

        private void FormOperationHis_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void refreshList(String s)
        {
            listView1.Items.Clear();
            String[] ss = s.Split(Constant.SPLIT1);
            foreach(String s1 in ss)
            {
                try
                {
                    String[] sss = s1.Split(Constant.SPLIT2);
                    ListViewItem item = new ListViewItem(sss[0]);
                    item.SubItems.Add(sss[1]);
                    item.SubItems.Add(sss[2]);
                    item.SubItems.Add(sss[3]);
                    listView1.Items.Add(item);
                }
                catch { }
            }
            labelCount.Text = listView1.Items.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stb = new StringBuilder(textBox1.Text).Append(Constant.SPLIT1);
            stb.Append(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(textBox2.Text);
            FormMain.C_Query_Operation(stb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show(this, "没有任何项目");
                return;
            }
            DataTable dt = new DataTable();
            foreach(ColumnHeader ch in listView1.Columns)
                dt.Columns.Add(ch.Text);
            foreach(ListViewItem item in listView1.Items)
            {
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, Config.APP_PATH + "用户操作记录.xls");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}