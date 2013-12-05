using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;

namespace YTGPS_Server
{
    public partial class FormMain : Form
    {
        private List<ClientSocket> smsSockets = new List<ClientSocket>();

        //��ʼ���ƶ�ר���б�
        private void  InitSmsList()
        {
            int i = 0;
            smsSockets.Clear();
            listViewSmsList.Items.Clear();
            foreach(SmsConfig smsconfig in Config.SmsList)
            {
                ClientSocket cs = new ClientSocket(i);
                cs.OnConnect += new ClientSocket.conncetDelegate(cs_OnConnect);
                cs.OnDisconnect += new ClientSocket.disconncetDelegate(cs_OnDisconnect);
                cs.OnReceive += new ClientSocket.receiveDelegeate(cs_OnReceive);
                smsSockets.Add(cs);
                ListViewItem item = new ListViewItem(smsconfig.SmsName);
                item.SubItems.Add(StrConst.STATUS_SMS_NOT_CONN);
                //item.Checked = smsconfig.Enabled;
                item.Tag = i.ToString();
                listViewSmsList.Items.Add(item);
                i++;
            }
        }
        //��������
        public void StartSmsConnection(int index)
        {
            if(!smsSockets[index].Connected)
                smsSockets[index].ConnectServer(Config.SmsList[index].SmsHost, Config.SmsList[index].SmsPort);
        }
        //ֹͣ����
        public void StopSmsConnection(int index)
        {
            smsSockets[index].NeedTest = false;
            smsSockets[index].ReConn = false;
            smsSockets[index].ForceDisConnect();
        }
        //������������
        public void StartSmsConnectionAll()
        {
            for(int index = 0; index < smsSockets.Count; index++)
            {
                if(!smsSockets[index].Connected)
                    smsSockets[index].ConnectServer(Config.SmsList[index].SmsHost, Config.SmsList[index].SmsPort);
            }
        }
        //ֹͣ��������
        public void StopSmsConnectionAll()
        {
            foreach(ClientSocket cs in smsSockets)
            {
                cs.NeedTest = false;
                cs.ForceDisConnect();
            }
        }
        //������Ϣ
        public bool SendSms(int index, String sim, String content)
        {
            if(smsSockets[index].HasLogin)
                return smsSockets[index].Send(Constant.HEAD + Constant.SMS_MSG + sim + Constant.SPLIT1 + content + Constant.FOOT);
            return false;
        }

