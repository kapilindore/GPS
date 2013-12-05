using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public partial class FormHandleAlarm : FormUntitle
    {
        private FormMain mainFrm;
        private Car car;

        private bool hasHandle = false;

        public delegate void ShowAlarmPosDelegate(AlarmPosition apos);
        public event ShowAlarmPosDelegate OnShowAlarmPos;

        public FormHandleAlarm(FormMain frm, Car c)
        {
            mainFrm = frm;
            InitializeComponent();
            this.SetFormStyle(false, false, false, true);
            FormMain.inAlarmHandle = true;
            car = c;
            foreach(AlarmPosition apos in FormMain.alarmList)
            {
                if(apos.Car == car)
                {
                    ListViewItem item = new ListViewItem(apos.Id.ToString());
                    listView1.Items.Add(item);
                    item.SubItems.Add(apos.Car.CarNO);
                    item.SubItems.Add(apos.GpsTime);
                    item.SubItems.Add(Position.POINTED[apos.Pointed]);
                    item.SubItems.Add(apos.Lo.ToString());
                    item.SubItems.Add(apos.La.ToString());
                    item.SubItems.Add(Position.DIR[apos.Direction]);
                    item.SubItems.Add(apos.Speed.ToString());
                    item.SubItems.Add(apos.Status);
                    item.SubItems.Add(apos.Alarm);
                    item.Tag = apos;
                }
            }
            label0.Text = car.CarNO;
            label1.Text = car.SimNO;
            label2.Text = car.MachineNO;
            label3.Text = car.ControlPassword;
            label4.Text = car.MachineType;
            label5.Text = Car.PROTOCOL[car.Protocol];
            label6.Text = Car.RoutewayList[car.Routeway];
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
            frm.onAlarm += new FormMain.onAlarmDelegate(frm_onAlarm);
            frm.onDisconn += new FormMain.onDisconnDelegate(frm_onDisconn);
        }

        void frm_onAlarm(AlarmPosition apos)
        {
            if(apos.Car.CarID == car.CarID)
            {
                ListViewItem item = new ListViewItem(apos.Id.ToString());
                listView1.Items.Add(item);
                item.SubItems.Add(apos.Car.CarNO);
                item.SubItems.Add(apos.GpsTime);
                item.SubItems.Add(Position.POINTED[apos.Pointed]);
                item.SubItems.Add(apos.Lo.ToString());
                item.SubItems.Add(apos.La.ToString());
                item.SubItems.Add(Position.DIR[apos.Direction]);
                item.SubItems.Add(apos.Speed.ToString());
                item.SubItems.Add(apos.Status);
                item.SubItems.Add(apos.Alarm);
                item.Tag = apos;
            }
        }

        void frm_onDisconn()
        {
            this.Close();
        }

        private void FormHandleAlarm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain.inAlarmHandle = false;
            mainFrm.onAlarm -= frm_onAlarm;
            mainFrm.onDisconn -= frm_onDisconn;
            FormMain.alarmHandleCar = null;
            if(!hasHandle)
            {
                FormMain.C_Alarm_Handle(car, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.C_Alarm_Free(car.CarID.ToString(), checkBox1.Checked ? "1" : "0");
            hasHandle = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMain.CheckCarNotify(car);
            List<Team> list = new List<Team>();
            Team team = new Team(car.Team);
            team.Cars.Add(car);
            list.Add(team);
            if(car.Protocol == Constant.PROTOCOL_QICHUAN)
            {
                FormPtXunLuoShu frm = new FormPtXunLuoShu(mainFrm, FormMain.user.TeamList, car.CarID);
                frm.Show();
            }
            else if(car.Protocol == Constant.PROTOCOL_TIANHE)
            {
                FormPtTianHe frm = new FormPtTianHe(mainFrm, FormMain.user.TeamList, car.CarID);
                frm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                OnShowAlarmPos(listView1.SelectedItems[0].Tag as AlarmPosition);
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}