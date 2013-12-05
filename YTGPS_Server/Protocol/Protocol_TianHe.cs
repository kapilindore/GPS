using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// GPRSЭ��2Э��
    /// </summary>
    public class Protocol_TianHe
    {
        public const String HEAD = "*HQ,";
        public const String FOOT = "#";

        public const char HEAD_HEX_1 = '$';
        public const char HEAD_HEX_2 = 'X';

        public const char OD_SET_SMS_NUM_M = 'A'; //���Ķ��ź���
        public const char OD_SET_SMS_NUM_S = 'B';//���ĸ������ź���
        public const char OD_SET_APN = 'C';//���ý��������APN
        public const char OD_SET_GPRS_CENTER = 'D';//����GPRS����
        public const char OD_SET_ALARM_SPEED = 'E';//���ó��ٱ����ٶ�
        public const char OD_SET_NOTIFY_SPEED = 'F';//���ó�����ʾ�ٶ�
        public const char OD_SET_ENCLOSURE = 'G';//���õ���Χ��
        public const char OD_SET_CALL_LIMIT = 'H';//���ú�������
        public const char OD_SET_AUTO_UPLOAD1 = 'I';//�����Զ��ش�(D1)
        public const char OD_SET_AUTO_UPLOAD2 = 'J';//�����Զ��ش�(S17)
        public const char OD_SET_WATCHING = 'K';//����
        public const char OD_SET_CUTDOWN = 'L';//���Ͷϵ�
        public const char OD_SET_CUSTOM_ALARM = 'M';//�����Զ��屨��
        public const char OD_SET_PARAM = 'N';//�����ն˲���
        public const char OD_SET_TEMP_ALARM = 'O';//�����¶ȱ���
        public const char OD_SET_SYSTEM = 'P';//ϵͳ����
        public const char OD_SET_OVER_DRIVER = 'Q';//����ƣ�ͼ�ʻ���
        public const char OD_SET_DOOR = 'R';//Զ�̿�����
        public const char OD_SET_FORTIFY = 'S';//Զ�����


        public const char OD_CTR_FREE_ALARM = 'a';//�������
        public const char OD_CTR_CONFIRM_ALARM = 'b';//ȷ�ϱ���
        public const char OD_CTR_REBOOT = 'c';//�����ն�
        public const char OD_CTR_RESET = 'd';//�ظ���������
        public const char OD_CTR_QUERY_MILE = 'e';//��ѯ���
        //���Ŷ�λ��Ϣ
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
                else pos.IsPointMsg = true;//��Э���޵�����λָ�ֻ����v1����
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
                        "�͵紫����1����",      "�ߵ紫����2Ϊ��",      "�ߵ紫����1Ϊ��",      "��ƿ�������",
                        "�������͵�",           "GPRS��������",         "����������󱨾�",     "�¶ȱ���",
                        "�͵紫����2����",      "GPS���߶�·",          "GPS���߿�·",          "��ƿ�����",
                        "�����ɺ󱸵�ع���",   "",                     "",                     "GPS���߹��ϱ���",
                        "����",                 "�Զ��屨��",           "��������",             "",
                        "",                     "ACC��",                "�������",             "���ſ�",
                        "��ֹʻ��Խ�籨��",     "GPS���߶�·����",      "GPS���߿�·����",      "��ֹʻ��Խ�籨��",
                        "�Ƿ���𱨾�",         "���ٱ���",             "�پ�",                 "����"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("��") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
                if(pos.Status.IndexOf("ACC��") < 0)
                    pos.Status = pos.Status + "ACC��";
                pos.AlarmHandle = (pos.Alarm == "") ? 0 : 1;
                return pos;
            }
            catch { }
            return null;
        }
        //gprs/cdma��λ��Ϣ
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
        //�������յ������ݣ����ض�λ��Ϣ�б�
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
        //gprs/cdmaѹ����Ϣ
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
                 * GPRSЭ��2Э��ͣ���ϴ�����ʱ��gpsʱ�䲻�䣬����ȡ������ʱ��
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
                        "�͵紫����1����",      "�ߵ紫����2Ϊ��",      "�ߵ紫����1Ϊ��",      "��ƿ�������",
                        "�������͵�",           "GPRS��������",         "����������󱨾�",     "�¶ȱ���",
                        "�͵紫����2����",      "GPS���߶�·",          "GPS���߿�·",          "��ƿ�����",
                        "�����ɺ󱸵�ع���",   "",                     "",                     "GPS���߹��ϱ���",
                        "����",                 "�Զ��屨��",           "��������",             "",
                        "",                     "ACC��",                "�������",             "���ſ�",
                        "��ֹʻ��Խ�籨��",     "GPS���߶�·����",      "GPS���߿�·����",      "��ֹʻ��Խ�籨��",
                        "�Ƿ���𱨾�",         "���ٱ���",             "�پ�",                 "����"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("��") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
                if(pos.Status.IndexOf("ACC��") < 0)
                    pos.Status = pos.Status + "ACC��";
                pos.AlarmHandle = (pos.Alarm == "") ? 0 : 1;
                return pos;
            }
            catch { }
            return null;
        }
        //����ѹ����Ϣ
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
        //��λ
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
        //ȡ������
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
        //���ɶ���ָ��
        public static String CreateSMSOrder(String mno, char type, String content, out String remark)
        {
            try
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mno).Append(",");
                String time = DateTime.Now.ToString(",HHmmss");
                switch(type)
                {
                    case OD_SET_SMS_NUM_M://���Ķ��ź���
                        stb.Append("S2").Append(time).Append(",").Append(content);
                        remark = "�������Ķ��ź���:";// +content;
                        break;
                    case OD_SET_SMS_NUM_S://���ĸ������ź���
                        stb.Append("S28").Append(time).Append(",").Append(content);
                        remark = "�������ĸ������ź���:";// + content;
                        break;
                    case OD_SET_APN://����APN
                        stb.Append("S24").Append(time).Append(",1,").Append(content);
                        remark = "���ý��������APN";
                        break;
                    case OD_SET_GPRS_CENTER://����GPRS����
                        stb.Append("S23").Append(time).Append(",").Append(content);
                        remark = "����GPRS����";
                        break;
                    case OD_SET_ALARM_SPEED://���ó��ٱ����ٶ�
                        stb.Append("S14").Append(time).Append(",").Append(content);
                        remark = "���ó��ٱ���";
                        break;
                    case OD_SET_NOTIFY_SPEED://���ó�����ʾ�ٶ�
                        stb.Append("S33").Append(time).Append(",").Append(content);
                        remark = "���ó�����ʾ";
                        break;
                    case OD_SET_ENCLOSURE://���õ���Χ��
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "���õ���Χ��";
                        break;
                    case OD_SET_CALL_LIMIT://���ú�������
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "���ú�������";
                        break;
                    case OD_SET_AUTO_UPLOAD1://�Զ��ش�D1
                        String[] ss1 = content.Split(',');
                        stb.Append("S17").Append(time).Append(",").Append(content);
                        remark = "�����Զ��ش�";
                        break;
                    case OD_SET_AUTO_UPLOAD2://�Զ��ش�S17
                        stb.Append("S17").Append(time).Append(",").Append(content);
                        remark = "�����Զ��ش�";
                        break;
                    case OD_SET_WATCHING://����
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "����:" + content;
                        break;

                    case OD_SET_CUTDOWN://���Ͷϵ�
                        String[] ss2 = content.Split(',');
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "�ָ��͵�";
                        else remark = "���Ͷϵ�";
                        break;
                    case OD_SET_CUSTOM_ALARM://�Զ��屨��
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "�����Զ��屨��";
                        break;
                    case OD_SET_PARAM://�����ն˲���
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "�����ն˲���";
                        break;

                    case OD_CTR_FREE_ALARM://�������
                        stb.Append("R7").Append(time);
                        remark = "�������";
                        break;
                    case OD_CTR_REBOOT://�����ն�
                        stb.Append("R1").Append(time);
                        remark = "�����ն�";
                        break;
                    case OD_SET_WATCHING://����
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "����:" + content;
                        break;
                    case OD_CTR_RESET://�ظ���������
                        stb.Append("S25").Append(time);
                        remark = "�ظ���������";
                        break;
                    case OD_CTR_QUERY_MILE://��ѯ���
                        stb.Append("S32").Append(time).Append(",1");
                        remark = "��ѯ���";
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
        //����gprs/cdmaָ��
        public static String CreateGPRSOrder(String mNO, char type, String content, out String remark)
        {
            try
            {
                StringBuilder stb = new StringBuilder(HEAD).Append(mNO).Append(",");
                String time = DateTime.Now.ToString(",HHmmss");
                switch(type)
                {
                    case OD_SET_SMS_NUM_M://���Ķ��ź���
                        stb.Append("S2").Append(time).Append(",").Append(content);
                        remark = "�������Ķ��ź���:";// +content;
                        break;
                    case OD_SET_SMS_NUM_S://���ĸ������ź���
                        stb.Append("S28").Append(time).Append(",").Append(content);
                        remark = "�������ĸ������ź���:";// + content;
                        break;
                    case OD_SET_ALARM_SPEED://���ó��ٱ����ٶ�
                        String[] ss = content.Split(Constant.SPLIT2);
                        stb.Append("S14").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[0])));
                        stb.Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[1]))).Append(",1,").Append(ss[2]);
                        remark = "���ó��ٱ���";
                        break;
                    case OD_SET_NOTIFY_SPEED://���ó�����ʾ�ٶ�
                        stb.Append("S33").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(content)));
                        remark = "���ó�����ʾ";
                        break;
                    case OD_SET_ENCLOSURE://���õ���Χ��
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "���õ���Χ��";
                        break;
                    case OD_SET_CALL_LIMIT://���ú�������
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "���ú�������";
                        break;
                    case OD_SET_AUTO_UPLOAD1://�Զ��ش�
                        String[] ss1 = content.Split(Constant.SPLIT2);
                        stb.Append("S17").Append(time).Append(",").Append(ss1[0]);
                        remark = "�����Զ��ش�";
                        break;
                    case OD_SET_CUTDOWN://���Ͷϵ�
                        String[] ss2 = content.Split(Constant.SPLIT2);
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "�ָ��͵�";
                        else remark = "���Ͷϵ�";
                        break;
                    case OD_SET_CUSTOM_ALARM://�Զ��屨��
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "�����Զ��屨��";
                        break;
                    case OD_SET_PARAM://�����ն˲���
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "�����ն˲���";
                        break;

                    case OD_CTR_FREE_ALARM://�������
                        stb.Append("R7").Append(time);
                        remark = "�������";
                        break;
                    case OD_CTR_REBOOT://�����ն�
                        stb.Append("R1").Append(time);
                        remark = "�����ն�";
                        break;
                    case OD_SET_WATCHING://����
                        stb.Append("R8").Append(time).Append(",").Append(content);
                        remark = "����:" + content;
                        break;
                    case OD_CTR_RESET://�ظ���������
                        stb.Append("S25").Append(time);
                        remark = "�ظ���������";
                        break;
                    case OD_CTR_QUERY_MILE://��ѯ���
                        stb.Append("S32").Append(time).Append(",1");
                        remark = "��ѯ���";
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
