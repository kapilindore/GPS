using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace YTGPS_Server
{
    /// <summary>
    ///  �ͻ���Socket
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
        /// ���Լ������
        /// </summary>
        public bool NeedTest
        {
            get { return needTest; }
            set { needTest = value; }
        }
        /// <summary>
        /// ���Ӽ��ɹ�
        /// </summary>
        public bool TestOk
        {
            get { return testOk; }
            set { testOk = value; }
        }
        /// <summary>
        /// �Ƿ��ѵ�½
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

        public delegate void conncetDelegate(int n, bool hasConn);//�����¼�
        public delegate void disconncetDelegate(int n);//�Ͽ��¼�
        public delegate void receiveDelegeate(int n, String msg);//�����¼�

        public event conncetDelegate OnConnect;
        public event disconncetDelegate OnDisconnect;
        public event receiveDelegeate OnReceive;

        public ClientSocket(int i)
        {
            id = i;
        }
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
        /// �Ͽ�����
        /// </summary>
        public void DisConnect()
        {
            acitve = false;
        }
        /// <summary>
        /// �Ͽ����ӣ�������
        /// </summary>
        public void ForceDisConnect()
        {
            acitve = false;
            reConn = false;
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
        /// ������Ϣ��������
        /// </summary>
        /// <param name="msg">��Ϣ</param>
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
