using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    class StrConst
    {
        public const String TITLE_MSG = "提示";
        public const String TITLE_WARN = "警告";
        public const String TITLE_ERR = "错误";

        public const String STATUS_LOGIN = "已登陆：";
        public const String STATUS_NOT_LOGIN = "未登陆";
        public const String STATUS_NO_ALARM = "没有车辆报警";
        public const String STATUS_HAS_ALARM = "有车辆报警，点击处理";
        public const String STATUS_NO_OVER_TIME = "没有车辆服务过期";
        public const String STATUS_HAS_OVER_TIME = "有车辆服务过期，点击处理";


        public const String CAR_STOPED = "[停机]";
        public const String CAR_OVER_TIME = "[服务过期]";
        public const String CAR_DECLARE_1 = "[故障、投诉:";
        public const String CAR_DECLARE_2 = "]";

        public const String MSG_NONE_SELECTED_CAR = "请选择车辆";
        public const String MSG_NONE_KEY_WORD = "请输入关键字";
        public const String MSG_EMPTY_INFO = "请输入完整信息";
        public const String MSG_CAR_STOPED = "车辆已停止服务";
        public const String MSG_REGION_QUERY = "请先选取区域";
        public const String MSG_NONE_GEO_INFO = "未搜索到信息，可能地图查询图层设置有误,";

        public const String ERR_LOAD_MAP = "载入地图时发生错误，请检查程序设置";
        public const String ERR_NONE_MAP = "没有配置地图，至少需要配置一个地图";
        public const String ERR_NONE_HELP_DOC = "没有找到帮助文档，请尝试重装程序";

        public const String WARN_DELETE = "确实要删除?";
        public const String WARN_EXIT = "请先推出登录,再关闭程序";
        public const String WARN_REGION_QUERY = "至少需要选取三个点，按确定继续选取区域，按取消放弃查询?";
        public const String WARN_IMPORT_DEFAULT_LAYER_SET = "导入会清空现有设置，是否继续?";

        #region log
        public const String COMMA = "，";
        public const String CONN_HAS_CONN = "已连接服务器，正在验证用户名和密码";
        public const String CONN_LOGIN = "已登陆服务器";
        public const String CONN_ERR_HOST = "连接服务器失败，请检查服务器IP和端口设置";
        public const String CONN_LOGIN_FAIL = "登陆失败，用户名或密码错误";
        public const String CONN_RELOGIN = "此用户已登陆";
        public const String CONN_DOWN_ERR = "异常断线";
        public const String CONN_DOWN = "已断开服务器连接";
        public const String CONN_LOGOUT = "退出登陆";
        public const String CONN_RECONN = "尝试重新连接服务器";
        public const String CONN_RECONN_OVER = "重连服务器超过限定次数，停止重连";

        public const String POS_WATCH = "监控信息更新：";
        public const String POS_POINT_OK = "定位成功：";
        public const String POS_POINT_FAIL = "定位失败，指令通道不通或其他原因：";
        public const String POS_HIS_POS_OK = "查询历史轨迹成功";
        public const String POS_HIS_POS_NONE = "查询历史轨迹信息为空";
        public const String POS_HIS_ALARM_OK = "查询历史报警成功";
        public const String POS_HIS_ALARM_NONE = "查询历史报警信息为空";
        public const String POS_REGION_QUERY_OK = "区域查车成功";
        public const String POS_REGION_QUERY_NONE = "区域查车信息为空";
        public const String POS_MILEAGE_OK = "查询里程信息成功：";
        public const String POS_PLACE_QUERY_OK = "查询自定义标注成功";
        public const String POS_PLACE_QUERY_NONE = "查询自定义标注信息为空";
        public const String POS_PLACE_MARK_OK = "自定义标注成功";
        public const String POS_PLACE_MARK_FAIL = "自定义标注失败";

        public const String INFO_ACCOUNT_LIST_OK = "更新账户列表成功";
        public const String INFO_ACCOUNT_LIST_FAIL = "更新账户列表失败：";
        public const String INFO_ACCOUNT_ADD_OK = "账户添加成功";
        public const String INFO_ACCOUNT_ADD_FAIL = "账户添加失败：";
        public const String INFO_ACCOUNT_MOD_OK = "账户信息修改成功";
        public const String INFO_ACCOUNT_MOD_FAIL = "账户信息修改失败：";
        public const String INFO_ACCOUNT_DEL_OK = "账户删除成功";
        public const String INFO_ACCOUNT_DEL_FAIL = "账户删除失败：";
        public const String INFO_TEAM_ADD_OK = "车队添加成功";
        public const String INFO_TEAM_ADD_FAIL = "车队添加失败：";
        public const String INFO_TEAM_MOD_OK = "车队修改成功";
        public const String INFO_TEAM_MOD_FAIL = "车队修改失败：";
        public const String INFO_TEAM_DEL_OK = "车队删除成功";
        public const String INFO_TEAM_DEL_FAIL = "车队删除失败：";
        public const String INFO_CAR_ADD_OK = "车辆添加成功";
        public const String INFO_CAR_ADD_FAIL = "车辆添加失败：";
        public const String INFO_CAR_MOD_OK = "车辆修改成功";
        public const String INFO_CAR_MOD_FAIL = "车辆修改失败：";
        public const String INFO_CAR_DEL_OK = "车辆删除成功";
        public const String INFO_CAR_DEL_FAIL = "车辆删除失败：";

        public const String SET_GET_SET_OK = "获取终端设置成功：";
        public const String SET_GET_SET_FAIL = "获取终端设置失败：";
        public const String SET_ORDER_OK = "指令发送成功";
        public const String SET_ORDER_FAIL = "指令发送失败：";
        public const String SET_ORDER_OTHER = "指令发送部分失败，未发送到车辆：";
        public const String SET_STOPED_FAIL = "设置服务状态失败：";
        public const String SET_SERVICE_TIME_FAIL = "设置服务日期失败：";
        public const String SET_NOTIFY_FAIL = "设置操作提示失败：";

        public const String ALARM_HANDLE_OK = "接警成功：";
        public const String ALARM_HANDLE_FAIL = "接警失败：";
        public const String ALARM_HANDLE_CANCEL = "已取消接警";
        public const String ALARM_FREE_OK = "解除报警成功：";
        public const String ALARM_FREE_FAIL = "解除报警失败：";
        public const String ALARM_FREE_OTHER = "解除报警成功，发送接触报警指令失败：";

        public const String CHAT = "收到新公告信息";

        public const String QUERY_OPERATION_OK = "查询操作记录成功";
        public const String QUERY_OPERATION_FAIL = "查询操作记录为空";
        public const String QUERY_ORDER_OK = "查询下发指令记录成功";
        public const String QUERY_ORDER_FAIL = "查询下发指令记录为空";
        public const String QUERY_DECLARE_OK = "查询故障、投诉申报记录成功";
        public const String QUERY_DECLARE_FAIL = "查询故障、投诉记录为空";

        public const String DECLARE_NEW_OK = "提交故障、投诉申报成功";
        public const String DECLARE_NEW_FAIL = "提交故障、投诉申报失败：";
        public const String DECLARE_DEAL_OK = "处理故障、投诉申报成功";
        public const String DECLARE_DEAL_FAIL = "处理故障、投诉申报失败：";

        public const String S_INFO_TEAM_ADD = "收到新车队信息：";
        public const String S_INFO_TEAM_MOD = "收到车队信息更新：";
        public const String S_INFO_TEAM_DEL = "收到车队被删除：";
        public const String S_INFO_CAR_ADD = "收到新车辆信息：";
        public const String S_INFO_CAR_MOD = "收到车辆信息更新：";
        public const String S_INFO_CAR_DEL = "收到车辆被删除：";
        public const String S_INFO_USER_INFO = "收到帐号信息更新";
        public const String S_INFO_ALARM = "收到新报警信息：";
        public const String S_INFO_ALARM_ERR_POS_1 = "收到新报警信息：报警信息解析错误[";
        public const String S_INFO_ALARM_ERR_POS_2 = "]";
        public const String S_INFO_ALARM_ERR_CAR_1 = "收到新报警信息：但未找到此车辆，车辆ID[";
        public const String S_INFO_ALARM_ERR_CAR_2 = "]";
        public const String S_INFO_FREE_ALARM = "收到车辆已接警或解除报警：";
        public const String S_INFO_SET_STOPED = "收到车辆服务状态更新：";
        public const String S_INFO_SET_SERVICE_TIME = "收到车辆服务日期更新：";
        public const String S_INFO_SET_NOTIFY = "收到车辆操作提示更新：";
        public const String S_INFO_DECLARE_ADD = "收到车辆新故障、投诉申报：";
        public const String S_INFO_DECLARE_DEAL = "收到车辆故障、投诉申报已处理：";

        public const String S_MSG_MESSAGE = "收到服务器信息：";
        public const String S_MSG_WARN = "收到服务器警告信息：";
        public const String S_MSG_ERR = "收到服务器错误信息：";

        public const String EXT_PORT_START_OK = "GIS扩展端口启动成功";
        public const String EXT_PORT_START_FAIL = "GIS扩展端口启动失败，请检查端口是否被占用";
        public const String EXT_PORT_STOPED = "GIS扩展端口已关闭";

        #endregion
    }
}
