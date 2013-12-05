using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace YTGPS_Server
{
    /// <summary>
    /// gps终端信息
    /// </summary>
    public class GPSInfo
    {
        private String simNO = "";
        private List<Position> posList = null;
        private String msg;
        private TcpTerminal tcpConn = null;
        private String udpRemote;
        /// <summary>
        /// udp终端地址
        /// </summary>
        public String UdpRemote
        {
            get { return udpRemote; }
            set { udpRemote = value; }
        }
        private int udpRPort;
        /// <summary>
        /// udp终端端口
        /// </summary>
        public int UdpRPort
        {
            get { return udpRPort; }
            set { udpRPort = value; }
        }
        /// <summary>
        /// 信息内容
        /// </summary>
        public String Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        private int protocol;
        /// <summary>
        /// 协议
        /// </summary>
        public int Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        /// <summary>
        /// sim卡号
        /// </summary>
        public String SimNO
        {
            get { return simNO; }
            set { simNO = value; }
        }
        /// <summary>
        /// 解析后的定位点列表
        /// </summary>
        public List<Position> PosList
        {
            get { return posList; }
            set { posList = value; }
        }
        /// <summary>
        /// tcp连接
        /// </summary>
        public TcpTerminal TcpConn
        {
            get { return tcpConn; }
            set { tcpConn = value; }
        }
        /// <summary>
        /// 短信GPS信息
        /// </summary>
        /// <param name="s">信息内容</param>
        /// <param name="sim">短信号码</param>
        public GPSInfo(String s, String sim)
        {
            msg = s;
            simNO = sim;
        }
        /// <summary>
        /// TCP GPS信息
        /// </summary>
        /// <param name="s">信息内容</param>
        /// <param name="tt">TCP连接</param>
        public GPSInfo(String s, TcpTerminal tt)
        {
            msg = s;
            tcpConn = tt;
        }
        /// <summary>
        /// UDP GPS信息
        /// </summary>
        /// <param name="s">信息内容</param>
        /// <param name="remote">远程地址</param>
        /// <param name="rport">远程端口</param>
        public GPSInfo(String s, String remote, int rport)
        {
            msg = s;
            udpRemote = remote;
            udpRPort = rport;
            
        }
    }
    /// <summary>
    /// gps定位信息解析线程
    /// </summary>
    public class Analyzer
    {
        private static int SLEEP_TIME = 1000;
        private static int MAX_ADD_TIME = 100;

        private int noneCount = 0;
        private bool active = false;
        private object synActive = new object();
        /// <summary>
        /// 是否已启动
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

        //加入/提取 原始GPS信息
        private object synIn = new object();
        /// <summary>
        /// 加入未解析信息到队列
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
        //加入/提取 已分析信息
        private object synOut = new object();
        private void AddOutInfo(List<GPSInfo> list)
        {
            lock(synOut)
            {
                outList.AddRange(list);
            }
        }
        /// <summary>
        /// 获取已解析的信息列表
        /// </summary>
        /// <returns>信息列表</returns>
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
        /// 开始线程
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            thread = new Thread(new ThreadStart(AnalyzeInfo));
            //线程名，调试用
            thread.Name = "analyzer_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// 停止线程
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            Active = false;
        }

        //内部线程
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
                            //短信信息
                            if(gi.SimNO != "")
                            {
                                if(gi.Msg.IndexOf(Protocol_TianHe.HEAD) >= 0)
                                    gi.PosList = Protocol_TianHe.Analyze(gi.Msg, false);
                                else if(gi.Msg.IndexOf(Protocol_DaSanTong.HEAD) >= 0)
                                    gi.PosList = Protocol_DaSanTong.Analyze(gi.Msg, false);
                            }
                            else if(gi.TcpConn != null)//tcp信息
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
                            else//udp信息
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
