using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// GPRSЭ��1Э��
    /// </summary>
    class Protocol_QiChuan
    {
        //*RS,123456789,V1,181003,A,2233.1055,N,11358.1257,E,51.00,000,070925,FFFFFBFD#
        public const String HEAD = "*RS,";
        public const String FOOT = "#";

        //order

        public const char OD_SET_SMS_NUM_M = 'A'; //���Ķ��ź��� 0
        public const char OD_SET_SMS_NUM_S = 'B';//���ĸ������ź���1
        public const char OD_SET_GPRS_CENTER = 'C';//����GPRS����2
        public const char OD_SET_ALARM_SPEED  = 'D';//���ó��ٱ����ٶ�3
        public const char OD_SET_NOTIFY_SPEED = 'E';//���ó�����ʾ�ٶ�4
        public const char OD_SET_ENCLOSURE = 'F';//���õ���Χ��5
        public const char OD_SET_CALL_LIMIT = 'G';//���ú�������6
        public const char OD_SET_AUTO_UPLOAD = 'H';//�����Զ��ش�7
        public const char OD_SET_WATCHING = 'I';//����8
        public const char OD_SET_CUTDOWN = 'J';//���Ͷϵ�9
        public const char OD_SET_CUSTOM_ALARM = 'K';//�����Զ��屨��10
        public const char OD_SET_PARAM = 'L';//�����ն˲���
        public const char OD_SET_DOOR = 'M';//Զ�̿�����12



        public const char OD_CTR_FREE_ALARM = 'a';//�������
        public const char OD_CTR_REBOOT = 'b';//�����ն�
        public const char OD_CTR_RESET = 'c';//�ظ���������
        public const char OD_CTR_QUERY_MILE = 'd';//��ѯ���

        //���Ŷ�λ��Ϣ
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
                        "�͵紫����1����",      "�ߵ紫����2Ϊ��",  "�ߵ紫����1Ϊ��",  "��ƿ�������",
                        "�������͵�",           "GPRS��������",     "����������󱨾�", "�¶ȱ���",
                        "�͵紫����2����",      "GPS���߶�·",      "GPS���߿�·",      "��ƿ�����",
                        "�����ɺ󱸵�ع���",   "",                 "",                 "GPS���ջ�����",
                        "����",                 "�Զ��屨��",       "��������",         "",
                        "",                     "",                 "�������",         "���ſ�",
                        "��ֹʻ��Խ�籨��",     "GPS���߶�·����",  "GPS���߿�·����",  "��ֹʻ��Խ�籨��",
                        "�Ƿ���𱨾�",         "���ٱ���",         "�پ�",             "����"
                    };
                for(int i = 0; i < 32; i++)
                    if(hex[i] == '0' && status[i] != "")
                    {
                        if(status[i].IndexOf("��") > 0)
                            pos.Alarm = pos.Alarm + status[i] + " ";
                        else pos.Status = pos.Status + status[i] + " ";
                    }
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
                return pos;
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
                stb.Append("S5").Append(DateTime.Now.ToString(",HHmmss")).Append(",1,0,").Append(FOOT);
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
                    case OD_SET_GPRS_CENTER://����GPRS����
                        stb.Append("S23").Append(time).Append(",").Append(content);
                        remark = "����GPRS����";/*:" + content.Replace(';', '.');
                        remark = remark.Insert(remark.LastIndexOf('.') + 1, ";����");
                        remark = remark.Remove(remark.LastIndexOf('.'), 1);
                        remark = remark.Insert(remark.LastIndexOf('.') + 1, ";�˿�");
                        remark = remark.Remove(remark.LastIndexOf('.'), 1);
                        remark = remark + "��";*/
                        break;
                    case OD_SET_ALARM_SPEED://���ó��ٱ����ٶ�
                        String[] ss = content.Split(',');
                        stb.Append("S14").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[0])));
                        stb.Append(",").Append(Pub.KmsToKts(Int32.Parse(ss[1]))).Append(",1,").Append(ss[2]);
                        remark = "���ó��ٱ���";/*�ٶ�:���" + ss[0] + "km/h;���" + ss[1] + "km/s;����ʱ��" + ss[2] + "s";*/
                        break;
                    case OD_SET_NOTIFY_SPEED://���ó�����ʾ�ٶ�
                        stb.Append("S33").Append(time).Append(",").Append(Pub.KmsToKts(Int32.Parse(content)));
                        remark = "���ó�����ʾ";/*�ٶ�:" + content + "km/h";*/
                        break;
                    case OD_SET_ENCLOSURE://���õ���Χ��
                        stb.Append("S21").Append(time).Append(",").Append(content);
                        remark = "���õ���Χ��";
                        break;
                    case OD_SET_CALL_LIMIT://���ú�������
                        stb.Append("S5").Append(time).Append(",").Append(content);
                        remark = "���ú�������";
                        break;
                    case OD_SET_AUTO_UPLOAD://�Զ��ش�
                        String[] ss1 = content.Split(',');
                        remark = "�����Զ��ش�";/*:" + ss1[0] + "s�ش�";*/
                        if(ss1[1] == "0")
                        {
                            stb.Append("S17").Append(time).Append(",").Append(ss1[0]);
                            remark = remark + ";���޴�";
                        }
                        else
                        {
                            stb.Append("D1").Append(time).Append(",").Append(ss1[0]).Append(",").Append(ss1[1]);
                            remark = remark + ";" + ss1[1] + "��";
                        }
                        break;
                    case OD_SET_CUTDOWN://���Ͷϵ�
                        String[] ss2 = content.Split(',');
                        stb.Append("S20").Append(time).Append(",").Append(content);
                        if(ss2[1] == "0")
                            remark = "�ָ��͵�";
                        else  remark = "���Ͷϵ�";
                        break;
                    case OD_SET_CUSTOM_ALARM://�Զ��屨��
                        stb.Append("S19").Append(time).Append(",").Append(content);
                        remark = "�����Զ��屨��";
                        break;
                    case OD_SET_PARAM://�����ն˲���
                        stb.Append("S12").Append(time).Append(",").Append(content);
                        remark = "�����ն˲���";
                        break;
                    case OD_SET_DOOR://Զ�̿�����
                        stb.Append("S6").Append(time).Append(",").Append(content);
                        if(content == "0")
                            remark = "Զ�̿���";
                        else remark = "Զ�̹���";
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
            String ret = "";
            remark = "";
            return ret;
        }
    }
}
