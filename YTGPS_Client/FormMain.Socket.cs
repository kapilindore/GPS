
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;



namespace YTGPS_Client
{
    public partial class FormMain : Form
    {
        public static ClientSocket dataSocket = new ClientSocket();
        
        private bool connOK = false;
        private String recStr = "";
        private object syncrecstr = new object();
        private String RecStr
        {  
            get
            {
                lock(syncrecstr)
                {
                    return recStr;
                }
            }
            set
            {
                lock(syncrecstr)
                {
                    recStr = value;
                }
            }
        }
        private int reconnCount = 0;

        public delegate void onConnectedDelegate(bool hasConn);
        public event onConnectedDelegate onConnected;

        public delegate void onLoginDelegate(bool hasLogin, bool isReconn);
        public event onLoginDelegate onLogin;

        public delegate void onDisconnDelegate();
        public event onDisconnDelegate onDisconn;

        public delegate void onGetSettingResponseDelegate(Car car);//取得终端设置返回
        public event onGetSettingResponseDelegate onGetSettingResponse;

        public delegate void onAlarmDelegate(AlarmPosition apos);//报警信息
        public event onAlarmDelegate onAlarm;

        public delegate void onModifyAccountDelegate(bool suc, String s);//修改帐号信息
        public event onModifyAccountDelegate onModifyAccount;

        public delegate void onModifyTeamDelegate(bool suc, String s);//修改车队信息
        public event onModifyTeamDelegate onModifyTeam;

        public delegate void onModifyCarDelegate(bool suc, String s);//修改车辆信息
        public event onModifyCarDelegate onModifyCar;

        public delegate void onDeclareModedDelegate(bool suc);//修改申报
        public event onDeclareModedDelegate onDeclareModed;

        public delegate void onDeclareHisContentdelegate(String s);//修改申报
        public event onDeclareHisContentdelegate onDeclareHisContent;

