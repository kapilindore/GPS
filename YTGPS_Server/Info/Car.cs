using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Data;

namespace YTGPS_Server
{
    /// <summary>
    /// 车辆
    /// </summary>
    public class Car
    {
        private int carID;
        private int teamID;
        private String carNO = "";
        private String simNO = "";
        private String machineNO = "";
        private String controlPassword = "";
        private String machineType = "";
        private int protocol = 0;
        private int routeway = 0;
        private String carType = "";
        private String carBrand = "";
        private String carColor = "";
        private String installPlace = "";
        private String installPerson = "";
        private String businessPerson = "";
        private String joinTime = "";
        private String overServiceTime = "";
        private String carRemark = "";
        private String driver = "";
        private String driverTel = "";
        private String driverMobile = "";
        private String driver2 = "";
        private String driver2Tel = "";
        private String driver2Mobile = "";
        private String password = "";
        private String driverAddress = "";
        private String driverFax = "";
        private String driverCompany = "";
        private String buyTime = "";
        private int stoped = 0;
        private String specialRequest = "";
        private String driverRemark = "";

        private bool regionAlarm = false;
        private int regionID;

        private int notify = 0;
        private String notifyStart = "";
        private String notifyEnd = "";
        private String notifyText = "";

        private int declareCount = 0;

        private Position pos = null;
        private Region region = null;
        private Team team;
        private bool hasLogin = false;
        private List<AlarmPosition> alarmPos = new List<AlarmPosition>();
        private List<Socket> watchSockets = new List<Socket>();
        private List<Socket> pointSockets = new List<Socket>();
        private List<Socket> getSetSockets = new List<Socket>();
        private DataClient handleAlarmClient = null;

