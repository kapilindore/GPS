using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace YTGPS_Server
{
    public partial class FormMain : Form
    {
        private ServerSocket modemServer = new ServerSocket();
        private Socket modemSocket = null;

        void modemServer_OnActive(bool actived)
        {
            try
            {
                this.BeginInvoke(new modem_OnActiveCallback(modem_OnActive), new object[] { actived });
            }
            catch { }
        }
        public delegate void modem_OnActiveCallback(bool actived);
        public void modem_OnActive(bool actived)
        {
            if(actived)
            {
                buttonModemStart.Enabled = false;
                buttonModemStop.Enabled = true;
                if(FormMain.LOG_MSG)
                    logger.AddMsg("短信猫服务启动");
            }
            else
            {
                buttonModemStart.Enabled = true;
                buttonModemStop.Enabled = false;
                MessageBox.Show(StrConst.ERR_PORT_MODEM);
            }
        }

        void modemServer_OnDeactive()
        {
            try
            {
                this.BeginInvoke(new modem_OnDeactiveCallback(modem_OnDeactive), null);
            }
            catch { }
        }
        public delegate void modem_OnDeactiveCallback();
        public void modem_OnDeactive()
        {
            buttonModemStart.Enabled = true;
            buttonModemStop.Enabled = false;
            if(FormMain.LOG_MSG)
                logger.AddMsg("短信猫服务停止");
        }

        void modemServer_OnConnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new modem_OnConnectCallback(modem_OnConnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void modem_OnConnectCallback(Socket socket);
        public void modem_OnConnect(Socket socket)
        {
            if(modemSocket != null)
                socket.Close();
        }

        void modemServer_OnDisconnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new modem_OnDisconnectCallback(modem_OnDisconnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void modem_OnDisconnectCallback(Socket socket);
        public void modem_OnDisconnect(Socket socket)
        {
            try
            {
                if(modemSocket == socket)
                {
                    modemSocket = null;
                    labelModemCount.Text = (Int32.Parse(labelModemCount.Text) - 1).ToString();
                }
            }
            catch { }
        }

        void modemServer_OnReceive(Socket socket, string msg)
        {
            try
            {
                this.BeginInvoke(new modemOnRevCallback(modemOnRev), new object[] { socket, msg });
            }
            catch { }
        }
        public delegate void modemOnRevCallback(Socket socket, string rec);
        public void modemOnRev(Socket socket, string rec)
        {
            try
            {
                if(rec.IndexOf(Constant.HEAD) == 0)
                {
                    //Console.WriteLine("rec modem:" + rec);
                    char key = rec[Constant.HEAD.Length];
                    String line = rec.Substring(Constant.HEAD.Length + 1, rec.IndexOf(Constant.FOOT) - Constant.HEAD.Length - 1);
                    switch(key)
                    {
                        case Constant.SMS_LOGIN://登陆
                            if(modemSocket == null && line == Config.ModemPw)
                            {
                                modemSocket = socket;
                                SendToModemSocket(modemSocket, new StringBuilder(Constant.HEAD).Append(Constant.SMS_LOGIN).Append(Constant.RESULT_OK).Append(Constant.FOOT).ToString());
                                labelModemCount.Text = (Int32.Parse(labelModemCount.Text) + 1).ToString();
                                if(FormMain.LOG_MSG)
                                    logger.AddMsg("短信猫中转程序已登陆");
                            }
                            else
                                SendToModemSocket(modemSocket, new StringBuilder(Constant.HEAD).Append(Constant.SMS_LOGIN).Append(Constant.RESULT_FAIL).Append(Constant.FOOT).ToString());
                            break;
                        case Constant.SMS_MSG://新信息
                            try
                            {
                                String[] ss = line.Split(Constant.SPLIT1);
                                //if(FormMain.LOG_MSG)
                                    //logger.AddMsg("短信猫终端信息:" + ss[1]);
                                GPSInfo gi = new GPSInfo(ss[1], ss[0]);
                                analyzer.AddInInfo(gi);
                            }
                            catch { }
                            break;
                        case Constant.C_TEST://连接测试
                            //SendToModemSocket(modemSocket, new StringBuilder(Constant.HEAD).Append(Constant.C_TEST).Append(Constant.FOOT).ToString());
                            break;
                        default:
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }

        public bool SendToModemSocket(Socket st, String msg)
        {
            try
            {
                //Console.WriteLine("s->modem:" + s);
                st.Send(modemServer.Encoding.GetBytes(msg.ToCharArray()));
                return true;
            }
            catch { }
            return false;
        }

        public bool SendSmsToModem(String no, String msg)
        {
            try
            {
                //Console.WriteLine("s->modem:" + s);
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.SMS_MSG).Append(no).Append(Constant.SPLIT1).Append(msg).Append(Constant.FOOT);
                modemSocket.Send(modemServer.Encoding.GetBytes(stb.ToString().ToCharArray()));
                return true;
            }
            catch { }
            return false;
        }
    }
}
