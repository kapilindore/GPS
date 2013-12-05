using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace YTGPS_Server
{
    /// <summary>
    /// GPRS协议3协议
    /// </summary>
    public class Protocol_VicZone
    {
        public const String HEAD = "*";
        public const String FOOT = "^";

       // public const char HEAD_HEX_1 = '$';
     //   public const char HEAD_HEX_2 = 'X';

        public const char OD_SET_ENCLOSURE = 'A';     
        
        public const char OD_SET_SMS_NUM_M = 'G'; //中心短信号码
        public const char OD_SET_SMS_NUM_S = 'j';//中心辅助短信号码
        public const char OD_SET_APN = 'C';//设置接入点名称APN
        public const char OD_SET_GPRS_CENTER = 'D';//设置GPRS中心
        public const char OD_SET_ALARM_SPEED = 'E';//设置超速报警速度
        public const char OD_SET_NOTIFY_SPEED = 'F';//设置超速提示速度
       // public const char OD_SET_ENCLOSURE = 'A';//设置电子围栏
        public const char OD_SET_CALL_LIMIT = 'H';//设置呼叫限制
        public const char OD_SET_AUTO_UPLOAD1 = 'I';//设置自动回传(D1)
       // public const char OD_SET_AUTO_UPLOAD2 = 'J';//设置自动回传(S17)
        public const char OD_SET_WATCHING = 'K';//监听
        public const char OD_SET_CUTDOWN = 'L';//断油断电
        public const char OD_SET_CUSTOM_ALARM = 'M';//设置自定义报警
        public const char OD_SET_PARAM = 'N';//设置终端参数
        public const char OD_SET_TEMP_ALARM = 'O';//设置温度报警
        public const char OD_SET_SYSTEM = 'P';//系统设置
        public const char OD_SET_OVER_DRIVER = 'Q';//设置疲劳驾驶监控
        public const char OD_SET_DOOR = 'R';//远程开关门
        public const char OD_SET_FORTIFY = 'S';//远程设防
        public const char OD_SET_AUTO_UPLOAD2 = 'B';   

        public const char OD_CTR_FREE_ALARM = 'a';//解除报警
        public const char OD_CTR_CONFIRM_ALARM = 'b';//确认报警
        public const char OD_CTR_REBOOT = 'c';//重启终端
        public const char OD_CTR_RESET = 'd';//回复出厂设置
        public const char OD_CTR_QUERY_MILE = 'e';//查询里程
  
 
        public static Position GetSMSPos(String src)
        {
           

            Position pos = new Position();
            

            
          //   MessageBox.Show(src);
           
            pos.MNO = src.Substring(16, 15);

         //   pos.MNO = pos.MNO.Substring(6, 2) + pos.MNO.Substring(4, 2) + pos.MNO.Substring(2, 2) + pos.MNO.Substring(0, 2);

             //   MessageBox.Show(pos.MNO);
            
           // var id = Int32.Parse("c0801081", System.Clobalization.NumberStyles.HexNumber);
// var newid = IPAddress.HostToNetworkOrder( id );
            pos.GpsTime = "20" + src.Substring(0, 2) + "-" + src.Substring(2, 2) + "-" + src.Substring(4,2) + " " + src.Substring(6, 2) + ":" + src.Substring(8, 2) + ":" + src.Substring(10, 2);
            if (src.IndexOf('A') >= 0)
            {
                String[] ss = src.Split('A');
                src = ss[1];
                pos.Pointed = 1;
                pos.La = Double.Parse(src.Substring(0, 2)) + (Double.Parse(src.Substring(2, 2)) / 60 + ((Double.Parse(src.Substring(5, 4))) / 10000) / 60);
                pos.Lo = Double.Parse(src.Substring(10, 3)) + (Double.Parse(src.Substring(13, 2)) / 60 + ((Double.Parse(src.Substring(16, 4))) / 10000) / 60); //精度
                pos.Speed = Pub.KtsToKms((int)(Double.Parse(src.Substring(21, 3)) + 0.1 * Double.Parse(src.Substring(25, 1))));
                double dir = Double.Parse(src.Substring(32, 3)) + 0.01 * Double.Parse(src.Substring(36, 2));
                if (dir < 90) pos.Direction = 1;
                else if (dir == 90) pos.Direction = 2;
                else if (dir < 180) pos.Direction = 3;
                else if (dir == 180) pos.Direction = 4;
                else if (dir < 270) pos.Direction = 5;
                else if (dir == 270) pos.Direction = 6;
                else if (dir > 270) pos.Direction = 7;
                pos.Mileage = (int)(Double.Parse(src.Substring(47, 6)) / 1000);
                pos.AlarmHandle = 0;

            }
            else
            {
                String[] ss = src.Split('V');
                src = ss[1];
                pos.Pointed = 0;
                pos.La = Double.Parse(src.Substring(0, 2)) + (Double.Parse(src.Substring(2, 2)) / 60 + ((Double.Parse(src.Substring(5, 4))) / 10000) / 60);
                pos.Lo = Double.Parse(src.Substring(10, 3)) + (Double.Parse(src.Substring(13, 2)) / 60 + ((Double.Parse(src.Substring(16, 4))) / 10000) / 60); //精度
                pos.Speed = Pub.KtsToKms((int)(Double.Parse(src.Substring(21, 3)) + 0.1 * Double.Parse(src.Substring(25, 1))));
                double dir = Double.Parse(src.Substring(32, 3)) + 0.01 * Double.Parse(src.Substring(36, 2));
                if (dir < 90) pos.Direction = 1;
                else if (dir == 90) pos.Direction = 2;
                else if (dir < 180) pos.Direction = 3;
                else if (dir == 180) pos.Direction = 4;
                else if (dir < 270) pos.Direction = 5;
                else if (dir == 270) pos.Direction = 6;
                else if (dir > 270) pos.Direction = 7;
                pos.Mileage = (int)(Double.Parse(src.Substring(47, 6)) / 1000);
                pos.AlarmHandle = 0;

            
            
            
            
            
            
            }

            
            
            /*
                        if((src.Substring(20,6)=="020301")||(src.Substring(20,6)=="020302")||(src.Substring(20,6)=="020307")||(src.Substring(20,6)=="020308")||(src.Substring(20,6)=="020304")||(src.Substring(20,6)=="02030B"))
                        {
                            try
                            {
                                pos.GpsTime = "20" + src.Substring(54, 2) + "-" + src.Substring(56, 2) + "-" + src.Substring(58, 2) + " " + src.Substring(60, 2) + ":" + src.Substring(62, 2) + ":" + src.Substring(64, 2);
                              //  MessageBox.Show(pos.GpsTime);

                                DateTime dt = DateTime.Parse(pos.GpsTime);
                                dt = dt.AddHours(8);
                                pos.GpsTime = dt.ToString("yyyy-MM-dd HH:mm:ss");

                            }
                            catch

                            { pos.GpsTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } 

                        pos.Pointed = 1;

                     //   pos.Mileage = (int)(((Double.Parse(src.Substring(46, 3)) + 0.1 * Double.Parse(src.Substring(49, 1))) * 0.51444 / 1000)); 
                       // pos.Mileage = 200;//(每移动200米报位一次.来计算

 


                        pos.La = Double.Parse(src.Substring(28, 2)) + (Double.Parse(src.Substring(30, 2))/60 +  ((Double.Parse(src.Substring(32, 4)))/10000)/60); // 维度
                        pos.Lo = Double.Parse(src.Substring(37, 3)) + (Double.Parse(src.Substring(40, 2))/60 +  ((Double.Parse(src.Substring(42, 4)))/10000)/60); //精度
                        pos.Speed = Pub.KtsToKms((int)(Double.Parse(src.Substring(46, 3)) + 0.1 * Double.Parse(src.Substring(49, 1))));
                        double dir = Double.Parse(src.Substring(50, 2)) + 0.1 * Double.Parse(src.Substring(52, 2));
                        if (dir < 90) pos.Direction = 1;
                        else if (dir == 90) pos.Direction = 2;
                        else if (dir < 180) pos.Direction = 3;
                        else if (dir == 180) pos.Direction = 4;
                        else if (dir < 270) pos.Direction = 5;
                        else if (dir == 270) pos.Direction = 6;
                        else if (dir > 270) pos.Direction = 7;

                        if (src.Substring(20, 6) == "020302") { pos.Alarm = "紧急报警" + ""; pos.Status = pos.Status + "ACC开"; }
                        if (src.Substring(20, 6) == "020307") { pos.Alarm = "断电报警" + ""; pos.Status = pos.Status + "ACC开"; }
                        if (src.Substring(20, 6) == "02030B") { pos.Alarm = "超速报警" + ""; pos.Status = pos.Status + "ACC开"; }
                        if (src.Substring(20, 6) == "020304") { pos.Alarm = "区域报警" + ""; pos.Status = pos.Status + "ACC开"; }                                 
                        pos.AlarmHandle = (pos.Alarm == "") ? 0 : 1;


                     //  pos.IsGetSetMsg = true;
                     //  pos.SettingStr = src;//硬件目前无独立获得设置命令 
            
  
         
                        }
            
            
             */
            return pos;
          

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
           

            if (src.IndexOf(HEAD) >= 0)
            {

              
                List<Position> list = new List<Position>();

                String[] lines = src.Split(new string[] { HEAD }, StringSplitOptions.RemoveEmptyEntries);
                //
                foreach (String line in lines)
                    if (line != "")
                    {
                        Position pos = null;
                        
                        
                        if (gprs)
                        {
                         
                            pos = GetGPRSPos(line.Substring(0, line.Length - 1));
                        }
                        else
                        {
                            pos = GetSMSPos(line.Substring(0, line.Length - 1));
                        }
                        if (pos != null)
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
                String flash;
                flash = mno.Substring(6, 2) + mno.Substring(4, 2) + mno.Substring(2, 2) + mno.Substring(0, 2);
                StringBuilder stb = new StringBuilder("@SJHX,").Append(flash).Append("7E7E00007E7E010501").Append("\r\n");
                return stb.ToString();
             
                

            
                
             /*
                StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",");
                stb.Append("010501");
                return stb.ToString();
                */

            }
        }
       
        //自动激活。自动下达20秒回传位置数据命令
        public static String AutoOrder(bool gprs, String mno)
        {
            if (gprs)
            {

                return "";

            }
            else
            {
                String flash;
                flash = mno.Substring(6, 2) + mno.Substring(4, 2) + mno.Substring(2, 2) + mno.Substring(0, 2);
                 StringBuilder stb = new StringBuilder("@SJHX,").Append(flash).Append("7E7E00007E7E0301031400").Append("\r\n");
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
                String flash;
                flash = mno.Substring(6, 2) + mno.Substring(4, 2) + mno.Substring(2, 2) + mno.Substring(0, 2);
                StringBuilder stb = new StringBuilder("@SJHX,").Append(flash).Append("7E7E00007E7E03010601").Append("\r\n");
                return stb.ToString();   //车机10秒回复一次GPRS维持报文.
            }
        }
        public static String BuildOrder(String mno, String content)
        {
            StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",").Append(content).Append(FOOT);
            return stb.ToString();
        }
        public static String CreateGPRSOrder(String mNO, char type, String content, out String remark)
        {
            string flash;
 



            flash = mNO.Substring(6, 2) + mNO.Substring(4, 2) + mNO.Substring(2, 2) + mNO.Substring(0, 2);
            try
            {
                StringBuilder stb = new StringBuilder("@SJHX,").Append(flash);
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
                        String[] str1 = content.Split(',');
                        if (str1[0] == "1") stb.Append("7E7E00007E7E030003").Append(str1[1]).Append("\r\n");
                        else stb.Append("7E7E00007E7E030003951234560116123456951234560116123456").Append("\r\n");
                        remark = "设置电子围栏";
                        break;
                    case OD_SET_CALL_LIMIT://设置呼叫限制
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "设置呼叫限制";
                        break;
                    case OD_SET_AUTO_UPLOAD2://顶事回传
                   



                        string str = "";
                        int a = IPAddress.NetworkToHostOrder(int.Parse(content));

                        byte[] btValue = BitConverter.GetBytes(a);




                        str = Convert.ToString(btValue[2], 16) + Convert.ToString(btValue[3], 16) + Convert.ToString(btValue[0], 16) + Convert.ToString(btValue[1], 16); //低字节在前

                        str = str.ToUpper();

                  //      str = str.Substring(2, 2) + str.Substring(0, 2);

                  
                       
                     

                           //http://blog.csdn.net/lcj8/archive/2008/04/24/2323451.aspx 参考文件
                  

                 
 

                            
                       
                       
                       
                       stb.Append("7E7E00007E7E030103").Append(str).Append("\r\n");
                        remark = "设置定时自动回传数据时间";
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
                        stb.Append("7E7E00007E7E03020100\r\n");
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
                    case OD_SET_APN: // 设置距离回传时间 50 米倍数

                        string strf = "";
                        int b = IPAddress.NetworkToHostOrder(int.Parse(content));

                        byte[] btValue_1 = BitConverter.GetBytes(b);
                        strf=Convert.ToString(btValue_1[2], 16) + Convert.ToString(btValue_1[3], 16);

                        strf = strf.ToUpper();
                        stb.Append("7E7E00007E7E030105").Append(strf).Append("\r\n");
                        remark = "设置距离倍数";
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
        
    }             // 类封装


}               //名字空间封装




