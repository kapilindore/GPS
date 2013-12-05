using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormChat : FormUntitle
    {
        public FormChat()
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(textBoxContent.Text == "")
                return;
            if((FormMain.user.Type == User.USER_TEAM || FormMain.user.Type == User.USER_CAR)
                && (checkBoxX1.Checked || checkBoxX3.Checked))
                checkBoxX2.Checked = true;
            String s = "";
            if(checkBoxX1.Checked)
                s = Constant.C_CHAT_TO_ALL.ToString();
            else if(checkBoxX2.Checked)
                s = Constant.C_CHAT_TO_ADMIN.ToString();
            else s = Constant.C_CHAT_TO_USER.ToString();
            FormMain.C_Chat(s + textBoxContent.Text);
            textBoxContent.Text = "";
        }

        private void FormChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.buttonSend.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.buttonClose.PerformClick();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void AddLine(String s)
        {
            listBox1.Items.Add(s);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        public void Clear()
        {
            listBox1.Items.Clear();
        }
    }
}