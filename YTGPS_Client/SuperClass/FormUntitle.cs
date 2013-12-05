using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormUntitle : Form
    {
        public FormUntitle()
        {
            InitializeComponent();
        }

        private int x = 0;
        private int y = 0;
        private bool sizeable = true;
        
        public void SetFormStyle(bool canSize, bool minbtn, bool maxbtn, bool xbtn)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            sizeable = canSize;
            buttonX1.Visible = minbtn;
            buttonX2.Visible = maxbtn;
            buttonX3.Visible = xbtn;
            labelTitle.Text = this.Text;
            buttonX1.Left = this.Width - 78;
            buttonX2.Left = this.Width - 52;
            buttonX3.Left = this.Width - 26;
        }

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += (e.X - x);
                this.Top += (e.Y - y);
            }
        }

        private void Title_DoubleClick(object sender, EventArgs e)
        {
            if(buttonX2.Visible)
                buttonX2.PerformClick();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}