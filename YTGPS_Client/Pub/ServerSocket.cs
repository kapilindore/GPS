using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace YTGPS_Client
{
    public class ServerSocket
    {
        private int port = 0;
        private bool active = false;
        private TcpListener listener;
        private List<Socket> socketList = new List<Socket>();

        public delegate void activeDelegate(bool actived);
        public delegate void deactiveDelegate();
        public delegate void conncetDelegate(Socket socket);
        public delegate void disconncetDelegate(Socket socket);
        public delegate void receiveDelegeate(Socket socket, String msg);

        public event activeDelegate OnActive;
        public event deactiveDelegate OnDeactive;
        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;

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
                    try
                    {
                        listener.Server.Close();
                    }
                    catch { }
                    try
                    {
                        listener.Stop();
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
                        rd.IsBackground = true;
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
        /// <param name="socket">连接</param>
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
                    Socket st = listener.AcceptSocket();
                    socketList.Add(st);
                    Thread rd = new Thread(new ThreadStart(ClientRun));
                    rd.IsBackground = true;
                    rd.Name = (socketList.Count - 1).ToString();
                    rd.Start();
                    if(OnConnect != null)
                        OnConnect(st);
                }
                catch{ break; }
            }
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
            try
            {
                listener.Server.Close();
            }
            catch { }
            try
            {
                listener.Stop();
            }
            catch { }
            listener = null;
            if(OnDeactive != null)
                OnDeactive();
        }
        //接收线程
        private void ClientRun()
        {
            Socket socket = socketList[Int32.Parse(Thread.CurrentThread.Name)];
            socket.SendBufferSize = 10240;
            socket.ReceiveBufferSize = 10240;
            try
            {
                while(socket.Connected)
                {
                    try
                    {
                        String rec = "";
                        byte[] buffer = new byte[10240];
                        int count = socket.Receive(buffer);
                        if(count == 0)
                            break;
                        rec = Encoding.Default.GetString(buffer, 0, count);
                        if(OnReceive != null)
                            OnReceive(socket, rec);
                    }
                    catch { break; }
                }
            }
            catch { }
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
            if(OnDisconnect != null)
                OnDisconnect(socket);
            socketList.Remove(socket);
        }
        #endregion

    }
}
