using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormCarInfo : Form
    {
        public FormCarInfo()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        //≥µ¡æ–≈œ¢
        public void ShowInfo(Car car, int x, int y)
        {
            label0.Text = car.CarID.ToString();
            label1.Text = car.SimNO;
            label2.Text = car.MachineNO;
            label3.Text = car.ControlPassword;
            label4.Text = car.MachineType;
            if(car.Protocol < Car.PROTOCOL.Length)
                label5.Text = Car.PROTOCOL[car.Protocol];
            else label5.Text = Car.PROTOCOL[0];
            if(car.Routeway < Car.RoutewayList.Count)
                label6.Text = Car.RoutewayList[car.Routeway];
            else label6.Text = Car.RoutewayList[0];
            label7.Text = car.CarType;
            label8.Text = car.CarBrand;
            label9.Text = car.CarColor;
            label10.Text = car.InstallPlace;
            label11.Text = car.InstallPerson;
            label12.Text = car.BusinessPerson;
            label13.Text = car.JoinTime;
            label14.Text = car.OverServiceTime;
            label15.Text = car.CarRemark;
            label16.Text = car.Driver;
            label17.Text = car.DriverTel;
            label18.Text = car.DriverMobile;
            label19.Text = car.Driver2;
            label20.Text = car.Driver2Tel;
            label21.Text = car.Driver2Mobile;
            label22.Text = car.Password;
            label23.Text = car.DriverAddress;
            label24.Text = car.DriverFax;
            label25.Text = car.DriverCompany;
            label26.Text = car.BuyTime;
            label27.Text = Car.SERVICE_STATUS[car.Stoped];
            label28.Text = car.SpecialRequest;
            label29.Text = car.DriverRemark;

            this.Text = car.CarNO + "[" + car.Team.TeamName + "]";
            this.Left = x - this.Width - 15;
            this.Top = y;
            this.Show();
        }
    }
}