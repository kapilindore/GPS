using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace YTGPS_Server
{
    public partial class FormMain : Form
    {
        public const bool LOG_MSG = true;//记录程序运行日志
        public const bool LOG_ERR = true;//记录查询错误日志

        public static Analyzer analyzer = new Analyzer();//协议解析线程
        public static Logger logger = new Logger();//日志记录线程
        public static DBAssistant dbAssistant = new DBAssistant();//辅助数据库线程

        private List<User> userList = new List<User>();//系统用户列表
        private List<Team> teamList = new List<Team>();//系统车队、车辆列表
        //private List<Region> regionList = new List<Region>();
        private DBManager dbm;

        private bool inited = false;

        public FormMain()
        {
            InitializeComponent();
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Config.APP_PATH = Application.StartupPath + "\\";
            Config.loadFromFile();
            InitSmsList();
            //分控服务
            dataServer.Encoding = Encoding.UTF8;
            dataServer.OnActive += new ServerSocket.activeDelegate(dataServer_OnActive);
            dataServer.OnDeactive += new ServerSocket.deactiveDelegate(dataServer_OnDeactive);
            dataServer.OnConnect += new ServerSocket.conncetDelegate(dataServer_OnConnect);
            dataServer.OnDisconnect += new ServerSocket.disconncetDelegate(dataServer_OnDisconnect);
            dataServer.OnReceive += new ServerSocket.receiveDelegeate(dataServer_OnReceive);
            //gprs tcp服务
            gprsServer.Encoding = null;
            gprsServer.OnActive += new ServerSocket.activeDelegate(gprsServer_OnActive);
            gprsServer.OnDeactive += new ServerSocket.deactiveDelegate(gprsServer_OnDeactive);
            gprsServer.OnConnect += new ServerSocket.conncetDelegate(gprsServer_OnConnect);
            gprsServer.OnDisconnect += new ServerSocket.disconncetDelegate(gprsServer_OnDisconnect);
            gprsServer.OnReceiveEx += new ServerSocket.receiveDelegeateEx(gprsServer_OnReceive);

            udpConnection.OnStart += new MoonStudio.Udp.UDPConnection.OnStartDelegate(udpConnection_OnStart);
            udpConnection.OnStop += new MoonStudio.Udp.UDPConnection.OnStopDelegate(udpConnection_OnStop);
            udpConnection.OnReceive += new MoonStudio.Udp.UDPConnection.OnReceiveDelegate(udpConnection_OnReceive);
            //短信服务
            modemServer.Encoding = Encoding.UTF8;
            modemServer.OnActive += new ServerSocket.activeDelegate(modemServer_OnActive);
            modemServer.OnDeactive += new ServerSocket.deactiveDelegate(modemServer_OnDeactive);
            modemServer.OnConnect += new ServerSocket.conncetDelegate(modemServer_OnConnect);
            modemServer.OnDisconnect += new ServerSocket.disconncetDelegate(modemServer_OnDisconnect);
            modemServer.OnReceive += new ServerSocket.receiveDelegeate(modemServer_OnReceive);
            //数据解析线程
            analyzer.OnAnalyze += new Analyzer.onAnalyzeDelegate(analyzer_OnAnalyze);
            analyzer.onError += new Analyzer.onErrorDelegate(analyzer_onError);
            LoadInfoFromDB();//初始化系统数据

            if(FormMain.LOG_MSG)
                logger.AddMsg("程序启动");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show(this, StrConst.WARN_EXIT, StrConst.TITLE_WARN, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ForceClose();
            }
            else e.Cancel = true;
        }
        //退出程序前关闭各个服务
        public void ForceClose()
        {
            if(FormMain.LOG_MSG)
                logger.AddMsg("程序退出");
            StopSmsConnectionAll();
            gprsServer.Active = false;
            dataServer.Active = false;
            modemServer.Active = false;
            logger.Stop();
            analyzer.Stop();
            dbAssistant.Stop();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            logger.Start();
            analyzer.Start();
            dbAssistant.Start();
            if(inited)
            {
                if(Config.SmsAutoStart)
                    buttonSmsStart.PerformClick();
                Thread.Sleep(250);
                if(Config.GprsAutoStart)
                {
                    buttonTcpStart.PerformClick();
                    buttonUdpStart.PerformClick();
                }
                Thread.Sleep(250);
                if(Config.ModemAutoStart)
                    buttonModemStart.PerformClick();
                Thread.Sleep(250);
                if(Config.DataAutoStart)
                    buttonDataStart.PerformClick();
            }
        }
        //记录程序异常
        void LogErrToFile(String source, String msg, String content)
        {
            try
            {
                FileInfo fi = new FileInfo(Application.StartupPath + "\\err_" + Pub.DateStr + ".log");
                StreamWriter sw = fi.AppendText();
                sw.WriteLine("");
                sw.WriteLine(Pub.DateTimeStr);
                sw.WriteLine(source);
                sw.WriteLine(msg);
                sw.WriteLine(content);
                sw.Close();
            }
            catch { }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < '0' || e.KeyChar > '9')
                e.KeyChar = (char)0;
        }
        //程序设置
        private void button4_Click(object sender, EventArgs e)
        {
            bool smsinuse = false;
            foreach(ClientSocket sc in smsSockets)
                if(sc.Connected)
                {
                    smsinuse = true;
                    break;
                }
            if(smsinuse || buttonDataStop.Enabled || gprsServer.Active || udpConnection.Active)
            {
                MessageBox.Show(this, StrConst.ERR_CONFIG);
                return;
            }
            FormConfig frm = new FormConfig(teamList);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                InitSmsList();
                inited = LoadInfoFromDB();
            }
        }
        //退出
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //隐藏
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }
        //关于程序
        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();/*
            String H = "0123456789ABCDEF";
            String s = "24 75 50 13 90 79 12 31 42 15 07 08 22 31 53 75 00 11 40 16 32 4C 00 01 45 FF FF FB FF FF 00 5B ";
            string ss = "";
            for(int i = 0; i < s.Length; i += 3)
                ss = ss + (char)(H.IndexOf(s[i]) * 16 + H.IndexOf(s[i + 1]));

            List<Position> pl = Protocol_TianHe.AnalyzeEx(ss, true);
            if(pl != null)
                MessageBox.Show(pl[0].La.ToString());*/
        }

        #region 移动短信接口
        //启动所有短信服务
        private void buttonSmsStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            StartSmsConnectionAll();
        }
        //关闭所有短信服务
        private void buttonSmsStop_Click(object sender, EventArgs e)
        {
            StopSmsConnectionAll();
        }
        //sms连接右键菜单
        private void listViewSmsList_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ListViewItem item = listViewSmsList.GetItemAt(e.X, e.Y);
                if(item != null)
                {
                    contextMenuStripSmsList.Tag = item.Tag;
                    toolStripMenuItemStart.Enabled = !smsSockets[Int32.Parse(item.Tag as String)].Connected;
                    toolStripMenuItemStop.Enabled = !toolStripMenuItemStart.Enabled;
                }
                else
                {
                    toolStripMenuItemStart.Enabled = false;
                    toolStripMenuItemStop.Enabled = false;
                }
            }
        }
        //启动连接
        private void toolStripMenuItemStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            StartSmsConnection(Int32.Parse(contextMenuStripSmsList.Tag as String));
        }
        //关闭连接
        private void toolStripMenuItemStop_Click(object sender, EventArgs e)
        {
            StopSmsConnection(Int32.Parse(contextMenuStripSmsList.Tag as String));
        }
        #endregion

        #region gprs服务
        //启动tcp服务
        private void buttonGprsStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            else
            {
                gprsServer.Port = Config.GprsPort;
                gprsServer.Active = true;
                buttonTcpStart.Enabled = false;
            }
        }
        //关闭tcp服务
        private void buttonGprsStop_Click(object sender, EventArgs e)
        {
            gprsServer.Active = false;
        }
        //启动udp服务
        private void buttonUdpStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            else
            {
                udpConnection.Start(Config.GprsPort);
                buttonUdpStart.Enabled = false;
            }
        }
        //关闭udp服务
        private void buttonUdpStop_Click(object sender, EventArgs e)
        {
            udpConnection.Stop();
        }
        #endregion

        #region 短信猫服务
        //启动
        private void buttonModemStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            else
            {
                modemServer.Port = Config.ModemPort;
                modemServer.Active = true;
                buttonModemStart.Enabled = false;
            }
        }
        //关闭
        private void buttonModemStop_Click(object sender, EventArgs e)
        {
            modemServer.Active = false;
        }
        #endregion

        #region 数据服务
        //启动数据服务
        private void buttonDataStart_Click(object sender, EventArgs e)
        {
            if(!inited && !LoadInfoFromDB())
            {
                MessageBox.Show(this, StrConst.ERR_DB);
                return;
            }
            else
            {
                dataServer.Port = Config.DataPort;
                dataServer.Active = true;
                buttonDataStart.Enabled = false;
            }
        }
        //关闭数据服务
        private void buttonDataStop_Click(object sender, EventArgs e)
        {
            dataServer.Active = false;
        }
        //服务启动 事件
        void dataServer_OnActive(bool actived)
        {
            try
            {
                this.BeginInvoke(new data_OnActiveCallback(data_OnActive), new object[] { actived });
            }
            catch { }
        }
        public delegate void data_OnActiveCallback(bool actived);
        public void data_OnActive(bool actived)
        {
            if(actived)
            {
                buttonDataStart.Enabled = false;
                buttonDataStop.Enabled = true;
                timerTest.Enabled = true;
                groupBoxSend.Enabled = true;
                if(FormMain.LOG_MSG)
                    logger.AddMsg("数据服务启动");
            }
            else
            {
                buttonDataStart.Enabled = true;
                buttonDataStop.Enabled = false;
                MessageBox.Show(StrConst.ERR_PORT_DATA);
            }
        }
        //服务关闭 事件
        void dataServer_OnDeactive()
        {
            try
            {
                this.BeginInvoke(new data_OnDeactiveCallback(data_OnDeactive), null);
            }
            catch { }
        }
        public delegate void data_OnDeactiveCallback();
        public void data_OnDeactive()
        {
            buttonDataStart.Enabled = true;
            buttonDataStop.Enabled = false;
            timerTest.Enabled = false;
            groupBoxSend.Enabled = false;
            if(FormMain.LOG_MSG)
                logger.AddMsg("数据服务停止");
        }
        //客户端连接 事件
        void dataServer_OnConnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new data_OnConnectCallback(data_OnConnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void data_OnConnectCallback(Socket socket);
        public void data_OnConnect(Socket socket)
        {
            dataClientList.Add(new DataClient(socket));
            labelDataCount.Text = (Int32.Parse(labelDataCount.Text) + 1).ToString();
        }
        //客户端断开连接 事件
        void dataServer_OnDisconnect(Socket socket)
        {
            try
            {
                this.BeginInvoke(new data_OnDisConnectCallback(data_OnDisConnect), new object[] { socket });
            }
            catch { }
        }
        public delegate void data_OnDisConnectCallback(Socket socket);
        public void data_OnDisConnect(Socket socket)
        {
            try
            {
                labelDataCount.Text = (Int32.Parse(labelDataCount.Text) - 1).ToString();
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.Socket == socket)
                    {
                        dataClientList.Remove(dc);
                        if(dc.LoginUser != null)
                        {
                            dc.LoginUser.HasLogin = false;
                            if(dc.HandleAlarmCar != null)
                            {
                                dc.HandleAlarmCar.HandleAlarmClient = null;
                                foreach(AlarmPosition apos in dc.HandleAlarmCar.AlarmPos)
                                    S_Alarm(dc.HandleAlarmCar, apos);
                                dc.HandleAlarmCar = null;
                            }
                        }
                        else if(dc.LoginTeam != null)
                            dc.LoginTeam.HasLogin = false;
                        else if(dc.LoginCar != null)
                            dc.LoginCar.HasLogin = false;
                        break;
                    }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //接收信息 事件
        void dataServer_OnReceive(Socket socket, string msg)
        {
            try
            {
                this.Invoke(new dataServer_OnReceiveDelegate(data_RevMsg), new object[] { socket, msg });
            }
            catch { }
        }
        private delegate void dataServer_OnReceiveDelegate(Socket st, String msg);
        //检测客户端连接是否正常
        private void timerTest_Tick(object sender, EventArgs e)
        {
            try
            {
                for(int i = 0; i < dataClientList.Count; i++)
                {
                    if(!dataClientList[i].TestOk && dataClientList[i].HasLogin)
                        continue;
                    dataClientList[i].ConnCount++;
                    if(dataClientList[i].ConnCount > DataClient.MAX_CONN_COUNT)
                        dataClientList[i].CloseConnection();
                }
            }
            catch(Exception ex)
            {
                if(FormMain.LOG_ERR)
                    LogErrToFile(ex.TargetSite.Name, ex.Message, ex.StackTrace);
            }
        }
        #endregion

        #region 定位信息解析线程
        //协议解析线程完成解析
        void analyzer_OnAnalyze()
        {
            try
            {
                this.BeginInvoke(new OnAnalyzerAnalyzeDelegate(analyzer_Analyzed), null);
            }
            catch { }
        }
        //更新收到的定位信息
        private delegate void OnAnalyzerAnalyzeDelegate();
        private void analyzer_Analyzed()
        {
            try
            {
                List<GPSInfo> list = analyzer.GetOutInfo();
                if(list == null)
                    return;
                foreach(GPSInfo gi in list)
                {
                    if(gi.PosList.Count > 0)
                    {
                        Car car = null;
                        if(gi.SimNO != "")//短信方式，以Sim卡号为标准
                        {
                            car = GetCarBySNO(gi.SimNO);
                            if(car != null)
                            {
                                if(gi.PosList[0].MNO != car.MachineNO)//检测终端序列号是否登记正确
                                {
                                    try
                                    {
                                        String s = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append("收到车辆").Append(car.CarNO).Append("终端信息，终端序列号错误，记录为").Append(car.MachineNO).Append("，收到为").Append(gi.PosList[0].MNO).Append(Constant.FOOT).ToString();
                                        foreach(DataClient dc in dataClientList)
                                            if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null && dc.LoginUser.PolicyModCar == 1)
                                                dc.Send(s);
                                        logger.AddMsg(new StringBuilder("收到车辆").Append(car.CarNO).Append("终端信息，终端序列号错误，记录为").Append(car.MachineNO).Append("，收到为").Append(gi.PosList[0].MNO).ToString());
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                car = GetCarByMNO(gi.PosList[0].MNO);//未找到sim卡记录，已终端序列号为标准
                                if(car != null)
                                {
                                    try
                                    {
                                        String s = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append("收到车辆").Append(car.CarNO).Append("终端信息，SIM号错误，记录为").Append(car.SimNO).Append("，收到为").Append(gi.SimNO).Append(Constant.FOOT).ToString();
                                        foreach(DataClient dc in dataClientList)
                                            if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null && dc.LoginUser.PolicyModCar == 1)
                                                dc.Send(s);
                                        logger.AddMsg(new StringBuilder("收到车辆").Append(car.CarNO).Append("终端信息，SIM号错误，记录为").Append(car.SimNO).Append("，收到为").Append(gi.SimNO).ToString());
                                    }
                                    catch { }
                                }
                                else//sim卡、终端序列号都未找到记录
                                {
                                    try
                                    {
                                        String s = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append("收到终端信息，但是未找到SIM卡[").Append(gi.SimNO).Append("]和终端序列号[").Append(gi.PosList[0].MNO).Append("]的记录").Append(Constant.FOOT).ToString();
                                        foreach(DataClient dc in dataClientList)
                                            if(dc.LoginUser != null)
                                                dc.Send(s);
                                        logger.AddMsg(new StringBuilder("收到终端信息，但是未找到SIM卡[").Append(gi.SimNO).Append("]和终端序列号[").Append(gi.PosList[0].MNO).Append("]的记录").ToString());
                                    }
                                    catch { }
                                    continue;
                                }
                            }
                        }
                        else if(gi.TcpConn != null)//tcp方式，以终端序列号为标准
                        {
                            if(gi.TcpConn.Car != null)
                            {
                                car = gi.TcpConn.Car;
                                car.GprsConn = gi.TcpConn;
                            }
                            else
                            {
                                car = GetCarByMNO(gi.PosList[0].MNO);
                                try
                                {
                                    //关闭重复的连接，释放资源
                                    if(car.GprsConn != null)
                                        car.GprsConn.Socket.Close();
                                }
                                catch { }
                                car.GprsConn = gi.TcpConn;
                                car.GprsConn.Car = car;
                            }
                        }
                        else//udp方式，以终端序列号为标准
                        {
                            car = GetCarByMNO(gi.PosList[0].MNO);
                            if(car != null)
                            {
                                UdpTerminal ut = (UdpTerminal)udpTable[gi.UdpRemote];
                                if(ut == null)
                                {
                                    ut = new UdpTerminal(gi.UdpRemote, gi.UdpRPort);
                                    udpTable.Add(gi.UdpRemote, ut);
                                }
                                ut.Port = gi.UdpRPort;
                                car.UdpAddr = ut;
                            }
                        }
                        foreach(Position pos in gi.PosList)
                        {
                            pos.CarID = car.CarID;
                            if(pos.Mileage == 0)
                                pos.Mileage = car.Pos.Mileage;/*
                                if(pos.Pointed == 0)//定位无效，位置以前次定位为准
                                {
                                    pos.La = car.Pos.La;
                                    pos.Lo = car.Pos.Lo;
                                }*/
                            if(pos.IsGetSetMsg)//获取设置指令回复
                            {
                                S_GetSetting(car, pos.SettingStr);
                            }
                            else
                            {
                                car.Pos.Clone(pos);
                                if(pos.Alarm != "")//是否有报警信息
                                {
                                    AlarmPosition apos = new AlarmPosition(0, pos);
                                    if(car.AlarmPos.Count == 0)
                                    {
                                        if(car.HandleAlarmClient != null)
                                            car.HandleAlarmClient.HandleAlarmCar = null;
                                        car.HandleAlarmClient = null;
                                    }
                                    car.AlarmPos.Add(apos);
                                    S_Alarm(car, apos);
                                }
                                S_RefreshWatching(car);
                                if(pos.IsPointMsg)
                                    S_Point(car);
                                //插入数据库
                                dbAssistant.AddPosition(pos.SqlInsertStr());
                            }
                        }
                    }
                }
            }
            catch{}
        }
        //定位线程错误
        void analyzer_onError(Exception e)
        {
            try
            {
                this.BeginInvoke(new OnAnalyzerErrorDelegate(analyzer_Error), new object[] { e });
            }
            catch { }
        }
        private delegate void OnAnalyzerErrorDelegate(Exception e);
        private void analyzer_Error(Exception e)
        {
            if(FormMain.LOG_ERR)
                logger.AddErr(e, "解析原始定位信息错误");
        }
        #endregion

        private void buttonSend_Click(object sender, EventArgs e)
        {
            S_Warning(comboBoxContent.Text);
            comboBoxContent.Text = "";
        }
    }
}