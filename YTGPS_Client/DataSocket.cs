using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace YTGPS_Client
{
    public class DataSocket
    {
        private const int BUFFER_SIZE = 10240;

        private TcpClient client = null;
        private bool active = false;

        public delegate void conncetDelegate(char status);
        public delegate void disconncetDelegate();
        public delegate void receiveDelegeate(String msg);

        public event conncetDelegate OnConnect;//�����¼�
        public event disconncetDelegate OnDisconnect;//�Ͽ��¼�
        public event receiveDelegeate OnReceive;//�յ���Ϣ�¼�

        //���ӷ�����
        public void ConnectServer()
        {
            if(active)
                return;
            try
            {
                client = new TcpClient();
                client.Connect(Config.Host, Config.Port);
                active = true;
                new Thread(new ThreadStart(Receive)).Start();
                OnConnect(Constant.SUCCESS);
            }
            catch
            {
                try
                {
                    client.Client.Close();
                }
                catch { }
                client = null;
                active = false;
                OnConnect(Constant.FAIL);
            }
        }
        //�Ͽ�����
        public void DisConnect()
        {
            active = false;
            try
            {
                client.Client.Close();
            }
            catch { }
        }
        //
        public bool Connected
        {
            get { return active; }
        }
        //����
        public bool ClientSend(String s)
        {
            if(active)
            {
                try
                {
                    client.Client.Send(Encoding.UTF8.GetBytes(s.ToCharArray()));
                    Console.WriteLine("c->s: " + s);
                    return true;
                }
                catch
                {
                    client.Client.Close();
                }
            }
            return false;
        }
        //�����߳�
        private void Receive()
        {
            client.Client.SendBufferSize = BUFFER_SIZE;
            client.Client.ReceiveBufferSize = BUFFER_SIZE;
            while(active)
            {
                try
                {
                    byte[] buffer = new byte[BUFFER_SIZE];
                    int count = client.Client.Receive(buffer);
                    if(count == 0)
                        break;
                    OnReceive(Encoding.UTF8.GetString(buffer, 0, count));
                }
                catch { break; }
            }
            try
            {
                client.Client.Close();
            }
            catch { }
            active = false;
            client = null;
            OnDisconnect();
        }
    }
}
