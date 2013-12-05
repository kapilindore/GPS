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
        /// �Ƿ����Զ�����
        /// </summary>
        public bool ReConn
        {
            get { return reConn; }
            set { reConn = value; }
        }

        public delegate void conncetDelegate(bool hasConn);//�����¼�
        public delegate void disconncetDelegate();//�Ͽ��¼�
        public delegate void receiveDelegeate(String msg);//�����¼�

        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        public bool Connected
        {
            get { return acitve; }
        }
        /// <summary>
        /// ����ָ���ķ�����
        /// </summary>
        /// <param name="host">��������ַ</param>
        /// <param name="port">�˿�</param>
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
        /// �Ͽ�����
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
        /// �Ͽ����ӣ�������
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
        //�����߳�
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
        /// ������Ϣ��������
        /// </summary>
        /// <param name="msg">��Ϣ</param>
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
