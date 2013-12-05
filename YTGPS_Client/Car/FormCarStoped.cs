using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCarStoped : FormUntitle
    {
        private Car car;

        public FormCarStoped(Car c)
        {
            InitializeComponent();
            this.SetFormStyle(false, false, false, false);
            comboBox1.Items.Add("����");
            comboBox1.Items.Add("ͣ��");
            car = c;
            labelCNO.Text = c.CarNO;
            labelStoped.Text = Car.SERVICE_STATUS[c.Stoped];
            comboBox1.SelectedIndex = Math.Abs(c.Stoped - 1);
        }

        private void FormCarStoped_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == car.Stoped)
            {
                MessageBox.Show(this, "����״̬û�иı�");
                return;
            }
            FormMain.C_Set_Stoped(car, comboBox1.SelectedIndex);
            this.Close();
        }
    }
}