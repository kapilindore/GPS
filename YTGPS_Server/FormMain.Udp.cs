using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MoonStudio.Udp;
using System.Xml;

namespace YTGPS_Server
{
    public class UdpTerminal
    {
        private string host;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public UdpTerminal(string h, int p)
        {
            host = h;
            port = p;
        }
    }

    public partial class FormMain : Form
    {
        private System.Collections.Hashtable udpTable = new System.Collections.Hashtable();
        private UDPConnection udpConnection = new UDPConnection();
        //发送信息
        public bool Send(UdpTerminal ut, String s)
        {
            return udpConnection.Send(ut.Host, ut.Port, s);
        }

        void udpConnection_OnStart(MoonStudio.Udp.UDPConnection uc, bool suc)
        {
            try
            {
                this.BeginInvoke(new udp_OnActiveCallback(udp_OnActive), new object[] { uc, suc });
            }
            catch { }
        }
        public delegate void udp_OnActiveCallback(UDPConnection uc, bool suc);
        public void udp_OnActive(UDPConnection uc, bool suc)
        {
            if(suc)
            {
                buttonUdpStart.Enabled = false;
                buttonUdpStop.Enabled = true;
                if(FormMain.LOG_MSG)
                    logger.AddMsg("UDP服务启动");
            }
            else
            {
                buttonUdpStart.Enabled = true;
                buttonUdpStop.Enabled = false;
                MessageBox.Show(StrConst.ERR_PORT_UDP);
            }
        }

        void udpConnection_OnStop(UDPConnection uc)
        {
            try
            {
                this.BeginInvoke(new udp_OnDeactiveCallback(udp_OnDeactive), new object[] { uc });
            }
            catch { }
        }
        public delegate void udp_OnDeactiveCallback(UDPConnection uc);
        public void udp_OnDeactive(UDPConnection uc)
        {
            buttonUdpStart.Enabled = true;
            buttonUdpStop.Enabled = false;
            if(FormMain.LOG_MSG)
                logger.AddMsg("UDP服务停止");
        }
  
       void udpConnection_OnReceive(MoonStudio.Udp.UDPConnection uc, string remote, int rPort, string msg)
        {
            try
            {
                //logger.AddMsg("udp终端信息(ascii):" + msg);
                //logger.AddMsg("udp终端信息(hex):" + Pub.RealHexToStr(msg));
                // MessageBox.Show(msg);
                //   MessageBox.Show(msg.Substring(5, 4));

                if (msg.Substring(1, 5) == "SJHXL")
                {
                    String str,str1="";
                    str = msg.Substring(6, 8);
                    str = str.Substring(6, 2) + str.Substring(4, 2) + str.Substring(2, 2) + str.Substring(0, 2);
                    DBManager dbms = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                  //  DataTable dt = dbms.ExecuteQuery("select * from Terminal where machineNO="+str+";"); //目前不使用该语句。使用下面的存储过程语句来判断是否存在记录
                    DataTable dt = dbms.ExecuteQuery("select_Terminal "+"'"+str+"'" );
                    foreach (DataRow dr in dt.Rows)
                    {
                   
                 str1=dr[0].ToString();
                
                    }

                    if (str1=="")
                    {
                      //  MessageBox.Show("a");
                        dbms.ExecuteUpdate("insert_Terminal " + "'" + str + "'" + "," + "'" + remote + "'" +","+ rPort);
                       string order = Protocol_XunLuoShu.AutoOrder(false,str);
                        udpConnection.Send(remote,rPort, order);
                        dbms.ExecuteUpdate("insert_Terminal " + "'" + str + "'" + "," + "'" + remote + "'" + "," + rPort);
                         order = Protocol_XunLuoShu.AutoOrder(false, str);
                        udpConnection.Send(remote, rPort, order);
                        dbms.ExecuteUpdate("insert_Terminal " + "'" + str + "'" + "," + "'" + remote + "'" + "," + rPort);
                         order = Protocol_XunLuoShu.AutoOrder(false, str);
                        udpConnection.Send(remote, rPort, order);

                    
                    }
                    else
                    {
                       // MessageBox.Show("b");
                        dbms.ExecuteUpdate("update_Terminal "+"'"+str+"'"+","+rPort+","+"'"+remote+"'");
                    }


                    dbms.Close();
                }

                if (msg.Substring(5, 4) == "TEST") udpConnection.Send(remote, rPort, msg);
                
                /* 检测GPRS网络是否发生虚连接 巡逻鼠硬件
                 E、判断车机与中心的连接情况
    实例：设备定时向中心发送字符“$SJHXTEST,”中心收到后原样字符串“$SJHXTEST,”发送给此IP地址即可，而不用管是哪个设备ID号码发过来的。
 //*/
                GPSInfo gi = new GPSInfo(msg, remote, rPort);

                analyzer.AddInInfo(gi);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
    }
}
