using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace YTGPS_Server
{
    /// <summary>
    ///  客户端Socket
    /// </summary>
    public class ClientSocket
    {
        private int id = 10000;
        private TcpClient client = null;
        private const int BUFFER_SIZE = 10240;
        private bool acitve = false;
        private bool reConn = false;
        private bool hasLogin = false;
        private bool testOk = false;
        private bool needTest = false;
        /// <summary>
        /// 可以检测连接
        /// </summary>
        public bool NeedTest
        {
            get { return needTest; }
            set { needTest = value; }
        }
        /// <summary>
        /// 连接检测成功
        /// </summary>
        public bool TestOk
        {
            get { return testOk; }
            set { testOk = value; }
        }
        /// <summary>
        /// 是否已登陆
        /// </summary>
        public bool HasLogin
        {
            get { return hasLogin; }
            set { hasLogin = value; }
        }
        public bool ReConn
        {
            get { return reConn; }
            set { reConn = value; }
        }

        public delegate void conncetDelegate(int n, bool hasConn);//连接事件
        public delegate void disconncetDelegate(int n);//断开事件
        public delegate void receiveDelegeate(int n, String msg);//接收事件

        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;

        public ClientSocket(int i)
        {
            id = i;
        }
        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool Connected
        {
            get { return acitve; }
        }
        /// <summary>
        /// 连接指定的服务器
        /// </summary>
        /// <param name="host">服务器地址</param>
        /// <param name="port">端口</param>
        public void ConnectServer(String host, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(host, port);
                acitve = true;
                Thread rd = new Thread(new ThreadStart(Receive));
                rd.Name = "client_socket_rev_" + id;
                rd.IsBackground = true;
                rd.Start();
                if(OnConnect != null)
                    OnConnect(id, true);
            }
            catch
            {
                try
                {
                    client.Client.Close();
                }
                catch { }
                client = null;
                acitve = false;
                if(OnConnect != null)
                    OnConnect(id, false);
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            acitve = false;
        }
        /// <summary>
        /// 断开连接，不重连
        /// </summary>
        public void ForceDisConnect()
        {
            acitve = false;
            reConn = false;
        }
        //接收线程
        private void Receive()
        {
            client.Client.SendBufferSize = BUFFER_SIZE;
            client.Client.ReceiveBufferSize = BUFFER_SIZE;
            while(acitve)
            {
                try
                {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int count = client.Client.Receive(buffer);
                    if(count == 0)
                        break;
                    String s = Encoding.UTF8.GetString(buffer, 0, count);
                    if(OnReceive != null)
                        OnReceive(id, s);
                    //Console.WriteLine("rec sms:" + s);
                }
                catch { break; }
            }
            try
            {
                client.Client.Close();
            }
            catch { }
            client = null;
            acitve = false;
            if(OnDisconnect != null)
                OnDisconnect(id);
        }
        /// <summary>
        /// 发送信息到服务器
        /// </summary>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public bool Send(String msg)
        {
            try
            {
                client.Client.Send(Encoding.UTF8.GetBytes(msg.ToCharArray()));
                //Console.WriteLine("send to sms:" + msg);
                return true;
            }
            catch
            {
                try
                {
                    client.Client.Close();
                }
                catch{}
                return false; 
            }
        }
    }
}
