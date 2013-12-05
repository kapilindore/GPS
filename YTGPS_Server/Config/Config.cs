using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace YTGPS_Server
{
    public class SmsConfig
    {
        private  String smsName = "�ƶ�����ר��";
        /// <summary>
        /// ר������
        /// </summary>
        public String SmsName
        {
            get { return smsName; }
            set { smsName = value; }
        }

        private  String smsHost = "";
        /// <summary>
        /// ������
        /// </summary>
        public  String SmsHost
        {
            get { return smsHost; }
            set { smsHost = value; }
        }

        private  int smsPort = 8700;
        /// <summary>
        /// �˿�
        /// </summary>
        public  int SmsPort
        {
            get { return smsPort; }
            set { smsPort = value; }
        }

        private  String smsPw = "";
        /// <summary>
        /// ����
        /// </summary>
        public  String SmsPw
        {
            get { return smsPw; }
            set { smsPw = value; }
        }

        private bool enabled = true;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
    }

    public class Config
    {
        private static String FILE = "server.xml";
        /// <summary>
        /// ��������·��
        /// </summary>
        public  static String APP_PATH;
        //
        private static String dbHost = "(local)";
        /// <summary>
        /// ���ݿ������
        /// </summary>
        public static String DbHost
        {
            get { return Config.dbHost; }
            set { Config.dbHost = value; }
        }

        private static String dbName = "YTGPS_cs";
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static String DbName
        {
            get { return Config.dbName; }
            set { Config.dbName = value; }
        }

        private static String dbUser = "sa";
        /// <summary>
        /// ���ݿ��û���
        /// </summary>
        public static String DbUser
        {
            get { return Config.dbUser; }
            set { Config.dbUser = value; }
        }

        private static String dbPw = "";
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public static String DbPw
        {
            get { return Config.dbPw; }
            set { Config.dbPw = value; }
        }
        //
        private static List<SmsConfig> smsList = new List<SmsConfig>();
        /// <summary>
        /// ר���б�
        /// </summary>
        public static List<SmsConfig> SmsList
        {
            get { return Config.smsList; }
            set { Config.smsList = value; }
        }

        private static bool smsAutoStart = false;
        /// <summary>
        /// �Զ�����ר��
        /// </summary>
        public static bool SmsAutoStart
        {
            get { return Config.smsAutoStart; }
            set { Config.smsAutoStart = value; }
        }

        private static int dataPort = 8800;
        /// <summary>
        /// ���ݶ˿�
        /// </summary>
        public static int DataPort
        {
            get { return Config.dataPort; }
            set { Config.dataPort = value; }
        }

        private static String dataPw = "";
        /// <summary>
        /// ���ݶ˿���֤��
        /// </summary>
        public static String DataPw
        {
            get { return Config.dataPw; }
            set { Config.dataPw = value; }
        }

        private static bool dataAutoStart = false;
        /// <summary>
        /// �Զ��������ݶ˿�
        /// </summary>
        public static bool DataAutoStart
        {
            get { return Config.dataAutoStart; }
            set { Config.dataAutoStart = value; }
        }

        private static int gprsPort = 8500;
        /// <summary>
        /// gprs���ն˿�
        /// </summary>
        public static int GprsPort
        {
            get { return Config.gprsPort; }
            set { Config.gprsPort = value; }
        }

        private static int tcpCutTime = 30;
        /// <summary>
        /// tcp�Զ��ж���Ч���ӵ�ʱ��
        /// </summary>
        public static int TcpCutTime
        {
            get { return Config.tcpCutTime; }
            set { Config.tcpCutTime = value; }
        }
        private static bool gprsAutoStart = false;
        /// <summary>
        /// �Զ�����gprs���շ���
        /// </summary>
        public static bool GprsAutoStart
        {
            get { return Config.gprsAutoStart; }
            set { Config.gprsAutoStart = value; }
        }

        private static int modemPort = 8600;
        /// <summary>
        /// ����è����˿�
        /// </summary>
        public static int ModemPort
        {
            get { return Config.modemPort; }
            set { Config.modemPort = value; }
        }

        private static String modemPw = "";
        /// <summary>
        /// ����è������֤��
        /// </summary>
        public static String ModemPw
        {
            get { return Config.modemPw; }
            set { Config.modemPw = value; }
        }

        private static bool modemAutoStart = false;
        /// <summary>
        /// �Զ���������è����
        /// </summary>
        public static bool ModemAutoStart
        {
            get { return Config.modemAutoStart; }
            set { Config.modemAutoStart = value; }
        }

        private static bool allowChat = true;
        /// <summary>
        /// ��������
        /// </summary>
        public static bool AllowChat
        {
            get { return Config.allowChat; }
            set { Config.allowChat = value; }
        }

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
            bool ret = false;
            try
            {
                XmlDocument XMLDom = new XmlDocument();
                XMLDom.Load(APP_PATH + FILE);
                XmlElement root = XMLDom.DocumentElement;
                dbHost = readXmlNode(root, "dbHost");
                dbName = readXmlNode(root, "dbName");
                dbUser = Pub.Decode(readXmlNode(root, "dbUser"));
                dbPw = Pub.Decode(readXmlNode(root, "dbPw"));

                SmsList.Clear();
                XmlNodeList smsnds = root.GetElementsByTagName("smsConfig");
                foreach(XmlElement snd in smsnds)
                {
                    SmsConfig smsconfig = new SmsConfig();
                    smsconfig.SmsName = readXmlNode(snd, "smsName");
                    smsconfig.SmsHost = readXmlNode(snd, "smsHost");
                    smsconfig.SmsPort = Int32.Parse(readXmlNode(snd, "smsPort"));
                    smsconfig.SmsPw = Pub.Decode(readXmlNode(snd, "smsPw"));
                    smsconfig.Enabled = readXmlNode(snd, "enabled") == "1";
                    SmsList.Add(smsconfig);
                }
                smsAutoStart = readXmlNode(root, "smsAutoStart") == "1";

                dataPort = Int32.Parse(readXmlNode(root, "dataPort"));
                dataPw = readXmlNode(root, "dataPw");
                dataAutoStart = readXmlNode(root, "dataAutoStart") == "1";

                modemPort = Int32.Parse(readXmlNode(root, "modemPort"));
                modemPw = readXmlNode(root, "modemPw");
                modemAutoStart = readXmlNode(root, "modemAutoStart") == "1";

                gprsPort = Int32.Parse(readXmlNode(root, "gprsPort"));
                tcpCutTime = Int32.Parse(readXmlNode(root, "tcpCutTime"));
                gprsAutoStart = readXmlNode(root, "gprsAutoStart") == "1";

                allowChat = readXmlNode(root, "allowChat") == "1";

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
            addTextNode(XMLDom, root, "dbHost", dbHost);
            addTextNode(XMLDom, root, "dbName", dbName);
            addTextNode(XMLDom, root, "dbUser", Pub.Encode(dbUser));
            addTextNode(XMLDom, root, "dbPw", Pub.Encode(dbPw));

            foreach(SmsConfig smsconfig in SmsList)
            {
                XmlElement smsnd = addNode(XMLDom, root, "smsConfig");
                addTextNode(XMLDom, smsnd, "smsName", smsconfig.SmsName);
                addTextNode(XMLDom, smsnd, "smsHost", smsconfig.SmsHost);
                addTextNode(XMLDom, smsnd, "smsPort", smsconfig.SmsPort.ToString());
                addTextNode(XMLDom, smsnd, "smsPw", Pub.Encode(smsconfig.SmsPw));
                addTextNode(XMLDom, smsnd, "enabled", smsconfig.Enabled ? "1" : "0");
            }
            addTextNode(XMLDom, root, "smsAutoStart", smsAutoStart ? "1" : "0");

            addTextNode(XMLDom, root, "dataPort", dataPort.ToString());
            addTextNode(XMLDom, root, "dataPw", dataPw);
            addTextNode(XMLDom, root, "dataAutoStart", dataAutoStart ? "1" : "0");

            addTextNode(XMLDom, root, "modemPort", modemPort.ToString());
            addTextNode(XMLDom, root, "modemPw", modemPw);
            addTextNode(XMLDom, root, "modemAutoStart", modemAutoStart ? "1" : "0");

            addTextNode(XMLDom, root, "gprsPort", gprsPort.ToString());
            addTextNode(XMLDom, root, "tcpCutTime", tcpCutTime.ToString());
            addTextNode(XMLDom, root, "gprsAutoStart", gprsAutoStart ? "1" : "0");

            addTextNode(XMLDom, root, "allowChat", allowChat ? "1" : "0");

            XMLDom.Save(APP_PATH + FILE);
        }
    }
}
