using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace YTGPS_Server
{
    class ServerSocket
    {
        private int port = 0;
        private bool active = false;
        private Encoding encoding = null;
        private TcpListener listener;
        private List<Socket> socketList = new List<Socket>();

        public delegate void activeDelegate(bool actived);
        public delegate void deactiveDelegate();
        public delegate void conncetDelegate(Socket socket);
        public delegate void disconncetDelegate(Socket socket);
        public delegate void receiveDelegeate(Socket socket, String msg);
        public delegate void receiveDelegeateEx(Socket socket, String msg);

        public event activeDelegate OnActive;
        public event deactiveDelegate OnDeactive;
        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;
        public event receiveDelegeateEx OnReceiveEx;
        /// <summary>
        /// 端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set
            {
                if(!active)
                    port = value;
            }
        }
        /// <summary>
        /// 解码/编码方式
        /// </summary>
        public Encoding Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }
        /// <summary>
        /// 启动/关闭服务
        /// </summary>
        public bool Active
        {
            get { return active; }
            set 
            {
                if(active && !value)
                {
                    active = false;
                    try
                    {
                        listener.Server.Close();
                    }
                    catch { }
                }
                else if(!active && value)
                {
                    listener = new TcpListener(port);
                    try
                    {
                        active = true;
                        listener.Start();
                        Thread rd = new Thread(new ThreadStart(Listen));
                        rd.Name = "server_socket_listen";
                        //rd.IsBackground = true;
                        rd.Start();
                        if(OnActive != null)
                            OnActive(true);
                    }
                    catch
                    {
                        try
                        {
                            listener.Stop();
                        }
                        catch { }
                        if(OnActive != null)
                            OnActive(false);
                    }
                }
            }
        }
        /// <summary>
        /// 关闭指定的连接
        /// </summary>
        /// <param name="socket"></param>
        public void CloseConnection(Socket socket)
        {
            foreach(Socket st in socketList)
                if(socket == st)
                {
                    try
                    {
                        st.Close();
                    }
                    catch { }
                    break;
                }
        }

        #region 内部线程
        //监听端口
        private void Listen()
        {
            while(active)
            {
                try
                {
                    Socket newSocket = listener.AcceptSocket();
                    Thread rd = new Thread(new ThreadStart(ClientRun));
                    socketList.Add(newSocket);
                    rd.Name = (socketList.Count - 1).ToString();
                    rd.IsBackground = true;
                    if(OnConnect != null)
                        OnConnect(newSocket);
                    rd.Start();
                }
                catch{ break; }
            }
            active = false;
            try
            {
                foreach(Socket st in socketList)
                {
                    try
                    {
                        st.Close();
                    }
                    catch { }
                }
            }
            catch { }
            listener = null;
            if(OnDeactive != null)
                OnDeactive();
        }
        //接收线程
        private void ClientRun()
        {
            Socket socket = null;
            try
            {
                socket = socketList[Int32.Parse(Thread.CurrentThread.Name)];
                socket.SendBufferSize = 10240;
                socket.ReceiveBufferSize = 10240;
                while(socket.Connected && active)
                {
                    try
                    {
                        String rec = "";
                        byte[] buffer = new byte[10240];
                        int count = socket.Receive(buffer);
                        if(count == 0)
                            break;
                        if(encoding != null)
                        {
                            rec = this.Encoding.GetString(buffer, 0, count);
                            if(rec == Constant.CONN_TEST)
                            {
                                socket.Send(this.Encoding.GetBytes(Constant.CONN_TEST));
                            }
                            else
                            {
                                if(OnReceive != null)
                                    OnReceive(socket, rec);
                            }
                        }
                        else if(OnReceiveEx != null)
                        {
                            StringBuilder stb = new StringBuilder();
                            for(int i = 0; i < count; i++)
                            {
                                stb.Append((char)(buffer[i]));
                            }
                            OnReceiveEx(socket, stb.ToString());
                        }
                    }
                    catch{}
                }
            }
            catch{}
            if(active)
            {
                try
                {
                    socket.Disconnect(false);
                }
                catch { }
                try
                {
                    socket.Close();
                }
                catch { }
            }
            if(OnDisconnect != null)
                OnDisconnect(socket);
            socketList.Remove(socket);
        }
        #endregion

    }
}
