using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormUserInfo : FormUntitle
    {
        private Account temp;
        public FormUserInfo(Account account)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
            temp = account;
            textBox1.Text = temp.Name;
            textBox2.Text = temp.Pw;
            textBox3.Text = temp.Tel;
            textBox4.Text = temp.Email;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != ""
                && (temp.Name != textBox1.Text || temp.Pw != textBox2.Text
                || temp.Tel != textBox3.Text || temp.Email != textBox4.Text))
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.Name = textBox1.Text;
            temp.Pw = textBox2.Text;
            temp.Tel = textBox3.Text;
            temp.Email = textBox4.Text;
        }

        private void FormUserInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
    }
}