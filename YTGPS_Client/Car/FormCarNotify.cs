using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCarNotify : FormUntitle
    {
        private Car car;

        public FormCarNotify(Car c)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
            car = c;
            labelcno.Text = car.CarNO;
            checkBox1.Checked = car.Notify == 1;
            try { dateTimePicker1.Value = DateTime.Parse(car.NotifyStart); }catch { }
            try { dateTimePicker2.Value = DateTime.Parse(car.NotifyEnd); }catch { }
            textBox1.Text = car.NotifyText;
        }

        private void FormCarNotify_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.C_Set_Notify(car.CarID, checkBox1.Checked, dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                dateTimePicker2.Value.ToString("yyyy-MM-dd"), textBox1.Text);
        }
    }
}