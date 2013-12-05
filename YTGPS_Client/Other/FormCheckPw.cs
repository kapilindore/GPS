using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCheckPw : FormUntitle
    {
        public FormCheckPw()
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == FormMain.user.Pw)
                button1.Enabled = true;
        }

        private void FormCheckPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
    }
}