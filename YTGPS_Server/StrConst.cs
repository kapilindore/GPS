using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    public class StrConst
    {
        public static String ERR_CONFIG = "请先停止所有服务,再进行程序设置!";
        public static String ERR_DB = "连接数据库失败!";
        public static String ERR_SMS = "连接移动专线失败!";
        public static String ERR_PORT_TCP = "启动TCP服务失败，端口已被占用!";
        public static String ERR_PORT_UDP = "启动UDP服务失败，端口已被占用!";
        public static String ERR_PORT_MODEM = "启动短信猫服务失败，端口已被占用!";
        public static String ERR_PORT_DATA = "启动数据服务失败，端口已被占用!";
        public static String ERR_DEL_SMS = "正在使用此连接，请先修改车辆信息再删除!";
        public static String ERR_SMS_CONN = " 连接失败，请检查服务器及端口设置!";
        public static String ERR_SMS_LOGIN = " 登陆失败，请检查验证码!";

        public static String OK_DB = "连接数据库成功!";
        public static String OK_SMS = "连接移动专线成功!";
        public static String OK_PORT = "端口可以使用!";

        public static String WARN_EXIT = "确实要退出程序?";

        public static String TITLE_WARN = "警告";
        public static String TITLE_MSG = "信息";
        public static String TITLE_ERR = "错误";

        public static String STATUS_SMS_NOT_CONN = "未连接";
        public static String STATUS_SMS_CONNECTING = "已连接，正在登陆...";
        public static String STATUS_SMS_CONNECTED = "已登陆";


        #region 客户端提示信息
        public static String RET_NO_POLICY = "权限不足";
        public static String RET_ERR_INFO = "资料错误";
        public static String RET_ECHO_INFO = "关键信息重复";
        public static String RET_UPDATE_DB = "更新数据库失败";
        #endregion

        #region 客户端警告、错误信息
        public static String ERR_CONN_DB = "与数据库连接意外断开";
        #endregion
    }
}
