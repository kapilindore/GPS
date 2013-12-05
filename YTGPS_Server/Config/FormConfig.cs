using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace YTGPS_Server
{
    public partial class FormConfig : Form
    {
        private List<Team> teamList;

        public FormConfig(List<Team> teams)
        {
            InitializeComponent();
            teamList = teams;
            textBoxDBHost.Text = Config.DbHost;
            textBoxDBName.Text = Config.DbName;
            textBoxDBUser.Text = Config.DbUser;
            textBoxDBPw.Text = Config.DbPw;

            foreach(SmsConfig smsconfig in Config.SmsList)
            {
                ListViewItem item = new ListViewItem(smsconfig.SmsName);
                item.SubItems.Add(smsconfig.SmsHost);
                item.SubItems.Add(smsconfig.SmsPort.ToString());
                item.SubItems.Add(smsconfig.SmsPw);
                //item.Checked = smsconfig.Enabled;
                item.Tag = listViewSmsList.Items.Count.ToString();
                listViewSmsList.Items.Add(item);
            }
            checkBoxSmsAutoStart.Checked = Config.SmsAutoStart;

            textBoxDataPort.Text = Config.DataPort.ToString();
            textBoxDataPort.KeyPress += PubEvent.KeyPress_NumInput;
            textBoxDataPw.Text = Config.DataPw;
            checkBoxDataAutoStart.Checked = Config.DataAutoStart;

            textBoxModemPort.Text = Config.ModemPort.ToString();
            textBoxModemPort.KeyPress += PubEvent.KeyPress_NumInput;
            textBoxModemPw.Text = Config.ModemPw;
            checkBoxModemAutoStart.Checked = Config.ModemAutoStart;

            textBoxGprsPort.Text = Config.GprsPort.ToString();
            numericUpDownTcpCutTime.Value = Config.TcpCutTime;
            checkBoxGprsAutoStart.Checked = Config.GprsAutoStart;

            checkBoxAllowChat.Checked = Config.AllowChat;
        }

        //测试数据库连接
        private void buttonTestDB_Click(object sender, EventArgs e)
        {
            DBManager dbm = DBManager.GetInstance(textBoxDBHost.Text, textBoxDBName.Text, textBoxDBUser.Text, textBoxDBPw.Text);
            if(dbm == null)
                MessageBox.Show(this, StrConst.ERR_DB);
            else
            {
                dbm.Close();
                MessageBox.Show(this, StrConst.OK_DB);
            }
        }

        private void listViewSmsList_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewItem item = listViewSmsList.GetItemAt(e.X, e.Y);
                if(item != null)
                {
                    toolStripMenuItem2.Enabled = true;
                    toolStripMenuItem3.Enabled = true;
                    toolStripMenuItem4.Enabled = true;
                    contextMenuStrip1.Tag = item;
                }
                else
                {
                    toolStripMenuItem2.Enabled = false;
                    toolStripMenuItem3.Enabled = false;
                    toolStripMenuItem4.Enabled = false;
                }
            }
        }
        //添加移动接口
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SmsConfig smsconfig = new SmsConfig();
            FormSmsConfig frm = new FormSmsConfig(smsconfig);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem(smsconfig.SmsName);
                item.SubItems.Add(smsconfig.SmsHost);
                item.SubItems.Add(smsconfig.SmsPort.ToString());
                item.SubItems.Add(smsconfig.SmsPw);
                item.Tag = listViewSmsList.Items.Count.ToString();
                //item.Checked = smsconfig.Enabled;
                listViewSmsList.Items.Add(item);
            }
        }
        //修改移动接口
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ListViewItem item = contextMenuStrip1.Tag as ListViewItem;
            SmsConfig smsconfig = new SmsConfig();
            smsconfig.SmsName = item.Text;
            smsconfig.SmsHost = item.SubItems[1].Text;
            smsconfig.SmsPort = Int32.Parse(item.SubItems[2].Text);
            smsconfig.SmsPw = item.SubItems[3].Text;
            FormSmsConfig frm = new FormSmsConfig(smsconfig);
            if(frm.ShowDialog(this) == DialogResult.OK)
            {
                item.Text = smsconfig.SmsName;
                item.SubItems[1].Text = smsconfig.SmsHost;
                item.SubItems[2].Text = smsconfig.SmsPort.ToString();
                item.SubItems[3].Text = smsconfig.SmsPw;
                //item.Checked = smsconfig.Enabled;
            }
        }
        //删除移动接口
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ListViewItem item = contextMenuStrip1.Tag as ListViewItem;
            String s = "";
            foreach(Team team in teamList)//查找使用此连接的车辆
                foreach(Car car in team.Cars)
                    if(car.Routeway - 2 == Int32.Parse(item.Tag as String))
                        s = s + car.CarNO + ",";
            if(s != "")
            {
                MessageBox.Show(this, s + StrConst.ERR_DEL_SMS);
                return;
            }
            listViewSmsList.Items.Remove(item);
        }
        //测试移动专线端口
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ListViewItem item = contextMenuStrip1.Tag as ListViewItem;
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(item.SubItems[1].Text, Int32.Parse(item.SubItems[2].Text));
            }
            catch { }
            if(client.Connected)
                MessageBox.Show(this, StrConst.OK_SMS);
            else MessageBox.Show(this, StrConst.ERR_SMS);
            client.Client.Close();
        }
        //测试端口是否可用
        private void TestPort(int port)
        {
            try
            {
                TcpListener listener = new TcpListener(port);
                listener.Start();
                listener.Server.Close();
                listener.Stop();
                MessageBox.Show(this, StrConst.OK_PORT);
            }
            catch { MessageBox.Show(this, StrConst.ERR_PORT_DATA); }
        }
        //测试分控服务
        private void buttonTestData_Click(object sender, EventArgs e)
        {
            TestPort(Int32.Parse(textBoxGprsPort.Text));
        }
        //测试gprs服务
        private void buttonGprsTest_Click(object sender, EventArgs e)
        {
            TestPort(Int32.Parse(textBoxDataPort.Text));
        }
        //测试短信猫服务
        private void buttonModemTest_Click(object sender, EventArgs e)
        {
            TestPort(Int32.Parse(textBoxModemPort.Text));
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Config.DbHost = textBoxDBHost.Text;
            Config.DbName = textBoxDBName.Text;
            Config.DbUser = textBoxDBUser.Text;
            Config.DbPw = textBoxDBPw.Text;
            Config.SmsList.Clear();
            foreach(ListViewItem item in listViewSmsList.Items)
            {
                SmsConfig smsconfig = new SmsConfig();
                smsconfig.SmsName = item.Text;
                smsconfig.SmsHost = item.SubItems[1].Text;
                smsconfig.SmsPort = Int32.Parse(item.SubItems[2].Text);
                smsconfig.SmsPw = item.SubItems[3].Text;
                Config.SmsList.Add(smsconfig);
                //smsconfig.Enabled = item.Checked;
            }
            Config.SmsAutoStart = checkBoxSmsAutoStart.Checked;

            Config.DataPort = Int32.Parse(textBoxDataPort.Text);
            Config.DataPw = textBoxDataPw.Text;
            Config.DataAutoStart = checkBoxDataAutoStart.Checked;

            Config.ModemPort = Int32.Parse(textBoxModemPort.Text);
            Config.ModemPw = textBoxModemPw.Text;
            Config.ModemAutoStart = checkBoxModemAutoStart.Checked;

            Config.GprsPort = Int32.Parse(textBoxGprsPort.Text);
            Config.TcpCutTime = (int)numericUpDownTcpCutTime.Value;
            Config.GprsAutoStart = checkBoxGprsAutoStart.Checked;

            Config.AllowChat = checkBoxAllowChat.Checked;

            Config.saveToFile();
        }
    }
}