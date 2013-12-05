using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Xml;

namespace YTGPS_Server
{
    /// <summary>
    /// tcpz终端连接
    /// </summary>
    public class TcpTerminal
    {
        private Socket socket;
        private Car car = null;
        private String recStr = "";
        private ushort counter;
        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        private object syncrecstr = new object();
        public String RecStr
        {
            get
            {
                lock(syncrecstr)
                {
                    return recStr;
                }
            }
            set
            {
                lock(syncrecstr)
                {
                    recStr = value;
                }
            }
        }
        private object syncCounter = new object();
        public ushort Counter
        {
            get
            {
                lock(syncCounter)
                {
                    return counter;
                }
            }
            set
            {
                lock(syncCounter)
                {
                    counter = value;
                }
            }
        }

        /// <summary>
        /// 构造TcpTerminal，1个小时内无信息的连接将被切断
        /// </summary>
        /// <param name="st"></param>
        public TcpTerminal(Socket st)
        {
            socket = st;
            counter = 0;
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Send(String s)
        {
            try
            {
                //Console.WriteLine("s->t:" + s);
                socket.Send(Encoding.ASCII.GetBytes(s.ToCharArray()));
                return true;
            }
            catch { }
            return false;
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }catch{}
        }
    }

    public partial class FormMain : Form
    {
        private const ushort OUT_TIME_MINS = 1;

        private ServerSocket gprsServer = new ServerSocket();
        //private List<GprsClient> gprsClientList = new List<GprsClient>();
        private System.Collections.Hashtable tcpTable = new System.Collections.Hashtable();
        //gprs 启动事件
        void gprsServer_OnActive(bool actived)
        {
            try
            {
                this.BeginInvoke(new gprs_OnActiveCallback(gprs_OnActive), new object[] { actived });
            }
            catch { }
        }
        public delegate void gprs_OnActiveCallback(bool actived);
        public void gprs_OnActive(bool actived)
        {
            if(actived)
            {
                buttonTcpStart.Enabled = false;
                buttonTcpStop.Enabled = true;
                timerTCP.Enabled = true;
                if(FormMain.LOG_MSG)
                    logger.AddMsg("TCP服务启动");
            }
            else
            {
                buttonTcpStart.Enabled = true;
                buttonTcpStop.Enabled = false;
                MessageBox.Show(StrConst.ERR_PORT_TCP);
            }
        }
        //gprs 关闭事件
        void gprsServer_OnDeactive()
        {
            try
            {
                this.BeginInvoke(new gprs_OnDeactiveCallback(gprs_OnDeactive), null);
            }
            catch { }
        }
        public delegate void gprs_OnDeactiveCallback();
        public void gprs_OnDeactive()
        {
            buttonTcpStart.Enabled = true;
            buttonTcpStop.Enabled = false;
            timerTCP.Enabled = false;
            if(FormMain.LOG_MSG)
                logger.AddMsg("TCP服务停止");
        }
        //gprs 连接事件
        void gprsServer_OnConnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new gprs_OnConnectCallback(gprs_OnConnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void gprs_OnConnectCallback(Socket socket);
        public void gprs_OnConnect(Socket socket)
        {
            tcpTable.Add(socket, new TcpTerminal(socket));
            //gprsClientList.Add(new GprsClient(socket));
            labelGprsCount.Text = (Int32.Parse(labelGprsCount.Text) + 1).ToString();
        }
        //gprs 断开事件
        void gprsServer_OnDisconnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new gprs_OnDisConnectCallback(gprs_OnDisConnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void gprs_OnDisConnectCallback(Socket socket);
        public void gprs_OnDisConnect(Socket socket)
        {
            try
            {
                labelGprsCount.Text = (Int32.Parse(labelGprsCount.Text) - 1).ToString();
                TcpTerminal gc = (TcpTerminal)tcpTable[socket];
                if(gc != null)
                {
                    if(gc.Car != null)
                        gc.Car.GprsConn = null;
                    tcpTable.Remove(gc);
                }
                /*
                for(int i = 0; i < gprsClientList.Count; i++)
                    if(socket == gprsClientList[i].Socket)
                    {
                        if(gprsClientList[i].Car != null)
                            gprsClientList[i].Car.GprsClient = null;
                        gprsClientList.RemoveAt(i);
                        break;
                    }*/
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //gprs 接收事件
        void gprsServer_OnReceive(Socket socket, string msg)
        {
            try
            {
                TcpTerminal gc = (TcpTerminal)tcpTable[socket];
                if(gc != null)
                {  
                    gc.Counter = 0;
                    //logger.AddMsg("tcp终端信息(ascii):" + msg);
                    
                   if (msg.Substring(13, 4) == "UB00")
                   {
                       String str="";
                       str = msg.Substring(0, 13) + "DB01" + msg.Substring(17,(msg.Length-17));
                     gc.Send(str); 
                   }

                   if (msg.Substring(13, 4) == "UB05")
                   {
                       String str = "",strt="",sucess="",fail="";

                       str = msg.Substring(17, 15);
                       DBManager dbmj = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);

                       DataTable dt = dbmj.ExecuteQuery("select machineNO from tCar where machineNO="+"'"+str+"';");
                       foreach (DataRow dr in dt.Rows)
                       {

                           strt = dr[0].ToString();

                       }

                       if (strt!= "")
                       {
                           sucess = msg.Substring(0, 13) + "DX061^";
                           gc.Send(sucess);
                           sucess = "";
                           sucess = msg.Substring(0, 13) + "0014^";
                           gc.Send(sucess);
                           dbmj.Close();

                       }
                        else
                       {
                           fail = msg.Substring(0, 13) + "DX060^";
                           gc.Send(fail);
                           dbmj.Close();

                           goto kick;

                           
                       }

                   
                   }

                 

                     
                    //logger.AddMsg("tcp终端信息(hex):" + Pub.RealHexToStr(msg));

                   GPSInfo gi = new GPSInfo(msg, gc);
                   analyzer.AddInInfo(gi);
               kick: ;

  
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }

        private void timerTCP_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach(TcpTerminal gc in tcpTable.Values)
                {
                    gc.Counter++;
                    if(gc.Counter >= Config.TcpCutTime)
                        gc.CloseConnection();
                }
            }
            catch { }
        }
    }
}
