using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormOverSvrList : FormUntitle
    {
        private List<Team> teamList;
        private Car selCar = null;

        public FormOverSvrList()
        {
            InitializeComponent();
            this.SetFormStyle(false, true, false, true);
        }

        private void FormOverServiceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void RefreshList(List<Team> list)
        {
            teamList = list;
            listView1.Items.Clear();
            button0.Enabled = false;
            button1.Enabled = false;
            selCar = null;
            foreach(Team team in list)
            {
                foreach(Car car in team.Cars)
                {
                    try
                    {
                        if(DateTime.Parse(car.OverServiceTime) < DateTime.Now)
                        {
                            ListViewItem item = new ListViewItem(car.CarNO);
                            item.SubItems.Add(car.JoinTime);
                            item.SubItems.Add(car.OverServiceTime);
                            item.SubItems.Add(Car.SERVICE_STATUS[car.Stoped]);
                            item.Tag = car;
                            listView1.Items.Add(item);
                        }
                    }
                    catch { }
                }
            }
            labelCount.Text = listView1.Items.Count.ToString();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if(item != null || selCar != (item.Tag as Car))
            {
                selCar = item.Tag as Car;
                label0.Text = selCar.CarNO;
                label1.Text = selCar.SimNO;
                label2.Text = selCar.MachineNO;
                label3.Text = selCar.ControlPassword;
                label4.Text = selCar.MachineType;
                label5.Text = Car.PROTOCOL[selCar.Protocol];
                label6.Text = Car.RoutewayList[selCar.Routeway];
                label7.Text = selCar.CarType;
                label8.Text = selCar.CarBrand;
                label9.Text = selCar.CarColor;
                label10.Text = selCar.InstallPlace;
                label11.Text = selCar.InstallPerson;
                label12.Text = selCar.BusinessPerson;
                label13.Text = selCar.JoinTime;
                label14.Text = selCar.OverServiceTime;
                label15.Text = selCar.CarRemark;
                label16.Text = selCar.Driver;
                label17.Text = selCar.DriverTel;
                label18.Text = selCar.DriverMobile;
                label19.Text = selCar.Driver2;
                label20.Text = selCar.Driver2Tel;
                label21.Text = selCar.Driver2Mobile;
                label22.Text = selCar.Password;
                label23.Text = selCar.DriverAddress;
                label24.Text = selCar.DriverFax;
                label25.Text = selCar.DriverCompany;
                label26.Text = selCar.BuyTime;
                label27.Text = Car.SERVICE_STATUS[selCar.Stoped];
                label28.Text = selCar.SpecialRequest;
                label29.Text = selCar.DriverRemark;
                button0.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                button0.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            FormMain.CheckCarNotify(selCar);
            FormCarStoped frm = new FormCarStoped(selCar);
            frm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.CheckCarNotify(selCar);
            FormCarServiceTime frm = new FormCarServiceTime(selCar);
            frm.ShowDialog(this);
        }
    }
}