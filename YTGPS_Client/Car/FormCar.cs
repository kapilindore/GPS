using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCar : FormUntitle
    {
        private Car temp;
        private bool inited = false;
        private FormMain frmMain;

        public FormCar(FormMain fMain, Car car)
        {
            InitializeComponent();
            frmMain = fMain;
            if(car.CarNO == "")
                this.Text = "添加车辆";
            else dateTimePicker13.Enabled = false;
            this.SetFormStyle(false, false, false, false);
            this.temp = car;
            labelTeam.Text = car.Team.TeamName;
            textBox00.Text = temp.CarNO;
            textBox0.Text = temp.SimNO;
            textBox0.KeyPress += Pub.KeyPress_NumInput;
            textBox1.Text = temp.MachineNO;
            //textBox1.KeyPress += Pub.KeyPress_NumInput;
            textBox2.Text = temp.ControlPassword;
            textBox3.Text = temp.MachineType;
            foreach(String s in Car.PROTOCOL)
                comboBox4.Items.Add(s);
            if(temp.Protocol < comboBox4.Items.Count)
                comboBox4.SelectedIndex = temp.Protocol;
            else comboBox4.SelectedIndex = 0;
            foreach(String s in Car.RoutewayList)
                comboBox5.Items.Add(s);
            if(comboBox5.Items.Count == 0)
                comboBox5.Enabled = false;
            if(temp.Routeway < comboBox5.Items.Count)
                comboBox5.SelectedIndex = temp.Routeway;
            else comboBox5.SelectedIndex = 0;
            comboBox6.Text = temp.CarBrand;
            comboBox7.Text = temp.CarType;
            comboBox8.Text = temp.CarColor;
            textBox9.Text = temp.InstallPlace;
            textBox10.Text = temp.InstallPerson;
            textBox11.Text = temp.BusinessPerson;
            try{ dateTimePicker12.Value = DateTime.Parse(temp.JoinTime); }catch{}
            try{ dateTimePicker13.Value = DateTime.Parse(temp.OverServiceTime);}catch{}
            textBox14.Text = temp.CarRemark;

            textBox15.Text = temp.Driver;
            textBox16.Text = temp.DriverTel;
            textBox16.KeyPress += Pub.KeyPress_NumInput;
            textBox17.Text = temp.DriverMobile;
            textBox17.KeyPress += Pub.KeyPress_NumInput;
            textBox18.Text = temp.Driver2;
            textBox19.Text = temp.Driver2Tel;
            textBox19.KeyPress += Pub.KeyPress_NumInput;
            textBox20.Text = temp.Driver2Mobile;
            textBox20.KeyPress += Pub.KeyPress_NumInput;
            textBox21.Text = temp.Password;
            textBox22.Text = temp.DriverAddress;
            textBox23.Text = temp.DriverFax;
            textBox24.Text = temp.DriverCompany;
            try { dateTimePicker25.Value = DateTime.Parse(temp.BuyTime); }catch { }
            textBox26.Text = temp.SpecialRequest;
            textBox27.Text = temp.DriverRemark;
            inited = true;
            frmMain.onModifyCar += new FormMain.onModifyCarDelegate(frmMain_onModifyCar);
        }

        private void FormCar_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.onModifyCar -= frmMain_onModifyCar;
        }

        void frmMain_onModifyCar(bool suc, string s)
        {
            if(suc)
                Close();
            else
            {
                if(this.Text == "添加车辆")
                    MessageBox.Show(StrConst.INFO_CAR_ADD_FAIL + s);
                else MessageBox.Show(StrConst.INFO_CAR_MOD_FAIL + s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.CarNO = textBox00.Text;
            temp.SimNO = textBox0.Text;
            temp.MachineNO = textBox1.Text;
            temp.ControlPassword = textBox2.Text;
            temp.MachineType = textBox3.Text;
            temp.Protocol = comboBox4.SelectedIndex;
            Config.PreProtocol = comboBox4.SelectedIndex;
            temp.Routeway = comboBox5.SelectedIndex;
            Config.PreRouteway = comboBox5.SelectedIndex;
            temp.CarBrand = comboBox6.Text;
            temp.CarType = comboBox7.Text;
            temp.CarColor = comboBox8.Text;
            temp.InstallPlace = textBox9.Text;
            temp.InstallPerson = textBox10.Text;
            temp.BusinessPerson = textBox11.Text;
            temp.JoinTime = dateTimePicker12.Value.ToString("yyyy-MM-dd");
            temp.OverServiceTime = dateTimePicker13.Value.ToString("yyyy-MM-dd");
            temp.CarRemark = textBox14.Text;

            temp.Driver = textBox15.Text;
            temp.DriverTel = textBox16.Text;
            temp.DriverMobile = textBox17.Text;
            temp.Driver2 = textBox18.Text;
            temp.Driver2Tel = textBox19.Text;
            temp.Driver2Mobile = textBox20.Text;
            temp.Password = textBox21.Text;
            temp.DriverAddress = textBox22.Text;
            temp.DriverFax = textBox23.Text;
            temp.DriverCompany = textBox24.Text;
            temp.BuyTime = dateTimePicker25.Value.ToString("yyyy-MM-dd");
            temp.SpecialRequest = textBox26.Text;
            temp.DriverRemark = textBox27.Text;
            if(this.Text == "添加车辆")
                FormMain.C_Info_AddCar(temp);
            else FormMain.C_Info_ModifyCar(temp);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox0.Text;
        }

        private void textBox_KeyPress2(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.KeyChar = (char)0;
        }

        private void FormCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)//enter
                this.button1.PerformClick();
            else if(e.KeyChar == 27)//esc
                this.button2.PerformClick();
        }
        private void textBox00_TextChanged(object sender, EventArgs e)
        {
            if(!inited)
                return;
            if(textBox00.Text != "" && textBox0.Text != "" && textBox1.Text != "" && textBox21.Text != ""
                && (temp.CarNO != textBox00.Text ||
                    temp.SimNO != textBox0.Text ||
                    temp.MachineNO != textBox1.Text ||
                    temp.ControlPassword != textBox2.Text ||
                    temp.MachineType != textBox3.Text ||
                    temp.Protocol != comboBox4.SelectedIndex ||
                    temp.Routeway != comboBox5.SelectedIndex ||
                    temp.CarBrand != comboBox6.Text ||
                    temp.CarType != comboBox7.Text ||
                    temp.CarColor != comboBox8.Text ||
                    temp.InstallPlace != textBox9.Text ||
                    temp.InstallPerson != textBox10.Text ||
                    temp.BusinessPerson != textBox11.Text ||
                    temp.CarRemark != textBox14.Text ||
                    temp.Driver != textBox15.Text ||
                    temp.DriverTel != textBox16.Text ||
                    temp.DriverMobile != textBox17.Text ||
                    temp.Driver2 != textBox18.Text ||
                    temp.Driver2Tel != textBox19.Text ||
                    temp.Driver2Mobile != textBox20.Text ||
                    temp.Password != textBox21.Text ||
                    temp.DriverAddress != textBox22.Text ||
                    temp.DriverFax != textBox23.Text ||
                    temp.DriverCompany != textBox24.Text ||
                    temp.SpecialRequest != textBox26.Text ||
                    temp.DriverRemark != textBox27.Text))
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            if(!inited)
                return;
            button1.Enabled = true;
        }
    }
}