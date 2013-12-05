using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using MoonStudio.Udp;

namespace YTGPS_Server
{
    //�ֿؿͻ�������
    public class DataClient
    {
        public const int MAX_CONN_COUNT = 120;

        private Socket socket;
        private User user = null;
        private Team team = null;
        private Car car = null;
        private int connCount = 0;
        private String recStr = "";
        private bool hasLogin = false;
        private bool testOk = false;
        private Car handleAlarmCar = null;
        private object syncrecstr = new object();
        public String RecStr
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
        public User LoginUser
        {
            get { return user; }
            set { user = value; }
        }
        public bool TestOk
        {
            get { return testOk; }
            set { testOk = value; }
        }
        public Team LoginTeam
        {
            get { return team; }
            set { team = value; }
        }
        public Car LoginCar
        {
            get { return car; }
            set { car = value; }
        }
        public Socket Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        public int ConnCount
        {
            get { return connCount; }
            set { connCount = value; }
        }
        public bool HasLogin
        {
            get { return hasLogin; }
            set { hasLogin = value; }
        }
        public Car HandleAlarmCar
        {
            get { return handleAlarmCar; }
            set { handleAlarmCar = value; }
        }

        public DataClient(Socket st)
        {
            socket = st;
        }
        //������Ϣ
        public bool Send(String s)
        {
            try
            {
                //Console.WriteLine("send:" + s);
                socket.Send(Encoding.UTF8.GetBytes(s.ToCharArray()));
                return true;
            }
            catch { }
            return false;
        }
        public void CloseConnection()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }catch{}
        }
    }

    public partial class FormMain : Form
    {
        private ServerSocket dataServer = new ServerSocket();
        private List<DataClient> dataClientList = new List<DataClient>();
        /*
         * �ֿط�����
         */
        /*
        private static void AddTextNode(XmlDocument XMLDom, XmlElement node, String name, String text)
        {
            XmlElement e = XMLDom.CreateElement(name);
            e.InnerText = text;
            node.AppendChild(e);
        }

        private static XmlElement AddNode(XmlDocument XMLDom, XmlElement node, String name)
        {
            XmlElement e = XMLDom.CreateElement(name);
            node.AppendChild(e);
            return e;
        }*/
        //������Ϣ
        private bool ClientSend(Socket client, String s)
        {
            if(client != null)
            {
                try
                {
                    //Console.WriteLine("send:" + s);
                    client.Send(Encoding.UTF8.GetBytes(s.ToCharArray()));
                    return true;
                }
                catch{}
            }
            return false;
        }

        private void data_RevMsg(Socket st, String mess)
        {
            try
            {
                //Console.WriteLine("rec:" + mess);

                
                DataClient dataClient = null;
                int index = 0;
                while(index < dataClientList.Count)
                {
                    if(dataClientList[index].Socket == st)
                    {
                        dataClient = dataClientList[index];
                        break;
                    }
                    index++;
                }
                if(dataClient == null)
                    return;
                dataClient.RecStr = dataClient.RecStr + mess;
                while(dataClient.RecStr.IndexOf(Constant.HEAD) == 0
                    && dataClient.RecStr.IndexOf(Constant.FOOT) > Constant.HEAD.Length)
                {
                    String msg = dataClient.RecStr.Substring(Constant.HEAD.Length, dataClient.RecStr.IndexOf(Constant.FOOT) - Constant.HEAD.Length);
                    dataClient.RecStr = dataClient.RecStr.Substring(dataClient.RecStr.IndexOf(Constant.FOOT) + Constant.FOOT.Length);
                    char key1 = msg[0];
                    if(key1 == Constant.C_TEST)
                    {
                        dataClient.ConnCount = 0;
                        C_Conn_Test(dataClient);
                        return;
                    }
                    char key2 = msg[1];
                    String line = msg.Substring(2);
                    if(key1 == Constant.C_CONN)
                    {
                        switch(key2)
                        {
                            case Constant.C_CONN_LOGIN:
                                C_Conn_Login(dataClient, line);
                                break;
                            case Constant.C_CONN_LOGOUT:
                                C_Conn_Logout(dataClient);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_POS)
                    {
                        switch(key2)
                        {
                            case Constant.C_POS_WATCH:
                                C_Pos_Watch(dataClient, line);
                                break;
                            case Constant.C_POS_STOP_WATCH:
                                C_Pos_StopWatch(dataClient, line);
                                break;
                            case Constant.C_POS_POINT:
                                C_Pos_Point(dataClient, line);
                                break;
                            case Constant.C_POS_HIS_POS:
                                C_Pos_HisPos(dataClient, line);
                                break;
                            case Constant.C_POS_HIS_ALARM:
                                C_Pos_HisAlarm(dataClient, line);
                                break;
                            case Constant.C_POS_REGION_QUERY:
                                C_Pos_RegionQuery(dataClient, line);
                                break;
                            case Constant.C_POS_MILEAGE:
                                C_Pos_Mileage(dataClient, line);
                                break;
                            case Constant.C_POS_PLACE_QUERY:
                                C_Pos_PlaceQuery(dataClient, line);
                                break;
                            case Constant.C_POS_PLACE_MARK:
                                C_Pos_PlaceMark(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_INFO)
                    {
                        switch(key2)
                        {
                            case Constant.C_INFO_ACCOUNT_LIST:
                                C_Info_AccountList(dataClient);
                                break;
                            case Constant.C_INFO_ACCOUNT_ADD:
                                C_Info_AddAccount(dataClient, line);
                                break;
                            case Constant.C_INFO_ACCOUNT_MOD:
                                C_Info_ModifyAccount(dataClient, line);
                                break;
                            case Constant.C_INFO_ACCOUNT_DEL:
                                C_Info_DelAccount(dataClient, line);
                                break;
                            case Constant.C_INFO_TEAM_ADD:
                                C_Info_AddTeam(dataClient, line);
                                break;
                            case Constant.C_INFO_TEAM_MOD:
                                C_Info_ModifyTeam(dataClient, line);
                                break;
                            case Constant.C_INFO_TEAM_DEL:
                                C_Info_DelTeam(dataClient, line);
                                break;
                            case Constant.C_INFO_CAR_ADD:
                                C_Info_AddCar(dataClient, line);
                                break;
                            case Constant.C_INFO_CAR_MOD:
                                C_Info_ModifyCar(dataClient, line);
                                break;
                            case Constant.C_INFO_CAR_DEL:
                                C_Info_DelCar(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_SET)
                    {
                        switch(key2)
                        {
                            case Constant.C_SET_GET_SET:
                                C_Set_GetSet(dataClient, line);
                                break;
                            case Constant.C_SET_ORDER:
                                C_Set_Order(dataClient, line);
                                break;
                            case Constant.C_SET_STOPED:
                                C_Set_Stoped(dataClient, line);
                                break;
                            case Constant.C_SET_SERVICE_TIME:
                                C_Set_ServiceTime(dataClient, line);
                                break;
                            case Constant.C_SET_NOTIFY:
                                C_Set_Notify(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_ALARM)
                    {
                        switch(key2)
                        {
                            case Constant.C_ALARM_HANDLE:
                                C_Alarm_Handle(dataClient, line);
                                break;
                            case Constant.C_ALARM_FREE:
                                C_Alarm_Free(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_CHAT)
                    {
                        if(!Config.AllowChat)
                            return;
                        switch(key2)
                        {
                            case Constant.C_CHAT_TO_ALL:
                                C_Chat_ToAll(dataClient, line);
                                break;
                            case Constant.C_CHAT_TO_ADMIN:
                                C_Chat_ToAdmin(dataClient, line);
                                break;
                            case Constant.C_CHAT_TO_USER:
                                C_Chat_ToUser(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_QUERY)
                    {
                        switch(key2)
                        {
                            case Constant.C_QUERY_OPERATION:
                                C_Query_Operation(dataClient, line);
                                break;
                            case Constant.C_QUERY_ORDER:
                                C_Query_Order(dataClient, line);
                                break;
                            case Constant.C_QUERY_DECLARE:
                                C_Query_Declare(dataClient, line);
                                break;
                        }
                    }
                    else if(key1 == Constant.C_DECLARE)
                    {
                        switch(key2)
                        {
                            case Constant.C_DECLARE_NEW:
                                C_Declare_New(dataClient, line);
                                break;
                            case Constant.C_DECLARE_LIST:
                                C_Declare_List(dataClient, line);
                                break;
                            case Constant.C_DECLARE_HIS_CONTENT:
                                C_Declare_HisContent(dataClient, line);
                                break;
                            case Constant.C_DECLARE_DEAL:
                                C_Declare_Deal(dataClient, line);
                                break;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }

        /************************************�ظ��ͻ���**********************************/
        /*
        private static XmlDocument NewXml()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><root></root>");
            return xml;
        }*/
        #region ������
        //�ظ��������
        private void C_Conn_Test(DataClient dataClient)
        {
            //dataClient.Send(Constant.CONN_TEST);
            if(dataClient.HasLogin && !dataClient.TestOk)
                dataClient.TestOk = true;
        }
        //�ظ���½
        private void C_Conn_Login(DataClient dataClient, String rec)
        {
            try
            {
                char result = Constant.RESULT_FAIL;
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_CONN).Append(Constant.C_CONN_LOGIN);
                StringBuilder stb2 = new StringBuilder();
                List<AlarmPosition> aList = new List<AlarmPosition>();
                String[] para = rec.Split(Constant.SPLIT1);
                int type = Int32.Parse(para[0]);
                if(type == User.USER_ADMIN || type == User.USER_OP)
                {
                    User user = GetUserByName(para[1]);
                    if(user != null && user.Password == para[2])
                    {
                        result = Constant.RESULT_OTHER;
                        if(!user.HasLogin)//����Ƿ��ѵ�½
                        {
                            user.HasLogin = true;

                            stb2.Append(user.ToString()).Append(Constant.SPLIT1);
                            foreach(Team team in user.Teams)
                            {
                                stb2.Append(team.ToString()).Append(Constant.SPLIT3);
                                foreach(Car car in team.Cars)
                                {
                                    stb2.Append(car.ToString()).Append(Constant.SPLIT3);
                                    if(car.HandleAlarmClient == null && user.PolicyAlarmList == 1)
                                    {
                                        foreach(AlarmPosition apos in car.AlarmPos)
                                        {
                                            aList.Add(apos);
                                        }
                                    }
                                }
                                stb2.Remove(stb2.Length-1, 1);
                                stb2.Append(Constant.SPLIT1);
                            }
                            dataClient.LoginUser = user;
                            result = Constant.RESULT_OK;
                        }
                    }
                }
                else if(type == User.USER_TEAM)
                {
                    Team team = null;
                    //����ID���߳�����
                    try
                    {
                        team = GetTeamByID(Int32.Parse(para[1]));
                    }
                    catch
                    {
                        team = GetTeamByName(para[1]);
                    }
                    if(team != null && team.Password == para[2])
                    {
                        result = Constant.RESULT_OTHER;
                        if(!team.HasLogin)
                        {
                            team.HasLogin = true;

                            stb2.Append(team.ToString()).Append(Constant.SPLIT3);
                            foreach(Car car in team.Cars)
                                stb2.Append(car.ToString()).Append(Constant.SPLIT3);
                            stb2.Remove(stb2.Length - 1, 1);
                            stb2.Append(Constant.SPLIT1);
                            dataClient.LoginTeam = team;
                            result = Constant.RESULT_OK;
                        }
                    }
                }
                else
                {
                    Car car = null;
                    try
                    {
                        car = GetCarByID(Int32.Parse(para[1]));
                    }
                    catch
                    {
                        car = GetCarByNO(para[1]);
                    }
                    if(car != null && car.Password == para[2])
                    {
                        result = Constant.RESULT_OTHER;
                        if(!car.HasLogin)
                        {
                            car.HasLogin = true;

                            stb2.Append(car.Team.ToString()).Append(Constant.SPLIT3);
                            stb2.Append(car.ToString()).Append(Constant.SPLIT1);
                            dataClient.LoginCar = car;
                            result = Constant.RESULT_OK;
                        }
                    }
                }
                //ָ��ͨ��
                stb2.Append("GPRS(TCP)").Append(Constant.SPLIT2).Append("GPRS(UDP)").Append(Constant.SPLIT2).Append("����Modem");
                foreach(SmsConfig smsconfig in Config.SmsList)
                    stb2.Append(Constant.SPLIT2).Append(smsconfig.SmsName);
                stb.Append(result);
                if(result == Constant.RESULT_OK)
                {
                    stb.Append(stb2.ToString());
                    dataClient.HasLogin = true;
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
                if(result == Constant.RESULT_OK && aList.Count > 0)
                {
                    String stba = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_ALARM).ToString();
                    foreach(AlarmPosition apos in aList)
                    {
                        dataClient.Send(stba + apos.ToString() + Constant.FOOT);
                    }
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��ǳ�
        private void C_Conn_Logout(DataClient dataClient)
        {
            dataServer.CloseConnection(dataClient.Socket);
        }
        #endregion

        #region λ����Ϣ��
        //�ظ����
        private void C_Pos_Watch(DataClient dataClient, String rec)
        {
            try
            {
                int count  = 0;
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_WATCH);
                int id = Int32.Parse(rec);
                if(id >= 100000)//����
                {
                    Car car = GetCarByID(id);
                    if(car != null && car.WatchSockets.IndexOf(dataClient.Socket) < 0)
                    {
                        car.WatchSockets.Add(dataClient.Socket);
                        stb.Append(car.CarID).Append(Constant.SPLIT1).Append(car.Pos.ToString()).Append(Constant.FOOT);
                        count++;
                    }
                }
                else//����
                {
                    Team team = GetTeamByID(id);
                    if(team != null)
                    {
                        foreach(Car car in team.Cars)
                        {
                            if(car.WatchSockets.IndexOf(dataClient.Socket) < 0)
                            {
                                car.WatchSockets.Add(dataClient.Socket);
                                stb.Append(car.CarID).Append(Constant.SPLIT1).Append(car.Pos.ToString()).Append(Constant.SPLIT1);
                                count++;
                            }
                        }
                        if(count > 0)
                            stb.Remove(stb.Length - 1, 1).Append(Constant.FOOT);
                    }
                }
                if(count > 0)
                    dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�������
        private void C_Pos_StopWatch(DataClient dataClient, String rec)
        {
            try
            {
                if(rec == "")//������м��
                {
                    foreach(Team team in teamList)
                        foreach(Car car in team.Cars)
                            car.WatchSockets.Remove(dataClient.Socket);
                }
                else
                {
                    int id = Int32.Parse(rec);
                    if(id >= 100000)//����
                    {
                        Car car = GetCarByID(id);
                        if(car != null)
                            car.WatchSockets.Remove(dataClient.Socket);
                    }
                    else//����
                    {
                        Team team = GetTeamByID(id);
                        if(team != null)
                            foreach(Car car in team.Cars)
                                car.WatchSockets.Remove(dataClient.Socket);
                    }
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���λ
        private void C_Pos_Point(DataClient dataClient, String rec)
        {
            try
            {
                String order = "";
                Car car = GetCarByID(Int32.Parse(rec));
                bool suc = false;
                if(car.Protocol == Constant.PROTOCOL_QICHUAN)
                {
                    order = Protocol_QiChuan.CreatePointOrder(false, car.MachineNO);
                    if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                    {
                        if(SendSmsToModem(car.SimNO, order))
                            suc = true;
                    }
                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if(car.Protocol == Constant.PROTOCOL_TIANHE)
                {
                    order = Protocol_TianHe.CreatePointOrder(false, car.MachineNO);
                    if(car.Routeway == Constant.ROUTE_WAY_TCP)
                    {
                        if(car.GprsConn != null && car.GprsConn.Send(order))
                            
                            suc = true;
                    }
                    else if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                    {
                        if(SendSmsToModem(car.SimNO, order))
                            suc = true;
                    }
                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if(car.Protocol == Constant.PROTOCOL_DASANTONG)
                {
                    order = Protocol_DaSanTong.CreatePointOrder(false, car.MachineNO);
                    if(car.Routeway == Constant.ROUTE_WAY_TCP)
                    {
                        if(car.GprsConn != null && car.GprsConn.Send(order))
                            suc = true;
                    }
                    else if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                    {
                        if(SendSmsToModem(car.SimNO, order))
                            suc = true;
                    }
                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if (car.Protocol == Constant.PROTOCOL_VicZone)
                {
                    order = Protocol_DaSanTong.CreatePointOrder(false, car.MachineNO);
                    if (car.Routeway == Constant.ROUTE_WAY_TCP)
                    {
                    
                           suc = true;
                    }
                    else if (car.Routeway == Constant.ROUTE_WAY_MODEM)
                    {
                        if (SendSmsToModem(car.SimNO, order))
                            suc = true;
                    }
                    else if (car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if (SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if (car.Protocol == Constant.PROTOCOL_XUNLUOSHU)
                {
                    order = Protocol_XunLuoShu.CreatePointOrder(false, car.MachineNO);
                    if (car.Routeway == Constant.ROUTE_WAY_UDP)
                    {
                        int port=0;

                        string IP=""; 

                        DBManager dbms = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                        DataTable dt = dbms.ExecuteQuery("select_Terminal " + "'" +car.MachineNO+ "'");
                           
                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }


                        udpConnection.Send(IP, port, order);

                        dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }
                        udpConnection.Send(IP, port, order);

                      
                      dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }
                        udpConnection.Send(IP, port, order);

                        
                        
                        dbms.Close();


                      //   suc = true;
                    }

                
                }

                if(suc)
                {
                    
                    if(car.PointSockets.IndexOf(dataClient.Socket) < 0)
                        car.PointSockets.Add(dataClient.Socket);
                }
                else
                {
                    if (car.Protocol != Constant.PROTOCOL_XUNLUOSHU||car.Protocol != Constant.PROTOCOL_VicZone)
                    {
                 StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_POINT).Append(Constant.RESULT_FAIL).Append(rec).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                    }

                    }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���ʷ�켣
        private void C_Pos_HisPos(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_HIS_POS);
                String[] para = rec.Split(Constant.SPLIT1);
                stb.Append(para[0]).Append(Constant.SPLIT1);
                DataTable dt = dbm.ExecuteQuery("select_his_pos " + para[0] + ",'" + para[1] + "','" + para[2] + "'");
                if(dt != null && dt.Rows.Count > 0)
                {
                    Position pos = new Position();
                    foreach(DataRow dr in dt.Rows)
                    {
                        for(int i = 0; i < 9; i++)
                            stb.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                        stb.Append(Constant.SPLIT1);
                    }
                    stb.Remove(stb.Length - 1, 1);
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���ʷ����
        private void C_Pos_HisAlarm(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_HIS_ALARM);
                String[] para = rec.Split(Constant.SPLIT1);
                String[] ids = para[0].Split(Constant.SPLIT2);
                StringBuilder sql = new StringBuilder("SELECT top 1000 carID,gpsTime,pointed,lo,la,speed,direction,status,alarm,remark,alarmHandle from tPosition where alarmHandle<>0 and gpsTime >= '");
                sql.Append(para[1]).Append("' and gpsTime <= '").Append(para[2]).Append("' and (carID=");
                foreach(String id in ids)
                    sql.Append(id).Append(" or carID=");
                sql.Remove(sql.Length - 10, 10).Append(")");
                DataTable dt = dbm.ExecuteQuery(sql.ToString());
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        for(int i = 0; i < 11; i++)
                            stb.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                        stb.Remove(stb.Length - 1, 1).Append(Constant.SPLIT1);
                    }
                    stb.Remove(stb.Length - 1, 1);
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�����鳵 ///////////////////////////////////////////
        private void C_Pos_RegionQuery(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_REGION_QUERY);
                String[] ss = rec.Split(Constant.SPLIT1);
                StringBuilder stbSql = new StringBuilder("select carID,lo,la from vPosition where gpsTime>='");
                stbSql.Append(ss[1]).Append("' and gpsTime<='").Append(ss[2]).Append("' ");
                if(ss[0] != "")
                    stbSql.Append("and teamID=").Append(ss[0]);
                DataTable dt = dbm.ExecuteQuery(stbSql.ToString());
                if(dt != null && dt.Rows.Count > 0)
                {
                    String cids = "";
                    Region region = new Region(ss[3]);
                    stb.Append(ss[1]).Append(Constant.SPLIT1).Append(ss[2]).Append(Constant.SPLIT1);
                    foreach(DataRow dr in dt.Rows)
                    {
                        String cid = dr[0].ToString();
                        if(cids.IndexOf(cid) >= 0)
                            continue;
                        else if(region.InRegion(new DPoint(Double.Parse(dr[1].ToString()), Double.Parse(dr[2].ToString()))))
                            cids = cids + cid + Constant.SPLIT1;
                    }
                    stb.Append(cids.Substring(0, cids.Length - 1));
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ����ͳ��
        private void C_Pos_Mileage(DataClient dataClient, String rec)
        {  // ĿǰӲ���޼�¼������롣select_mileageAʹ�����ݿ�洢�ṹ���м��㷵�ؽ��
          

            try
            {
                String[] para = rec.Split(Constant.SPLIT1);
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_MILEAGE);
                String cid = para[0];
                String m = "0";
                bool check = false;

                DataTable dc = dbm.ExecuteQuery("select_mileage " + para[0] + ",'" + para[1] + "','" + para[2] + "'");

                if (dc != null && dc.Rows.Count > 0)
                    m = dc.Rows[0][0].ToString();
               
                 if (m == ""||m=="0")
                {
                    DataTable dt = dbm.ExecuteQuery("select_mileageA " + para[0] + ",'" + para[1] + "','" + para[2] + "'");

                    foreach (DataRow dr in dt.Rows)
                    {
                        float getvalue = float.Parse(dr[0].ToString());



                        int s = (int)getvalue;

                        m = s.ToString();
                        check = true;


                    }

                   
                    
                     
                }

 stb.Append(para[0]).Append(Constant.SPLIT1).Append(m).Append(Constant.FOOT);
                
                 dataClient.Send(stb.ToString());
                 if (check)
                 {
                     dbm.ExecuteQuery("delete from temp;");
                     dbm.ExecuteQuery("delete from mileage;");
                     dbm.ExecuteQuery("delete from mileage_com;");
                 }

            
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���ע��ѯ
        private void C_Pos_PlaceQuery(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_PLACE_QUERY);
                DataTable dt = dbm.ExecuteQuery("select_palce " + rec);
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                        stb.Append(dr[0].ToString()).Append(Constant.SPLIT2).Append(dr[1].ToString()).Append(Constant.SPLIT2).Append(dr[2].ToString()).Append(Constant.SPLIT1);
                    stb.Remove(stb.Length - 1, 1);
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���ע
        private void C_Pos_PlaceMark(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_PLACE_MARK);
                String[] para = rec.Split(Constant.SPLIT1);
                if(dbm.ExecuteUpdate("insert_place '" + para[0] + "','" + para[1] + "','" + para[2] + "'"))
                    stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                else stb.Append(Constant.RESULT_FAIL).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
                String us = "";
                if(dataClient.LoginUser != null)
                    us = dataClient.LoginUser.UserName;
                else if(dataClient.LoginTeam != null)
                    us = dataClient.LoginTeam.TeamName;
                else if(dataClient.LoginCar != null)
                    us = dataClient.LoginCar.CarNO;
                dbAssistant.AddOperation(us, "��ӱ�ע:���� " + para[0]);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion

        #region ������Ϣ��
        //�ظ���ӳ���
        private void C_Info_AddTeam(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_TEAM_ADD);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyModTeam == 1)
                {
                    Team team = Team.Parse(rec);
                    if(team == null)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        return;
                    }
                    if(GetTeamByName(team.TeamName) == null)
                    {
                        DataTable dt = dbm.ExecuteQuery(team.SqlInsertStr());
                        if(dt != null)
                        {
                            team.TeamID = Int32.Parse(dt.Rows[0][0].ToString());
                            team.JoinTime = Pub.DateTimeStr;
                            teamList.Add(team);
                            stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                            dataClient.Send(stb.ToString());
                            StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_TEAM_ADD);
                            stb1.Append(team.ToString()).Append(Constant.FOOT);
                            String s1 = stb1.ToString();
                            if(dataClient.LoginUser.UserType == User.USER_OP)//����Ƿֿؿͻ���,����ӹ���Ȩ��
                            {
                                dataClient.LoginUser.TeamStr = dataClient.LoginUser.TeamStr + Constant.SPLIT3 + team.TeamID.ToString();
                                dataClient.LoginUser.Teams.Add(team);
                                dbm.ExecuteUpdate(dataClient.LoginUser.SqlUpdateStr());
                                dataClient.Send(s1);
                            }
                            //֪ͨ����ϵͳ����Ա
                            DataClient[] tempList = dataClientList.ToArray();
                            foreach(DataClient dc in tempList)
                                if(dc.LoginUser != null && dc.LoginUser.UserType == User.USER_ADMIN)
                                    dc.Send(s1);
                            dbAssistant.AddOperation(dataClient.LoginUser.UserName, "��ӳ���:���Ӻ�" + team.TeamName);
                            return;
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ECHO_INFO).Append(":������").Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��޸ĳ�����Ϣ
        private void C_Info_ModifyTeam(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_TEAM_MOD);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyModTeam == 1)
                {
                    Team team = Team.Parse(rec);
                    if(team == null)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        return;
                    }
                    if(dbm.ExecuteUpdate(team.SqlUpdateStr()))
                    {
                        GetTeamByID(team.TeamID).Clone(team);
                        stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());

                        StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_TEAM_MOD);
                        stb1.Append(team.ToString()).Append(Constant.FOOT);
                        String s1 = stb1.ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(team.TeamID) != null)
                                || (dc.LoginTeam != null && dc.LoginTeam.TeamID == team.TeamID)
                                || (dc.LoginCar != null && dc.LoginCar.TeamID == team.TeamID))
                                dc.Send(s1);
                        }
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "�޸ĳ�����Ϣ:���Ӻ�" + team.TeamName);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�ɾ������
        private void C_Info_DelTeam(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_TEAM_DEL);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyModTeam == 1)
                {
                    Team team = GetTeamByID(Int32.Parse(rec));
                    if(team != null && dbm.ExecuteUpdate(team.SqlDeleteStr()))
                    {
                        //stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        //dataClient.Send(stb.ToString());

                        StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_TEAM_DEL);
                        stb1.Append(team.TeamID).Append(Constant.FOOT);
                        String s1 = stb1.ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if(dc.LoginTeam == team || (dc.LoginCar != null && dc.LoginCar.TeamID == team.TeamID))//�Ͽ���ɾ�������û�
                                dc.CloseConnection();
                            else if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(team.TeamID) != null)
                                dc.Send(s1);
                        }
                        teamList.Remove(team);
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "ɾ������:���Ӻ�" + team.TeamName);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ���ӳ���
        private void C_Info_AddCar(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_CAR_ADD);
                if((dataClient.LoginUser != null && dataClient.LoginUser.PolicyModCar == 1) || (dataClient.LoginTeam != null && dataClient.LoginTeam.PolicyModCar == 1))
                {
                    String[] para = rec.Split(Constant.SPLIT1);
                    Team team = GetTeamByID(Int32.Parse(para[0]));
                    Car car = Car.Parse(para[1]);
                    car.TeamID = team.TeamID;
                    car.Team = team;
                    if(car == null)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        return;
                    }
                    Car car1 = CheckCarInfo(car);
                    if(car1 == null)
                    {
                        DataTable dt = dbm.ExecuteQuery(car.SqlInsertStr(team.TeamID));
                        if(dt != null)
                        {
                            car.CarID = Int32.Parse(dt.Rows[0][0].ToString());
                            car.Pos = new Position();
                            team.Cars.Add(car);

                            stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                            dataClient.Send(stb.ToString());

                            StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_CAR_ADD);
                            stb1.Append(team.TeamID).Append(Constant.SPLIT1).Append(car.ToString()).Append(Constant.FOOT);
                            String s1 = stb1.ToString();
                            DataClient[] tempList = dataClientList.ToArray();
                            foreach(DataClient dc in tempList)
                            {
                                if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(team.TeamID) != null)
                                    || (dc.LoginTeam != null && dc.LoginTeam.TeamID == team.TeamID))
                                    dc.Send(s1);
                            }
                            String opUser = "";
                            if(dataClient.LoginUser != null)
                                opUser = "[����Ա]" + dataClient.LoginUser.UserName;
                            else opUser = "[�����û�]" + dataClient.LoginTeam.TeamName;
                            dbAssistant.AddOperation(opUser, "��ӳ���:���ƺ�" + car.CarNO);
                            return;
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ECHO_INFO).Append(",�ѵǼǴ����ϵĳ���:").Append(car1.CarNO).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��޸ĳ���
        private void C_Info_ModifyCar(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_CAR_MOD);
                if((dataClient.LoginUser != null && dataClient.LoginUser.PolicyModCar == 1) || (dataClient.LoginTeam != null && dataClient.LoginTeam.PolicyModCar == 1))
                {
                    Car car = Car.Parse(rec);
                    if(car == null)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        return;
                    }
                    Car car1 = CheckCarInfo(car);
                    if(car1 == null)
                    {
                        if(dbm.ExecuteUpdate(car.SqlUpdateStr()))
                        {
                            Car car2 = GetCarByID(car.CarID);
                            int tid = car2.TeamID;
                            car2.Clone(car);
                            car2.TeamID = tid;
                            stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                            dataClient.Send(stb.ToString());

                            StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_CAR_MOD);
                            stb1.Append(car2.ToString()).Append(Constant.FOOT);
                            String s1 = stb1.ToString();
                            DataClient[] tempList = dataClientList.ToArray();
                            foreach(DataClient dc in tempList)
                            {
                                if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car2.TeamID) != null)
                                    || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car2.TeamID)
                                    || (dc.LoginCar != null && dc.LoginCar.CarID == car2.CarID))
                                {
                                    dc.Send(s1);
                                }
                            }
                            String opUser = "";
                            if(dataClient.LoginUser != null)
                                opUser = "[����Ա]" + dataClient.LoginUser.UserName;
                            else opUser = "[�����û�]" + dataClient.LoginTeam.TeamName;
                            dbAssistant.AddOperation(opUser, "�޸ĳ�����Ϣ:���ƺ�" + car2.CarNO);
                            return;
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ECHO_INFO).Append(",�ѵǼǴ����ϵĳ���").Append(car1.CarNO).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�ɾ������
        private void C_Info_DelCar(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_CAR_DEL);
                if((dataClient.LoginUser != null && dataClient.LoginUser.PolicyModCar == 1) || (dataClient.LoginTeam != null && dataClient.LoginTeam.PolicyModCar == 1))
                {
                    Car car = GetCarByID(Int32.Parse(rec));
                    if(car != null && dbm.ExecuteUpdate(car.SqlDeleteStr()))
                    {
                        //stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        //dataClient.Send(stb.ToString());

                        StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_CAR_DEL);
                        stb1.Append(car.CarID).Append(Constant.FOOT);
                        String s1 = stb1.ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if(dc.LoginCar == car)
                                dc.CloseConnection();
                            else if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null
                                || dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                dc.Send(s1);
                        }
                        if(car.GprsConn != null)//�ر�GPRS����
                            car.GprsConn.CloseConnection();
                        car.Team.Cars.Remove(car);
                        String opUser = "";
                        if(dataClient.LoginUser != null)
                            opUser = "[����Ա]" + dataClient.LoginUser.UserName;
                        else opUser = "[�����û�]" + dataClient.LoginTeam.TeamName;
                        dbAssistant.AddOperation(opUser, "ɾ������:���ƺ�" + car.CarNO);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��ʺ��б�
        private void C_Info_AccountList(DataClient dataClient)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_ACCOUNT_LIST);
                if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_ADMIN)
                {
                    stb.Append(Constant.RESULT_OK);
                    foreach(User user in userList)
                        stb.Append(user.ToString()).Append(Constant.SPLIT1);
                    stb.Remove(stb.Length - 1, 1).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�����ʺ�
        private void C_Info_AddAccount(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_ACCOUNT_ADD);
                if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_ADMIN)
                {
                    User user = User.Parse(rec);
                    if(user == null)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        return;
                    }
                    if(user.UserName != "" && user.Password != "" && GetUserByName(user.UserName) == null)
                    {
                        DataTable dt = dbm.ExecuteQuery(user.SqlInsertStr());
                        if(dt != null)
                        {
                            user.UserID = Int32.Parse(dt.Rows[0][0].ToString());
                            user.JoinTime = Pub.DateTimeStr;
                            if(user.UserType == User.USER_ADMIN)
                                user.Teams = teamList;
                            else
                            {
                                String[] temp = user.TeamStr.Split(Constant.SPLIT_EX_1);
                                foreach(String s in temp)
                                {
                                    try
                                    {
                                        Team team = GetTeamByID(Int32.Parse(s));
                                        if(team != null)
                                            user.Teams.Add(team);
                                    }
                                    catch { }
                                }
                            }
                            userList.Add(user);
                            stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                            dbAssistant.AddOperation(dataClient.LoginUser.UserName, "����ʺ�:�û���" + user.UserName);
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ECHO_INFO).Append(":�û���").Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��޸��ʺ�
        private void C_Info_ModifyAccount(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_ACCOUNT_MOD);
                User user1 = User.Parse(rec);
                if(user1 == null)
                {
                    stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO).Append(Constant.FOOT);
                    dataClient.Send(stb.ToString());
                    return;
                }
                if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_ADMIN || dataClient.LoginUser.UserID == user1.UserID)
                {
                    if(dbm.ExecuteUpdate(user1.SqlUpdateStr()))
                    {
                        User user = GetUserByID(user1.UserID);
                        user.Clone(user1);
                        if(user.UserType != User.USER_ADMIN)
                        {
                            String[] temp = user.TeamStr.Split(Constant.SPLIT_EX_1);
                            user.Teams.Clear();
                            foreach(String s in temp)
                            {
                                try
                                {
                                    Team team = GetTeamByID(Int32.Parse(s));
                                    if(team != null)
                                        user.Teams.Add(team);
                                }
                                catch { }
                            }
                        }
                        else user.Teams = teamList;

                        stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());

                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if(dc.LoginUser == user)//֪ͨ�������û�������Ϣ
                            {
                                StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_USER_INFO);

                                stb1.Append(user.ToString()).Append(Constant.SPLIT1);
                                foreach(Team team in user.Teams)
                                {
                                    stb1.Append(team.ToString()).Append(Constant.SPLIT3);
                                    foreach(Car car in team.Cars)
                                        stb1.Append(car.ToString()).Append(Constant.SPLIT3);
                                    stb1.Remove(stb1.Length - 1, 1);
                                    stb1.Append(Constant.SPLIT1);
                                }
                                stb1.Remove(stb1.Length - 1, 1).Append(Constant.FOOT);
                                dc.Send(stb1.ToString());
                                break;
                            }
                        }
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "�޸��ʺ���Ϣ:�û���" + user.UserName);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ�ɾ���ʺ�
        private void C_Info_DelAccount(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_INFO).Append(Constant.C_INFO_ACCOUNT_DEL);
                if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_ADMIN)
                {
                    User user = GetUserByID(Int32.Parse(rec));
                    if(user != null && dbm.ExecuteUpdate(user.SqlDeleteStr()))
                    {
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                            if(dc.LoginUser == user)
                            {
                                dc.CloseConnection();
                                break;
                            }
                        userList.Remove(user);
                        stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "ɾ���ʺ�:�û���" + user.UserName);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion

        #region ������
        //�ظ�ȡ���ն�����
        private void C_Set_GetSet(DataClient dataClient, String rec)
        {
            try
            {
                String[] ss = rec.Split(Constant.SPLIT1);
                Car car = GetCarByID(Int32.Parse(ss[0]));
                bool suc = false;
                if(car.Protocol == Constant.PROTOCOL_QICHUAN)
                {
                    String order = Protocol_QiChuan.CreateGetSettingOrder(false, car.MachineNO);
                    if(car.Routeway == Constant.ROUTE_WAY_TCP)
                    {
                    }
                    else if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                    {
                        if(SendSmsToModem(car.SimNO, order))
                            suc = true;
                    }
                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if(car.Protocol == Constant.PROTOCOL_TIANHE)
                {
                    String order = Protocol_TianHe.CreateGetSettingOrder(false, car.MachineNO);
                    if(car.Routeway == Constant.ROUTE_WAY_TCP)
                    {
                        if(car.GprsConn != null && car.GprsConn.Send(order))
                            suc = true;
                    }
                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                    {
                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                            suc = true;
                    }
                }
                else if (car.Protocol == Constant.PROTOCOL_XUNLUOSHU)
                {
                    String order = Protocol_XunLuoShu.CreateGetSettingOrder(false, car.MachineNO);
                    if (car.Routeway == Constant.ROUTE_WAY_UDP)
                    {
                        int port = 0;

                        string IP = "";

                        DBManager dbms = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                        DataTable dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");

                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }


                        udpConnection.Send(IP, port, order);
                        dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }


                        udpConnection.Send(IP, port, order);

                        dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                        foreach (DataRow dr in dt.Rows)
                        {

                            IP = dr[1].ToString();
                            port = Int32.Parse(dr[2].ToString());

                        }


                        udpConnection.Send(IP, port, order);

                        dbms.Close();

                            //suc = true;

                    }
                    // ��Ӳ��Ŀǰ������ģʽ����

                   }

                if(suc)
                {
                    if(car.GetSetSockets.IndexOf(dataClient.Socket) < 0)
                        car.GetSetSockets.Add(dataClient.Socket);
                    //dbAssistant.AddOperation(dataClient.LoginUser.UserName, "��ȡ�ն�����:���ƺ�" + car.CarNO);
                }
                else
                {
                    if (car.Protocol != Constant.PROTOCOL_XUNLUOSHU)
                    {
                        StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_GET_SET).Append(Constant.RESULT_FAIL).Append(ss[0]).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                    }

                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��·�ָ��
        private void C_Set_Order(DataClient dataClient, String rec)
        {


            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_ORDER);
                int maxCount = 1, smsCount = 0, gprsCount = 0, modemCount = 0;
                String sucNO = "", failNo = "", order = "", remark = "";
                if((dataClient.LoginUser != null && (dataClient.LoginUser.UserType == User.USER_ADMIN || dataClient.LoginUser.PolicyOrder == 1))
                    || (dataClient.LoginTeam != null && dataClient.LoginTeam.PolicyOrder == 1))
                {
                    String[] para = rec.Split(Constant.SPLIT1);
                    if(para.Length == 4)
                    {
                        String[] cids = para[1].Split(Constant.SPLIT_EX_2);
                        maxCount = cids.Length;
                        if(para[0] == Constant.PROTOCOL_QICHUAN.ToString())//GPRSЭ��1Э��
                        {
                            foreach(String cid in cids)
                            {
                                try
                                {
                                    Car car = GetCarByID(Int32.Parse(cid));
                                    if(car.Routeway == Constant.ROUTE_WAY_TCP)
                                    {
                                        failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                        continue;
                                    }
                                    order = Protocol_QiChuan.CreateSMSOrder(car.MachineNO, para[2][0], para[3], out remark);
                                    //Console.WriteLine(remark + ":" + order);
                                    if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                                    {
                                        if(SendSmsToModem(car.SimNO, order))
                                        {
                                            modemCount++;
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                    }
                                    else if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                                    {
                                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                                        {
                                            smsCount++;
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                    }
                                    else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                }
                                catch { }
                            }
                        }
                        else if (para[0] == Constant.PROTOCOL_TIANHE.ToString())//GPRSЭ��2Э��
                        {
                            foreach (String cid in cids)
                            {
                                try
                                {
                                    Car car = GetCarByID(Int32.Parse(cid));
                                    remark = para[3];
                                    if (car.Routeway == Constant.ROUTE_WAY_TCP)
                                    {
                                        if (car.GprsConn == null)
                                        {
                                            failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                            continue;
                                        }
                                        order = Protocol_TianHe.BuildOrder(car.MachineNO, para[2]);
                                        if (order != "" && car.GprsConn.Send(order))
                                        {
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                            gprsCount++;
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                    }
                                    else if (car.Routeway == Constant.ROUTE_WAY_MODEM)
                                    {
                                        if (SendSmsToModem(car.SimNO, order))
                                        {
                                            modemCount++;
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                    }
                                    else
                                    {
                                        order = Protocol_TianHe.BuildOrder(car.MachineNO, para[2]);
                                        if (SendSms(car.Routeway - 2, car.SimNO, order))
                                        {
                                            smsCount++;
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                    }
                                }
                                catch { }
                            }

                        }
                        else if (para[0] == Constant.PROTOCOL_XUNLUOSHU.ToString())//GPRSЭ��4Э��
                        {
                            foreach (String cid in cids)
                            {
                                try
                                {
                                    Car car = GetCarByID(Int32.Parse(cid));
                                    if (car.Routeway == Constant.ROUTE_WAY_UDP)
                                    {


                                        order = Protocol_XunLuoShu.CreateGPRSOrder(car.MachineNO, para[2][0], para[3], out remark);
                                        if (order != "")
                                        {
                                            int port = 0;

                                            string IP = "";

                                            DBManager dbms = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                                            DataTable dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");

                                            foreach (DataRow dr in dt.Rows)
                                            {

                                                IP = dr[1].ToString();
                                                port = Int32.Parse(dr[2].ToString());

                                            }
                                           


                                            udpConnection.Send(IP, port, order);
                                            
                                            dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                                           
                                            foreach (DataRow dr in dt.Rows)
                                            {

                                                IP = dr[1].ToString();
                                                port = Int32.Parse(dr[2].ToString());

                                            }
                                            udpConnection.Send(IP, port, order);
                                            dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");
                                            foreach (DataRow dr in dt.Rows)
                                            {

                                                IP = dr[1].ToString();
                                                port = Int32.Parse(dr[2].ToString());

                                            }
                                            udpConnection.Send(IP, port, order);
                                            
                                            dbms.Close();
                                            sucNO = sucNO + car.CarNO + Constant.SPLIT_EX_2.ToString();
                                            gprsCount++;
                                        }
                                        else failNo = failNo + car.CarNO + Constant.SPLIT_EX_2.ToString();

                                    }
                                }

                                catch { }
                            }
                        }

                        
                        
                        }
                   

                    if((smsCount + gprsCount + modemCount) > 0)
                    {
                        String op = "";
                        if(dataClient.LoginUser != null)
                            op = "[����Ա]" + dataClient.LoginUser.UserName;
                        else if(dataClient.LoginTeam != null)
                            op = "[�����û�]" + dataClient.LoginTeam.TeamName;
                        dbAssistant.AddOrder(sucNO, op, order, remark, DateTime.Now);
                    }
                }
                if(maxCount > 0 && maxCount == (smsCount + gprsCount + modemCount))
                {
                    stb.Append(Constant.RESULT_OK).Append("ָ��[").Append(remark).Append("]�����͵�").Append(sucNO).Append("�ɹ�");
                }
                else if((smsCount + gprsCount + modemCount) == 0)
                {
                    stb.Append(Constant.RESULT_FAIL).Append("ָ��[").Append(remark).Append("]�����͵�").Append(failNo).Append("ʧ��");
                }
                else
                {
                    stb.Append(Constant.RESULT_FAIL).Append("ָ��[").Append(remark).Append("]�����͵�").Append(sucNO).Append("�ɹ���ʧ�ܣ�").Append(failNo);
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ����÷���״̬
        private void C_Set_Stoped(DataClient dataClient, String rec)
        {
            try
            {
                String[] para = rec.Split(Constant.SPLIT1);
                Car car = GetCarByID(Int32.Parse(para[0]));
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_STOPED);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyOverTime == 1)
                {
                    int stp = Int32.Parse(para[1]);
                    if(car != null && dbm.ExecuteUpdate(car.SqlUpdateStopedStr(stp)))
                    {
                        car.Stoped = stp;
                        //stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        //dataClient.Send(stb.ToString());

                        String s1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_SET_STOPED).Append(rec).Append(Constant.FOOT).ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                || (dc.LoginCar != null && dc.LoginCar.CarID == car.CarID))
                                dc.Send(s1);
                        }
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "���ó�������״̬:���ƺ�" + car.CarNO);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ����÷�������
        private void C_Set_ServiceTime(DataClient dataClient, String rec)
        {
            try
            {
                String[] para = rec.Split(Constant.SPLIT1);
                Car car = GetCarByID(Int32.Parse(para[0]));
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_SERVICE_TIME);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyOverTime == 1)
                {
                    bool suc = false;
                    if(para[2] == "1")
                        suc = dbm.ExecuteUpdate(car.SqlUpdateServiceTimeStr(para[1], 0));
                    else suc = dbm.ExecuteUpdate(car.SqlUpdateServiceTimeStr(para[1], car.Stoped));
                    if(suc)
                    {
                        String s = para[0] + Constant.SPLIT1 + para[1] + Constant.SPLIT1;
                        car.OverServiceTime = para[1];
                        if(para[2] == "1")
                            car.Stoped = 0;
                        //stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        //dataClient.Send(stb.ToString());

                        String s1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_SET_SERVICE_TIME).Append(rec).Append(Constant.FOOT).ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                || (dc.LoginCar != null && dc.LoginCar.CarID == car.CarID))
                                dc.Send(s1);
                        }
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "���ó�����������:���ƺ�" + car.CarNO);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ����ò�����ʾ
        private void C_Set_Notify(DataClient dataClient, String rec)
        {
            try
            {
                String[] para = rec.Split(Constant.SPLIT1);
                Car car = GetCarByID(Int32.Parse(para[0]));
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_NOTIFY);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyNotify == 1)
                {
                    bool suc = false;
                    if(para[1] == "0")
                    {
                        if(dbm.ExecuteUpdate(car.SqlUpdateDisableNotify()))
                        {
                            car.Notify = 0;
                            suc = true;
                        }
                    }
                    else
                    {
                        if(dbm.ExecuteUpdate(car.SqlUpdateEnableNotify(para[2], para[3], para[4])))
                        {
                            car.Notify = 1;
                            car.NotifyStart = para[2];
                            car.NotifyEnd = para[3];
                            car.NotifyText = para[4];
                            suc = true;
                        }
                    }
                    if(suc)
                    {
                        //stb.Append(Constant.RESULT_OK).Append(Constant.FOOT);
                        //dataClient.Send(stb.ToString());

                        String s1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_SET_NOTIFY).Append(rec).Append(Constant.FOOT).ToString();
                        DataClient[] tempList = dataClientList.ToArray();
                        foreach(DataClient dc in tempList)
                        {
                            if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                || (dc.LoginCar != null && dc.LoginCar.CarID == car.CarID))
                                dc.Send(s1);
                        }
                        dbAssistant.AddOperation(dataClient.LoginUser.UserName, "���ó���������ʾ:���ƺ�" + car.CarNO);
                        return;
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(car.CarNO).Append(Constant.SPLIT1).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion

        #region ����������
        //�ظ��Ӿ�
        private void C_Alarm_Handle(DataClient dataClient, String rec)
        {
            try
            {
                String[] para = rec.Split(Constant.SPLIT1);
                Car car = GetCarByID(Int32.Parse(para[0]));
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_ALARM).Append(Constant.C_ALARM_HANDLE);
                if(dataClient.LoginUser != null && (dataClient.LoginUser.UserType == User.USER_ADMIN || dataClient.LoginUser.PolicyAlarmList == 1))
                {
                    if(para[1][0] == Constant.RESULT_OK)//�Ӿ�
                    {
                        if(car.HandleAlarmClient == null && car.AlarmPos.Count > 0)
                        {
                            car.HandleAlarmClient = dataClient;
                            if(dataClient.HandleAlarmCar != null)
                                foreach(AlarmPosition apos in car.AlarmPos)
                                    S_Alarm(car, apos);
                            dataClient.HandleAlarmCar = car;
                            String s1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_FREE_ALARM).Append(para[0]).Append(Constant.FOOT).ToString();
                            DataClient[] tempList = dataClientList.ToArray();
                            foreach(DataClient dc in tempList)//��������ϯ�����ѽӾ�
                                if(dc != dataClient && dc.LoginUser != null && dc.LoginUser.PolicyAlarmList == 1 && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                {
                                    dc.Send(s1);
                                }

                            stb.Append(Constant.RESULT_OK).Append(para[0]).Append(Constant.FOOT);
                            dataClient.Send(stb.ToString());
                            //dbAssistant.AddOperation(dataClient.LoginUser.UserName, "�Ӿ�:���ƺ�" + car.CarNO);
                            return;
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(para[0]).Append(Constant.SPLIT1).Append("�ó��������ѱ��Ӿ�����").Append(Constant.FOOT);
                    }
                    else//ȡ���Ӿ�
                    {
                        if(car.HandleAlarmClient == dataClient)//�Ƿ�Ϊ�Ӿ�����ϯ
                        {
                            car.HandleAlarmClient = null;
                            dataClient.HandleAlarmCar = null;
                            foreach(AlarmPosition apos in car.AlarmPos)
                                S_Alarm(car, apos);
                            //dbAssistant.AddOperation(dataClient.LoginUser.UserName, "ȡ���Ӿ�:���ƺ�" + car.CarNO);
                            stb.Append(Constant.FOOT);
                        }
                    }
                }
                else stb.Append(Constant.RESULT_FAIL).Append(para[0]).Append(Constant.SPLIT1).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�ظ��������
        private void C_Alarm_Free(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_ALARM).Append(Constant.C_ALARM_FREE);
                String[] para = rec.Split(Constant.SPLIT1);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyAlarmList == 1)
                {
                    bool hasSuc = false;
                    Car car = GetCarByID(Int32.Parse(para[0]));
                    if(car == null)
                        return;
                    //Console.WriteLine("��ϯ������� cno:" + car.CarNO + ";user:" + dataClient.LoginUser.UserName);
                    if(dbm.ExecuteUpdate("update_alarm_free " + para[0] + "," + dataClient.LoginUser.UserID.ToString()))
                    {
                        try
                        {
                            car.AlarmPos.Clear();
                            if(para[1] == "1")//�������ָ��
                            {
                                if(car.Routeway >= Constant.ROUTE_WAY_SMS)
                                {
                                    if(car.Protocol == Constant.PROTOCOL_QICHUAN)
                                    {
                                        String remark = "", order = Protocol_QiChuan.CreateSMSOrder(car.MachineNO, Protocol_QiChuan.OD_CTR_FREE_ALARM, "", out remark);
                                        if(SendSms(car.Routeway - 2, car.SimNO, order))
                                            stb.Append(Constant.RESULT_OK).Append(para[0]).Append(Constant.FOOT);
                                        else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                                    }
                                    else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                                }
                                else if(car.Routeway == Constant.ROUTE_WAY_MODEM)
                                {
                                    if(car.Protocol == Constant.PROTOCOL_QICHUAN)
                                    {
                                        String remark = "", order = Protocol_QiChuan.CreateSMSOrder(car.MachineNO, Protocol_QiChuan.OD_CTR_FREE_ALARM, "", out remark);
                                        if (SendSmsToModem(car.SimNO, order))
                                            stb.Append(Constant.RESULT_OK).Append(para[0]).Append(Constant.FOOT);
                                        else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                                    }
                                    else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                                }
                                else if (car.Routeway == Constant.ROUTE_WAY_UDP)
                                {
                                    if (car.Protocol == Constant.PROTOCOL_XUNLUOSHU)
                                    {
                                        String remark = "", order = Protocol_XunLuoShu.CreateGPRSOrder(car.MachineNO, Protocol_XunLuoShu.OD_CTR_FREE_ALARM, "", out remark);

                                        int port = 0;

                                        string IP = "";

                                        DBManager dbms = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                                        DataTable dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");

                                        foreach (DataRow dr in dt.Rows)
                                        {

                                            IP = dr[1].ToString();
                                            port = Int32.Parse(dr[2].ToString());

                                        }

                                       
                                        udpConnection.Send(IP, port, order);
                                        
                                        dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");

                                        foreach (DataRow dr in dt.Rows)
                                        {

                                            IP = dr[1].ToString();
                                            port = Int32.Parse(dr[2].ToString());

                                        }
                                        udpConnection.Send(IP, port, order);
                                      
                                        dt = dbms.ExecuteQuery("select_Terminal " + "'" + car.MachineNO + "'");

                                        foreach (DataRow dr in dt.Rows)
                                        {

                                            IP = dr[1].ToString();
                                            port = Int32.Parse(dr[2].ToString());

                                        }
                                        udpConnection.Send(IP, port, order);


                                        dbms.Close();
                                        stb.Append(Constant.RESULT_OK).Append(para[0]).Append(Constant.FOOT);

                                    }
                                    else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                                }

                                else stb.Append(Constant.RESULT_OTHER).Append(para[0]).Append(Constant.FOOT);
                            }
                            else stb.Append(Constant.RESULT_OK).Append(para[0]).Append(Constant.FOOT);
                            //Console.WriteLine("��ϯ��������ɹ� cno:" + car.CarNO + ";user:" + dataClient.LoginUser.UserName);
                            hasSuc = true;
                            dataClient.Send(stb.ToString());

                            String s1 = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_FREE_ALARM).Append(para[0]).Append(Constant.FOOT).ToString();
                            DataClient[] tempList = dataClientList.ToArray();
                            foreach(DataClient dc in tempList)
                            {
                                if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null && dc.LoginUser.PolicyAlarmList == 1)
                                {
                                    dc.Send(s1);
                                    //Console.WriteLine("����ϯ���ͽ������ cno:" + car.CarNO + ";user:" + dc.LoginUser.UserName);
                                }
                            }
                            car.HandleAlarmClient = null;
                            dbAssistant.AddOperation(dataClient.LoginUser.UserName, "�������:���ƺ�" + car.CarNO);
                        }
                        catch { }
                    }
                    if(!hasSuc)
                    {
                        stb.Append(Constant.RESULT_FAIL).Append(para[0]).Append(Constant.SPLIT1).Append(StrConst.RET_UPDATE_DB).Append(Constant.FOOT);
                        dataClient.Send(stb.ToString());
                        car.HandleAlarmClient = null;
                        foreach(AlarmPosition apos in car.AlarmPos)
                            S_Alarm(car, apos);
                        return;
                    }
                }
                else stb.Append(Constant.RESULT_FAIL).Append(para[0]).Append(Constant.SPLIT1).Append(StrConst.RET_NO_POLICY).Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion

        #region ������Ϣ
        //����������Ϣ
        private void C_Chat_ToAll(DataClient dataClient, String rec)
        {
            try
            {
                String sender = "";
                if(dataClient.LoginUser != null)
                    sender = "[����Ա]" + dataClient.LoginUser.UserName;
                else if(dataClient.LoginTeam != null)
                    sender = "[����]" + dataClient.LoginTeam.TeamName;
                else sender = "[����]" + dataClient.LoginCar.CarNO;
                String s = new StringBuilder(Constant.HEAD).Append(Constant.C_CHAT).Append(Constant.C_CHAT_TO_ALL).Append(sender).Append(Constant.SPLIT1).Append(rec).Append(Constant.FOOT).ToString();
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    dc.Send(s);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //������Ա��Ϣ
        private void C_Chat_ToAdmin(DataClient dataClient, String rec)
        {
            try
            {
                String sender = "";
                if(dataClient.LoginUser != null)
                    sender = "[����Ա]" + dataClient.LoginUser.UserName;
                else if(dataClient.LoginTeam != null)
                    sender = "[����]" + dataClient.LoginTeam.TeamName;
                else sender = "[����]" + dataClient.LoginCar.CarNO;
                String s = new StringBuilder(Constant.HEAD).Append(Constant.C_CHAT).Append(Constant.C_CHAT_TO_ADMIN).Append(sender).Append(Constant.SPLIT1).Append(rec).Append(Constant.FOOT).ToString();
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.LoginUser != null 
                        || (dc.LoginTeam != null && dc == dataClient)
                        || (dc.LoginCar != null && dc == dataClient))
                        dc.Send(s);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //���û���Ϣ
        private void C_Chat_ToUser(DataClient dataClient, String rec)
        {
            try
            {
                String sender = "";
                if(dataClient.LoginUser != null)
                    sender = "[����Ա]" + dataClient.LoginUser.UserName;
                else if(dataClient.LoginTeam != null)
                    sender = "[����]" + dataClient.LoginTeam.TeamName;
                else sender = "[����]" + dataClient.LoginCar.CarNO;
                String s = new StringBuilder(Constant.HEAD).Append(Constant.C_CHAT).Append(Constant.C_CHAT_TO_USER).Append(sender).Append(Constant.SPLIT1).Append(rec).Append(Constant.FOOT).ToString();
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.LoginUser == null
                        || (dc.LoginUser != null && dc == dataClient))
                        dc.Send(s);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion

        #region ��ѯͳ��
        //�ظ�������¼��ѯ
        //������,ʱ��1,ʱ��2,��������
        private void C_Query_Operation(DataClient dataClient, String rec)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_OPERATION);
            String[] ss = rec.Split(Constant.SPLIT1);
            if(ss.Length == 4)
            {
                StringBuilder stbSql = new StringBuilder("select * from tOperation ");
                stbSql.Append(" where opDate  >= '").Append(ss[1]).Append("' ");
                stbSql.Append(" and opDate  <= '").Append(ss[2]).Append("' ");
                stbSql.Append(" and remark  like '%").Append(ss[3]).Append("%' ");
                if(dataClient.LoginCar != null)
                {
                    stbSql.Append("and opUser='").Append(dataClient.LoginCar.CarNO).Append("' ");
                }
                else if(dataClient.LoginTeam != null)
                {
                    stbSql.Append("and opUser='").Append(dataClient.LoginTeam.TeamName).Append("' ");
                }
                else if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_OP)
                {
                    stbSql.Append("and opUser='").Append(dataClient.LoginUser.UserName).Append("'");
                }
                else stbSql.Append(" and opUser  like '%").Append(ss[0]).Append("%' ");
                DataTable dt = dbm.ExecuteQuery(stbSql.ToString());
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        for(int i = 0; i < 4; i++)
                            stb.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                        stb.Append(Constant.SPLIT1);
                    }
                    stb.Remove(stb.Length - 1, 1);
                }
            }
            stb.Append(Constant.FOOT);
            dataClient.Send(stb.ToString());
        }
        //�ظ�ָ���·���¼��ѯ
        //������,ʱ��1,ʱ��2,����,ָ������
        private void C_Query_Order(DataClient dataClient, String rec)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_ORDER);
            String[] ss = rec.Split(Constant.SPLIT1);
            if(ss.Length == 5)
            {
                StringBuilder stbSql = new StringBuilder("select * from tOrder ");
                stbSql.Append(" where sendTime  >= '").Append(ss[1]).Append("' ");
                stbSql.Append(" and sendTime  <= '").Append(ss[2]).Append("' ");
                stbSql.Append(" and carNO  like '%").Append(ss[3]).Append("%' ");
                stbSql.Append(" and remark  like '%").Append(ss[4]).Append("%' ");
                if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_OP)
                {
                    stbSql.Append("and opUser='").Append(dataClient.LoginUser.UserName).Append("'");
                }
                else stbSql.Append(" and opUser  like '%").Append(ss[0]).Append("%' ");
                //Console.WriteLine(stbSql.ToString());
                DataTable dt = dbm.ExecuteQuery(stbSql.ToString());
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        for(int i = 0; i < 6; i++)
                            stb.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                        stb.Append(Constant.SPLIT1);
                    }
                    stb.Remove(stb.Length - 1, 1);
                }
            }
            stb.Append(Constant.FOOT);
            dataClient.Send(stb.ToString());
        }
        //�ظ��걨��¼��ѯ
        //ID,�걨ʱ��1,�걨ʱ��2,����,�Ѵ���,������,���ѯ����ʱ��,����ʱ��1,����ʱ��2,������Ա,����,���
        private void C_Query_Declare(DataClient dataClient, String rec)
        {
            String[] ss = rec.Split(Constant.SPLIT1);
            StringBuilder stbPara = new StringBuilder();
            stbPara.Append(" where declareID  like '%").Append(ss[0]).Append("%' ");
            if(ss[1] != "")
                stbPara.Append(" and referDate  >= '").Append(ss[1]).Append("' ");
            if(ss[2] != "")
                stbPara.Append(" and referDate  <= '").Append(ss[2]).Append("' ");
            stbPara.Append(" and declareContent  like '%").Append(ss[3]).Append("%' ");
            if(ss[4] == "1")
                stbPara.Append(" and opUser  = '' ");
            else
            {
                if(ss[4] == "2")
                {
                    stbPara.Append(" and opUser  <> '' ");
                }
                stbPara.Append(" and opUser like '%").Append(ss[5]).Append("%' ");
                if(ss[6] == "1")
                {
                    stbPara.Append(" and opDate  >= '").Append(ss[7]).Append("' ");
                    stbPara.Append(" and opDate  <= '").Append(ss[8]).Append("' ");
                }
                stbPara.Append(" and mechanic like '%").Append(ss[9]).Append("%' ");
                if(ss[10] != "0")
                    stbPara.Append(" and satisfaction = ").Append(Int32.Parse(ss[10]) - 1).Append(" ");
                stbPara.Append(" and opinion like '%").Append(ss[11]).Append("%' ");
            }
            if(ss[12] != "")
                stbPara.Append(" and carID=").Append(ss[12]).Append(" ");
            StringBuilder stbSql = new StringBuilder("select * from vDeclare ").Append(stbPara.ToString());
            if(dataClient.LoginCar != null)
            {
                stbSql.Append("and carID=").Append(dataClient.LoginCar.CarID);
            }
            else if(dataClient.LoginTeam != null)
            {
                stbSql.Append("and teamID=").Append(dataClient.LoginTeam.TeamID);
            }
            else if(dataClient.LoginUser != null && dataClient.LoginUser.UserType == User.USER_OP)
            {
                stbSql.Append("and (teamID=0 or teamID=");
                foreach(Team t in dataClient.LoginUser.Teams)
                    stbSql.Append(t.TeamID).Append(" or teamID=");
                stbSql.Remove(stbSql.Length - 12, 11).Append(")");
            }
            DataTable dt = dbm.ExecuteQuery(stbSql.ToString());
            StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.C_QUERY).Append(Constant.C_QUERY_DECLARE);
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    for(int i = 0; i < 12; i++)
                        stb1.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                    stb1.Append(Constant.SPLIT1);
                }
                stb1.Remove(stb1.Length - 1, 1);
            }
            stb1.Append(Constant.FOOT);
            dataClient.Send(stb1.ToString());
        }
        #endregion

        #region ���ϡ�Ͷ��
        private void C_Declare_List(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_LIST);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyDeclare == 1)
                {
                    Car car = GetCarByID(Int32.Parse(rec));
                    if(car != null)
                    {
                        DataTable dt = dbm.ExecuteQuery("select_declare " + rec);
                        if(dt.Rows.Count > 0)
                        {
                            foreach(DataRow dr in dt.Rows)
                            {
                                for(int i = 0; i < 12; i++)
                                    stb.Append(dr[i].ToString()).Append(Constant.SPLIT2);
                                stb.Append(Constant.SPLIT1);
                            }
                            stb.Remove(stb.Length - 1, 1);
                        }
                    }
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        private void C_Declare_New(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_NEW);
                Declare dec = Declare.Parse(rec);
                if(dec != null)
                {
                    Car car = GetCarByID(dec.CarID);
                    if(car != null)
                    {
                        DataTable dt = dbm.ExecuteQuery(dec.SqlInsertStr());
                        if(dt != null)
                        {
                            car.DeclareCount++;
                            stb.Append(Constant.RESULT_OK).Append(car.CarID);
                            StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_DECLARE).Append(Constant.S_DECLARE_ADD).Append(dec.CarID).Append(Constant.FOOT);
                            foreach(DataClient dc in dataClientList)
                            {
                                if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                    || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                    || (dc.LoginCar != null && dc.LoginCar.CarID == dec.CarID))
                                    dc.Send(stb1.ToString());
                            }
                            String op = "";
                            if(dataClient.LoginUser != null)
                                op = "[����Ա]" + dataClient.LoginUser.UserName;
                            else if(dataClient.LoginTeam != null)
                                op = "[�����û�]" + dataClient.LoginTeam.TeamName;
                            else op = "[�����û�]" + dataClient.LoginCar.CarNO;
                            dbAssistant.AddOperation(op, "�ύ���ϡ�Ͷ���걨");
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO);
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        private void C_Declare_Deal(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_DEAL);
                if(dataClient.LoginUser != null && dataClient.LoginUser.PolicyDeclare == 1)
                {
                    Declare dec = Declare.Parse(rec);
                    if(dec != null)
                    {
                        Car car = GetCarByID(dec.CarID);
                        DataTable dt = dbm.ExecuteQuery(dec.SqlUpdateStr(car.CarID));
                        if(dt != null)
                        {
                            stb.Append(Constant.RESULT_OK).Append(car.CarID);
                            int dcount = Int32.Parse(dt.Rows[0][0].ToString());
                            if(car.DeclareCount != dcount)
                            {
                                car.DeclareCount = dcount;
                                StringBuilder stb1 = new StringBuilder(Constant.HEAD).Append(Constant.S_DECLARE).Append(Constant.S_DECLARE_DEAL);
                                stb1.Append(car.CarID).Append(Constant.SPLIT1).Append(car.DeclareCount).Append(Constant.FOOT);
                                foreach(DataClient dc in dataClientList)
                                {
                                    if((dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null)
                                        || (dc.LoginTeam != null && dc.LoginTeam.TeamID == car.TeamID)
                                        || (dc.LoginCar != null && dc.LoginCar.CarID == dec.CarID))
                                        dc.Send(stb1.ToString());
                                }
                                dbAssistant.AddOperation(dataClient.LoginUser.UserName, "������ϡ�Ͷ��:����" + dec.DeclareID);
                            }
                            else dbAssistant.AddOperation(dataClient.LoginUser.UserName, "�޸Ĺ��ϡ�Ͷ��:����" + dec.DeclareID);
                        }
                        else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_UPDATE_DB);
                    }
                    else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_ERR_INFO);
                }
                else stb.Append(Constant.RESULT_FAIL).Append(StrConst.RET_NO_POLICY);
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        private void C_Declare_HisContent(DataClient dataClient, String rec)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_DECLARE).Append(Constant.C_DECLARE_HIS_CONTENT);
                String[] ss = rec.Split(Constant.SPLIT1);
                StringBuilder stbSql = new StringBuilder("select referDate,declareContent from vDeclare  where");
                stbSql.Append(" carID=").Append(ss[0]);
                stbSql.Append(" and referDate  <= '").Append(ss[1]).Append("' ");
                DataTable dt = dbm.ExecuteQuery(stbSql.ToString());
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        stb.Append("[").Append(dr[0].ToString()).Append("]").Append(dr[1].ToString());
                        stb.Append(Constant.SPLIT1);
                    }
                    stb.Remove(stb.Length - 1, 1);
                }
                stb.Append(Constant.FOOT);
                dataClient.Send(stb.ToString());
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        #endregion
        /**********************************************************************/

        #region ������Ϣ
        //���¼�س���λ��
        private void S_RefreshWatching(Car car)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_WATCH);
                stb.Append(car.CarID).Append(Constant.SPLIT1).Append(car.Pos.ToString()).Append(Constant.FOOT);
                String s = stb.ToString();
                Socket[] tempList = car.WatchSockets.ToArray();
                foreach(Socket st in tempList)
                    if(car.PointSockets.IndexOf(st) < 0)
                        if(!ClientSend(st, s))
                            car.WatchSockets.Remove(st);
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //�±�����Ϣ
        private void S_Alarm(Car car, AlarmPosition apos)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.S_INFO).Append(Constant.S_INFO_ALARM);
                stb.Append(apos.ToString()).Append(Constant.FOOT);
                String s = stb.ToString();
                if(car.HandleAlarmClient == null)//�Ƿ��ѽӾ�
                {
                    DataClient[] tempList = dataClientList.ToArray();
                    foreach(DataClient dc in tempList)//����(δ�Ӿ�)
                        if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null && dc.LoginUser.PolicyAlarmList == 1)
                            dc.Send(s);
                }
                else
                {
                    bool send = false;
                    DataClient[] tempList = dataClientList.ToArray();
                    foreach(DataClient dc in tempList)//����(�ѽӾ�)
                        if(dc == car.HandleAlarmClient)
                        {
                            send = dc.Send(s);
                            break;
                        }
                    if(!send)//����ʧ�ܣ����ýӾ��û���ͬʱ���͵�������ϯ
                    {
                        car.HandleAlarmClient = null;
                        foreach(DataClient dc in tempList)
                            if(dc.LoginUser != null && dc.LoginUser.GetTeamByID(car.TeamID) != null && dc.LoginUser.PolicyAlarmList == 1)
                                dc.Send(s);
                    }
                }
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //��λ����
        private void S_Point(Car car)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_POS).Append(Constant.C_POS_POINT);
                stb.Append(Constant.RESULT_OK).Append(car.CarID).Append(Constant.SPLIT1).Append(car.Pos.ToString()).Append(Constant.FOOT);
                String s = stb.ToString();
                Socket[] tempList = car.PointSockets.ToArray();
                foreach(Socket st in tempList)
                    ClientSend(st, s);
                car.PointSockets.Clear();
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }
        //ȡ�����÷���
        private void S_GetSetting(Car car, String ss)
        {
            try
            {
                StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.C_SET).Append(Constant.C_SET_GET_SET);
                stb.Append(Constant.RESULT_OK).Append(car.CarID).Append(Constant.SPLIT1).Append(ss).Append(Constant.FOOT);
                String s = stb.ToString();
                Socket[] tempList = car.GetSetSockets.ToArray();
                foreach(Socket st in tempList)
                    ClientSend(st, s);
                car.GetSetSockets.Clear();
            }
            catch(Exception e)
            {
                if(FormMain.LOG_ERR)
                    logger.AddErr(e, "");
            }
        }

        #endregion

        #region ��������Ϣ
        //������Ϣ
        private void S_Error(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_ERR).Append(s).Append(Constant.FOOT);
            try
            {
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.LoginUser != null) 
                        dc.Send(stb.ToString());
            }
            catch { }
        }
        //������Ϣ
        private void S_Warning(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_WARN).Append(s).Append(Constant.FOOT);
            try
            {
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.LoginUser != null)
                        dc.Send(stb.ToString());
            }
            catch { }
        }
        //��ͨ��Ϣ
        private void S_Message(String s)
        {
            StringBuilder stb = new StringBuilder(Constant.HEAD).Append(Constant.S_MSG).Append(Constant.S_MSG_MESSAGE).Append(s).Append(Constant.FOOT);
            try
            {
                DataClient[] tempList = dataClientList.ToArray();
                foreach(DataClient dc in tempList)
                    if(dc.LoginUser != null)
                        dc.Send(stb.ToString());
            }
            catch { }
        }
        #endregion
    }
}