        //public delegate void onHandleAlarmDelegate(bool suc, String s);//接警返回
        //public event onHandleAlarmDelegate onHandleAlarm;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region socket事件
        //连接 事件
        void dataSocket_OnConnect(bool conn)
        {
          

            MessageToMainForm dd = new MessageToMainForm(f_MessageToMainForm);
            this.Invoke(dd, new object[] { DATA_CONN, conn ? 1 : 0 });
        }
        //断开 事件
        void dataSocket_OnDisconnect()
        {
            try
            {
                MessageToMainForm dd = new MessageToMainForm(f_MessageToMainForm);
                this.Invoke(dd, new object[] { DATA_DISCONN, 0 });
            }
            catch { }
        }
        //接收 事件
        void dataSocket_OnReceive(string msg)
        {
            this.RecStr += msg;
            MessageToMainForm dd = new MessageToMainForm(f_MessageToMainForm);
            this.Invoke(dd, new object[] { DATA_REV, 0 });
        }
        #endregion
        //连接成功/失败处理
        public void DataOnConn(bool conn)
        {
            if(conn)
            {
                if(onConnected != null)
                    onConnected(true);
                C_Conn_Login();
            }
            else
            {
                if(onConnected != null)
                    onConnected(false);
                Log(StrConst.CONN_ERR_HOST);
                if(dataSocket.ReConn && Config.AutoReconn)
                {
                    timerReconn.Enabled = true;
                    return;
                }
                SetLogoutStatus();
            }
        }
        //连接断开处理
        public void DataOnDisConn()
        {
            timerTest.Enabled = false;
            SetLogoutStatus();
            if(onDisconn != null)
                onDisconn();
            if(dataSocket.ReConn)
            {
                Log(StrConst.CONN_DOWN_ERR);
                if(Config.ConnDownSound)
                    PlaySound(Config.APP_PATH + Constant.FILE_SOUND_DOWN);
                if(Config.AutoReconn && dataSocket.ReConn)
                {
                    timerReconn.Enabled = true;
                }
            }
            else Log(StrConst.CONN_DOWN);
        }
        //接收信息处理
        public void DataOnReceive()
        {
            try
            {
                String rec = RecStr;
                if(rec.IndexOf(Constant.HEAD) == 0 && rec.IndexOf(Constant.FOOT) > Constant.HEAD.Length)
                {
                    rec = rec.Substring(0, rec.LastIndexOf(Constant.FOOT) + Constant.FOOT.Length);
                    RecStr = RecStr.Substring(rec.Length);
                }
                else rec = "";
                while(rec.IndexOf(Constant.HEAD) == 0 && rec.IndexOf(Constant.FOOT) > Constant.HEAD.Length)
                {
                    String line = rec.Substring(Constant.HEAD.Length, rec.IndexOf(Constant.FOOT) - Constant.HEAD.Length);
                    rec = rec.Substring(rec.IndexOf(Constant.FOOT) + Constant.FOOT.Length);
                    char key1 = line[0];
                    if(key1 == Constant.C_TEST)
                    {
                        connOK = true;
                        timerCheckConn.Enabled = false;
                        timerTest.Enabled = true;
                    }
                    else
                    {
                        char key2 = line[1];
                        line = line.Substring(2);
                        if(key1 == Constant.C_CONN)
                        {
                            switch(key2)
                            {
                                case Constant.C_CONN_LOGIN:
                                    R_Login(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_POS)
                        {
                            switch(key2)
                            {
                                case Constant.C_POS_WATCH:
                                    R_Watching(line);
                                    break;
                                case Constant.C_POS_POINT:
                                    R_Point(line);
                                    break;
                                case Constant.C_POS_HIS_POS:
                                    R_HisPos(line);
                                    break;
                                case Constant.C_POS_HIS_ALARM:
                                    R_HisAlarm(line);
                                    break;
                                case Constant.C_POS_REGION_QUERY:
                                    R_RegionQuery(line);
                                    break;
                                case Constant.C_POS_MILEAGE:
                                    R_HisMileage(line);
                                    break;
                                case Constant.C_POS_PLACE_QUERY:
                                    R_PlaceQuery(line);
                                    break;
                                case Constant.C_POS_PLACE_MARK:
                                    R_PlaceMark(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_INFO)
                        {
                            switch(key2)
                            {
                                case Constant.C_INFO_ACCOUNT_LIST:
                                    R_AccountList(line);
                                    break;
                                case Constant.C_INFO_ACCOUNT_ADD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyAccount != null)
                                            onModifyAccount(true, null);
                                        Log(StrConst.INFO_ACCOUNT_ADD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyAccount != null)
                                            onModifyAccount(false, line.Substring(1));
                                        Log(StrConst.INFO_ACCOUNT_ADD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_ACCOUNT_MOD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyAccount != null)
                                            onModifyAccount(true, null);
                                        Log(StrConst.INFO_ACCOUNT_MOD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyAccount != null)
                                            onModifyAccount(false, line.Substring(1));
                                        Log(StrConst.INFO_ACCOUNT_MOD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_ACCOUNT_DEL:
                                    if(line[0] == Constant.RESULT_OK)
                                        Log(StrConst.INFO_ACCOUNT_DEL_OK);
                                    else Log(StrConst.INFO_ACCOUNT_DEL_FAIL + line.Substring(1));
                                    break;
                                case Constant.C_INFO_TEAM_ADD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyTeam != null)
                                            onModifyTeam(false, null);
                                        Log(StrConst.INFO_TEAM_ADD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyTeam != null)
                                            onModifyTeam(true, line.Substring(1));
                                        Log(StrConst.INFO_TEAM_ADD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_TEAM_MOD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyTeam != null)
                                            onModifyTeam(true, null);
                                        Log(StrConst.INFO_TEAM_MOD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyTeam != null)
                                            onModifyTeam(false, line.Substring(1));
                                        Log(StrConst.INFO_TEAM_MOD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_TEAM_DEL:
                                    if(line[0] == Constant.RESULT_OK)
                                        Log(StrConst.INFO_TEAM_DEL_OK);
                                    else Log(StrConst.INFO_TEAM_MOD_FAIL + line.Substring(1));
                                    break;
                                case Constant.C_INFO_CAR_ADD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyCar != null)
                                            onModifyCar(true, null);
                                        Log(StrConst.INFO_CAR_ADD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyCar != null)
                                            onModifyCar(false, line.Substring(1));
                                        Log(StrConst.INFO_CAR_ADD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_CAR_MOD:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        if(onModifyCar != null)
                                            onModifyCar(true, null);
                                        Log(StrConst.INFO_CAR_MOD_OK);
                                    }
                                    else
                                    {
                                        if(onModifyCar != null)
                                            onModifyCar(false, line.Substring(1));
                                        Log(StrConst.INFO_CAR_MOD_FAIL + line.Substring(1));
                                    }
                                    break;
                                case Constant.C_INFO_CAR_DEL:
                                    if(line[0] == Constant.RESULT_OK)
                                        Log(StrConst.INFO_CAR_DEL_OK);
                                    else Log(StrConst.INFO_CAR_DEL_FAIL + line.Substring(1));
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_SET)
                        {
                            switch(key2)
                            {
                                case Constant.C_SET_GET_SET:
                                    R_GetSetting(line);
                                    break;
                                case Constant.C_SET_ORDER:
                                    if(line[0] == Constant.RESULT_OK)
                                        Log(StrConst.SET_ORDER_OK + line.Substring(1));
                                    else if(line[0] == Constant.RESULT_FAIL)
                                        Log(StrConst.SET_ORDER_FAIL + line.Substring(1));
                                    break;
                                case Constant.C_SET_STOPED:
                                    if(line[0] == Constant.RESULT_FAIL)
                                        Log(StrConst.SET_STOPED_FAIL + line.Substring(1));
                                    break;
                                case Constant.C_SET_SERVICE_TIME:
                                    if(line[0] == Constant.RESULT_FAIL)
                                        Log(StrConst.SET_SERVICE_TIME_FAIL + line.Substring(1));
                                    break;
                                case Constant.C_SET_NOTIFY:
                                    if(line[0] == Constant.RESULT_FAIL)
                                        Log(StrConst.SET_NOTIFY_FAIL + line.Substring(1));
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_ALARM)
                        {
                            switch(key2)
                            {
                                case Constant.C_ALARM_HANDLE:
                                    R_HanleAlarm(line);
                                    break;
                                case Constant.C_ALARM_FREE:
                                    R_FreeAlarm(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_CHAT)
                            S_Chat(key2 + line);
                        else if(key1 == Constant.C_QUERY)
                        {
                            switch(key2)
                            {
                                case Constant.C_QUERY_OPERATION:
                                    R_OperationHis(line);
                                    break;
                                case Constant.C_QUERY_ORDER:
                                    R_OrderHis(line);
                                    break;
                                case Constant.C_QUERY_DECLARE:
                                    R_DeclareListHis(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.C_DECLARE)
                        {
                            switch(key2)
                            {
                                case Constant.C_DECLARE_NEW:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        Log(StrConst.DECLARE_NEW_OK);
                                        if(onDeclareModed != null)
                                            onDeclareModed(true);
                                    }
                                    else
                                    {
                                        Log(StrConst.DECLARE_NEW_FAIL + line.Substring(1));
                                        if(onDeclareModed != null)
                                            onDeclareModed(false);
                                    }
                                    break;
                                case Constant.C_DECLARE_LIST:
                                    R_DeclareList(line.Substring(1));
                                    break;
                                case Constant.C_DECLARE_HIS_CONTENT:
                                    if(onDeclareHisContent != null)
                                        onDeclareHisContent(line);
                                    break;
                                case Constant.C_DECLARE_DEAL:
                                    if(line[0] == Constant.RESULT_OK)
                                    {
                                        Log(StrConst.DECLARE_DEAL_OK);
                                        if(onDeclareModed != null)
                                            onDeclareModed(true);
                                    }
                                    else
                                    {
                                        Log(StrConst.DECLARE_DEAL_FAIL + line.Substring(1));
                                        if(onDeclareModed != null)
                                            onDeclareModed(false);
                                    }
                                    break;
                            }
                        }
                        else if(key1 == Constant.S_INFO)
                        {
                            switch(key2)
                            {
                                case Constant.S_INFO_TEAM_ADD:
                                    S_AddTeam(line);
                                    break;
                                case Constant.S_INFO_TEAM_MOD:
                                    S_ModifyTeam(line);
                                    break;
                                case Constant.S_INFO_TEAM_DEL:
                                    S_DelTeam(line);
                                    break;
                                case Constant.S_INFO_CAR_ADD:
                                    S_AddCar(line);
                                    break;
                                case Constant.S_INFO_CAR_MOD:
                                    S_ModifyCar(line);
                                    break;
                                case Constant.S_INFO_CAR_DEL:
                                    S_DelCar(line);
                                    break;
                                case Constant.S_INFO_USER_INFO:
                                    S_UserInfo(line);
                                    break;
                                case Constant.S_INFO_SET_STOPED:
                                    S_SetCarStoped(line);
                                    break;
                                case Constant.S_INFO_SET_SERVICE_TIME:
                                    S_SetCarServiceTime(line);
                                    break;
                                case Constant.S_INFO_SET_NOTIFY:
                                    S_SetCarNotify(line);
                                    break;
                                case Constant.S_INFO_ALARM:
                                    S_Alarm(line);
                                    break;
                                case Constant.S_INFO_FREE_ALARM:
                                    S_FreeAlarm(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.S_DECLARE)
                        {
                            switch(key2)
                            {
                                case Constant.S_DECLARE_ADD:
                                    S_DeclareAdd(line);
                                    break;
                                case Constant.S_DECLARE_DEAL:
                                    S_DeclareDeal(line);
                                    break;
                            }
                        }
                        else if(key1 == Constant.S_MSG)
                        {
                            switch(key2)
                            {
                                case Constant.S_MSG_MESSAGE:
                                    Log(StrConst.S_MSG_MESSAGE + line);
                                    break;
                                case Constant.S_MSG_WARN:
                                    if(Config.ServWarnSound)
                                        PlaySound(Config.APP_PATH + Constant.FILE_SOUND_SEV_WARN);
                                    MessageBox.Show(this, line, StrConst.TITLE_WARN);
                                    Log(StrConst.S_MSG_WARN + line);
                                    break;
                                case Constant.S_MSG_ERR:
                                    if(Config.ServWarnSound)
                                        PlaySound(Config.APP_PATH + Constant.FILE_SOUND_SEV_WARN);
                                    MessageBox.Show(this, line, StrConst.TITLE_WARN);
                                    Log(StrConst.S_MSG_ERR + line);
                                    break;
                            }
                        }
                        if(Config.NotifySound)
                            PlaySound(Config.APP_PATH + Constant.FILE_SOUND_NOTIFY);
                    }
                }
            }
            catch { }
        }
        /**************************************************************************
         * 发送、接收数据处理
        **************************************************************************/
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 客户端发送指令
        //检测连接
        private void C_Conn_Test()
        {
            dataSocket.Send(Constant.CONN_TEST);
        }
        //登陆
        private void C_Conn_Login()
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_CONN).Append(Constant.C_CONN_LOGIN);
            stb.Append(user.Type).Append(Constant.SPLIT1).Append(user.Name).Append(Constant.SPLIT1).Append(user.Pw).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //退出登陆
        private void C_Conn_Logout()
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_CONN).Append(Constant.C_CONN_LOGOUT).Append(Constant.FOOT);
            if(dataSocket.Send(stb.ToString()))
                dataSocket.ForceDisConnect();
        }
        //----------------------------------------------------------------------//
        //监控 车辆
        private void C_Pos_Watch(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_WATCH);
            stb.Append(car.CarID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
            if(car.ItemInList != null && car.ItemInList.ForeColor != COLOR_CAR_OVER_SERVICE && car.ItemInList.ForeColor != COLOR_CAR_STOP)
                car.ItemInList.ForeColor = COLOR_CAR_IN_WATCH;
        }
        //监控 车队
        private void C_Pos_Watch(Team team)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_WATCH);
            stb.Append(team.TeamID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
            foreach(Car car in team.Cars)
                if(car.ItemInList != null && car.ItemInList.ForeColor != COLOR_CAR_OVER_SERVICE && car.ItemInList.ForeColor != COLOR_CAR_STOP)
                    car.ItemInList.ForeColor = COLOR_CAR_IN_WATCH;
        }
        //停止监控 车辆
        private void C_Pos_StopWatch(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_STOP_WATCH);
            stb.Append(car.CarID).Append(Constant.FOOT);
            if(dataSocket.Send(stb.ToString()))
                RemoveWatching(car);
        }
        //停止监控 车队
        private void C_Pos_StopWatch(Team team)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_STOP_WATCH);
            stb.Append(team.TeamID).Append(Constant.FOOT);
            if(dataSocket.Send(stb.ToString()))
                RemoveWatching(team);
        }
        //停止所有监控
        private void C_Pos_StopWatch()
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_STOP_WATCH).Append(Constant.FOOT);
            if(dataSocket.Send(stb.ToString()))
                RemoveWatching();
        }
        //定位
        private void C_Pos_Point(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_POINT);
            stb.Append(car.CarID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //历史轨迹
        private void C_Pos_HisPos(Car car, String sTime, String eTime)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_HIS_POS);
            stb.Append(car.CarID).Append(Constant.SPLIT1).Append(sTime).Append(Constant.SPLIT1).Append(eTime).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //历史报警
        private void C_Pos_HisAlarm(String ids, String sTime, String eTime)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_HIS_ALARM);
            stb.Append(ids).Append(Constant.SPLIT1).Append(sTime).Append(Constant.SPLIT1).Append(eTime).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //里程统计
        private void C_Pos_Mileage(String ids, String sTime, String eTime)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_MILEAGE);
            stb.Append(ids).Append(Constant.SPLIT1).Append(sTime).Append(Constant.SPLIT1).Append(eTime).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //区域查车
        private void C_Pos_Region_Query(String tid, String sTime, String eTime, String pts)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_REGION_QUERY);
            stb.Append(tid).Append(Constant.SPLIT1).Append(sTime).Append(Constant.SPLIT1).Append(eTime).Append(Constant.SPLIT1).Append(pts).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //标注查询
        private void C_Pos_PlaceQuery(String key)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_PLACE_QUERY);
            stb.Append(key).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //标注
        private void C_Pos_PlaceMark(String name, String lo, String la)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_PLACE_MARK);
            stb.Append(name).Append(Constant.SPLIT1).Append(lo).Append(Constant.SPLIT1).Append(la).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //----------------------------------------------------------------------//
        //接警
        public static void C_Alarm_Handle(Car car, bool handle)
        {
            CheckCarNotify(car);
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_ALARM).Append(Constant.C_ALARM_HANDLE);
            stb.Append(car.CarID).Append(Constant.SPLIT1).Append(handle ? Constant.RESULT_OK : Constant.RESULT_FAIL).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //解除报警
        public static bool C_Alarm_Free(String cid, String needOrder)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_ALARM).Append(Constant.C_ALARM_FREE);
            stb.Append(cid).Append(Constant.SPLIT1).Append(needOrder).Append(Constant.FOOT);
            return dataSocket.Send(stb.ToString());
        }
        //----------------------------------------------------------------------//
        //添加车队
        public static void C_Info_AddTeam(Team team)
        {
            team.TeamID = 0;
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_TEAM_ADD).Append(team.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //修改车队信息
        public static void C_Info_ModifyTeam(Team team)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_TEAM_MOD).Append(team.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //删除车队
        private void C_Info_DelTeam(int teamID)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_TEAM_DEL).Append(teamID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //添加车辆
        public static void C_Info_AddCar(Car car)
        {
            car.CarID = 0;
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_CAR_ADD).Append(car.Team.TeamID).Append(Constant.SPLIT1).Append(car.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //修改车辆信息
        public static void C_Info_ModifyCar(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_CAR_MOD).Append(car.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //删除车辆
        private void C_Info_DelCar(int carID)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_CAR_DEL).Append(carID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //取得帐号列表
        public static void C_Info_AccountList()
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_ACCOUNT_LIST).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //添加帐号
        public static void C_Info_AddAccount(Account account)
        {
            account.Id = 0;
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_ACCOUNT_ADD).Append(account.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //修改帐号
        public static void C_Info_ModifyAccount(Account account)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_ACCOUNT_MOD).Append(account.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //删除帐号
        public static void C_Info_DelAccount(int aID)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO);
            stb.Append(Constant.C_INFO_ACCOUNT_DEL).Append(aID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //----------------------------------------------------------------------//
        //下发指令
        public static void C_Set_Order(String order)
        {
       

            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_ORDER);
            stb.Append(order).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
          
        }
        //修改车辆服务状态
        public static void C_Set_Stoped(Car car, int status)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_STOPED);
            stb.Append(car.CarID).Append(Constant.SPLIT1).Append(status).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //修改车辆服务日期
        public static void C_Set_ServiceTime(Car car, String stime, bool cancelStop)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_SERVICE_TIME);
            stb.Append(car.CarID).Append(Constant.SPLIT1).Append(stime).Append(Constant.SPLIT1).Append(cancelStop ? 1 : 0).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //修改车辆操作提示
        public static void C_Set_Notify(int cid, bool enable, String sDate, String eDate, String text)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_NOTIFY);
            if(enable)
            {
                stb.Append(cid).Append(Constant.SPLIT1).Append("1").Append(Constant.SPLIT1);
                stb.Append(sDate).Append(Constant.SPLIT1).Append(eDate).Append(Constant.SPLIT1);
                stb.Append(text).Append(Constant.SPLIT1).Append(Constant.FOOT);
            }
            else stb.Append(cid).Append(Constant.SPLIT1).Append("0").Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //取得终端设置
        public static void C_Set_GetSet(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_GET_SET);
            stb.Append(car.CarID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //聊天信息
        public static void C_Chat(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_CHAT);
            stb.Append(s).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //----------------------------------------------------------------------//
        //操作记录查询
        public static void C_Query_Operation(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_OPERATION);
            stb.Append(s).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //指令记录查询
        public static void C_Query_Order(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_ORDER);
            stb.Append(s).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //申报记录查询
        public static void C_DeclareListHis(String para)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_DECLARE);
            stb.Append(para).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //----------------------------------------------------------------------//
        //获取待处理申报
        public static void C_DeclareList(Car car)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_LIST);
            stb.Append(car.CarID).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //新申报
        public static void C_NewDeclare(Declare dec)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_NEW);
            stb.Append(dec.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //处理申报
        public static void C_ModDeclare(Declare dec)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_DEAL);
            stb.Append(dec.ToString()).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        //车辆申报历史
        public static void C_DeclareCarHis(String cid, String date)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_HIS_CONTENT);
            stb.Append(cid).Append(Constant.SPLIT1).Append(date).Append(Constant.FOOT);
            dataSocket.Send(stb.ToString());
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 处理服务器回复信息
        /*
         * 回复-登陆
         * 用户信息 S1 车队1信息 S3 车辆1信息 S3 车辆2信息 S1 车队2信息 S3 车辆3信息 S3 车辆4信息 S1 ... S1 指令信道信息
         */
        private void R_Login(String rec)
        {
            if(rec[0] == Constant.RESULT_OK)
            {
                dataSocket.ReConn = true;
                timerReconn.Interval = 5000 + new System.Random().Next(1000 + reconnCount, 10000 + reconnCount);
                reconnCount = 0;
                user.TeamList.Clear();
                try
                {
                    String[] s = rec.Substring(1).Split(Constant.SPLIT1);
                    Car.ParseRouteway(s[s.Length - 1]);//指令通道
                    int tstart = 0;
                    if(user.Type == User.USER_ADMIN || user.Type == User.USER_OP)//用户信息
                    {
                        user.Update(s[0]);
                        tstart = 1;
                    }
                    for(int i = tstart; i < s.Length - 1; i++)//车队车辆信息
                    {
                        String[] ss = s[i].Split(Constant.SPLIT3);
                        Team team = Team.Parse(ss[0]);
                        if(team != null)
                        {
                            user.TeamList.Add(team);
                            for(int j = 1; j < ss.Length; j++)
                            {
                                Car car = Car.Parse(ss[j]);
                                if(car != null)
                                {
                                    car.Team = team;
                                    car.TeamID = team.TeamID;
                                    team.Cars.Add(car);
                                }
                            }
                        }
                    }
                    Log(StrConst.CONN_LOGIN);

                    UpdateTeamNCar();
                    //UpdateAlarmList();
                    SetLoginStatus();
                    Config.AddLogin(user.Host, user.Port, user.Type, user.Name);
                    if(onLogin != null)
                        onLogin(true, false);
                    timerTest.Enabled = true;
                }
                catch { }
            }
            else if(rec[0] == Constant.RESULT_OTHER)
            {
                Log(StrConst.CONN_RELOGIN);
                if(onLogin != null)
                    onLogin(false, true);
                Config.AddLogin(user.Host, user.Port, user.Type, user.Name);
                dataSocket.DisConnect();
            }
            else
            {
                Log(StrConst.CONN_LOGIN_FAIL);
                if(onLogin != null)
                    onLogin(false, false);
                dataSocket.ForceDisConnect();
            }
        }
        //回复-监控
        private void R_Watching(String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            for(int i = 0; i < ss.Length - 1; i += 2)
            {
                Car car = user.GetCarByID(Int32.Parse(ss[i]));
                if(car != null)
                {
                    Position pos = Position.Parse(ss[i + 1]);
                    if(pos != null)
                    {
                        if(car.Pos != null)
                        {
                            if(car.PreGPSTime == pos.GpsTime)
                                return;
                            car.PreGPSTime = car.Pos.GpsTime;
                        }
                        car.Pos = pos;
                        SetWatchingCar(car);
                        Log(StrConst.POS_WATCH + car.CarNO);
                    }
                }
            }
        }
        //回复－定位
        private void R_Point(String rec)
        {
            if(rec[0] == Constant.RESULT_OK)
            {
                String[] ss = rec.Substring(1).Split(Constant.SPLIT1);
                if(ss.Length == 2)
                {
                    Car car = user.GetCarByID(Int32.Parse(ss[0]));
                    if(car != null)
                    {
                        if(car.Pos != null)
                            car.PreGPSTime = car.Pos.GpsTime;
                        car.Pos = Position.Parse(ss[1]);
                        SetPointedCar(car);
                        Log(StrConst.POS_POINT_OK + car.CarNO);
                    }
                }
            }
            else
            {
                Car car = user.GetCarByID(Int32.Parse(rec));
                if(car != null)
                    Log(StrConst.POS_POINT_FAIL + car.CarNO);
            }
        }
        //回复-接警
        private void R_HanleAlarm(String rec)
        {
            if(rec.Length == 0)
            {
                Log(StrConst.ALARM_HANDLE_CANCEL);
                return;
            }
            if(rec[0] == Constant.RESULT_OK)
            {
                alarmHandleCar = user.GetCarByID(Int32.Parse(rec.Substring(1)));
                if(Config.AutoWatchOnHandleAlarm && !alarmHandleCar.IsWatched)
                    C_Pos_Watch(alarmHandleCar);
                UpdateAlarmList();
                Log(StrConst.ALARM_HANDLE_OK + alarmHandleCar.CarNO);

                FormHandleAlarm frm = new FormHandleAlarm(this, alarmHandleCar);
                frm.OnShowAlarmPos += new FormHandleAlarm.ShowAlarmPosDelegate(OnShowAlarmPos);
                frm.Show();
            }
            else
            {
                String[] ss = rec.Substring(1).Split(Constant.SPLIT1);
                Car car = user.GetCarByID(Int32.Parse(ss[0]));
                Log(StrConst.ALARM_HANDLE_FAIL + car.CarNO + StrConst.COMMA + ss[1]);
                for(int i = 0; i < alarmList.Count; i++)
                    if(alarmList[i].Car.CarID == car.CarID)
                    {
                        alarmList.RemoveAt(i);
                        i--;
                    }
                UpdateAlarmList();
            }
        }
        //回复-解除报警
        private void R_FreeAlarm(String rec)
        {
            String[] ss = rec.Substring(1).Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(ss[0]));
            if(rec[0] == Constant.RESULT_FAIL)
            {
                Log(StrConst.ALARM_FREE_FAIL + car.CarNO + StrConst.COMMA + ss[1]);
            }
            else
            {
                if(rec[0] == Constant.RESULT_OTHER)
                    Log(StrConst.ALARM_FREE_OTHER + car.CarNO);
                else Log(StrConst.ALARM_FREE_OK + car.CarNO);
                for(int i = 0; i < alarmList.Count; i++)
                    if(alarmList[i].Car.CarID == car.CarID)
                    {
                        alarmList.RemoveAt(i);
                        i--;
                    }
            }
            UpdateAlarmList();
        }
        //回复－取得设置
        private void R_GetSetting(String rec)
        {
            String[] ss = rec.Substring(1).Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(ss[0]));
            if(rec[0] == Constant.RESULT_OK)
            {
                car.SettingStr = rec.Substring(rec.IndexOf(Constant.SPLIT1) + 1);
                Log(StrConst.SET_GET_SET_OK + car.CarNO);
                if(onGetSettingResponse != null)
                    onGetSettingResponse(car);
            }
            else
            {
                car.SettingStr = "";
                Log(StrConst.SET_GET_SET_FAIL + car.CarNO);
                if(onGetSettingResponse != null)
                    onGetSettingResponse(car);
            }
        }
        //回复-历史轨迹
        private void R_HisPos(String rec)
        {
            hisPosList.Clear();
            String[] ss = rec.Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(ss[0]));
            if(car != null)
            {
                hisPosList.Clear();
                for(int i=1; i<ss.Length; i++)
                {
                    Position pos = Position.Parse(ss[i]);
                    if(pos != null)
                    {
                        pos.Car = car;
                        hisPosList.Add(pos);
                    }
                }
                SetHisPosList();
            }
        }
        //回复－历史报警
        private void R_HisAlarm(String rec)
        {
            hisAlarmList.Clear();
            String[] ss = rec.Split(Constant.SPLIT1);
            for(int i = 0; i < ss.Length; i++)
            {
                String[] sss = ss[i].Split(Constant.SPLIT2);
                Car car = user.GetCarByID(Int32.Parse(sss[0]));
                if(car != null)
                {
                    HisAlarmPosition pos = HisAlarmPosition.Parse(ss[i].Substring(sss[0].Length + 1));
                    pos.Car = car;
                    hisAlarmList.Add(pos);
                }
            }
            SetHisAlarmList();
        }
        //回复－里程统计
        private void R_HisMileage(String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(ss[0]));
            car.Mileage = Int32.Parse(ss[1]);
            UpdateMileage(car);
        }
        //回复－区域查车
        private void R_RegionQuery(String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            try
            {
                regionQueryCarList.Cars.Clear();
                dateTimeRegionQuery1 = DateTime.Parse(ss[0]);
                dateTimeRegionQuery2 = DateTime.Parse(ss[1]);
                for(int i = 2; i < ss.Length; i++)
                {
                    if(ss[i] == null || ss[i] == "")
                        continue;
                    Car car = user.GetCarByID(Int32.Parse(ss[i]));
                    if(car != null)
                        regionQueryCarList.Cars.Add(car);
                }
            }
            catch { }
            SetRegionQueryList();
        }
        //回复－标注查询
        private void R_PlaceQuery(String rec)
        {
            placeList.Clear();
            String[] ss = rec.Split(Constant.SPLIT1);
            foreach(String s in ss)
            {
                Place place = Place.Parse(s);
                placeList.Add(place);
            }
            SetPlaceList();
        }
        //回复 － 标注
        private void R_PlaceMark(String rec)
        {
            if(rec[0] == Constant.RESULT_OK)
            {
                textBoxMarkName.Text = "";
                textBoxMarkLo.Text = "";
                textBoxMarkLa.Text = "";
                Log(StrConst.POS_PLACE_MARK_OK);
            }
            else Log(StrConst.POS_PLACE_MARK_FAIL);
        }
        //回复 － 取得帐号列表
        private void R_AccountList(String rec)
        {
            if(rec[0] == Constant.RESULT_OK)
            {
                String[] ss = rec.Substring(1).Split(Constant.SPLIT1);
                accountList.Clear();
                foreach(String s in ss)
                {
                    Account accout = Account.Parse(s);
                    accountList.Add(accout);
                }
                frmAccountList.RefeshList();
                Log(StrConst.INFO_ACCOUNT_LIST_OK);
            }
            else Log(StrConst.INFO_ACCOUNT_LIST_FAIL + rec.Substring(1));
        }
        //回复 - 待处理申报
        private void R_DeclareList(String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            List<Declare> list = new List<Declare>();
            foreach(String s in ss)
            {
                Declare dec = Declare.Parse(s);
                if(dec != null)
                    list.Add(dec);
            }
            FormDeclareList frm = new FormDeclareList(this, list);
            frm.Show(this);
        }
        //回复 - 历史申报记录
        private void R_DeclareListHis(String rec)
        {
            List<Declare> list = new List<Declare>();
            String[] ss = rec.Split(Constant.SPLIT1);
            foreach(String s in ss)
            {
                Declare dec = Declare.Parse(s);
                if(dec != null)
                    list.Add(dec);
            }
            if(list.Count == 0)
                Log(StrConst.QUERY_DECLARE_FAIL);
            else Log(StrConst.QUERY_DECLARE_OK);
            frmDeclareListHis.refreshList(this, list);
            frmDeclareListHis.Show();
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 处理用户界面更新
        //设置登陆状态
        public void SetLoginStatus()
        {
            toolStripStatusLabelLogin.Text = StrConst.STATUS_LOGIN + user.Name;
            listViewWatching.Enabled = true;
            ToolStripMenuItemSystem.Enabled = (user.Type == User.USER_ADMIN || user.Type == User.USER_OP);
            ToolStripMenuItem1ModUserInfo.Enabled = (user.Type == User.USER_ADMIN || user.Type == User.USER_OP);
            ToolStripMenuItem1AccoutList.Enabled = (user.Type == User.USER_ADMIN);
            ToolStripMenuItemQuery.Enabled = true;
            ToolStripMenuItemQueryOperation.Enabled = (user.Type == User.USER_ADMIN || user.Type == User.USER_OP);
            ToolStripMenuItemQueryOperation.Enabled = (user.Type == User.USER_ADMIN || user.Type == User.USER_OP);
            ToolStripMenuItemForm.Enabled = true;
            contextMenuStripWatching.Enabled = true;
            contextMenuStripCars.Enabled = true;
            buttonItemLogin.Enabled = false;

            expandablePanelCarList.Enabled = true;
            expandablePanelHisPos.Enabled = true;
            expandablePanelHisAlarm.Enabled = true;
            expandablePanelMileage.Enabled = true;
            expandablePanelRegionQuery.Enabled = true;
            expandablePanelMarkPlace.Enabled = true;
            expandablePanelQueryPlace.Enabled = true;

            if(Config.AutoStartGis)
            {
                gisServer.Port = Config.GisPort;
                gisServer.Active = true;
            }
            hasLogin = true;
        }
        //设置登出状态
        private void SetLogoutStatus()
        {
            ClearMap();
            hasLogin = false;
            
            gisServer.Active = false;

            frmCarList.Hide();

            accountList.Clear();
            frmAccountList.RefeshList();
            frmAccountList.Hide();

            alarmHandleCar = null;
            alarmList.Clear();
            frmAlarmList.Hide();

            frmOverServiceList.Hide();

            frmHisAlarm.RefreshList();
            frmHisAlarm.Hide();

            frmHisPos.RefreshList();
            frmHisPos.Hide();

            alarmList.Clear();
            timerAlarmSound.Enabled = false;
            toolStripStatusLabelAlarm.Text = "";
            toolStripStatusLabelOverService.Text = "";

            listViewWatching.Items.Clear();
            listViewWatching.Enabled = false;
            ToolStripMenuItem0Login.Enabled = true;
            ToolStripMenuItem0Logout.Enabled = false;
            ToolStripMenuItemSystem.Enabled = false;
            ToolStripMenuItemQuery.Enabled = false;
            ToolStripMenuItemForm.Enabled = false;
            contextMenuStripCars.Enabled = false;
            contextMenuStripWatching.Enabled = false;
            buttonItemLogin.Enabled = true;
            buttonItemLogout.Enabled = false;

            frmChat.Clear();
            frmChat.Hide();

            toolStripStatusLabelLogin.Text = StrConst.STATUS_NOT_LOGIN;
            
            expandablePanelCarList.Enabled = false;
            expandablePanelHisPos.Enabled = false;
            expandablePanelHisAlarm.Enabled = false;
            expandablePanelMileage.Enabled = false;
            expandablePanelRegionQuery.Enabled = false;
            expandablePanelMarkPlace.Enabled = false;
            expandablePanelQueryPlace.Enabled = false;/**/
        }
        //更新车辆、车队信息
        private void UpdateTeamNCar()
        {
            RefreshCarList();
            SetHisAlarmCarList();
            SetHisPosTeamList();
            SetMileageTeamList();
            SetRegionQueryTeamList();
        }
        //更新历史轨迹车队列表
        private void SetHisPosTeamList()
        {
            comboBoxExHisTeam.Items.Clear();
            foreach(Team team in user.TeamList)
                comboBoxExHisTeam.Items.Add(team.TeamName);
            if(comboBoxExHisTeam.Items.Count > 0)
                comboBoxExHisTeam.SelectedIndex = 0;
        }
        //更新历史报警车辆列表
        private void SetHisAlarmCarList()
        {
            treeViewHisAlarm.Nodes.Clear();
            String key = comboBoxExHisAlarmKey.Text.ToLower();
            foreach(Team team in user.TeamList)
            {
                TreeNode tn = new TreeNode(team.TeamName);
                foreach(Car car in team.Cars)
                {
                    if(key != "" && !(car.CarNO.ToLower().IndexOf(key) >= 0 || car.Driver.ToLower().IndexOf(key) >= 0
                                        || car.SimNO.IndexOf(key) >= 0 || car.MachineNO.IndexOf(key) >= 0))
                        continue;
                    TreeNode tn1 = new TreeNode(car.CarNO + "[" + car.Driver + "]");
                    tn1.Tag = car;
                    tn.Nodes.Add(tn1);
                }
                tn.Tag = team;
                treeViewHisAlarm.Nodes.Add(tn);
            }

        }
        //更新里程查询车队列表
        private void SetMileageTeamList()
        {
            comboBoxExMileageTeam.Items.Clear();
            foreach(Team team in user.TeamList)
                comboBoxExMileageTeam.Items.Add(team.TeamName);
            if(comboBoxExMileageTeam.Items.Count > 0)
                comboBoxExMileageTeam.SelectedIndex = 0;
        }
        //更新区域查车车队列表
        private void SetRegionQueryTeamList()
        {
            comboBoxExRegionQueryTeam.Items.Clear();
            comboBoxExRegionQueryTeam.Items.Add("");
            foreach(Team team in user.TeamList)
                comboBoxExRegionQueryTeam.Items.Add(team.TeamName);
            comboBoxExRegionQueryTeam.SelectedIndex = 0;
        }
        //更新监控列表
        public void SetWatchingCar(Car car)
        {
            Color tColor = Color.Black;
            if(car.Pos.Alarm != "")
                tColor = Color.Red;
            if(car.ItemInWatch == null)
            {
                ListViewItem item = new ListViewItem(car.CarNO);
                car.ItemInWatch = item;
                item.Tag = car;
                item.ForeColor = tColor;
                item.SubItems.Add(car.Pos.GpsTime).ForeColor = tColor;
                item.SubItems.Add("-1").ForeColor = tColor;
                item.SubItems.Add(Position.POINTED[car.Pos.Pointed]).ForeColor = tColor;
                item.SubItems.Add(Position.DIR[car.Pos.Direction]).ForeColor = tColor;
                item.SubItems.Add(car.Pos.Speed.ToString()).ForeColor = tColor;
                item.SubItems.Add(car.Pos.Status).ForeColor = tColor;
                item.SubItems.Add(car.Pos.Alarm).ForeColor = tColor;
                if(Config.AutoGetCarGeoInfo)
                    item.SubItems.Add(GetPosInfo(car.Pos.Lo, car.Pos.La)).ForeColor = tColor;
                else item.SubItems.Add("").ForeColor = tColor;
                listViewWatching.Items.Insert(0, item);
            }
            else
            {
                long dt = 0;
                try
                {
                    dt = Pub.DateDiff(DateTime.Parse(car.PreGPSTime), DateTime.Parse(car.Pos.GpsTime));
                }
                catch { }
                if(dt == 0)
                    return;
                car.ItemInWatch.ForeColor = tColor;
                car.ItemInWatch.SubItems[1].Text = car.Pos.GpsTime;
                car.ItemInWatch.SubItems[1].ForeColor = tColor;
                car.ItemInWatch.SubItems[2].Text = dt.ToString();
                car.ItemInWatch.SubItems[2].ForeColor = tColor;
                car.ItemInWatch.SubItems[3].Text = Position.POINTED[car.Pos.Pointed];
                car.ItemInWatch.SubItems[3].ForeColor = tColor;
                car.ItemInWatch.SubItems[4].Text = Position.DIR[car.Pos.Direction];
                car.ItemInWatch.SubItems[4].ForeColor = tColor;
                car.ItemInWatch.SubItems[5].Text = car.Pos.Speed.ToString();
                car.ItemInWatch.SubItems[5].ForeColor = tColor;
                car.ItemInWatch.SubItems[6].Text = car.Pos.Status;
                car.ItemInWatch.SubItems[6].ForeColor = tColor;
                car.ItemInWatch.SubItems[7].Text = car.Pos.Alarm;
                car.ItemInWatch.SubItems[7].ForeColor = tColor;
                if(Config.AutoGetCarGeoInfo)
                    car.ItemInWatch.SubItems[8].Text = GetPosInfo(car.Pos.Lo, car.Pos.La);
                else car.ItemInWatch.SubItems[8].Text = "";/**/
                car.ItemInWatch.SubItems[8].ForeColor = tColor;
            }
            RefreshWatching(car);
        }
        //定位
        private void SetPointedCar(Car car)
        {
            if(car.ItemInWatch != null)
            {
                car.ItemInWatch.SubItems[1].Text = car.Pos.GpsTime;
                long dt = 0;
                try
                {
                    dt = Pub.DateDiff(DateTime.Parse(car.PreGPSTime), DateTime.Parse(car.Pos.GpsTime));
                }
                catch { }
                car.ItemInWatch.SubItems[2].Text = dt.ToString();
                car.ItemInWatch.SubItems[3].Text = Position.POINTED[car.Pos.Pointed];
                car.ItemInWatch.SubItems[4].Text = Position.DIR[car.Pos.Direction];
                car.ItemInWatch.SubItems[5].Text = car.Pos.Speed.ToString();
                car.ItemInWatch.SubItems[6].Text = car.Pos.Status;
                car.ItemInWatch.SubItems[7].Text = car.Pos.Alarm;/**/
            }
            RefreshWatching(car);
            MoveMap(car);
        }
        //更新历史轨迹列表
        private void SetHisPosList()
        {
            listBoxHisPos.Items.Clear();
            ClearHisPosLayer();
            groupBoxHisPlay.Enabled = (hisPosList.Count > 1);
            if(hisPosList.Count > 0)
            {
                foreach(Position pos in hisPosList)
                    listBoxHisPos.Items.Add(pos.Car.CarNO + "[" + pos.GpsTime + "]");
                frmHisPos.RefreshList();
                RefreshHisPos();
                Log(StrConst.POS_HIS_POS_OK);
            }
            else Log(StrConst.POS_HIS_POS_NONE);
        }
        //更新历史报警列表
        private void SetHisAlarmList()
        {
            listBoxHisAlarm.Items.Clear();
            ClearHisAlarmLayer();
            if(hisAlarmList.Count > 0)
            {
                foreach(HisAlarmPosition pos in hisAlarmList)
                    listBoxHisAlarm.Items.Add(pos.Car.CarNO + "[" + pos.GpsTime + "][" + pos.Alarm + "]");
                frmHisAlarm.RefreshList();
                RefreshHisAlarm();
                Log(StrConst.POS_HIS_ALARM_OK);
            }
            else Log(StrConst.POS_HIS_ALARM_NONE);
        }
        //更新标注查询列表
        private void SetPlaceList()
        {
            listBoxPlaces.Items.Clear();
            if(placeList.Count == 0)
                Log(StrConst.POS_PLACE_QUERY_NONE);
            else
            {
                foreach(Place place in placeList)
                    listBoxPlaces.Items.Add(place.Name);
                if(placeList.Count > 0)
                    Log(StrConst.POS_PLACE_QUERY_OK);
                else Log(StrConst.POS_PLACE_QUERY_NONE);
            }
        }
        //更新报警列表
        private void UpdateAlarmList()
        {
            if(user.Type == User.USER_ADMIN || user.Type == User.USER_OP)
            {
                frmAlarmList.RefreshList(alarmList);
                if(alarmList.Count > 0)
                {
                    toolStripStatusLabelAlarm.ForeColor = Color.Red;
                    toolStripStatusLabelAlarm.Text = StrConst.STATUS_HAS_ALARM;
                    if(alarmHandleCar == null)//是否正在接警，如果是，不弹出报警列表和响报警声
                    {
                        if(Config.AutoAlarmList)
                            toolStripStatusLabelAlarm.PerformClick();
                        if(Config.AlarmSound)
                        {
                            PlaySound(Config.APP_PATH + Constant.FILE_SOUND_ALARM);
                            timerAlarmSound.Enabled = true;
                        }
                    }
                }
                else
                {
                    toolStripStatusLabelAlarm.ForeColor = Color.Green;
                    toolStripStatusLabelAlarm.Text = StrConst.STATUS_NO_ALARM;
                    timerAlarmSound.Enabled = false;
                }
            }
        }
        //更新里程统计+油耗计算
        private void UpdateMileage(Car car)
        {
            FormFuel frm = new FormFuel();


            frm.ShowDialog();
           
            double youhao = car.Mileage * user.fuel;

            String[] temp = new String[richTextBoxMileage.Lines.Length + 4];
            richTextBoxMileage.Lines.CopyTo(temp, 0);
            temp.SetValue(car.CarNO, richTextBoxMileage.Lines.Length);
            temp.SetValue("从" + dateTimePickerHisMileage1.Text + "到" + dateTimePickerHisMileage2.Text, richTextBoxMileage.Lines.Length + 1);
            temp.SetValue("共行驶" + car.Mileage.ToString() + "公里" + " " + "预计油耗" + youhao.ToString() + "升", richTextBoxMileage.Lines.Length + 2);
            temp.SetValue("", richTextBoxMileage.Lines.Length + 3);
            richTextBoxMileage.Lines = temp;
            Log(StrConst.POS_MILEAGE_OK + car.CarNO);
            user.fuel = 0.00;

        }
        //更新区域查车列表
        private void SetRegionQueryList()
        {
            listBoxRegionQuery.Items.Clear();
            foreach(Car car in regionQueryCarList.Cars)
                listBoxRegionQuery.Items.Add(car.CarNO);
            if(regionQueryCarList.Cars.Count > 0)
                Log(StrConst.POS_REGION_QUERY_OK);
            else Log(StrConst.POS_REGION_QUERY_NONE);
        }
        //检测是否操作是否显示提示信息
        public static void CheckCarNotify(Car car)
        {
            if(car.Notify == 1)
            {
                try
                {
                    if(DateTime.Parse(car.NotifyStart) <= DateTime.Now && DateTime.Parse(car.NotifyEnd) >= DateTime.Now)
                        MessageBox.Show(car.NotifyText);
                }
                catch { }
            }
        }
        //操作记录
        private void R_OperationHis(String rec)
        {
            frmOperationHis.refreshList(rec);
            frmOperationHis.Show();
            if(rec == "")
                Log(StrConst.QUERY_OPERATION_FAIL);
            else Log(StrConst.QUERY_OPERATION_OK);
        }
        //指令记录
        private void R_OrderHis(String rec)
        {
            frmOrderHis.refreshList(rec);
            frmOrderHis.Show();
            if(rec == "")
                Log(StrConst.QUERY_ORDER_FAIL);
            else Log(StrConst.QUERY_ORDER_OK);
        }
        //公告信息
        private void S_Chat(String rec)
        {
            String[] para = rec.Substring(1).Split(Constant.SPLIT1);
            String s = "";
            if(rec[0] == Constant.C_CHAT_TO_ALL)
                s = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + para[0] + " 对所有人说：" + para[1];
            else if(rec[0] == Constant.C_CHAT_TO_ADMIN)
                s = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + para[0] + " 对所有管理员说：" + para[1];
            else
                s = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]") + para[0] + " 对所有用户说：" + para[1];
            frmChat.AddLine(s);
            if(Config.AutoChatForm)
                frmChat.Show();
            Log(StrConst.CHAT);
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region 处理服务器系统更新信息
        //新车队
        private void S_AddTeam(String rec)
        {
            Team team = Team.Parse(rec);
            user.TeamList.Add(team);
            Log(StrConst.S_INFO_TEAM_ADD + team.TeamName);
            UpdateTeamNCar();
        }
        //更改车队信息
        private void S_ModifyTeam(String rec)
        {
            Team team = Team.Parse(rec);
            user.UpdateTeam(team);
            Log(StrConst.S_INFO_TEAM_MOD + team.TeamName);
            UpdateTeamNCar();
        }
        //删除车队
        private void S_DelTeam(String rec)
        {
            Log(StrConst.S_INFO_TEAM_DEL + user.DeleteTeam(Int32.Parse(rec)));
            UpdateTeamNCar();
        }
        //新车辆
        private void S_AddCar(String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            Team team = user.GetTeamByID(Int32.Parse(ss[0]));
            if(team != null)
            {
                Car car = Car.Parse(ss[1]);
                car.Team = team;
                car.TeamID = team.TeamID;
                team.Cars.Add(car);
                Log(StrConst.S_INFO_CAR_ADD + car.CarNO);
                UpdateTeamNCar();
            }
        }
        //更改车辆信息
        private void S_ModifyCar(String rec)
        {
            Car car = Car.Parse(rec);
            user.UpdateCar(car);
            Log(StrConst.S_INFO_CAR_MOD + car.CarNO);
            UpdateTeamNCar();
        }
        //删除车辆
        private void S_DelCar(String rec)
        {
            Log(StrConst.S_INFO_CAR_DEL + user.DeleteCar(Int32.Parse(rec)));
            UpdateTeamNCar();
        }
        //帐号信息
        private void S_UserInfo(String rec)
        {
            user.TeamList.Clear();

            String[] s = rec.Split(Constant.SPLIT1);
            user.Update(s[0]);
            for(int i = 1; i < s.Length; i++)//车队车辆信息
            {
                String[] ss = s[i].Split(Constant.SPLIT3);
                Team team = Team.Parse(ss[0]);
                if(team != null)
                {
                    user.TeamList.Add(team);
                    for(int j = 1; j < ss.Length; j++)
                    {
                        Car car = Car.Parse(ss[j]);
                        if(car != null)
                        {
                            car.Team = team;
                            car.TeamID = team.TeamID;
                            team.Cars.Add(car);
                        }
                    }
                }
            }
            Log(StrConst.S_INFO_USER_INFO);
            UpdateTeamNCar();
        }
        //新报警
        private void S_Alarm(String rec)
        {
            AlarmPosition apos = AlarmPosition.Parse(rec);
            if(apos != null)
            {
                bool hasIn = false;
                foreach(AlarmPosition pos in alarmList)
                    if(pos.CarID == apos.CarID && pos.GpsTime == apos.GpsTime)//是否已包含在报警列表里面
                    {
                        hasIn = true;
                        break;
                    }
                if(!hasIn)
                {
                    apos.Car = user.GetCarByID(apos.CarID);
                    if(apos.Car != null)
                    {
                        alarmList.Add(apos);
                        Log(StrConst.S_INFO_ALARM + apos.Car.CarNO);
                        try
                        {
                            if(onAlarm != null)
                                onAlarm(apos);
                        }
                        catch { }
                    }
                    else Log(StrConst.S_INFO_ALARM_ERR_CAR_1 + rec + StrConst.S_INFO_ALARM_ERR_CAR_2);
                }
                UpdateAlarmList();
            }
            else Log(StrConst.S_INFO_ALARM_ERR_POS_1 + rec + StrConst.S_INFO_ALARM_ERR_POS_2);
        }
        //报警已解除
        private void S_FreeAlarm(String rec)
        {
            int cid = Int32.Parse(rec);
            for(int i = 0; i < alarmList.Count; i++)
                if(alarmList[i].Car.CarID == cid)
                {
                    alarmList.RemoveAt(i);
                    i--;
                }
            Log(StrConst.S_INFO_FREE_ALARM + user.GetCarByID(cid).CarNO);
            UpdateAlarmList();
        }
        //车辆服务状态设置
        private void S_SetCarStoped(String rec)
        {
            String[] para = rec.Split(Constant.SPLIT1);
            int stp = Int32.Parse(para[1]);
            Car car = user.GetCarByID(Int32.Parse(para[0]));
            if(car.Stoped != stp)
            {
                car.Stoped = stp;
                Log(StrConst.S_INFO_SET_STOPED + car.CarNO);
                UpdateTeamNCar();
            }
        }
        //车辆服务日期设置
        private void S_SetCarServiceTime(String rec)
        {
            String[] para = rec.Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(para[0]));
            car.OverServiceTime = para[1];
            if(para[2] == "1")
                car.Stoped = 0;
            Log(StrConst.S_INFO_SET_SERVICE_TIME + car.CarNO);
            UpdateTeamNCar();
        }
        //车辆操作提示设置
        private void S_SetCarNotify(String rec)
        {
            String[] para = rec.Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(para[0]));
            car.Notify = Int32.Parse(para[1]);
            car.NotifyStart = para[2];
            car.NotifyEnd = para[3];
            car.NotifyText = para[4];
            Log(StrConst.S_INFO_SET_NOTIFY + car.CarNO);
        }
        //新故障、投诉申报
        private void S_DeclareAdd(String rec)
        {
            Car car = user.GetCarByID(Int32.Parse(rec));
            car.DeclareCount++;
            Log(StrConst.S_INFO_DECLARE_ADD + car.CarNO);
            UpdateTeamNCar();
        }
        //故障、投诉申报已处理
        private void S_DeclareDeal(String rec)
        {
            String[] para = rec.Split(Constant.SPLIT1);
            Car car = user.GetCarByID(Int32.Parse(para[0]));
            car.DeclareCount = Int32.Parse(para[1]);
            Log(StrConst.S_INFO_DECLARE_DEAL + car.CarNO);
            UpdateTeamNCar();
        }
        #endregion
    }
}