        #region SMS socket�¼�
        //�����¼�
        void cs_OnConnect(int index, bool hasConn)
        {
            try
            {
                this.BeginInvoke(new sms_OnConnCallback(sms_OnConn), new object[] { index, hasConn });
            }
            catch { }
        }
        public delegate void sms_OnConnCallback(int index, bool hasConn);
        public void sms_OnConn(int index, bool hasConn)
        {
            if(hasConn)
            {
                listViewSmsList.Items[index].SubItems[1].Text = StrConst.STATUS_SMS_CONNECTING;
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.SMS_LOGIN).Append(Config.SmsList[index].SmsPw).Append(Constant.FOOT);
                smsSockets[index].Send(stb.ToString());
            }
            else
            {
                if(!smsSockets[index].ReConn)
                    MessageBox.Show(Config.SmsList[index].SmsName + StrConst.ERR_SMS_CONN);
            }
        }
        //���ӶϿ��¼�
        void cs_OnDisconnect(int index)
        {
            try
            {
                this.BeginInvoke(new sms_OnDisconnCallback(sms_OnDisconn), new object[] { index });
            }
            catch { }
        }
        public delegate void sms_OnDisconnCallback(int index);
        public void sms_OnDisconn(int index)
        {
            if(smsSockets[index].HasLogin && FormMain.LOG_MSG)
                logger.AddMsg("�ƶ�ר��[" + Config.SmsList[index].SmsName + "]�Ͽ�");
            smsSockets[index].HasLogin = false;
            smsSockets[index].NeedTest = false;
            listViewSmsList.Items[index].SubItems[1].Text = StrConst.STATUS_SMS_NOT_CONN;
            S_Warning(new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append("����ר��(").Append(Config.SmsList[index].SmsName).Append(")�����ѶϿ�").Append(Constant.FOOT).ToString());
        }
        //�����¼�
        void cs_OnReceive(int index, string rec)
        {
            try
            {
                this.BeginInvoke(new sms_OnRevCallback(sms_OnRev), new object[] { index, rec });
            }
            catch { }
        }
        public delegate void sms_OnRevCallback(int index, string rec);
        public void sms_OnRev(int index, string rec)
        {
            try
            {
                if(rec.IndexOf(Constant.HEAD) == 0)
                {
                    //Console.WriteLine("rec sms:" + rec);
                    char key = rec[Constant.HEAD.Length];
                    String line = rec.Substring(Constant.HEAD.Length + 1, rec.IndexOf(Constant.FOOT) - Constant.HEAD.Length - 1);
                    switch(key)
                    {
                        case Constant.SMS_LOGIN://��½����
                            if(line[0] == Constant.RESULT_OK)
                            {
                                smsSockets[index].HasLogin = true;
                                smsSockets[index].ReConn = true;
                                smsSockets[index].TestOk = true;
                                listViewSmsList.Items[index].SubItems[1].Text = StrConst.STATUS_SMS_CONNECTED;
                                S_Message(new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append("����ר��(").Append(Config.SmsList[index].SmsName).Append(")������").Append(Constant.FOOT).ToString());
                                if(FormMain.LOG_MSG)
                                    logger.AddMsg("�ƶ�ר��[" + Config.SmsList[index].SmsName + "]����");
                            }
                            else
                            {
                                smsSockets[index].ReConn = false;
                                smsSockets[index].NeedTest = false;
                                smsSockets[index].DisConnect();
                                MessageBox.Show(Config.SmsList[index].SmsName + StrConst.ERR_SMS_LOGIN);
                            }
                            break;
                        case Constant.SMS_MSG://����Ϣ
                            try
                            {
                                String[] ss = line.Split(Constant.SPLIT1);
                                //if(FormMain.LOG_MSG)
                                //logger.AddMsg("�ƶ�ר���ն���Ϣ:" + ss[1]);
                                //Console.WriteLine("modem:" + ss[0] + ";" + ss[1]);
                                GPSInfo gi = new GPSInfo(ss[1], ss[0]);
                                analyzer.AddInInfo(gi);
                            }
                            catch { }
                            break;
                        case Constant.C_TEST://���Ӳ���
                            smsSockets[index].TestOk = true;
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
        #endregion

        #region �������
        private void TestSmsConnection()
        {
            try
            {
                foreach(ClientSocket cs in smsSockets)
                {
                    if(cs.TestOk)
                    {
                        cs.TestOk = false;
                        cs.NeedTest = true;
                        if(cs.HasLogin)
                            cs.Send(Constant.CONN_TEST);
                    }
                }
            }
            catch { }
        }
        private void timerSmsTest_Tick(object sender, EventArgs e)
        {
            timerSmsTest.Enabled = false;
            TestSmsConnection();
            timerSmsReconn.Enabled = true;
        }
        //
        private void timerSmsReconn_Tick(object sender, EventArgs e)
        {
            timerSmsReconn.Enabled = false;
            try
            {
                for(int i=0; i<smsSockets.Count; i++)
                {
                    if(!smsSockets[i].TestOk && smsSockets[i].NeedTest && smsSockets[i].ReConn)
                    {
                        smsSockets[i].DisConnect();
                        smsSockets[i].ConnectServer(Config.SmsList[i].SmsHost, Config.SmsList[i].SmsPort);
                    }
                }
            }
            catch { }
            timerSmsTest.Enabled = true;
        }
        #endregion
    }
}
