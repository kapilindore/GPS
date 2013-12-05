using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace YTGPS_Server
{
    /// <summary>
    /// gps�ն���Ϣ
    /// </summary>
    public class GPSInfo
    {
        private String simNO = "";
        private List<Position> posList = null;
        private String msg;
        private TcpTerminal tcpConn = null;
        private String udpRemote;
        /// <summary>
        /// udp�ն˵�ַ
        /// </summary>
        public String UdpRemote
        {
            get { return udpRemote; }
            set { udpRemote = value; }
        }
        private int udpRPort;
        /// <summary>
        /// udp�ն˶˿�
        /// </summary>
        public int UdpRPort
        {
            get { return udpRPort; }
            set { udpRPort = value; }
        }
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private int protocol;
        /// <summary>
        /// Э��
        /// </summary>
        public int Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        /// <summary>
        /// sim����
        /// </summary>
        public String SimNO
        {
            get { return simNO; }
            set { simNO = value; }
        }
        /// <summary>
        /// ������Ķ�λ���б�
        /// </summary>
        public List<Position> PosList
        {
            get { return posList; }
            set { posList = value; }
        }
        /// <summary>
        /// tcp����
        /// </summary>
        public TcpTerminal TcpConn
        {
            get { return tcpConn; }
            set { tcpConn = value; }
        }
        /// <summary>
        /// ����GPS��Ϣ
        /// </summary>
        /// <param name="s">��Ϣ����</param>
        /// <param name="sim">���ź���</param>
        public GPSInfo(String s, String sim)
        {
            msg = s;
            simNO = sim;
        }
        /// <summary>
        /// TCP GPS��Ϣ
        /// </summary>
        /// <param name="s">��Ϣ����</param>
        /// <param name="tt">TCP����</param>
        public GPSInfo(String s, TcpTerminal tt)
        {
            msg = s;
            tcpConn = tt;
        }
        /// <summary>
        /// UDP GPS��Ϣ
        /// </summary>
        /// <param name="s">��Ϣ����</param>
        /// <param name="remote">Զ�̵�ַ</param>
        /// <param name="rport">Զ�̶˿�</param>
        public GPSInfo(String s, String remote, int rport)
        {
            msg = s;
            udpRemote = remote;
            udpRPort = rport;
            
        }
    }
    /// <summary>
    /// gps��λ��Ϣ�����߳�
    /// </summary>
    public class Analyzer
    {
        private static int SLEEP_TIME = 1000;
        private static int MAX_ADD_TIME = 100;

        private int noneCount = 0;
        private bool active = false;
        private object synActive = new object();
        /// <summary>
        /// �Ƿ�������
        /// </summary>
        public bool Active
        {
            get
            {
                lock(synActive)
                {
                    return active; 
                } 
            }
            set
            {
                lock(synActive)
                {
                    active = value; 
                }
            }
        }

        private List<GPSInfo> inList = new List<GPSInfo>();
        private List<GPSInfo> outList = new List<GPSInfo>();

        public delegate void onAnalyzeDelegate();
        public event onAnalyzeDelegate OnAnalyze;
        public delegate void onErrorDelegate(Exception e);
        public event onErrorDelegate onError;

        private Thread thread;

        //����/��ȡ ԭʼGPS��Ϣ
        private object synIn = new object();
        /// <summary>
        /// ����δ������Ϣ������
        /// </summary>
        /// <param name="info"></param>
        public void AddInInfo(GPSInfo info)
        {
            lock(synIn)
            {
                inList.Add(info);
            }
        }
        private List<GPSInfo> GetInInfo()
        {
            lock(synIn)
            {
                List<GPSInfo> list = new List<GPSInfo>();
                list.AddRange(inList);
                inList.Clear();
                return list;
            }
        }
        //����/��ȡ �ѷ�����Ϣ
        private object synOut = new object();
        private void AddOutInfo(List<GPSInfo> list)
        {
            lock(synOut)
            {
                outList.AddRange(list);
            }
        }
        /// <summary>
        /// ��ȡ�ѽ�������Ϣ�б�
        /// </summary>
        /// <returns>��Ϣ�б�</returns>
        public List<GPSInfo> GetOutInfo()
        {
            lock(synOut)
            {
                if(outList.Count == 0)
                    return null;
                List<GPSInfo> list = new List<GPSInfo>();
                list.AddRange(outList);
                outList.Clear();
                return list;
            }
        }
        /// <summary>
        /// ��ʼ�߳�
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            thread = new Thread(new ThreadStart(AnalyzeInfo));
            //�߳�����������
            thread.Name = "analyzer_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// ֹͣ�߳�
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            Active = false;
        }

        //�ڲ��߳�
        private void AnalyzeInfo()
        {
            while(Active)
            {
                try
                {
                    List<GPSInfo> list = GetInInfo();
                    if(list.Count == 0)
                    {
                        noneCount++;
                    }
                    else
                    {
                        noneCount = 0;
                        for(int i=0; i<list.Count; i++)
                        {
                            GPSInfo gi = list[i];
                            //������Ϣ
                            if(gi.SimNO != "")
                            {
                                if(gi.Msg.IndexOf(Protocol_TianHe.HEAD) >= 0)
                                    gi.PosList = Protocol_TianHe.Analyze(gi.Msg, false);
                                else if(gi.Msg.IndexOf(Protocol_DaSanTong.HEAD) >= 0)
                                    gi.PosList = Protocol_DaSanTong.Analyze(gi.Msg, false);
                            }
                            else if(gi.TcpConn != null)//tcp��Ϣ
                            {
                             //   if(gi.Msg.IndexOf(Protocol_TianHe.HEAD) >= 0)
                              //      gi.PosList = Protocol_TianHe.Analyze(gi.Msg, true);
                              //  else if(gi.Msg.IndexOf(Protocol_DaSanTong.HEAD) >= 0)
                              //      gi.PosList = Protocol_DaSanTong.Analyze(gi.Msg, true);
                             //   else if(gi.Msg.IndexOf(Protocol_TianHe.HEAD_HEX_1) >= 0 || gi.Msg.IndexOf(Protocol_TianHe.HEAD_HEX_2) >= 0)
                              //      gi.PosList = Protocol_TianHe.AnalyzeEx(gi.Msg, true);
                                if(gi.Msg.IndexOf(Protocol_VicZone.HEAD)>=0)
                                    gi.PosList = Protocol_VicZone.Analyze(gi.Msg, true);
                            
                            }
                            else//udp��Ϣ
                            {
                          
                                gi.PosList = Protocol_XunLuoShu.Analyze(gi.Msg, true);

                                // if(gi.Msg.IndexOf(Protocol_TianHe.HEAD_HEX_1) >= 0 || gi.Msg.IndexOf(Protocol_TianHe.HEAD_HEX_2) >= 0)
                                  //  gi.PosList = Protocol_TianHe.AnalyzeEx(gi.Msg, true);
                            }
                            if(gi.PosList == null)
                            {
                                list.RemoveAt(i);
                                i--;
                            }
                        }

                        AddOutInfo(list);
                        if(OnAnalyze != null)
                            OnAnalyze();
                    }
                    if(noneCount > MAX_ADD_TIME)
                        noneCount = MAX_ADD_TIME;
                    try
                    {
                        System.Threading.Thread.Sleep(SLEEP_TIME + noneCount * 100);
                    }
                    catch { }
                }
                catch(Exception e)
                {
                    if(onError != null)
                        onError(e);
                }
            }
            thread = null;
        }
    }
}
