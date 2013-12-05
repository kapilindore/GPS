using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormDeclareListHis : FormUntitle
    {
        private List<Declare> decList = null;
        private FormMain frmMain;

        public FormDeclareListHis()
        {
            InitializeComponent();
            this.SetFormStyle(true, true, true, true);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker3.Value = DateTime.Now.AddMonths(-1);
        }

        private void FormDeclareListHis_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void refreshList(FormMain f, List<Declare> list)
        {
            frmMain = f;
            decList = list;
            listView1.Items.Clear();
            try
            {
            }
            catch { };
            foreach(Declare dec in decList)
            {
                ListViewItem item = new ListViewItem(dec.DeclareID.ToString());
                item.SubItems.Add(dec.ReferDate);
                item.SubItems.Add(dec.DeclareContent);
                Car car = FormMain.user.GetCarByID(dec.CarID);
                if(car != null)
                {
                    item.SubItems.Add(car.CarNO);
                    if(dec.OpUser != "")
                    {
                        item.SubItems.Add("是");
                        item.SubItems.Add(dec.Operation);
                        item.SubItems.Add(dec.Fittings);
                        item.SubItems.Add(dec.Mechanic);
                        item.SubItems.Add(dec.Opinion);
                        item.SubItems.Add(dec.OpUser);
                        item.SubItems.Add(dec.OpDate);
                    }
                    else item.SubItems.Add("否");
                    item.Tag = dec;
                    listView1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stb = new StringBuilder(textBox1.Text).Append(Constant.SPLIT1);
            stb.Append(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(textBox2.Text).Append(Constant.SPLIT1).Append(comboBox1.SelectedIndex.ToString());
            stb.Append(Constant.SPLIT1).Append(textBox3.Text);
            stb.Append(Constant.SPLIT1).Append(checkBox1.Checked ? "1" : "0").Append(Constant.SPLIT1);
            stb.Append(dateTimePicker3.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(dateTimePicker4.Value.ToString("yyyy-MM-dd HH:mm")).Append(Constant.SPLIT1);
            stb.Append(textBox4.Text).Append(Constant.SPLIT1).Append(comboBox2.SelectedIndex.ToString());
            stb.Append(Constant.SPLIT1).Append(textBox5.Text).Append(Constant.SPLIT1);
            FormMain.C_DeclareListHis(stb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                Declare dec = (listView1.SelectedItems[0].Tag as Declare);
                FormDeclare frm = new FormDeclare(frmMain, dec);
                frm.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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
                String[] values = { item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, 
                    item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text,
                    item.SubItems[7].Text,item.SubItems[8].Text,item.SubItems[9].Text,item.SubItems[10].Text};
                dt.Rows.Add(values);
            }
            Pub.ExportExcel(dt, Config.APP_PATH + "投诉、故障记录.xls");
        }
    }
}