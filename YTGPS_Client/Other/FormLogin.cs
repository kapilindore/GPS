using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormLogin : FormUntitle
    {
        private FormMain frmMain;

        public FormLogin(FormMain fmain)
        {
            InitializeComponent();
            frmMain = fmain;
            this.SetFormStyle(false, false, false, false);
            foreach(HostConfig lc in Config.LoginList)
                comboBoxhost.Items.Add(lc.Host);
            foreach(UserConfig ur in Config.UserList)
                comboBoxuser.Items.Add(ur.Name);
            comboBoxtype.Items.Add("系统管理员");
            comboBoxtype.Items.Add("分控管理员");
            comboBoxtype.Items.Add("车队用户");
           // comboBoxtype.Items.Add("车辆用户");
            comboBoxtype.SelectedIndex = 0;
            if(comboBoxhost.Items.Count > 0)
                comboBoxhost.SelectedIndex = 0;
            if(comboBoxuser.Items.Count > 0)
                comboBoxuser.SelectedIndex = 0;
            frmMain.onConnected += new FormMain.onConnectedDelegate(frmMain_onConnected);
            frmMain.onLogin += new FormMain.onLoginDelegate(frmMain_onLogin);
            frmMain.onDisconn += new FormMain.onDisconnDelegate(frmMain_onDisconn);
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.onLogin -= frmMain_onLogin;
            frmMain.onConnected -= frmMain_onConnected;
            frmMain.onDisconn -= frmMain_onDisconn;
        }

        private void comboBoxhost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxhost.SelectedIndex >= 0)
                textBoxport.Text = Config.LoginList[comboBoxhost.SelectedIndex].Port.ToString();
        }

        private void comboBoxuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxuser.SelectedIndex >= 0)
                comboBoxtype.SelectedIndex = Config.UserList[comboBoxuser.SelectedIndex].Type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBoxhost.Text == "" || textBoxport.Text == ""
                || comboBoxuser.Text == "" || textBoxpw.Text == "")
            {
                MessageBox.Show(this, StrConst.MSG_EMPTY_INFO, StrConst.TITLE_MSG);
                return;
            }
            FormMain.user.Host = comboBoxhost.Text;
            FormMain.user.Port = Int32.Parse(textBoxport.Text);
            FormMain.user.Type = comboBoxtype.SelectedIndex;
            FormMain.user.Name = comboBoxuser.Text;
            FormMain.user.Pw = textBoxpw.Text;
            panel1.Enabled = false;
            button1.Enabled = false;
            frmMain.Login();
        }

        void frmMain_onConnected(bool hasConn)
        {
            if(hasConn)
                labelInfo.Text = StrConst.CONN_HAS_CONN;
            else
            {
                labelInfo.Text = StrConst.CONN_ERR_HOST;
                panel1.Enabled = true;
                button1.Enabled = true;
            }
        }

        void frmMain_onLogin(bool hasLogin, bool isReconn)
        {
            if(hasLogin)
                this.Close();
            else
            {
                if(isReconn)
                    labelInfo.Text = StrConst.CONN_RELOGIN;
                else labelInfo.Text = StrConst.CONN_LOGIN_FAIL;
                panel1.Enabled = true;
                button1.Enabled = true;
            }
        }

        void frmMain_onDisconn()
        {
            if (labelInfo.Text != StrConst.CONN_RELOGIN && 
                labelInfo.Text != StrConst.CONN_LOGIN_FAIL)
                labelInfo.Text = StrConst.CONN_DOWN_ERR;
            panel1.Enabled = true;
            button1.Enabled = true;
        }

        private void FormLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void textBoxport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.KeyChar = (char)0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMain.Logout();
        }
    }
}