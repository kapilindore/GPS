using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.Sockets;

/*
 * GIS��չ�˿ڣ����ⲿ�����������ͨѶ
 */

namespace YTGPS_Client
{
    public partial class FormMain : Form
    {
        public static ServerSocket gisServer = new ServerSocket();
        public static Socket gisSocket = null;

        private const char CAR_LIST_BY_TEL = 'A';
        private const char CAR_LIST_BY_NO = 'B';
        private const char SEL_CAR = 'C';
        private const char CAR_POINT = 'D';

        private const char Ext_QUERY_TEAMS = 'A';           //��ȡ������Ϣ
        private const char Ext_QUERY_TEAMS_ALL = 'A';       //��ȡ���г���
        private const char Ext_QUERY_TEAMS_BY_TID = 'B';    //ģ����ѯ����ID
        private const char Ext_QUERY_TEAMS_BY_TNAME = 'C';  //ģ����ѯ������
        private const char Ext_QUERY_TEAMS_BY_CID = 'D';    //��ȡ����ID���ڳ���
        private const char Ext_QUERY_TEAMS_BY_CNO = 'E';    //��ȡ���ƺ������ڳ���

        private const char Ext_QUERY_CARS = 'B';            //��ȡ������Ϣ
        private const char Ext_QUERY_CARS_ALL = 'A';        //��ȡ���г���
        private const char Ext_QUERY_CARS_IN_TEAM = 'A';    //��ȡָ�������е����г���
        private const char Ext_QUERY_CARS_BY_CID = 'B';     //ģ����ѯ����ID
        private const char Ext_QUERY_CARS_BY_CNO = 'C';     //ģ����ѯ���ƺ���
        private const char Ext_QUERY_CARS_BY_SIM = 'D';     //ģ����ѯSIM����
        private const char Ext_QUERY_CARS_BY_MNO = 'E';     //ģ����ѯ�ն����к�
        private const char Ext_QUERY_CARS_BY_DRIVER = 'F';  //ģ����ѯ����
        private const char Ext_QUERY_CARS_BY_TEL = 'G';     //ģ����ѯ�����绰
        private const char Ext_QUERY_CARS_BY_MOBILE = 'H';  //ģ����ѯ�����ֻ�

        private const char Ext_CTRL_CAR = 'C';
        private const char Ext_CTRL_CAR_SELECT = 'A';       //�ڳ����б�����ؼ��ֹ��˳���
        private const char Ext_CTRL_CAR_POINT = 'B';        //��λ����
        private const char Ext_CTRL_CAR_WATCH = 'C';        //��س���
        private const char Ext_CTRL_CAR_GIS_INFO = 'D';     //��ȡ�������λ�õ���Ϣ


        //��GIS�˿ڷ�����Ϣ�����뷽ʽΪϵͳĬ�ϱ���
        private bool GisSend(String msg)
        {
            try
            {
                gisSocket.Send(Encoding.Default.GetBytes(msg.ToCharArray()));
                return true;
            }
            catch
            {
                try
                {
                    gisSocket.Close();
                }
                catch { }
                return false;
            }
        }
        //gis socket���������¼�
        private void gisServer_OnActive(bool actived)
        {
            try
            {
                this.BeginInvoke(new gis_OnActiveDelegate(GisOnActive), new object[] { actived });
            }
            catch { }
        }
        private delegate void gis_OnActiveDelegate(bool actived);
        private void GisOnActive(bool actived)
        {
            if(actived)
            {
                ToolStripMenuItemGisServer.Checked = true;
                Log(StrConst.EXT_PORT_START_OK);
            }
            else
            {
                Log(StrConst.EXT_PORT_START_FAIL);
                MessageBox.Show(StrConst.EXT_PORT_START_FAIL);
            }
        }
        //gis socket����ֹͣ�¼�
        private void gisServer_OnDeactive()
        {
            try
            {
                this.BeginInvoke(new gis_OnDeactiveDelegate(GisOnDeactive), null);
            }
            catch { }
        }
        private delegate void gis_OnDeactiveDelegate();
        private void GisOnDeactive()
        {
            ToolStripMenuItemGisServer.Checked = false;
            Log(StrConst.EXT_PORT_STOPED);
        }
        //gis socket�����¼�
        private void gisSocket_OnConnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new gis_OnConnectDelegate(GisOnConnect), new object[] { socket });
            }
            catch { }
        }
        private delegate void gis_OnConnectDelegate(Socket socket);
        private void GisOnConnect(Socket socket)
        {
            if(gisSocket == null)
                gisSocket = socket;
            else socket.Close();
        }
        //gis socket�Ͽ��¼�
        private void gisServer_OnDisconnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new gis_OnDisConnectDelegate(GisOnDisConnect), new object[] { socket });
            }
            catch { }
        }
        private delegate void gis_OnDisConnectDelegate(Socket socket);
        private void GisOnDisConnect(Socket socket)
        {
            if(gisSocket == socket)
                gisSocket = null;
        }
        //gis socketͨѶ
        private void gisSocket_OnReceive(Socket socket, string msg)
        {
            try
            {
                this.BeginInvoke(new gis_OnReceiveDelegate(GisOnReceive), new object[] { msg });
            }
            catch { }
        }
        private delegate void gis_OnReceiveDelegate(string msg);
        private void GisOnReceive(string msg)
        {
            //Console.WriteLine("GIS rev:" + msg);
            char key = msg[0];
            msg = msg.Substring(1);
            if(key == CAR_LIST_BY_TEL)
            {
                while(msg.Length > 7)
                    msg = msg.Substring(1);
                List<Car> cars = user.GetCarsByTel(msg);
                StringBuilder stb = new StringBuilder();
                stb.Append(CAR_LIST_BY_TEL);
                foreach(Car car in cars)
                    stb.Append(car.CarNO).Append(",").Append(car.Driver)
                        .Append(",").Append(car.DriverAddress).Append(";");
                if(cars.Count > 0)
                    stb.Remove(stb.Length - 1, 1);
                GisSend(stb.ToString());
            }
            else if(key == CAR_LIST_BY_NO)
            {
                List<Car> cars = user.GetCarsByNO(msg);
                StringBuilder stb = new StringBuilder();
                stb.Append(CAR_LIST_BY_NO);
                foreach(Car car in cars)
                    stb.Append(car.CarNO).Append(",").Append(car.Driver)
                        .Append(",").Append(car.DriverAddress).Append(";");
                if(cars.Count > 0)
                    stb.Remove(stb.Length - 1, 1);
                GisSend(stb.ToString());
            }
            else if(key == SEL_CAR)
            {
                Car car = user.GetCarByNO(msg);
                if(car != null)
                {
                    this.Activate();
                    comboBoxExKey.Text = car.CarNO;
                    C_Pos_Watch(car);

                    C_Pos_Point(car);
                    //FormCarPw frm = new FormCarPw(car);
                    //frm.ShowDialog(this);
                }
            }/*
            else if(key == CAR_POINT)
            {
                Car car = user.GetCarByNO(msg);
                if(car != null)
                {
                    MessageToMainForm dd = new MessageToMainForm(f_MessageToMainFormGis);
                    this.Invoke(dd, new object[] { GIS_POINT, car.CarID });
                }
            }*/
        }
    }
}
