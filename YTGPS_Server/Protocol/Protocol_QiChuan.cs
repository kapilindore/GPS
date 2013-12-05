using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// GPRS协议1协议
    /// </summary>
    class Protocol_QiChuan
    {
        //*RS,123456789,V1,181003,A,2233.1055,N,11358.1257,E,51.00,000,070925,FFFFFBFD#
        public const String HEAD = "*RS,";
        public const String FOOT = "#";

        //order

        public const char OD_SET_SMS_NUM_M = 'A'; //中心短信号码 0
        public const char OD_SET_SMS_NUM_S = 'B';//中心辅助短信号码1
        public const char OD_SET_GPRS_CENTER = 'C';//设置GPRS中心2
        public const char OD_SET_ALARM_SPEED  = 'D';//设置超速报警速度3
        public const char OD_SET_NOTIFY_SPEED = 'E';//设置超速提示速度4
        public const char OD_SET_ENCLOSURE = 'F';//设置电子围栏5
        public const char OD_SET_CALL_LIMIT = 'G';//设置呼叫限制6
        public const char OD_SET_AUTO_UPLOAD = 'H';//设置自动回传7
        public const char OD_SET_WATCHING = 'I';//监听8
        public const char OD_SET_CUTDOWN = 'J';//断油断电9
        public const char OD_SET_CUSTOM_ALARM = 'K';//设置自定义报警10
        public const char OD_SET_PARAM = 'L';//设置终端参数
        public const char OD_SET_DOOR = 'M';//远程开关门12



        public const char OD_CTR_FREE_ALARM = 'a';//解除报警
        public const char OD_CTR_REBOOT = 'b';//重启终端
        public const char OD_CTR_RESET = 'c';//回复出厂设置
        public const char OD_CTR_QUERY_MILE = 'd';//查询里程

        //短信定位信息
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
                    }
                    else if(ss[2] == "S5")
                    {
                        add = 5;
                        pos.IsPointMsg = true;
                    }
                    else if(ss[2] == "S26")
                    {
                        pos.IsGetSetMsg = true;
                        pos.SettingStr = src.Substring(src.IndexOf(ss[5]));
                        return pos;
                    }
                    else add = 2;
                }
                try
                {
                    pos.GpsTime = "20" + ss[add + 10].Substring(4) + "-" + ss[add + 10].Substring(2, 2) + "-" + ss[add + 10].Substring(0, 2)
                        + " " + ss[add + 2].Substring(0, 2) + ":" + ss[add + 2].Substring(2, 2) + ":" + ss[add + 2].Substring(4);
                    DateTime dt = DateTime.Parse(pos.GpsTime);
                    dt = dt.AddHours(8);
                    pos.GpsTime = dt.ToString("yyyy-MM-dd HH:mm:ss");
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
                        "低电传感器1搭铁",      "高电传感器2为高",  "高电传感器1为高",  "电瓶拆除报警",
                        "车辆断油电",           "GPRS阻塞报警",     "三次密码错误报警", "温度报警",
                        "低电传感器2搭铁",      "GPS天线短路",      "GPS天线开路",      "电瓶被拆除",
                        "主机由后备电池供电",   "",                 "",                 "GPS接收机故障",
                        "超速",                 "自定义报警",       "发动机开",         "",
                        "",                     "",                 "车辆设防",         "车门开",
                        "禁止驶出越界报警",     "GPS天线短路报警",  "GPS天线开路报警",  "禁止驶入越界报警",
                        "非法点火报警",         "超速报警",         "劫警",             "盗警"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("警") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
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
                return pos;
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
                
                String[] lines = src.Split(new string[]{HEAD}, StringSplitOptions.RemoveEmptyEntries);
                foreach(String line in lines)
                    if(line != "")
                    {
                        Position pos = null;
                        if(gprs)
                        {
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
                stb.Append("S5").Append(DateTime.Now.ToString(",HHmmss")).Append(",1,0,").Append(FOOT);
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
                    case OD_SET_GPRS_CENTER://设置GPRS中心
                        stb.Append("S23").Append(time).Append(",").Append(content);
                        remark = "设置GPRS中心";/*:" + content.Replace(';', '.');
                        remark = remark.Insert(remark.LastIndexOf('.') + 1, ";重连");
                        remark = remark.Remove(remark.LastIndexOf('.'), 1);
                        remark = remark.Insert(remark.LastIndexOf('.') + 1, ";端口");
                        remark = remark.Remove(remark.LastIndexOf('.'), 1);
                        remark = remark + "次";*/
                        break;
                    case OD_SET_ALARM_SPEED://设置超速报警速度
                        String[] ss = content.Split(',');
                        stb.Append("S14").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[0])));
                        stb.Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[1]))).Append(",1,").Append(ss[2]);
                        remark = "设置超速报警";/*速度:最低" + ss[0] + "km/h;最高" + ss[1] + "km/s;持续时间" + ss[2] + "s";*/
                        break;
                    case OD_SET_NOTIFY_SPEED://设置超速提示速度
                        stb.Append("S33").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(content)));
                        remark = "设置超速提示";/*速度:" + content + "km/h";*/
                        break;
                    case OD_SET_ENCLOSURE://设置电子围栏
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "设置电子围栏";
                        break;
                    case OD_SET_CALL_LIMIT://设置呼叫限制
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "设置呼叫限制";
                        break;
                    case OD_SET_AUTO_UPLOAD://自动回传
                        String[] ss1 = content.Split(',');
                        remark = "设置自动回传";/*:" + ss1[0] + "s回传";*/
                        if(ss1[1] == "0")
                        {
                            stb.Append("S17").Append(time).Append(",").Append(ss1[0]);
                            remark = remark + ";无限次";
                        }
                        else
                        {
                            stb.Append("D1").Append(time).Append(",").Append(ss1[0]).Append(",").Append(ss1[1]);
                            remark = remark + ";" + ss1[1] + "次";
                        }
                        break;
                    case OD_SET_CUTDOWN://断油断电
                        String[] ss2 = content.Split(',');
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "恢复油电";
                        else  remark = "断油断电";
                        break;
                    case OD_SET_CUSTOM_ALARM://自定义报警
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "设置自定义报警";
                        break;
                    case OD_SET_PARAM://设置终端参数
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "设置终端参数";
                        break;
                    case OD_SET_DOOR://远程开关门
                        stb.Append("S6").Append(time).Append(",").Append(content);
                        if(content == "0")
                            remark = "远程开门";
                        else remark = "远程关门";
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
            String ret = "";
            remark = "";
            return ret;
        }
    }
}
