using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    public class Constant
    {
        /// <summary>
        /// tcpͨ��
        /// </summary>
        public const int ROUTE_WAY_TCP = 0;
        /// <summary>
        /// udpͨ��
        /// </summary>
        public const int ROUTE_WAY_UDP = 1;
        /// <summary>
        /// ����èͨ��
        /// </summary>
        public const int ROUTE_WAY_MODEM = 2;
        /// <summary>
        /// �ƶ�ר��ͨ��
        /// </summary>
        public const int ROUTE_WAY_SMS = 3;
        /// <summary>
        /// GPRSЭ��1Э��
        /// </summary>
        public const int PROTOCOL_QICHUAN = 0;
        /// <summary>
        /// GPRSЭ��2Э��
        /// </summary>
        public const int PROTOCOL_TIANHE = 1;
        /// <summary>
        /// GPRSЭ��3Э��
        /// </summary>
        public const int PROTOCOL_DASANTONG = 2;
        /// <summary>
        /// GPRSЭ��4Э��
        /// </summary>
        public const int PROTOCOL_XUNLUOSHU = 3;
        
        /// <summary>
        /// ��Ϣͷ
        /// </summary>
        public static String HEAD = "" + (char)0x11 + (char)0x12;
        /// <summary>
        /// ��Ϣβ
        /// </summary>
        public static String FOOT = "" + (char)0x13 + (char)0x14;
        /// <summary>
        /// �ָ��1
        /// </summary>
        public const char SPLIT1 = (char)0x00;
        /// <summary>
        /// �ָ��2
        /// </summary>
        public const char SPLIT2 = (char)0x0e;
        /// <summary>
        /// �ָ��3
        /// </summary>
        public const char SPLIT3 = (char)0x0f;

        /// <summary>
        /// �ָ��1���������ݿ�洢
        /// </summary>
        public const char SPLIT_EX_1 = '|';
        /// <summary>
        /// �ָ��2���������ݿ�洢
        /// </summary>
        public const char SPLIT_EX_2 = ',';

        /// <summary>
        /// �����ʧ��
        /// </summary>
        public const char RESULT_FAIL = '0';
        /// <summary>
        /// ������ɹ�
        /// </summary>
        public const char RESULT_OK = '1';
        /// <summary>
        /// ���������
        /// </summary>
        public const char RESULT_OTHER = '2';

        //�ͻ��� -> ������
        /// <summary>
        /// ���Ӳ���
        /// </summary>
        public const char C_TEST = '@';//
        /// <summary>
        /// �������֣��������
        /// </summary>
        public const char C_CONN = 'A';//
        /// <summary>
        /// ��½
        /// </summary>
        public const char C_CONN_LOGIN = 'A';
        /// <summary>
        /// �˳���½
        /// </summary>
        public const char C_CONN_LOGOUT = 'B';

        /// <summary>
        /// �������֣�λ����Ϣ���
        /// </summary>
        public const char C_POS = 'B';//
        /// <summary>
        /// ���
        /// </summary>
        public const char C_POS_WATCH = 'A';
        /// <summary>
        /// ֹͣ���
        /// </summary>
        public const char C_POS_STOP_WATCH = 'B';
        /// <summary>
        /// ��λ
        /// </summary>
        public const char C_POS_POINT = 'C';
        /// <summary>
        /// ��ʷ�켣
        /// </summary>
        public const char C_POS_HIS_POS = 'D';
        /// <summary>
        /// ��ʷ����
        /// </summary>
        public const char C_POS_HIS_ALARM = 'E';
        /// <summary>
        /// ����鳵
        /// </summary>
        public const char C_POS_REGION_QUERY = 'F';
        /// <summary>
        /// ���ͳ��
        /// </summary>
        public const char C_POS_MILEAGE = 'G';
        /// <summary>
        /// �Զ����ע��ѯ
        /// </summary>
        public const char C_POS_PLACE_QUERY = 'H';
        /// <summary>
        /// �Զ����ע
        /// </summary>
        public const char C_POS_PLACE_MARK = 'I';

        /// <summary>
        /// �������֣�������Ϣ���
        /// </summary>
        public const char C_INFO = 'C';//
        /// <summary>
        /// ��ȡ�ʻ��б�
        /// </summary>
        public const char C_INFO_ACCOUNT_LIST = 'A';
        /// <summary>
        /// ����ʻ�
        /// </summary>
        public const char C_INFO_ACCOUNT_ADD = 'B';
        /// <summary>
        /// �޸��ʻ�
        /// </summary>
        public const char C_INFO_ACCOUNT_MOD = 'C';
        /// <summary>
        /// ɾ���ʻ�
        /// </summary>
        public const char C_INFO_ACCOUNT_DEL = 'D';
        /// <summary>
        /// ��ӳ���
        /// </summary>
        public const char C_INFO_TEAM_ADD = 'E';
        /// <summary>
        /// �޸ĳ���
        /// </summary>
        public const char C_INFO_TEAM_MOD = 'F';
        /// <summary>
        /// ɾ������
        /// </summary>
        public const char C_INFO_TEAM_DEL = 'G';
        /// <summary>
        /// ��ӳ���
        /// </summary>
        public const char C_INFO_CAR_ADD = 'H';
        /// <summary>
        /// �޸ĳ���
        /// </summary>
        public const char C_INFO_CAR_MOD = 'I';
        /// <summary>
        /// ɾ������
        /// </summary>
        public const char C_INFO_CAR_DEL = 'J';

        /// <summary>
        /// �������֣��������
        /// </summary>
        public const char C_SET = 'D'; //�������
        /// <summary>
        /// ��ȡ�ն�����
        /// </summary>
        public const char C_SET_GET_SET = 'A';
        /// <summary>
        /// ����ָ��
        /// </summary>
        public const char C_SET_ORDER = 'B';
        /// <summary>
        /// ����ͣ��
        /// </summary>
        public const char C_SET_STOPED = 'C';
        /// <summary>
        /// ���÷�������
        /// </summary>
        public const char C_SET_SERVICE_TIME = 'D';
        /// <summary>
        /// ���ò�����ʾ
        /// </summary>
        public const char C_SET_NOTIFY = 'E';

        /// <summary>
        /// �������֣������������
        /// </summary>
        public const char C_ALARM = 'E';
        /// <summary>
        /// �Ӿ�
        /// </summary>
        public const char C_ALARM_HANDLE = 'A';
        /// <summary>
        /// �������
        /// </summary>
        public const char C_ALARM_FREE = 'B';

        /// <summary>
        /// �������֣��ͻ���������Ϣ
        /// </summary>
        public const char C_CHAT = 'F';
        /// <summary>
        /// ���͵�����
        /// </summary>
        public const char C_CHAT_TO_ALL = 'A';
        /// <summary>
        /// ���͵����й���Ա
        /// </summary>
        public const char C_CHAT_TO_ADMIN = 'B';
        /// <summary>
        /// ���͵������û�
        /// </summary>
        public const char C_CHAT_TO_USER = 'C';

        /// <summary>
        /// �������֣���ѯͳ��
        /// </summary>
        public const char C_QUERY = 'G';
        public const char C_QUERY_OPERATION = 'A';
        public const char C_QUERY_ORDER = 'B';
        public const char C_QUERY_DECLARE = 'C';

        /// <summary>
        /// �������֣����ϡ�Ͷ��
        /// </summary>
        public const char C_DECLARE = 'H';
        /// <summary>
        /// ���ϡ�Ͷ�߼�¼
        /// </summary>
        public const char C_DECLARE_LIST = 'A';
        /// <summary>
        /// �¹��ϡ�Ͷ�߼�¼
        /// </summary>
        public const char C_DECLARE_NEW = 'B';
        /// <summary>
        /// ������ϡ�Ͷ�߼�¼
        /// </summary>
        public const char C_DECLARE_DEAL = 'C';
        /// <summary>
        /// ���ϡ�Ͷ�߼�¼��ʷ����
        /// </summary>
        public const char C_DECLARE_HIS_CONTENT = 'D';

        //������ -> �ͻ���
        /// <summary>
        /// �������֣�ϵͳ��Ϣ�䶯֪ͨ
        /// </summary>
        public const char S_INFO = 'X';
        /// <summary>
        /// �������
        /// </summary>
        public const char S_INFO_TEAM_ADD = 'A';
        /// <summary>
        /// �����޸�
        /// </summary>
        public const char S_INFO_TEAM_MOD = 'B';
        /// <summary>
        /// ����ɾ��
        /// </summary>
        public const char S_INFO_TEAM_DEL = 'C';
        /// <summary>
        /// �������
        /// </summary>
        public const char S_INFO_CAR_ADD = 'D';
        /// <summary>
        /// �����޸�
        /// </summary>
        public const char S_INFO_CAR_MOD = 'E';
        /// <summary>
        /// ����ɾ��
        /// </summary>
        public const char S_INFO_CAR_DEL = 'F';
        /// <summary>
        /// �ʻ��޸�
        /// </summary>
        public const char S_INFO_USER_INFO = 'G';
        /// <summary>
        /// �±���
        /// </summary>
        public const char S_INFO_ALARM = 'H';
        /// <summary>
        /// �����ѽ��
        /// </summary>
        public const char S_INFO_FREE_ALARM = 'I';
        /// <summary>
        /// ����ͣ��״̬
        /// </summary>
        public const char S_INFO_SET_STOPED = 'J';
        /// <summary>
        /// ������������
        /// </summary>
        public const char S_INFO_SET_SERVICE_TIME = 'K';
        /// <summary>
        /// ����������ʾ
        /// </summary>
        public const char S_INFO_SET_NOTIFY = 'L';

        /// <summary>
        /// �������֣����ϡ�Ͷ��
        /// </summary>
        public const char S_DECLARE = 'a';//
        /// <summary>
        /// ���걨
        /// </summary>
        public const char S_DECLARE_ADD = 'a';//
        /// <summary>
        /// �걨�Ѵ���
        /// </summary>
        public const char S_DECLARE_DEAL = 'b';//

        /// <summary>
        /// �������֣�������״̬��Ϣ
        /// </summary>
        public const char S_MSG = 'Y'; //
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public const char S_MSG_MESSAGE = 'A';
        /// <summary>
        /// ������������Ϣ
        /// </summary>
        public const char S_MSG_WARN = 'B';
        /// <summary>
        /// ������������Ϣ
        /// </summary>
        public const char S_MSG_ERR = 'C';

        //������ <-> ��Ϣ���ճ���
        /// <summary>
        /// ��½
        /// </summary>
        public const char SMS_LOGIN = 'A';
        /// <summary>
        /// ����/������Ϣ
        /// </summary>
        public const char SMS_MSG = 'B';

        /// <summary>
        /// ���������ַ���
        /// </summary>
        public static String CONN_TEST = HEAD + C_TEST + FOOT;


        public const String FILE_SOUND_ALARM = "sounds\\alarm.wav";
        public const String FILE_SOUND_NOTIFY = "sounds\\notify.wav";
        public const String FILE_SOUND_DOWN = "sounds\\down.wav";
        public const String FILE_SOUND_SEV_WARN = "sounds\\warn.wav";
        public const String FILE_HELP_DOC = "GPS����ϵͳ�ͻ������˵��.doc";
    }
}