        private TcpTerminal gprsConn = null;
        private UdpTerminal udpAddr = null;

        
        #region public function
        public Car()
        {
        }
        public Car(Car car)
        {
            Clone(car);
        }
        /// <summary>
        /// 复制车辆信息
        /// </summary>
        /// <param name="car"></param>
        public void Clone(Car car)
        {
            this.carID = car.carID;
            this.teamID = car.teamID;
            this.carNO = car.carNO;
            this.simNO = car.simNO;
            this.machineNO = car.machineNO;
            this.controlPassword = car.controlPassword;
            this.machineType = car.machineType;
            this.protocol = car.protocol;
            this.routeway = car.routeway;
            this.carType = car.carType;
            this.carBrand = car.carBrand;
            this.carColor = car.carColor;
            this.installPlace = car.installPlace;
            this.installPerson = car.installPerson;
            this.businessPerson = car.businessPerson;
            this.joinTime = car.joinTime;
            this.overServiceTime = car.overServiceTime;
            this.carRemark = car.carRemark;
            this.driver = car.driver;
            this.driverTel = car.driverTel;
            this.driverMobile = car.driverMobile;
            this.driver2 = car.driver2;
            this.driver2Tel = car.driver2Tel;
            this.driver2Mobile = car.driver2Mobile;
            this.password = car.password;
            this.driverAddress = car.driverAddress;
            this.driverFax = car.driverFax;
            this.driverCompany = car.driverCompany;
            this.buyTime = car.buyTime;
            this.stoped = car.stoped;
            this.specialRequest = car.specialRequest;
            this.driverRemark = car.driverRemark;
            this.regionAlarm = car.regionAlarm;
            this.regionID = car.regionID;
            this.notify = car.notify;
            this.notifyStart = car.notifyStart;
            this.notifyEnd = car.notifyEnd;
            this.notifyText = car.notifyText;
            this.declareCount = car.declareCount;
        }
        /// <summary>
        /// 把车辆转换到字符串形式
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(carID.ToString()).Append(Constant.SPLIT2).Append(carNO);
            stb.Append(Constant.SPLIT2).Append(simNO).Append(Constant.SPLIT2).Append(machineNO);
            stb.Append(Constant.SPLIT2).Append(controlPassword).Append(Constant.SPLIT2).Append(machineType);
            stb.Append(Constant.SPLIT2).Append(protocol).Append(Constant.SPLIT2).Append(routeway);
            stb.Append(Constant.SPLIT2).Append(carType);
            stb.Append(Constant.SPLIT2).Append(carBrand).Append(Constant.SPLIT2).Append(carColor);
            stb.Append(Constant.SPLIT2).Append(installPlace).Append(Constant.SPLIT2).Append(installPerson);
            stb.Append(Constant.SPLIT2).Append(businessPerson).Append(Constant.SPLIT2).Append(joinTime);
            stb.Append(Constant.SPLIT2).Append(overServiceTime).Append(Constant.SPLIT2).Append(carRemark);
            stb.Append(Constant.SPLIT2).Append(driver).Append(Constant.SPLIT2).Append(driverTel);
            stb.Append(Constant.SPLIT2).Append(driverMobile).Append(Constant.SPLIT2).Append(driver2);
            stb.Append(Constant.SPLIT2).Append(driver2Tel).Append(Constant.SPLIT2).Append(driver2Mobile);
            stb.Append(Constant.SPLIT2).Append(password).Append(Constant.SPLIT2).Append(driverAddress);
            stb.Append(Constant.SPLIT2).Append(driverFax).Append(Constant.SPLIT2).Append(driverCompany);
            stb.Append(Constant.SPLIT2).Append(buyTime).Append(Constant.SPLIT2).Append(stoped);
            stb.Append(Constant.SPLIT2).Append(specialRequest).Append(Constant.SPLIT2).Append(driverRemark);
            stb.Append(Constant.SPLIT2).Append(notify).Append(Constant.SPLIT2).Append(notifyStart);
            stb.Append(Constant.SPLIT2).Append(notifyEnd).Append(Constant.SPLIT2).Append(notifyText);
            stb.Append(Constant.SPLIT2).Append(declareCount);
            return stb.ToString();
        }
        /// <summary>
        /// 从数据库行初始化
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Car ParseWithPosition(DataRow dr)
        {
            Car car = new Car();
            try
            {
                car.carID = Int32.Parse(dr[0].ToString());
                car.TeamID = Int32.Parse(dr[1].ToString().ToString());
                car.carNO = dr[2].ToString();
                car.simNO = dr[3].ToString();
                car.machineNO = dr[4].ToString();
                car.controlPassword = dr[5].ToString();
                car.machineType = dr[6].ToString();
                car.protocol = Int32.Parse(dr[7].ToString());
                car.routeway = Int32.Parse(dr[8].ToString());
                car.carType = dr[9].ToString();
                car.carBrand = dr[10].ToString();
                car.carColor = dr[11].ToString();
                car.installPlace = dr[12].ToString();
                car.installPerson = dr[13].ToString();
                car.businessPerson = dr[14].ToString();
                car.joinTime = dr[15].ToString();
                car.overServiceTime = dr[16].ToString();
                car.carRemark = dr[17].ToString();
                car.driver = dr[18].ToString();
                car.driverTel = dr[19].ToString();
                car.driverMobile = dr[20].ToString();
                car.driver2 = dr[21].ToString();
                car.driver2Tel = dr[22].ToString();
                car.driver2Mobile = dr[23].ToString();
                car.password = dr[24].ToString();
                car.driverAddress = dr[25].ToString();
                car.driverFax = dr[26].ToString();
                car.driverCompany = dr[27].ToString();
                car.buyTime = dr[28].ToString();
                car.stoped = Int32.Parse(dr[29].ToString());
                car.specialRequest = dr[30].ToString();
                car.driverRemark = dr[31].ToString();
                car.RegionAlarm = dr[32].ToString() == "1";
                car.RegionID = Int32.Parse(dr[33].ToString());
                car.Notify = Int32.Parse(dr[34].ToString());
                car.NotifyStart = dr[35].ToString();
                car.NotifyEnd = dr[36].ToString();
                car.NotifyText = dr[37].ToString();
                car.Pos = new Position();
                car.Pos.GpsTime = dr[38].ToString();
                car.Pos.Pointed = Int32.Parse(dr[39].ToString());
                car.Pos.Lo = Double.Parse(dr[40].ToString());
                car.Pos.La = Double.Parse(dr[41].ToString());
                car.Pos.Speed = Int32.Parse(dr[42].ToString());
                car.Pos.Direction = Int32.Parse(dr[43].ToString());
                car.Pos.Status = dr[44].ToString();
                car.Pos.Alarm = dr[45].ToString();
                car.Pos.Mileage = Int32.Parse(dr[47].ToString());
                car.Pos.AlarmHandle = Int32.Parse(dr[46].ToString());
            }
            catch { return null; }
            return car;
        }
        /// <summary>
        /// 从字符串初始化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Car Parse(String s)
        {
            Car car = new Car();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                car.carID = Int32.Parse(ss[0]);
                car.carNO = ss[1];
                car.simNO = ss[2];
                car.machineNO = ss[3];
                car.controlPassword = ss[4];
                car.machineType = ss[5];
                car.protocol = Int32.Parse(ss[6]);
                car.routeway = Int32.Parse(ss[7]);
                car.carType = ss[8];
                car.carBrand = ss[9];
                car.carColor = ss[10];
                car.installPlace = ss[11];
                car.installPerson = ss[12];
                car.businessPerson = ss[13];
                car.joinTime = ss[14];
                car.overServiceTime = ss[15];
                car.carRemark = ss[16];
                car.driver = ss[17];
                car.driverTel = ss[18];
                car.driverMobile = ss[19];
                car.driver2 = ss[20];
                car.driver2Tel = ss[21];
                car.driver2Mobile = ss[22];
                car.password = ss[23];
                car.driverAddress = ss[24];
                car.driverFax = ss[25];
                car.driverCompany = ss[26];
                car.buyTime = ss[27];
                car.stoped = Int32.Parse(ss[28]);
                car.specialRequest = ss[29];
                car.driverRemark = ss[30];
                car.Notify = Int32.Parse(ss[31]);
                car.NotifyStart = ss[32];
                car.NotifyEnd = ss[33];
                car.NotifyText = ss[34];
            }
            catch { return null; }
            return car;
        }
        /// <summary>
        /// 数据库插入语句
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public String SqlInsertStr(int tid)
        {
            StringBuilder stb = new StringBuilder("insert_car ");
            stb.Append(tid).Append(",'").Append(carNO);
            stb.Append("','").Append(simNO).Append("','").Append(machineNO);
            stb.Append("','").Append(controlPassword).Append("','").Append(machineType);
            stb.Append("',").Append(protocol).Append(",").Append(routeway);
            stb.Append(",'").Append(carType);
            stb.Append("','").Append(carBrand).Append("','").Append(carColor);
            stb.Append("','").Append(installPlace).Append("','").Append(installPerson);
            stb.Append("','").Append(businessPerson).Append("','").Append(joinTime);
            stb.Append("','").Append(overServiceTime).Append("','").Append(carRemark);
            stb.Append("','").Append(driver).Append("','").Append(driverTel);
            stb.Append("','").Append(driverMobile).Append("','").Append(driver2);
            stb.Append("','").Append(driver2Tel).Append("','").Append(driver2Mobile);
            stb.Append("','").Append(password).Append("','").Append(driverAddress);
            stb.Append("','").Append(driverFax).Append("','").Append(driverCompany);
            stb.Append("','").Append(buyTime);
            stb.Append("','").Append(specialRequest).Append("','").Append(driverRemark).Append("'");
            return stb.ToString();
        }
        /// <summary>
        /// 数据库更新语句
        /// </summary>
        /// <returns></returns>
        public String SqlUpdateStr()
        {
            StringBuilder stb = new StringBuilder("update_car ");
            stb.Append(carID).Append(",'").Append(carNO);
            stb.Append("','").Append(simNO).Append("','").Append(machineNO);
            stb.Append("','").Append(controlPassword).Append("','").Append(machineType);
            stb.Append("',").Append(protocol).Append(",").Append(routeway);
            stb.Append(",'").Append(carType);
            stb.Append("','").Append(carBrand).Append("','").Append(carColor);
            stb.Append("','").Append(installPlace).Append("','").Append(installPerson);
            stb.Append("','").Append(businessPerson).Append("','").Append(joinTime);
            stb.Append("','").Append(overServiceTime).Append("','").Append(carRemark);
            stb.Append("','").Append(driver).Append("','").Append(driverTel);
            stb.Append("','").Append(driverMobile).Append("','").Append(driver2);
            stb.Append("','").Append(driver2Tel).Append("','").Append(driver2Mobile);
            stb.Append("','").Append(password).Append("','").Append(driverAddress);
            stb.Append("','").Append(driverFax).Append("','").Append(driverCompany);
            stb.Append("','").Append(buyTime);
            stb.Append("','").Append(specialRequest).Append("','").Append(driverRemark).Append("'");
            return stb.ToString();
        }
        /// <summary>
        /// 更新车辆停机状态语句
        /// </summary>
        /// <param name="stp"></param>
        /// <returns></returns>
        public String SqlUpdateStopedStr(int stp)
        {
            StringBuilder stb = new StringBuilder("update_car_stoped ");
            stb.Append(carID).Append(",").Append(stp);
            return stb.ToString();
        }
        /// <summary>
        /// 更新服务日期语句
        /// </summary>
        /// <param name="s"></param>
        /// <param name="stp"></param>
        /// <returns></returns>
        public String SqlUpdateServiceTimeStr(String s, int stp)
        {
            StringBuilder stb = new StringBuilder("update_car_overServiceTime ");
            stb.Append(carID).Append(",'").Append(s).Append("',").Append(stp);
            return stb.ToString();
        }
        /// <summary>
        /// 更新操作提示语句
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="ne"></param>
        /// <param name="nt"></param>
        /// <returns></returns>
        public String SqlUpdateEnableNotify(String ns, String ne, String nt)
        {
            StringBuilder stb = new StringBuilder("update_car_enable_notify ");
            stb.Append(carID).Append(",'").Append(ns).Append("','").Append(ne).Append("','").Append(nt).Append("'");
            return stb.ToString();
        }
        /// <summary>
        /// 更新操作提示语句
        /// </summary>
        public String SqlUpdateDisableNotify()
        {
            return "update_car_disable_notify " + carID.ToString();
        }
        /// <summary>
        /// 数据库删除语句
        /// </summary>
        /// <returns></returns>
        public String SqlDeleteStr()
        {
            return "delete_car " + carID.ToString();
        }
        #endregion

        #region set/get
        public UdpTerminal UdpAddr
        {
            get { return udpAddr; }
            set { udpAddr = value; }
        }
        public int DeclareCount
        {
            get { return declareCount; }
            set { declareCount = value; }
        }
        public TcpTerminal GprsConn
        {
            get { return gprsConn; }
            set { gprsConn = value; }
        }
        public DataClient HandleAlarmClient
        {
            get { return handleAlarmClient; }
            set { handleAlarmClient = value; }
        }
        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        public int TeamID
        {
            get { return teamID; }
            set { teamID = value; }
        }
        public String CarNO
        {
            get { return carNO; }
            set { carNO = value; }
        }
        public String SimNO
        {
            get { return simNO; }
            set { simNO = value; }
        }
        public String MachineNO
        {
            get { return machineNO; }
            set { machineNO = value; }
        }
        public String ControlPassword
        {
            get { return controlPassword; }
            set { controlPassword = value; }
        }
        public String MachineType
        {
            get { return machineType; }
            set { machineType = value; }
        }
        public int Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        public int Routeway
        {
            get { return routeway; }
            set { routeway = value; }
        }
        public String CarType
        {
            get { return carType; }
            set { carType = value; }
        }
        public String CarBrand
        {
            get { return carBrand; }
            set { carBrand = value; }
        }
        public String CarColor
        {
            get { return carColor; }
            set { carColor = value; }
        }
        public String InstallPlace
        {
            get { return installPlace; }
            set { installPlace = value; }
        }
        public String InstallPerson
        {
            get { return installPerson; }
            set { installPerson = value; }
        }
        public String BusinessPerson
        {
            get { return businessPerson; }
            set { businessPerson = value; }
        }
        public String JoinTime
        {
            get { return joinTime; }
            set { joinTime = value; }
        }
        public String OverServiceTime
        {
            get { return overServiceTime; }
            set { overServiceTime = value; }
        }
        public String CarRemark
        {
            get { return carRemark; }
            set { carRemark = value; }
        }
        public String Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        public String DriverTel
        {
            get { return driverTel; }
            set { driverTel = value; }
        }
        public String DriverMobile
        {
            get { return driverMobile; }
            set { driverMobile = value; }
        }
        public String Driver2
        {
            get { return driver2; }
            set { driver2 = value; }
        }
        public String Driver2Tel
        {
            get { return driver2Tel; }
            set { driver2Tel = value; }
        }
        public String Driver2Mobile
        {
            get { return driver2Mobile; }
            set { driver2Mobile = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String DriverAddress
        {
            get { return driverAddress; }
            set { driverAddress = value; }
        }
        public String DriverFax
        {
            get { return driverFax; }
            set { driverFax = value; }
        }
        public String DriverCompany
        {
            get { return driverCompany; }
            set { driverCompany = value; }
        }
        public String BuyTime
        {
            get { return buyTime; }
            set { buyTime = value; }
        }
        public int Stoped
        {
            get { return stoped; }
            set { stoped = value; }
        }
        public String SpecialRequest
        {
            get { return specialRequest; }
            set { specialRequest = value; }
        }
        public String DriverRemark
        {
            get { return driverRemark; }
            set { driverRemark = value; }
        }
        public bool RegionAlarm
        {
            get { return regionAlarm; }
            set { regionAlarm = value; }
        }
        public int RegionID
        {
            get { return regionID; }
            set { regionID = value; }
        }
        public Region Region
        {
            get { return region; }
            set { region = value; }
        }
        public Team Team
        {
            get { return team; }
            set { team = value; }
        }
        public Position Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public bool HasLogin
        {
            get { return hasLogin; }
            set { hasLogin = value; }
        }
        public List<AlarmPosition> AlarmPos
        {
            get { return alarmPos; }
            set { alarmPos = value; }
        }
        public List<Socket> WatchSockets
        {
            get { return watchSockets; }
            set { watchSockets = value; }
        }
        public int Notify
        {
            get { return notify; }
            set { notify = value; }
        }
        public String NotifyStart
        {
            get { return notifyStart; }
            set { notifyStart = value; }
        }
        public String NotifyEnd
        {
            get { return notifyEnd; }
            set { notifyEnd = value; }
        }
        public String NotifyText
        {
            get { return notifyText; }
            set { notifyText = value; }
        }

        public List<Socket> PointSockets
        {
            get { return pointSockets; }
            set { pointSockets = value; }
        }

        public List<Socket> GetSetSockets
        {
            get { return getSetSockets; }
            set { getSetSockets = value; }
        }
        #endregion
    }
    /// <summary>
    /// 定位点
    /// </summary>
    public class Position
    {
        public static String[] DIR = { "正北", "东北", "正东", "东南", "正南", "西南", "正西", "西北" };
        public static String[] POINTED = { "未定位", "正常" };

        private String mNO = "";
        private int carID;
        private String gpsTime = "";
        private int pointed = 0;
        private double lo = 116.46;
        private double la = 39.92;
        private int speed = 0;
        private int direction = 0;
        private String status = "";
        private String alarm = "";
        private int alarmHandle = 0;
        private int mileage = 0;

        private TcpTerminal gprsClient = null;
        private bool hasPoint = false;//是否保护定位信息，登陆、获取设置等不一定有定位信息在内
        private bool isPointMsg = false;//定位返回信息
        private bool isGetSetMsg = false;//获取设置返回信息
        private bool isLoginMsg = false;//登陆信息
        private String settingStr = "";


        public TcpTerminal GprsClient
        {
            get { return gprsClient; }
            set { gprsClient = value; }
        }
        public bool HasPoint
        {
            get { return hasPoint; }
            set { hasPoint = value; }
        }
        public bool IsLoginMsg
        {
            get { return isLoginMsg; }
            set { isLoginMsg = value; }
        }
        public String SettingStr
        {
            get { return settingStr; }
            set { settingStr = value; }
        }
        public bool IsGetSetMsg
        {
            get { return isGetSetMsg; }
            set { isGetSetMsg = value; }
        }

        public bool IsPointMsg
        {
            get { return isPointMsg; }
            set { isPointMsg = value; }
        }

        public String MNO
        {
            get { return mNO; }
            set { mNO = value; }
        }
        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        public String GpsTime
        {
            get { return gpsTime; }
            set { gpsTime = value; }
        }
        public int Pointed
        {
            get { return pointed; }
            set { pointed = value; }
        }
        public double Lo
        {
            get { return lo; }
            set { lo = value; }
        }
        public double La
        {
            get { return la; }
            set { la = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public String Alarm
        {
            get { return alarm; }
            set { alarm = value; }
        }
        public int AlarmHandle
        {
            get { return alarmHandle; }
            set { alarmHandle = value; }
        }
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        /// <summary>
        /// 复制定位点信息
        /// </summary>
        /// <param name="pos"></param>
        public void Clone(Position pos)
        {
            this.gpsTime = pos.gpsTime;
            this.pointed = pos.pointed;
            this.lo = pos.lo;
            this.la = pos.la;
            this.speed = pos.speed;
            this.direction = pos.direction;
            this.status = pos.status;
            this.alarm = pos.alarm;
            this.alarmHandle = pos.alarmHandle;
        }
        /// <summary>
        /// 把定位点转换到字符串形式
        /// </summary>
        /// <returns></returns>
        public override String  ToString()
        {
            StringBuilder stb = new StringBuilder(gpsTime).Append(Constant.SPLIT2);
            stb.Append(pointed).Append(Constant.SPLIT2).Append(lo).Append(Constant.SPLIT2);
            stb.Append(la).Append(Constant.SPLIT2).Append(speed).Append(Constant.SPLIT2);
            stb.Append(direction).Append(Constant.SPLIT2).Append(status).Append(Constant.SPLIT2);
            stb.Append(alarm).Append(Constant.SPLIT2).Append(alarmHandle);
            return stb.ToString();
        }
        /// <summary>
        /// 从字符串解析定位点
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Position Parse(String s)
        {
            Position pos = new Position();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                pos.GpsTime = ss[0];
                pos.Pointed = Int32.Parse(ss[1]);
                pos.Lo = Double.Parse(ss[2]);
                pos.La = Double.Parse(ss[3]);
                pos.Speed = Int32.Parse(ss[4]);
                pos.Direction = Int32.Parse(ss[5]);
                pos.Status = ss[6];
                pos.Alarm = ss[7];
                pos.AlarmHandle = Int32.Parse(ss[8]);
            }
            catch { return null; }
            return pos;
        }
        /// <summary>
        /// 数据库插入语句
        /// </summary>
        /// <returns></returns>
        public String SqlInsertStr()
        {
            StringBuilder stb = new StringBuilder("insert_position ");
            stb.Append(carID).Append(",'").Append(gpsTime).Append("',");
            stb.Append(pointed).Append(",").Append(lo).Append(",");
            stb.Append(la).Append(",").Append(speed).Append(",");
            stb.Append(direction).Append(",'").Append(status).Append("','");
            stb.Append(alarm).Append("',");
            stb.Append(mileage).Append(",").Append(alarmHandle);
            return stb.ToString();
        }
    }
    /// <summary>
    /// 报警定位点
    /// </summary>
    public class AlarmPosition : Position
    {
        private int opUserID = 0;

        public int OpUserID
        {
            get { return opUserID; }
            set { opUserID = value; }
        }

        public AlarmPosition()
        {
            AlarmHandle = 1;
        }
        /// <summary>
        /// 复制定位点信息
        /// </summary>
        /// <param name="pos"></param>
        public AlarmPosition(int pid, Position pos)
        {
            id = pid;
            CarID = pos.CarID;
            GpsTime = pos.GpsTime;
            Pointed = pos.Pointed;
            Lo = pos.Lo;
            La = pos.La;
            Speed = pos.Speed;
            Direction = pos.Direction;
            Status = pos.Status;
            Alarm = pos.Alarm;
            AlarmHandle = 1;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 把定位点转换到字符串形式
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(id.ToString()).Append(Constant.SPLIT2);
            stb.Append(CarID).Append(Constant.SPLIT2).Append(GpsTime).Append(Constant.SPLIT2);
            stb.Append(Pointed).Append(Constant.SPLIT2).Append(Lo).Append(Constant.SPLIT2);
            stb.Append(La).Append(Constant.SPLIT2).Append(Speed).Append(Constant.SPLIT2);
            stb.Append(Direction).Append(Constant.SPLIT2).Append(Status).Append(Constant.SPLIT2);
            stb.Append(Alarm).Append(Constant.SPLIT2).Append(AlarmHandle);
            return stb.ToString();
        }

        /// <summary>
        /// 从字符串解析定位点
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static new AlarmPosition Parse(String s)
        {
            AlarmPosition pos = new AlarmPosition();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                pos.id = Int32.Parse(ss[0]);
                pos.CarID = Int32.Parse(ss[1]);
                pos.GpsTime = ss[2];
                pos.Pointed = Int32.Parse(ss[3]);
                pos.Lo = Double.Parse(ss[4]);
                pos.La = Double.Parse(ss[5]);
                pos.Speed = Int32.Parse(ss[6]);
                pos.Direction = Int32.Parse(ss[7]);
                pos.Status = ss[8];
                pos.Alarm = ss[9];
                pos.AlarmHandle = Int32.Parse(ss[10]);
            }
            catch { return null; }
            return pos;
        }
    }
}
