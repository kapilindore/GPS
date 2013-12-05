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
 * GIS扩展端口，与外部程序进行数据通讯
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

        private const char Ext_QUERY_TEAMS = 'A';           //获取车队信息
        private const char Ext_QUERY_TEAMS_ALL = 'A';       //获取所有车队
        private const char Ext_QUERY_TEAMS_BY_TID = 'B';    //模糊查询车队ID
        private const char Ext_QUERY_TEAMS_BY_TNAME = 'C';  //模糊查询车队名
        private const char Ext_QUERY_TEAMS_BY_CID = 'D';    //获取车辆ID所在车队
        private const char Ext_QUERY_TEAMS_BY_CNO = 'E';    //获取车牌号码所在车队

        private const char Ext_QUERY_CARS = 'B';            //获取车辆信息
        private const char Ext_QUERY_CARS_ALL = 'A';        //获取所有车辆
        private const char Ext_QUERY_CARS_IN_TEAM = 'A';    //获取指定车队中的所有车辆
        private const char Ext_QUERY_CARS_BY_CID = 'B';     //模糊查询车辆ID
        private const char Ext_QUERY_CARS_BY_CNO = 'C';     //模糊查询车牌号码
        private const char Ext_QUERY_CARS_BY_SIM = 'D';     //模糊查询SIM卡号
        private const char Ext_QUERY_CARS_BY_MNO = 'E';     //模糊查询终端序列号
        private const char Ext_QUERY_CARS_BY_DRIVER = 'F';  //模糊查询车主
        private const char Ext_QUERY_CARS_BY_TEL = 'G';     //模糊查询车主电话
        private const char Ext_QUERY_CARS_BY_MOBILE = 'H';  //模糊查询车主手机

        private const char Ext_CTRL_CAR = 'C';
        private const char Ext_CTRL_CAR_SELECT = 'A';       //在车辆列表输入关键字过滤车辆
        private const char Ext_CTRL_CAR_POINT = 'B';        //定位车辆
        private const char Ext_CTRL_CAR_WATCH = 'C';        //监控车辆
        private const char Ext_CTRL_CAR_GIS_INFO = 'D';     //获取车辆最后位置的信息


        //向GIS端口发送信息，编码方式为系统默认编码
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
        //gis socket服务启动事件
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
        //gis socket服务停止事件
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
        //gis socket连接事件
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
        //gis socket断开事件
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
        //gis socket通讯
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
