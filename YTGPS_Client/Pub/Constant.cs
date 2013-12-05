using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    public class Constant
    {
        /// <summary>
        /// tcp通道
        /// </summary>
        public const int ROUTE_WAY_TCP = 0;
        /// <summary>
        /// udp通道
        /// </summary>
        public const int ROUTE_WAY_UDP = 1;
        /// <summary>
        /// 短信猫通道
        /// </summary>
        public const int ROUTE_WAY_MODEM = 2;
        /// <summary>
        /// 移动专线通道
        /// </summary>
        public const int ROUTE_WAY_SMS = 3;
        /// <summary>
        /// GPRS协议1协议
        /// </summary>
        public const int PROTOCOL_QICHUAN = 0;
        /// <summary>
        /// GPRS协议2协议
        /// </summary>
        public const int PROTOCOL_TIANHE = 1;
        /// <summary>
        /// GPRS协议3协议
        /// </summary>
        public const int PROTOCOL_DASANTONG = 2;
        /// <summary>
        /// GPRS协议4协议
        /// </summary>
        public const int PROTOCOL_XUNLUOSHU = 3;
        
        /// <summary>
        /// 信息头
        /// </summary>
        public static String HEAD = "" + (char)0x11 + (char)0x12;
        /// <summary>
        /// 信息尾
        /// </summary>
        public static String FOOT = "" + (char)0x13 + (char)0x14;
        /// <summary>
        /// 分割符1
        /// </summary>
        public const char SPLIT1 = (char)0x00;
        /// <summary>
        /// 分割符2
        /// </summary>
        public const char SPLIT2 = (char)0x0e;
        /// <summary>
        /// 分割符3
        /// </summary>
        public const char SPLIT3 = (char)0x0f;

        /// <summary>
        /// 分割符1，用于数据库存储
        /// </summary>
        public const char SPLIT_EX_1 = '|';
        /// <summary>
        /// 分割符2，用于数据库存储
        /// </summary>
        public const char SPLIT_EX_2 = ',';

        /// <summary>
        /// 结果，失败
        /// </summary>
        public const char RESULT_FAIL = '0';
        /// <summary>
        /// 结果，成功
        /// </summary>
        public const char RESULT_OK = '1';
        /// <summary>
        /// 结果，其他
        /// </summary>
        public const char RESULT_OTHER = '2';

        //客户端 -> 服务器
        /// <summary>
        /// 连接测试
        /// </summary>
        public const char C_TEST = '@';//
        /// <summary>
        /// 主命令字，连接相关
        /// </summary>
        public const char C_CONN = 'A';//
        /// <summary>
        /// 登陆
        /// </summary>
        public const char C_CONN_LOGIN = 'A';
        /// <summary>
        /// 退出登陆
        /// </summary>
        public const char C_CONN_LOGOUT = 'B';

        /// <summary>
        /// 主命令字，位置信息相关
        /// </summary>
        public const char C_POS = 'B';//
        /// <summary>
        /// 监控
        /// </summary>
        public const char C_POS_WATCH = 'A';
        /// <summary>
        /// 停止监控
        /// </summary>
        public const char C_POS_STOP_WATCH = 'B';
        /// <summary>
        /// 定位
        /// </summary>
        public const char C_POS_POINT = 'C';
        /// <summary>
        /// 历史轨迹
        /// </summary>
        public const char C_POS_HIS_POS = 'D';
        /// <summary>
        /// 历史报警
        /// </summary>
        public const char C_POS_HIS_ALARM = 'E';
        /// <summary>
        /// 区域查车
        /// </summary>
        public const char C_POS_REGION_QUERY = 'F';
        /// <summary>
        /// 里程统计
        /// </summary>
        public const char C_POS_MILEAGE = 'G';
        /// <summary>
        /// 自定义标注查询
        /// </summary>
        public const char C_POS_PLACE_QUERY = 'H';
        /// <summary>
        /// 自定义标注
        /// </summary>
        public const char C_POS_PLACE_MARK = 'I';

        /// <summary>
        /// 主命令字，其他信息相关
        /// </summary>
        public const char C_INFO = 'C';//
        /// <summary>
        /// 获取帐户列表
        /// </summary>
        public const char C_INFO_ACCOUNT_LIST = 'A';
        /// <summary>
        /// 添加帐户
        /// </summary>
        public const char C_INFO_ACCOUNT_ADD = 'B';
        /// <summary>
        /// 修改帐户
        /// </summary>
        public const char C_INFO_ACCOUNT_MOD = 'C';
        /// <summary>
        /// 删除帐户
        /// </summary>
        public const char C_INFO_ACCOUNT_DEL = 'D';
        /// <summary>
        /// 添加车队
        /// </summary>
        public const char C_INFO_TEAM_ADD = 'E';
        /// <summary>
        /// 修改车队
        /// </summary>
        public const char C_INFO_TEAM_MOD = 'F';
        /// <summary>
        /// 删除车队
        /// </summary>
        public const char C_INFO_TEAM_DEL = 'G';
        /// <summary>
        /// 添加车辆
        /// </summary>
        public const char C_INFO_CAR_ADD = 'H';
        /// <summary>
        /// 修改车辆
        /// </summary>
        public const char C_INFO_CAR_MOD = 'I';
        /// <summary>
        /// 删除车辆
        /// </summary>
        public const char C_INFO_CAR_DEL = 'J';

        /// <summary>
        /// 主命令字，设置相关
        /// </summary>
        public const char C_SET = 'D'; //设置相关
        /// <summary>
        /// 获取终端设置
        /// </summary>
        public const char C_SET_GET_SET = 'A';
        /// <summary>
        /// 发送指令
        /// </summary>
        public const char C_SET_ORDER = 'B';
        /// <summary>
        /// 设置停机
        /// </summary>
        public const char C_SET_STOPED = 'C';
        /// <summary>
        /// 设置服务日期
        /// </summary>
        public const char C_SET_SERVICE_TIME = 'D';
        /// <summary>
        /// 设置操作提示
        /// </summary>
        public const char C_SET_NOTIFY = 'E';

        /// <summary>
        /// 主命令字，报警处理相关
        /// </summary>
        public const char C_ALARM = 'E';
        /// <summary>
        /// 接警
        /// </summary>
        public const char C_ALARM_HANDLE = 'A';
        /// <summary>
        /// 解除报警
        /// </summary>
        public const char C_ALARM_FREE = 'B';

        /// <summary>
        /// 主命令字，客户端聊天信息
        /// </summary>
        public const char C_CHAT = 'F';
        /// <summary>
        /// 发送到所有
        /// </summary>
        public const char C_CHAT_TO_ALL = 'A';
        /// <summary>
        /// 发送到所有管理员
        /// </summary>
        public const char C_CHAT_TO_ADMIN = 'B';
        /// <summary>
        /// 发送到所有用户
        /// </summary>
        public const char C_CHAT_TO_USER = 'C';

        /// <summary>
        /// 主命令字，查询统计
        /// </summary>
        public const char C_QUERY = 'G';
        public const char C_QUERY_OPERATION = 'A';
        public const char C_QUERY_ORDER = 'B';
        public const char C_QUERY_DECLARE = 'C';

        /// <summary>
        /// 主命令字，故障、投诉
        /// </summary>
        public const char C_DECLARE = 'H';
        /// <summary>
        /// 故障、投诉记录
        /// </summary>
        public const char C_DECLARE_LIST = 'A';
        /// <summary>
        /// 新故障、投诉记录
        /// </summary>
        public const char C_DECLARE_NEW = 'B';
        /// <summary>
        /// 处理故障、投诉记录
        /// </summary>
        public const char C_DECLARE_DEAL = 'C';
        /// <summary>
        /// 故障、投诉记录历史内容
        /// </summary>
        public const char C_DECLARE_HIS_CONTENT = 'D';

        //服务器 -> 客户端
        /// <summary>
        /// 主命令字，系统信息变动通知
        /// </summary>
        public const char S_INFO = 'X';
        /// <summary>
        /// 车队添加
        /// </summary>
        public const char S_INFO_TEAM_ADD = 'A';
        /// <summary>
        /// 车队修改
        /// </summary>
        public const char S_INFO_TEAM_MOD = 'B';
        /// <summary>
        /// 车队删除
        /// </summary>
        public const char S_INFO_TEAM_DEL = 'C';
        /// <summary>
        /// 车辆添加
        /// </summary>
        public const char S_INFO_CAR_ADD = 'D';
        /// <summary>
        /// 车辆修改
        /// </summary>
        public const char S_INFO_CAR_MOD = 'E';
        /// <summary>
        /// 车辆删除
        /// </summary>
        public const char S_INFO_CAR_DEL = 'F';
        /// <summary>
        /// 帐户修改
        /// </summary>
        public const char S_INFO_USER_INFO = 'G';
        /// <summary>
        /// 新报警
        /// </summary>
        public const char S_INFO_ALARM = 'H';
        /// <summary>
        /// 报警已解除
        /// </summary>
        public const char S_INFO_FREE_ALARM = 'I';
        /// <summary>
        /// 车辆停机状态
        /// </summary>
        public const char S_INFO_SET_STOPED = 'J';
        /// <summary>
        /// 车辆服务日期
        /// </summary>
        public const char S_INFO_SET_SERVICE_TIME = 'K';
        /// <summary>
        /// 车辆操作提示
        /// </summary>
        public const char S_INFO_SET_NOTIFY = 'L';

        /// <summary>
        /// 主命令字，故障、投诉
        /// </summary>
        public const char S_DECLARE = 'a';//
        /// <summary>
        /// 新申报
        /// </summary>
        public const char S_DECLARE_ADD = 'a';//
        /// <summary>
        /// 申报已处理
        /// </summary>
        public const char S_DECLARE_DEAL = 'b';//

        /// <summary>
        /// 主命令字，服务器状态信息
        /// </summary>
        public const char S_MSG = 'Y'; //
        /// <summary>
        /// 服务器信息
        /// </summary>
        public const char S_MSG_MESSAGE = 'A';
        /// <summary>
        /// 服务器警告信息
        /// </summary>
        public const char S_MSG_WARN = 'B';
        /// <summary>
        /// 服务器错误信息
        /// </summary>
        public const char S_MSG_ERR = 'C';

        //服务器 <-> 信息接收程序
        /// <summary>
        /// 登陆
        /// </summary>
        public const char SMS_LOGIN = 'A';
        /// <summary>
        /// 接收/发送信息
        /// </summary>
        public const char SMS_MSG = 'B';

        /// <summary>
        /// 测试连接字符串
        /// </summary>
        public static String CONN_TEST = HEAD + C_TEST + FOOT;


        public const String FILE_SOUND_ALARM = "sounds\\alarm.wav";
        public const String FILE_SOUND_NOTIFY = "sounds\\notify.wav";
        public const String FILE_SOUND_DOWN = "sounds\\down.wav";
        public const String FILE_SOUND_SEV_WARN = "sounds\\warn.wav";
        public const String FILE_HELP_DOC = "GPS车载系统客户端软件说明.doc";
    }
}
