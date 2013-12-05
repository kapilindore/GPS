using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace YTGPS_Client
{
    public class ClientSocket
    {
        private TcpClient client;
        private const int BUFFER_SIZE = 10240;
        private bool acitve = false;
        private bool reConn = false;
        /// <summary>
        /// 是否是自动重连
        /// </summary>
        public bool ReConn
        {
            get { return reConn; }
            set { reConn = value; }
        }

        public delegate void conncetDelegate(bool hasConn);//连接事件
        public delegate void disconncetDelegate();//断开事件
        public delegate void receiveDelegeate(String msg);//接收事件

        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;

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
                rd.IsBackground = true;
                rd.Start();
                OnConnect(true);
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
                OnConnect(false);
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            acitve = false;
            try
            {
                client.Client.Shutdown(SocketShutdown.Both);
                client.Client.Close();
                client.Close();
            }
            catch { }
        }
        /// <summary>
        /// 断开连接，不重连
        /// </summary>
        public void ForceDisConnect()
        {
            acitve = false;
            reConn = false;
            try
            {
                client.Client.Shutdown(SocketShutdown.Both);
                client.Client.Close();
                client.Close();
            }
            catch { }
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
                    //Console.WriteLine("rec:" +  s);
                    OnReceive(s);
                }
                catch { break; }
            }
            try
            {
                client.Client.Close();
            }
            catch { }
            client = null;
            OnDisconnect();
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
                //Console.WriteLine("send:" + msg);
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
