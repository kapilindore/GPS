using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// GPRS协议2协议
    /// </summary>
    public class Protocol_TianHe
    {
        public const String HEAD = "*HQ,";
        public const String FOOT = "#";

        public const char HEAD_HEX_1 = '$';
        public const char HEAD_HEX_2 = 'X';

        public const char OD_SET_SMS_NUM_M = 'A'; //中心短信号码
        public const char OD_SET_SMS_NUM_S = 'B';//中心辅助短信号码
        public const char OD_SET_APN = 'C';//设置接入点名称APN
        public const char OD_SET_GPRS_CENTER = 'D';//设置GPRS中心
        public const char OD_SET_ALARM_SPEED = 'E';//设置超速报警速度
        public const char OD_SET_NOTIFY_SPEED = 'F';//设置超速提示速度
        public const char OD_SET_ENCLOSURE = 'G';//设置电子围栏
        public const char OD_SET_CALL_LIMIT = 'H';//设置呼叫限制
        public const char OD_SET_AUTO_UPLOAD1 = 'I';//设置自动回传(D1)
        public const char OD_SET_AUTO_UPLOAD2 = 'J';//设置自动回传(S17)
        public const char OD_SET_WATCHING = 'K';//监听
        public const char OD_SET_CUTDOWN = 'L';//断油断电
        public const char OD_SET_CUSTOM_ALARM = 'M';//设置自定义报警
        public const char OD_SET_PARAM = 'N';//设置终端参数
        public const char OD_SET_TEMP_ALARM = 'O';//设置温度报警
        public const char OD_SET_SYSTEM = 'P';//系统设置
        public const char OD_SET_OVER_DRIVER = 'Q';//设置疲劳驾驶监控
        public const char OD_SET_DOOR = 'R';//远程开关门
        public const char OD_SET_FORTIFY = 'S';//远程设防


        public const char OD_CTR_FREE_ALARM = 'a';//解除报警
        public const char OD_CTR_CONFIRM_ALARM = 'b';//确认报警
        public const char OD_CTR_REBOOT = 'c';//重启终端
        public const char OD_CTR_RESET = 'd';//回复出厂设置
        public const char OD_CTR_QUERY_MILE = 'e';//查询里程
        //短信定位信息
        //*RS,123456789,V1,181003,A,2233.1055,N,11358.1257,E,51.00,000,070925,FFFFFBFD#
        public static Position GetSMSPos(String src)
        {
            Position pos = new Position();
            try
            {
                //Console.WriteLine(src);
                String[] ss = src.Split(',');
                pos.MNO = ss[0];
                int add = 0;
                if(ss[1] == "V4")
                {
                    if(ss[2] == "S32")
                    {
                        add = 3;
                        pos.Mileage = (int)(Double.Parse(ss[4]) * 0.51444 / 1000);
                    }/*
                    else if(ss[2] == "S5")
                    {
                        add = 5;
                        pos.IsPointMsg = true;
                    }/*/
                    else if(ss[2] == "S26")
                    {
                        pos.IsGetSetMsg = true;
                        pos.SettingStr = src.Substring(src.IndexOf(ss[5]));
                        return pos;
                    }
                    else add = 2;
                }
                else pos.IsPointMsg = true;//此协议无单独定位指令，只好用v1代替
                try
                {/*
                    pos.GpsTime = "20" + ss[add + 10].Substring(4) + "-" + ss[add + 10].Substring(2, 2) + "-" + ss[add + 10].Substring(0, 2)
                        + " " + ss[add + 2].Substring(0, 2) + ":" + ss[add + 2].Substring(2, 2) + ":" + ss[add + 2].Substring(4);
                    DateTime dt = DateTime.Parse(pos.GpsTime);
                    dt = dt.AddHours(8);
                    pos.GpsTime = dt.ToString("yyyy-MM-dd HH:mm:ss");*/
                    pos.GpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch { pos.GpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } 
                
                pos.Pointed = (ss[add + 3] == "A") ? 1 : 0;

                pos.La = Double.Parse(ss[add + 4].Substring(0, 2)) + Double.Parse(ss[add + 4].Substring(2)) / 60;
                if(ss[add + 5] == "S")
                    pos.La = 0 - pos.La;
                pos.Lo = Double.Parse(ss[add + 6].Substring(0, 3)) + Double.Parse(ss[add + 6].Substring(3)) / 60;
                if(ss[add + 7] == "W")
                    pos.Lo = 0 - pos.Lo;
                pos.Speed = Pub.KtsToKms((int)Double.Parse(ss[add + 8]));
                if(ss[add + 9] == "")
                    pos.Direction = 0;
                else
                {
                    pos.Direction = 0;
                    double dir = Double.Parse(ss[add + 9]);
                    if(dir < 90) pos.Direction = 1;
                    else if(dir == 90) pos.Direction = 2;
                    else if(dir < 180) pos.Direction = 3;
                    else if(dir == 180) pos.Direction = 4;
                    else if(dir < 270) pos.Direction = 5;
                    else if(dir == 270) pos.Direction = 6;
                    else if(dir > 270) pos.Direction = 7;
                }
                if(ss[add + 11].Length > 8)
                    ss[add + 11] = ss[add + 11].Substring(0, 8);
                String hex = Pub.HexToBin(ss[add + 11]);
                String[] status = {
                        "低电传感器1搭铁",      "高电传感器2为高",      "高电传感器1为高",      "电瓶拆除报警",
                        "车辆断油电",           "GPRS阻塞报警",         "三次密码错误报警",     "温度报警",
                        "低电传感器2搭铁",      "GPS天线短路",          "GPS天线开路",          "电瓶被拆除",
                        "主机由后备电池供电",   "",                     "",                     "GPS天线故障报警",
                        "超速",                 "自定义报警",           "发动机开",             "",
                        "",                     "ACC关",                "车辆设防",             "车门开",
                        "禁止驶出越界报警",     "GPS天线短路报警",      "GPS天线开路报警",      "禁止驶入越界报警",
                        "非法点火报警",         "超速报警",             "劫警",                 "盗警"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("警") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
                if(pos.Status.IndexOf("ACC关") < 0)
                    pos.Status = pos.Status + "ACC开";
                pos.AlarmHandle = (pos.Alarm == "") ? 0 : 1;
                return pos;
            }
            catch { }
            return null;
        }
        //gprs/cdma定位信息
        public static Position GetGPRSPos(String src)
        {
            Position pos = new Position();
            try
            {
                return GetSMSPos(src);
            }
            catch { }
            return null;
        }
        //分析接收到的数据，返回定位信息列表
        public static List<Position> Analyze(String src, bool gprs)
        {
            if(src.IndexOf(HEAD) >= 0)
            {
                while(src.IndexOf(HEAD) != 0)
                    src = src.Substring(src.IndexOf(HEAD));
                if(src.IndexOf(FOOT) <= 0)
                    return null;
                List<Position> list = new List<Position>();

                String[] lines = src.Split(new string[] { HEAD }, StringSplitOptions.RemoveEmptyEntries);
                foreach(String line in lines)
                    if(line != "")
                    {
                        Position pos = null;
                        if(gprs)
                        {
                            pos = GetGPRSPos(line.Substring(0, line.Length - 1));
                        }
                        else
                        {
                            pos = GetSMSPos(line.Substring(0, line.Length - 1));
                        }
                        if(pos != null)
                            list.Add(pos);
                    }
                return list;
            }
            return null;
        }
        //gprs/cdma压缩信息
        //24 75 50 13 90 79 16 04 33 14 08 08 22 31 46 01 00 11 40 19 44 3C 00 01 92 FF FF FB FF FF 00 03
        //24 75 50 13 90 79 16 04 33 14 08 08 22 31 46 01 00 11 40 19 44 3C 00 01 92 FF FF FB FF FF 00 03
        //24 30 80 72 25 23 04 20 38 15 08 08 24 54 60 96 00 11 83 64 28 5C 00 02 67 FF FF FB FF FF 00 5D
        //char c = 1100
        public static Position GetPosEx(String src)
        {
            Position pos = new Position();
            try
            {
                String ss = Pub.RealHexToHex(src.Substring(1, src.Length - 3));
                Console.WriteLine(ss.Length.ToString());
                if(src[0] == HEAD_HEX_2)
                {
                    pos.Mileage = (int)(Int32.Parse(ss.Substring(0, 10)) * 0.51444 / 1000);
                }
                StringBuilder stb = new StringBuilder();
                pos.MNO = ss.Substring(0, 10);
                /*
                 * GPRS协议2协议停车上传数据时，gps时间不变，所以取服务器时间
                 */
                try
                {/*
                    stb.Append("20").Append(ss.Substring(20, 2)).Append("-");
                    stb.Append(ss.Substring(18, 2)).Append("-").Append(ss.Substring(16, 2)).Append(" ");
                    stb.Append(ss.Substring(10, 2)).Append(":").Append(ss.Substring(12, 2)).Append(":");
                    stb.Append(ss.Substring(14, 2));
                    DateTime dt = DateTime.Parse(stb.ToString());
                    dt = dt.AddHours(8);
                    pos.GpsTime = dt.ToString("yyyy-MM-dd HH:mm:ss");*/
                    pos.GpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch { pos.GpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }

                pos.La = Double.Parse(ss.Substring(22, 2)) + Double.Parse(ss.Substring(24, 6).Insert(2, ".")) / 60;
                pos.Lo = Double.Parse(ss.Substring(32, 3)) + Double.Parse(ss.Substring(35, 6).Insert(2, ".")) / 60;

                String temp = Pub.HexToBin(ss.Substring(41, 1));
                if(temp[0] == '0')
                    pos.Lo = 0 - pos.Lo;
                if(temp[1] == '0')
                    pos.La = 0 - pos.La;
                if(temp[2] == '0')
                    pos.Pointed = 0;
                else pos.Pointed = 1;

                pos.Speed = Pub.KtsToKms(Int32.Parse(ss.Substring(42, 3)));
                pos.Direction = 0;
                int dir = Int32.Parse(ss.Substring(45, 3));
                if(dir < 90) pos.Direction = 1;
                else if(dir == 90) pos.Direction = 2;
                else if(dir < 180) pos.Direction = 3;
                else if(dir == 180) pos.Direction = 4;
                else if(dir < 270) pos.Direction = 5;
                else if(dir == 270) pos.Direction = 6;
                else if(dir > 270) pos.Direction = 7;
                String hex = Pub.HexToBin(ss.Substring(48, 8));
                String[] status = {
                        "低电传感器1搭铁",      "高电传感器2为高",      "高电传感器1为高",      "电瓶拆除报警",
                        "车辆断油电",           "GPRS阻塞报警",         "三次密码错误报警",     "温度报警",
                        "低电传感器2搭铁",      "GPS天线短路",          "GPS天线开路",          "电瓶被拆除",
                        "主机由后备电池供电",   "",                     "",                     "GPS天线故障报警",
                        "超速",                 "自定义报警",           "发动机开",             "",
                        "",                     "ACC关",                "车辆设防",             "车门开",
                        "禁止驶出越界报警",     "GPS天线短路报警",      "GPS天线开路报警",      "禁止驶入越界报警",
                        "非法点火报警",         "超速报警",             "劫警",                 "盗警"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("警") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
                if(pos.Status.IndexOf("ACC关") < 0)
                    pos.Status = pos.Status + "ACC开";
                pos.AlarmHandle = (pos.Alarm == "") ? 0 : 1;
                return pos;
            }
            catch { }
            return null;
        }
        //分析压缩信息
        public static List<Position> AnalyzeEx(String src, bool gprs)
        {
            try
            {
                if(src.IndexOf(HEAD_HEX_1) >= 0 || src.IndexOf(HEAD_HEX_2) >= 0)
                {
                    while(src.IndexOf(HEAD_HEX_1) != 0 && src.IndexOf(HEAD_HEX_2) != 0)
                        src = src.Substring(1);
                    List<Position> list = new List<Position>();
                    while(src.Length >= 32)
                    {
                        String line = src.Substring(0, 32);
                        Position pos = GetPosEx(line);
                        if(pos != null)
                            list.Add(pos);
                        src = src.Substring(32);
                    }
                    return list;
                }
            }
            catch { }
            return null;
        }
        //定位
        public static String CreatePointOrder(bool gprs, String mno)
        {
            if(gprs)
            {
                return "";
            }
            else
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",");
                stb.Append("S32").Append(DateTime.Now.ToString(",HHmmss")).Append(",1").Append(FOOT);
                return stb.ToString();
            }
        }
        //取得设置
        public static String CreateGetSettingOrder(bool gprs, String mno)
        {
            if(gprs)
            {
                return "";
            }
            else
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",");
                stb.Append("S26").Append(DateTime.Now.ToString(",HHmmss")).Append(FOOT);
                return stb.ToString();
            }
        }
        public static String BuildOrder(String mno, String content)
        {
            StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",").Append(content).Append(FOOT);
            return stb.ToString();
        }
        /*
        //生成短信指令
        public static String CreateSMSOrder(String mno, char type, String content, out String remark)
        {
            try
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",");
                String time = DateTime.Now.ToString(",HHmmss");
                switch(type)
                {
                    case OD_SET_SMS_NUM_M://中心短信号码
                        stb.Append("S2").Append(time).Append(",").Append(content);
                        remark = "设置中心短信号码:";// +content;
                        break;
                    case OD_SET_SMS_NUM_S://中心辅助短信号码
                        stb.Append("S28").Append(time).Append(",").Append(content);
                        remark = "设置中心辅助短信号码:";// + content;
                        break;
                    case OD_SET_APN://设置APN
                        stb.Append("S24").Append(time).Append(",1,").Append(content);
                        remark = "设置接入点名称APN";
                        break;
                    case OD_SET_GPRS_CENTER://设置GPRS中心
                        stb.Append("S23").Append(time).Append(",").Append(content);
                        remark = "设置GPRS中心";
                        break;
                    case OD_SET_ALARM_SPEED://设置超速报警速度
                        stb.Append("S14").Append(time).Append(",").Append(content);
                        remark = "设置超速报警";
                        break;
                    case OD_SET_NOTIFY_SPEED://设置超速提示速度
                        stb.Append("S33").Append(time).Append(",").Append(content);
                        remark = "设置超速提示";
                        break;
                    case OD_SET_ENCLOSURE://设置电子围栏
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "设置电子围栏";
                        break;
                    case OD_SET_CALL_LIMIT://设置呼叫限制
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "设置呼叫限制";
                        break;
                    case OD_SET_AUTO_UPLOAD1://自动回传D1
                        String[] ss1 = content.Split(',');
                        stb.Append("S17").Append(time).Append(",").Append(content);
                        remark = "设置自动回传";
                        break;
                    case OD_SET_AUTO_UPLOAD2://自动回传S17
                        stb.Append("S17").Append(time).Append(",").Append(content);
                        remark = "设置自动回传";
                        break;
                    case OD_SET_WATCHING://监听
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "监听:" + content;
                        break;

                    case OD_SET_CUTDOWN://断油断电
                        String[] ss2 = content.Split(',');
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "恢复油电";
                        else remark = "断油断电";
                        break;
                    case OD_SET_CUSTOM_ALARM://自定义报警
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "设置自定义报警";
                        break;
                    case OD_SET_PARAM://设置终端参数
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "设置终端参数";
                        break;

                    case OD_CTR_FREE_ALARM://解除报警
                        stb.Append("R7").Append(time);
                        remark = "解除报警";
                        break;
                    case OD_CTR_REBOOT://重启终端
                        stb.Append("R1").Append(time);
                        remark = "重启终端";
                        break;
                    case OD_SET_WATCHING://监听
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "监听:" + content;
                        break;
                    case OD_CTR_RESET://回复出厂设置
                        stb.Append("S25").Append(time);
                        remark = "回复出厂设置";
                        break;
                    case OD_CTR_QUERY_MILE://查询里程
                        stb.Append("S32").Append(time).Append(",1");
                        remark = "查询里程";
                        break;
                    default:
                        remark = "";
                        break;
                }
                stb.Append(FOOT);
                return stb.ToString();
            }
            catch
            { remark = ""; return ""; }
        }
        //生成gprs/cdma指令
        public static String CreateGPRSOrder(String mNO, char type, String content, out String remark)
        {
            try
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mNO).Append(",");
                String time = DateTime.Now.ToString(",HHmmss");
                switch(type)
                {
                    case OD_SET_SMS_NUM_M://中心短信号码
                        stb.Append("S2").Append(time).Append(",").Append(content);
                        remark = "设置中心短信号码:";// +content;
                        break;
                    case OD_SET_SMS_NUM_S://中心辅助短信号码
                        stb.Append("S28").Append(time).Append(",").Append(content);
                        remark = "设置中心辅助短信号码:";// + content;
                        break;
                    case OD_SET_ALARM_SPEED://设置超速报警速度
                        String[] ss = content.Split(Constant.SPLIT2);
                        stb.Append("S14").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[0])));
                        stb.Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[1]))).Append(",1,").Append(ss[2]);
                        remark = "设置超速报警";
                        break;
                    case OD_SET_NOTIFY_SPEED://设置超速提示速度
                        stb.Append("S33").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(content)));
                        remark = "设置超速提示";
                        break;
                    case OD_SET_ENCLOSURE://设置电子围栏
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "设置电子围栏";
                        break;
                    case OD_SET_CALL_LIMIT://设置呼叫限制
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "设置呼叫限制";
                        break;
                    case OD_SET_AUTO_UPLOAD1://自动回传
                        String[] ss1 = content.Split(Constant.SPLIT2);
                        stb.Append("S17").Append(time).Append(",").Append(ss1[0]);
                        remark = "设置自动回传";
                        break;
                    case OD_SET_CUTDOWN://断油断电
                        String[] ss2 = content.Split(Constant.SPLIT2);
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "恢复油电";
                        else remark = "断油断电";
                        break;
                    case OD_SET_CUSTOM_ALARM://自定义报警
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "设置自定义报警";
                        break;
                    case OD_SET_PARAM://设置终端参数
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "设置终端参数";
                        break;

                    case OD_CTR_FREE_ALARM://解除报警
                        stb.Append("R7").Append(time);
                        remark = "解除报警";
                        break;
                    case OD_CTR_REBOOT://重启终端
                        stb.Append("R1").Append(time);
                        remark = "重启终端";
                        break;
                    case OD_SET_WATCHING://监听
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "监听:" + content;
                        break;
                    case OD_CTR_RESET://回复出厂设置
                        stb.Append("S25").Append(time);
                        remark = "回复出厂设置";
                        break;
                    case OD_CTR_QUERY_MILE://查询里程
                        stb.Append("S32").Append(time).Append(",1");
                        remark = "查询里程";
                        break;
                    default:
                        remark = "";
                        break;
                }
                stb.Append(FOOT);
                return stb.ToString();
            }
            catch
            { remark = ""; return ""; }
        }*/
    }
}
