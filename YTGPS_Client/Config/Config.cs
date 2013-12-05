using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace YTGPS_Client
{
    /// <summary>
    /// ͼ������
    /// </summary>
    public class GeoInfoLayer
    {
        public const int REGION_LAYER = 0;
        public const int POINT_LAYER = 1;

        private String tableName = "";
        private String colName = "Name";
        private int type = REGION_LAYER;
        private int distance = 100;
        private String head = "";
        private String foot = "";

        #region get/set
        /// <summary>
        /// ͼ����
        /// </summary>
        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public String ColName
        {
            get { return colName; }
            set { colName = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// ������Χ
        /// </summary>
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        /// <summary>
        /// ��Ϣͷ
        /// </summary>
        public String Head
        {
            get { return head; }
            set { head = value; }
        }
        /// <summary>
        /// ��Ϣβ
        /// </summary>
        public String Foot
        {
            get { return foot; }
            set { foot = value; }
        }
        #endregion

        public GeoInfoLayer()
        {
        }

        public GeoInfoLayer(String tname, String cName, int ltype, int dis, String h, String f)
        {
            tableName = tname;
            colName = cName;
            type = ltype;
            distance = dis;
            head = h;
            foot = f;
        }

        public GeoInfoLayer(GeoInfoLayer gl)
        {
            tableName = gl.tableName;
            colName = gl.colName;
            type = gl.type;
            distance = gl.distance;
            head = gl.head;
            foot = gl.foot;
        }
    }
    /// <summary>
    /// ��ͼ
    /// </summary>
    public class MapFile
    {
        private String name;
        private String file;
        private List<GeoInfoLayer> geoInfoList = new List<GeoInfoLayer>();
        /// <summary>
        /// ��ͼ��
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// gst�ļ�
        /// </summary>
        public String File
        {
            get { return file; }
            set { file = value; }
        }
        public MapFile()
        {
        }
        public MapFile(String s1, String s2)
        {
            name = s1;
            file = s2;
        }
        public MapFile(MapFile mf)
        {
            name = mf.name;
            file = mf.file;
            foreach(GeoInfoLayer gl in mf.geoInfoList)
                geoInfoList.Add(new GeoInfoLayer(gl));
        }
        /// <summary>
        /// ͼ�������б�
        /// </summary>
        public List<GeoInfoLayer> GeoInfoList
        {
            get { return geoInfoList; }
            set { geoInfoList = value; }
        }
    }
    /// <summary>
    /// ��½�ɹ��ķ�����
    /// </summary>
    public class HostConfig
    {
        private String host = "";
        private int port = 8800;

        public String Host
        {
            get { return host; }
            set { host = value; }
        }
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public HostConfig(String s1, int s2)
        {
            host = s1;
            port = s2;
        }
    }
    /// <summary>
    /// ��½�ɹ����û���
    /// </summary>
    public class UserConfig
    {
        private String name;
        private int type = 0;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public UserConfig(String s1, int s2)
        {
            Name = s1;
            Type = s2;
        }
    }
    /// <summary>
    /// �����ļ�
    /// </summary>
    public class Config
    {
        public static String APP_PATH = "";
        private static MapFile defaultMap = new MapFile();

        private static String FILE = "client.xml";
        private static List<MapFile> mapList = new List<MapFile>();

        private static bool autoLogin = false;
        private static String host = "";
        private static int port = 8800;
        private static int userType = 0;
        private static String user = "";
        private static String pw = "";

        private static bool autoReconn = true;
        private static bool autoAlarmList = true;
        private static bool autoWatchOnPoint = true;
        private static bool autoWatchOnHandleAlarm = true;
        private static bool autoChatForm = true;
        private static bool autoGetCarGeoInfo = true;
        public static double myzoom = 0;
        public static double lo = 0, la = 0;

        private static int gisPort = 8900;
        private static bool autoStartGis = false;

        private static int maxReconnInc = 20;

        private static bool alarmSound = true;
        private static bool notifySound = true;
        private static bool servWarnSound = true;
        private static bool connDownSound = true;

        private static List<HostConfig> hostList = new List<HostConfig>();
        private static List<UserConfig> userList = new List<UserConfig>();

        private static int preProtocol = 0;
        private static int preRouteway = 0;

        #region get/set
        /// <summary>
        /// Ĭ��ͼ������
        /// </summary>
        public static bool AutoGetCarGeoInfo
        {
            get { return Config.autoGetCarGeoInfo; }
            set { Config.autoGetCarGeoInfo = value; }
        }
        /// <summary>
        /// Ĭ�ϵ�ͼ
        /// </summary>
        public static MapFile DefaultMap
        {
            get { return Config.defaultMap; }
        }
        /// <summary>
        /// gis��չ�˿�
        /// </summary>
        public static int GisPort
        {
            get { return Config.gisPort; }
            set { Config.gisPort = value; }
        }
        /// <summary>
        /// ֪������gis��չ�˿�
        /// </summary>
        public static bool AutoStartGis
        {
            get { return Config.autoStartGis; }
            set { Config.autoStartGis = value; }
        }
        /// <summary>
        /// ǰ�������ָ��ͨ��
        /// </summary>
        public static int PreRouteway
        {
            get { return Config.preRouteway; }
            set { Config.preRouteway = value; }
        }
        /// <summary>
        /// ǰ�������Э��
        /// </summary>
        public static int PreProtocol
        {
            get { return Config.preProtocol; }
            set { Config.preProtocol = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public static bool AlarmSound
        {
            get { return Config.alarmSound; }
            set { Config.alarmSound = value; }
        }
        /// <summary>
        /// ��Ϣ��ʾ����
        /// </summary>
        public static bool NotifySound
        {
            get { return Config.notifySound; }
            set { Config.notifySound = value; }
        }
        /// <summary>
        /// ��������ַ
        /// </summary>
        public static String Host
        {
            get { return Config.host; }
            set { Config.host = value; }
        }
        /// <summary>
        /// �������˿�
        /// </summary>
        public static int Port
        {
            get { return Config.port; }
            set { Config.port = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public static int UserType
        {
            get { return Config.userType; }
            set { Config.userType = value; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public static String User
        {
            get { return Config.user; }
            set { Config.user = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public static String Pw
        {
            get { return Config.pw; }
            set { Config.pw = value; }
        }
        /// <summary>
        /// �Զ���½
        /// </summary>
        public static bool AutoLogin
        {
            get { return Config.autoLogin; }
            set { Config.autoLogin = value; }
        }
        /// <summary>
        /// �Զ�����
        /// </summary>
        public static bool AutoReconn
        {
            get { return Config.autoReconn; }
            set { Config.autoReconn = value; }
        }
        /// <summary>
        /// �Զ����������б�
        /// </summary>
        public static bool AutoAlarmList
        {
            get { return Config.autoAlarmList; }
            set { Config.autoAlarmList = value; }
        }
        /// <summary>
        /// ��λ���Զ����
        /// </summary>
        public static bool AutoWatchOnPoint
        {
            get { return Config.autoWatchOnPoint; }
            set { Config.autoWatchOnPoint = value; }
        }
        /// <summary>
        /// �Ӿ�ʱ�Զ����
        /// </summary>
        public static bool AutoWatchOnHandleAlarm
        {
            get { return Config.autoWatchOnHandleAlarm; }
            set { Config.autoWatchOnHandleAlarm = value; }
        }
        /// <summary>
        /// �Զ�̸��������Ϣ
        /// </summary>
        public static bool AutoChatForm
        {
            get { return Config.autoChatForm; }
            set { Config.autoChatForm = value; }
        }
        /// <summary>
        /// ����¼��
        /// </summary>
        public static int MaxReconnInc
        {
            get { return Config.maxReconnInc; }
            set { Config.maxReconnInc = value; }
        }
        /// <summary>
        /// ��ͼ�б�
        /// </summary>
        internal static List<MapFile> MapList
        {
            get { return Config.mapList; }
            set { Config.mapList = value; }
        }
        /// <summary>
        /// ��½�ɹ���������¼
        /// </summary>
        public static List<HostConfig> LoginList
        {
            get { return Config.hostList; }
            set { Config.hostList = value; }
        }
        /// <summary>
        /// ��½�ɹ��û���¼
        /// </summary>
        public static List<UserConfig> UserList
        {
            get { return Config.userList; }
            set { Config.userList = value; }
        }
        /// <summary>
        /// ������������Ϣ����
        /// </summary>
        public static bool ServWarnSound
        {
            get { return Config.servWarnSound; }
            set { Config.servWarnSound = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public static bool ConnDownSound
        {
            get { return Config.connDownSound; }
            set { Config.connDownSound = value; }
        }
        #endregion

        private Config()
        {
        }

        private static String readXmlNode(XmlElement node, String name)
        {
            return node.GetElementsByTagName(name)[0].InnerText;
        }

        private static void addTextNode(XmlDocument XMLDom, XmlElement node, String name, String text)
        {
            XmlElement e = XMLDom.CreateElement(name);
            e.InnerText = text;
            node.AppendChild(e);
        }

        private static XmlElement addNode(XmlDocument XMLDom, XmlElement node, String name)
        {
            XmlElement e = XMLDom.CreateElement(name);
            node.AppendChild(e);
            return e;
        }
        /// <summary>
        /// ���������ļ�
        /// </summary>
        /// <returns></returns>
        public static bool loadFromFile()
        {
            defaultMap.Name = "ȫ��ͼ";
            defaultMap.File = APP_PATH + "maps\\china\\map.gst";
            defaultMap.GeoInfoList.Clear();
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("ʡ��", "Name", 0, 0, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("�н�", "Name", 0, 0, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("���ؽ�", "Name", 0, 0, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("����", "Name", 1, 200, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("ʡ��", "Name", 1, 200, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("�е�", "Name", 1, 150, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("�ص�", "Name", 1, 100, "", ""));
            defaultMap.GeoInfoList.Add(new GeoInfoLayer("��Ϣ��", "Name", 1, 200, "", "����"));
            bool ret = false;
            try
            {
                XmlDocument XMLDom = new XmlDocument();
                XMLDom.Load(APP_PATH + FILE);
                XmlElement root = XMLDom.DocumentElement;
                host = readXmlNode(root, "host");
                port = Int32.Parse(readXmlNode(root, "port"));
                userType = Int32.Parse(readXmlNode(root, "userType"));
                user = readXmlNode(root, "user");
                pw = Pub.decode(readXmlNode(root, "pw"));
                autoLogin = (readXmlNode(root, "autoLogin") == "1");
                autoReconn = (readXmlNode(root, "autoReconn") == "1");
                autoAlarmList = (readXmlNode(root, "autoAlarmList") == "1");
                autoWatchOnPoint = (readXmlNode(root, "autoWatchOnPoint") == "1");
                autoWatchOnHandleAlarm = (readXmlNode(root, "autoWatchOnHandleAlarm") == "1");
                autoChatForm = (readXmlNode(root, "autoChatForm") == "1");
                autoGetCarGeoInfo = (readXmlNode(root, "autoGetCarGeoInfo") == "1");
                gisPort = Int32.Parse(readXmlNode(root, "telPort"));
                autoStartGis = (readXmlNode(root, "autoStartGis") == "1");

                myzoom = double.Parse(readXmlNode(root, "myzoom"));
                lo = double.Parse(readXmlNode(root,"lo"));
                la = double.Parse(readXmlNode(root,"la"));

                XmlNodeList mlist = root.GetElementsByTagName("maps"); 
                

                mapList.Clear();
                for(int i = 0; i < mlist.Count; i++)
                {
                    MapFile mf = new MapFile(readXmlNode(mlist.Item(i) as XmlElement, "name"), readXmlNode(mlist.Item(i) as XmlElement, "file"));
                    XmlNodeList llist = (mlist[i] as XmlElement).GetElementsByTagName("layers");
                    for(int j = 0; j < llist.Count; j++)
                    {
                        GeoInfoLayer gi = new GeoInfoLayer();
                        gi.TableName = readXmlNode(llist.Item(j) as XmlElement, "tableName");
                        gi.ColName = readXmlNode(llist.Item(j) as XmlElement, "colName");
                        gi.Type = Int32.Parse(readXmlNode(llist.Item(j) as XmlElement, "type"));
                        gi.Distance = Int32.Parse(readXmlNode(llist.Item(j) as XmlElement, "distance"));
                        gi.Head = readXmlNode(llist.Item(j) as XmlElement, "head");
                        gi.Foot = readXmlNode(llist.Item(j) as XmlElement, "foot");
                        mf.GeoInfoList.Add(gi);
                    }
                    mapList.Add(mf);
                }
                XmlNodeList hlist = root.GetElementsByTagName("hosts");
                hostList.Clear();
                for(int i = 0; i < hlist.Count; i++)
                {
                    hostList.Add(new HostConfig(readXmlNode(hlist.Item(i) as XmlElement, "host"), Int32.Parse(readXmlNode(hlist.Item(i) as XmlElement, "port"))));
                }
                XmlNodeList ulist = root.GetElementsByTagName("users");
                userList.Clear();
                for(int i = 0; i < ulist.Count; i++)
                {
                    userList.Add(new UserConfig(readXmlNode(ulist.Item(i) as XmlElement, "name"), Int32.Parse(readXmlNode(ulist.Item(i) as XmlElement, "type"))));
                }
                ret = true;
                

            
            }
            catch
            {
                saveToFile();
            }
            return ret;
        }
        /// <summary>
        /// ���浽�����ļ�
        /// </summary>
        public static void saveToFile()
        {
            XmlDocument XMLDom = new XmlDocument();
            XMLDom.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\" ?><set></set>");
            XmlElement root = XMLDom.DocumentElement;
            addTextNode(XMLDom, root, "host", host);
            addTextNode(XMLDom, root, "port", port.ToString());
            addTextNode(XMLDom, root, "userType", userType.ToString());
            addTextNode(XMLDom, root, "user", user);
            addTextNode(XMLDom, root, "pw", Pub.encode(pw));
            addTextNode(XMLDom, root, "autoLogin", (autoLogin ? "1" : "0"));
            addTextNode(XMLDom, root, "autoReconn", (autoReconn ? "1" : "0"));
            addTextNode(XMLDom, root, "autoAlarmList", (autoAlarmList ? "1" : "0"));
            addTextNode(XMLDom, root, "autoWatchOnPoint", (autoWatchOnPoint ? "1" : "0"));
            addTextNode(XMLDom, root, "autoWatchOnHandleAlarm", (autoWatchOnHandleAlarm ? "1" : "0"));
            addTextNode(XMLDom, root, "autoChatForm", (autoChatForm ? "1" : "0"));
            addTextNode(XMLDom, root, "autoGetCarGeoInfo", (autoGetCarGeoInfo ? "1" : "0"));
            addTextNode(XMLDom, root, "telPort", gisPort.ToString());
            addTextNode(XMLDom, root, "autoStartGis", (autoStartGis ? "1" : "0"));
            addTextNode(XMLDom, root, "myzoom", myzoom.ToString());
            addTextNode(XMLDom, root, "lo", lo.ToString());
            addTextNode(XMLDom, root, "la", la.ToString());


            if(mapList.Count == 0)
                mapList.Add(defaultMap);
            for(int i = 0; i < mapList.Count; i++)
            {
                XmlElement m = addNode(XMLDom, root, "maps");
                addTextNode(XMLDom, m, "name", mapList[i].Name);
                addTextNode(XMLDom, m, "file", mapList[i].File);
                foreach(GeoInfoLayer gi in mapList[i].GeoInfoList)
                {
                    XmlElement l = addNode(XMLDom, m, "layers");
                    addTextNode(XMLDom, l, "tableName", gi.TableName);
                    addTextNode(XMLDom, l, "colName", gi.ColName);
                    addTextNode(XMLDom, l, "type", gi.Type.ToString());
                    addTextNode(XMLDom, l, "distance", gi.Distance.ToString());
                    addTextNode(XMLDom, l, "head", gi.Head);
                    addTextNode(XMLDom, l, "foot", gi.Foot);
                }
            }
            for(int i = 0; i < hostList.Count; i++)
            {
                XmlElement m = addNode(XMLDom, root, "hosts");
                addTextNode(XMLDom, m, "host", hostList[i].Host);
                addTextNode(XMLDom, m, "port", hostList[i].Port.ToString());
            }
            for(int i = 0; i < userList.Count; i++)
            {
                XmlElement m = addNode(XMLDom, root, "users");
                addTextNode(XMLDom, m, "name", userList[i].Name);
                addTextNode(XMLDom, m, "type", userList[i].Type.ToString());
            }
            XMLDom.Save(APP_PATH + FILE);
        }
        /// <summary>
        /// �����½�ɹ��ķ��������û�
        /// </summary>
        /// <param name="h"></param>
        /// <param name="p"></param>
        /// <param name="utp"></param>
        /// <param name="u"></param>
        public static void AddLogin(String h, int p, int utp, String u)
        {
            bool hasin = false;
            foreach(HostConfig hc in hostList)
                if(hc.Host == h && hc.Port == p)
                {
                    hasin = true;
                    hostList.Remove(hc);
                    hostList.Insert(0, hc);
                    break;
                }
            if(!hasin)
            {
                HostConfig hc = new HostConfig(h, p);
                hostList.Insert(0, hc);
                while(hostList.Count > 10)
                    hostList.RemoveAt(hostList.Count - 1);
            }
            hasin = false;
            foreach(UserConfig ur in userList)
                if(ur.Name == u && ur.Type == utp)
                {
                    hasin = true;
                    userList.Remove(ur);
                    userList.Insert(0, ur);
                    break;
                }
            if(!hasin)
            {
                UserConfig ur = new UserConfig(u, utp);
                userList.Insert(0, ur);
                while(userList.Count > 10)
                    userList.RemoveAt(userList.Count - 1);
            }
            saveToFile();
        }
    }
}
