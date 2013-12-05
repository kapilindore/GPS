using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    class StrConst
    {
        public const String TITLE_MSG = "��ʾ";
        public const String TITLE_WARN = "����";
        public const String TITLE_ERR = "����";

        public const String STATUS_LOGIN = "�ѵ�½��";
        public const String STATUS_NOT_LOGIN = "δ��½";
        public const String STATUS_NO_ALARM = "û�г�������";
        public const String STATUS_HAS_ALARM = "�г����������������";
        public const String STATUS_NO_OVER_TIME = "û�г����������";
        public const String STATUS_HAS_OVER_TIME = "�г���������ڣ��������";


        public const String CAR_STOPED = "[ͣ��]";
        public const String CAR_OVER_TIME = "[�������]";
        public const String CAR_DECLARE_1 = "[���ϡ�Ͷ��:";
        public const String CAR_DECLARE_2 = "]";

        public const String MSG_NONE_SELECTED_CAR = "��ѡ����";
        public const String MSG_NONE_KEY_WORD = "������ؼ���";
        public const String MSG_EMPTY_INFO = "������������Ϣ";
        public const String MSG_CAR_STOPED = "������ֹͣ����";
        public const String MSG_REGION_QUERY = "����ѡȡ����";
        public const String MSG_NONE_GEO_INFO = "δ��������Ϣ�����ܵ�ͼ��ѯͼ����������,";

        public const String ERR_LOAD_MAP = "�����ͼʱ�������������������";
        public const String ERR_NONE_MAP = "û�����õ�ͼ��������Ҫ����һ����ͼ";
        public const String ERR_NONE_HELP_DOC = "û���ҵ������ĵ����볢����װ����";

        public const String WARN_DELETE = "ȷʵҪɾ��?";
        public const String WARN_EXIT = "�����Ƴ���¼,�ٹرճ���";
        public const String WARN_REGION_QUERY = "������Ҫѡȡ�����㣬��ȷ������ѡȡ���򣬰�ȡ��������ѯ?";
        public const String WARN_IMPORT_DEFAULT_LAYER_SET = "���������������ã��Ƿ����?";

        #region log
        public const String COMMA = "��";
        public const String CONN_HAS_CONN = "�����ӷ�������������֤�û���������";
        public const String CONN_LOGIN = "�ѵ�½������";
        public const String CONN_ERR_HOST = "���ӷ�����ʧ�ܣ����������IP�Ͷ˿�����";
        public const String CONN_LOGIN_FAIL = "��½ʧ�ܣ��û������������";
        public const String CONN_RELOGIN = "���û��ѵ�½";
        public const String CONN_DOWN_ERR = "�쳣����";
        public const String CONN_DOWN = "�ѶϿ�����������";
        public const String CONN_LOGOUT = "�˳���½";
        public const String CONN_RECONN = "�����������ӷ�����";
        public const String CONN_RECONN_OVER = "���������������޶�������ֹͣ����";

        public const String POS_WATCH = "�����Ϣ���£�";
        public const String POS_POINT_OK = "��λ�ɹ���";
        public const String POS_POINT_FAIL = "��λʧ�ܣ�ָ��ͨ����ͨ������ԭ��";
        public const String POS_HIS_POS_OK = "��ѯ��ʷ�켣�ɹ�";
        public const String POS_HIS_POS_NONE = "��ѯ��ʷ�켣��ϢΪ��";
        public const String POS_HIS_ALARM_OK = "��ѯ��ʷ�����ɹ�";
        public const String POS_HIS_ALARM_NONE = "��ѯ��ʷ������ϢΪ��";
        public const String POS_REGION_QUERY_OK = "����鳵�ɹ�";
        public const String POS_REGION_QUERY_NONE = "����鳵��ϢΪ��";
        public const String POS_MILEAGE_OK = "��ѯ�����Ϣ�ɹ���";
        public const String POS_PLACE_QUERY_OK = "��ѯ�Զ����ע�ɹ�";
        public const String POS_PLACE_QUERY_NONE = "��ѯ�Զ����ע��ϢΪ��";
        public const String POS_PLACE_MARK_OK = "�Զ����ע�ɹ�";
        public const String POS_PLACE_MARK_FAIL = "�Զ����עʧ��";

        public const String INFO_ACCOUNT_LIST_OK = "�����˻��б�ɹ�";
        public const String INFO_ACCOUNT_LIST_FAIL = "�����˻��б�ʧ�ܣ�";
        public const String INFO_ACCOUNT_ADD_OK = "�˻���ӳɹ�";
        public const String INFO_ACCOUNT_ADD_FAIL = "�˻����ʧ�ܣ�";
        public const String INFO_ACCOUNT_MOD_OK = "�˻���Ϣ�޸ĳɹ�";
        public const String INFO_ACCOUNT_MOD_FAIL = "�˻���Ϣ�޸�ʧ�ܣ�";
        public const String INFO_ACCOUNT_DEL_OK = "�˻�ɾ���ɹ�";
        public const String INFO_ACCOUNT_DEL_FAIL = "�˻�ɾ��ʧ�ܣ�";
        public const String INFO_TEAM_ADD_OK = "������ӳɹ�";
        public const String INFO_TEAM_ADD_FAIL = "�������ʧ�ܣ�";
        public const String INFO_TEAM_MOD_OK = "�����޸ĳɹ�";
        public const String INFO_TEAM_MOD_FAIL = "�����޸�ʧ�ܣ�";
        public const String INFO_TEAM_DEL_OK = "����ɾ���ɹ�";
        public const String INFO_TEAM_DEL_FAIL = "����ɾ��ʧ�ܣ�";
        public const String INFO_CAR_ADD_OK = "������ӳɹ�";
        public const String INFO_CAR_ADD_FAIL = "�������ʧ�ܣ�";
        public const String INFO_CAR_MOD_OK = "�����޸ĳɹ�";
        public const String INFO_CAR_MOD_FAIL = "�����޸�ʧ�ܣ�";
        public const String INFO_CAR_DEL_OK = "����ɾ���ɹ�";
        public const String INFO_CAR_DEL_FAIL = "����ɾ��ʧ�ܣ�";

        public const String SET_GET_SET_OK = "��ȡ�ն����óɹ���";
        public const String SET_GET_SET_FAIL = "��ȡ�ն�����ʧ�ܣ�";
        public const String SET_ORDER_OK = "ָ��ͳɹ�";
        public const String SET_ORDER_FAIL = "ָ���ʧ�ܣ�";
        public const String SET_ORDER_OTHER = "ָ��Ͳ���ʧ�ܣ�δ���͵�������";
        public const String SET_STOPED_FAIL = "���÷���״̬ʧ�ܣ�";
        public const String SET_SERVICE_TIME_FAIL = "���÷�������ʧ�ܣ�";
        public const String SET_NOTIFY_FAIL = "���ò�����ʾʧ�ܣ�";

        public const String ALARM_HANDLE_OK = "�Ӿ��ɹ���";
        public const String ALARM_HANDLE_FAIL = "�Ӿ�ʧ�ܣ�";
        public const String ALARM_HANDLE_CANCEL = "��ȡ���Ӿ�";
        public const String ALARM_FREE_OK = "��������ɹ���";
        public const String ALARM_FREE_FAIL = "�������ʧ�ܣ�";
        public const String ALARM_FREE_OTHER = "��������ɹ������ͽӴ�����ָ��ʧ�ܣ�";

        public const String CHAT = "�յ��¹�����Ϣ";

        public const String QUERY_OPERATION_OK = "��ѯ������¼�ɹ�";
        public const String QUERY_OPERATION_FAIL = "��ѯ������¼Ϊ��";
        public const String QUERY_ORDER_OK = "��ѯ�·�ָ���¼�ɹ�";
        public const String QUERY_ORDER_FAIL = "��ѯ�·�ָ���¼Ϊ��";
        public const String QUERY_DECLARE_OK = "��ѯ���ϡ�Ͷ���걨��¼�ɹ�";
        public const String QUERY_DECLARE_FAIL = "��ѯ���ϡ�Ͷ�߼�¼Ϊ��";

        public const String DECLARE_NEW_OK = "�ύ���ϡ�Ͷ���걨�ɹ�";
        public const String DECLARE_NEW_FAIL = "�ύ���ϡ�Ͷ���걨ʧ�ܣ�";
        public const String DECLARE_DEAL_OK = "������ϡ�Ͷ���걨�ɹ�";
        public const String DECLARE_DEAL_FAIL = "������ϡ�Ͷ���걨ʧ�ܣ�";

        public const String S_INFO_TEAM_ADD = "�յ��³�����Ϣ��";
        public const String S_INFO_TEAM_MOD = "�յ�������Ϣ���£�";
        public const String S_INFO_TEAM_DEL = "�յ����ӱ�ɾ����";
        public const String S_INFO_CAR_ADD = "�յ��³�����Ϣ��";
        public const String S_INFO_CAR_MOD = "�յ�������Ϣ���£�";
        public const String S_INFO_CAR_DEL = "�յ�������ɾ����";
        public const String S_INFO_USER_INFO = "�յ��ʺ���Ϣ����";
        public const String S_INFO_ALARM = "�յ��±�����Ϣ��";
        public const String S_INFO_ALARM_ERR_POS_1 = "�յ��±�����Ϣ��������Ϣ��������[";
        public const String S_INFO_ALARM_ERR_POS_2 = "]";
        public const String S_INFO_ALARM_ERR_CAR_1 = "�յ��±�����Ϣ����δ�ҵ��˳���������ID[";
        public const String S_INFO_ALARM_ERR_CAR_2 = "]";
        public const String S_INFO_FREE_ALARM = "�յ������ѽӾ�����������";
        public const String S_INFO_SET_STOPED = "�յ���������״̬���£�";
        public const String S_INFO_SET_SERVICE_TIME = "�յ������������ڸ��£�";
        public const String S_INFO_SET_NOTIFY = "�յ�����������ʾ���£�";
        public const String S_INFO_DECLARE_ADD = "�յ������¹��ϡ�Ͷ���걨��";
        public const String S_INFO_DECLARE_DEAL = "�յ��������ϡ�Ͷ���걨�Ѵ���";

        public const String S_MSG_MESSAGE = "�յ���������Ϣ��";
        public const String S_MSG_WARN = "�յ�������������Ϣ��";
        public const String S_MSG_ERR = "�յ�������������Ϣ��";

        public const String EXT_PORT_START_OK = "GIS��չ�˿������ɹ�";
        public const String EXT_PORT_START_FAIL = "GIS��չ�˿�����ʧ�ܣ�����˿��Ƿ�ռ��";
        public const String EXT_PORT_STOPED = "GIS��չ�˿��ѹر�";

        #endregion
    }
}
