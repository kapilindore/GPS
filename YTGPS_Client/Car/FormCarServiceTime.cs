using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCarServiceTime : FormUntitle
    {
        private Car car;

        public FormCarServiceTime(Car c)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
            car = c;
            labelCNO.Text = c.CarNO;
            labelServiceTime.Text = c.OverServiceTime;
            dateTimePicker1.Value = DateTime.Now.AddMonths(1);
        }

        private void FormOverService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value <= DateTime.Now && MessageBox.Show(this, "新服务日期早于当前日期，是否继续设置？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            FormMain.C_Set_ServiceTime(car, dateTimePicker1.Value.ToString("yyyy-MM-dd"), checkBox1.Checked);
            this.Close();
        }
    }
}