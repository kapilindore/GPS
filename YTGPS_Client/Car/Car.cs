using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Client
{
    public class Car
    {
        public static String ClassName = "Car";
        private static List<String> routewayList = new List<string>();
        public static List<String> RoutewayList
        {
            get { return Car.routewayList; }
            set { Car.routewayList = value; }
        }
        public static String[] PROTOCOL = { "", "", "","GPRS协议A","GPRS协议B"};
        public static String[] SERVICE_STATUS = { "正常", "停机" };

        private int carID;
        private int teamID;
        private String carNO = "";
        private String simNO = "";
        private String machineNO = "";
        private String controlPassword = "";
        private String machineType = "";
        private int protocol = Config.PreProtocol;
        private int routeway = Config.PreRouteway;
        private String carType = "";
        private String carBrand = "";
        private String carColor = "";
        private String installPlace = "";
        private String installPerson = "";
        private String businessPerson = "";
        private String joinTime = Pub.DateTimeStr;
        private String overServiceTime = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
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

        private String preGPSTime = Pub.DateTimeStr;

        private int regionAlarm = 0;
        private int regionID;

        private Team team;
        private Position pos = null;
        private int mileage = 0;
        private int totalMileage = 0;
        private TreeNode itemInList = null;
        private ListViewItem itemInWatch = null;

        private int notify = 0;
        private String notifyStart = Pub.DateStr;
        private String notifyEnd = Pub.DateStr;
        private String notifyText = "";

        private int declareCount = 0;

        private String setting = "";

        private bool teamPreCheck = false;
        private bool isWatched = false;

        #region public function
        public Car()
        {
        }
        public Car(Car car)
        {
            Clone(car);
        }

        public void Clone(Car car)
        {
            this.team = car.team;
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
            this.NotifyStart = car.NotifyStart;
            this.NotifyEnd = car.NotifyEnd;
            this.NotifyText = car.NotifyText;
        }

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
            stb.Append(Constant.SPLIT2).Append(Notify).Append(Constant.SPLIT2).Append(NotifyStart);
            stb.Append(Constant.SPLIT2).Append(NotifyEnd).Append(Constant.SPLIT2).Append(NotifyText);
            return stb.ToString();
        }
        //从字符串初始化
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
                car.notify = Int32.Parse(ss[31]);
                car.notifyStart = ss[32];
                car.notifyEnd = ss[33];
                car.notifyText = ss[34];
                car.declareCount = Int32.Parse(ss[35]);
            }
            catch { return null; }
            return car;
        }

        public static void AddRouteway(String s)
        {
            routewayList.Add(s);
        }

        public static void DelRouteway(int index)
        {
            routewayList.RemoveAt(index);
        }

        public static void ParseRouteway(String s)
        {
            routewayList.Clear();
            String[] ss = s.Split(Constant.SPLIT2);
            foreach(String s1 in ss)
                routewayList.Add(s1);
        }
        #endregion

        #region set/get
        public int DeclareCount
        {
            get { return declareCount; }
            set { declareCount = value; }
        }
        public bool IsWatched
        {
            get { return isWatched; }
            set { isWatched = value; }
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
        public int RegionAlarm
        {
            get { return regionAlarm; }
            set { regionAlarm = value; }
        }
        public int RegionID
        {
            get { return regionID; }
            set { regionID = value; }
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
        public String SettingStr
        {
            get { return setting; }
            set { setting = value; }
        }
        public String PreGPSTime
        {
            get { return preGPSTime; }
            set { preGPSTime = value; }
        }
        //
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
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public int TotalMileage
        {
            get { return totalMileage; }
            set { totalMileage = value; }
        }
        public TreeNode ItemInList
        {
            get { return itemInList; }
            set { itemInList = value; }
        }
        public ListViewItem ItemInWatch
        {
            get { return itemInWatch; }
            set { itemInWatch = value; }
        }

        public bool TeamPreCheck
        {
            get { return teamPreCheck; }
            set { teamPreCheck = value; }
        }
        #endregion
    }

    public class QueryCondition
    {
        public static String[] LABEL = new String[]{
            "车牌",
            "Sim卡号",
            "终端序列号",
            "反控密码",
            "终端型号",
            "车辆品牌",
            "车辆类型",
            "车身颜色",
            "安装地点",
            "安装人员",
            "业务人员",
            "入网日期",
            "服务日期",
            "车辆信息备注",
            "车主1",
            "车主1电话",
            "车主1手机",
            "车主2",
            "车主2电话",
            "车主2手机",
            "登陆密码",
            "家庭地址",
            "办公室电话",
            "车主公司",
            "购车日期",
            "特殊要求",
            "用户信息备注"
            };
        public static String[] TYPE = new String[]{
            "包含关键字",
            "等于关键字",
            "不包含关键字"
            };

        private int label = 0;
        private int type = 0;
        private String keyword = "";

        public int Label
        {
            get { return label; }
            set { label = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public String Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
    }

    public class CarList
    {
        public CarList()
        {
            cars = new List<Car>();
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public Car GetCarByID(int id)
        {
            foreach(Car car in cars)
                if(car.CarID == id)
                    return car;
            return null;
        }
    }

    public class Team : CarList
    {
        public static String ClassName = "Team";

        private int teamID;
        private int policyModCar = 0;
        private int policyOrder = 0;
        private int policyRegion = 1;
        private int policyRegionAlarm = 1;

        private bool carPreCheck = false;

        public Team()
        {
        }


        public Team(Team team)
        {
            Clone(team);
        }

        public void Clone(Team team)
        {
            this.TeamID = team.TeamID;
            this.password = team.password;
            this.TeamName = team.TeamName;
            this.TeamLinkman = team.TeamLinkman;
            this.TeamTel = team.TeamTel;
            this.teamAddress = team.teamAddress;
            this.PolicyModCar = team.PolicyModCar;
            this.PolicyOrder = team.PolicyOrder;
            this.policyRegion = team.policyRegion;
            this.PolicyRegionAlarm = team.PolicyRegionAlarm;
        }

        public bool CarPreCheck
        {
            get { return carPreCheck; }
            set { carPreCheck = value; }
        }

        public int TeamID
        {
            get { return teamID; }
            set { teamID = value; }
        }
        private String password = "";

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        private String teamName = "";

        public String TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }
        private String teamAddress = "";

        public String TeamAddress
        {
            get { return teamAddress; }
            set { teamAddress = value; }
        }
        private String teamTel = "";

        public String TeamTel
        {
            get { return teamTel; }
            set { teamTel = value; }
        }
        private String teamLinkman = "";

        public String TeamLinkman
        {
            get { return teamLinkman; }
            set { teamLinkman = value; }
        }
        private String joinTime = "";

        public String JoinTime
        {
            get { return joinTime; }
            set { joinTime = value; }
        }
        public int PolicyModCar
        {
            get { return policyModCar; }
            set { policyModCar = value; }
        }
        public int PolicyOrder
        {
            get { return policyOrder; }
            set { policyOrder = value; }
        }
        public int PolicyRegion
        {
            get { return policyRegion; }
            set { policyRegion = value; }
        }
        public int PolicyRegionAlarm
        {
            get { return policyRegionAlarm; }
            set { policyRegionAlarm = value; }
        }

        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(teamID.ToString()).Append(Constant.SPLIT2);
            stb.Append(password).Append(Constant.SPLIT2).Append(teamName).Append(Constant.SPLIT2);
            stb.Append(teamLinkman).Append(Constant.SPLIT2).Append(teamTel).Append(Constant.SPLIT2);
            stb.Append(teamAddress).Append(Constant.SPLIT2).Append(joinTime).Append(Constant.SPLIT2);
            stb.Append(PolicyModCar).Append(Constant.SPLIT2).Append(PolicyOrder).Append(Constant.SPLIT2);
            stb.Append(policyRegion).Append(Constant.SPLIT2).Append(PolicyRegionAlarm);
            return stb.ToString();
        }

        public static Team Parse(String s)
        {
            Team team = new Team();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                team.TeamID = Int32.Parse(ss[0]);
                team.password = ss[1];
                team.TeamName = ss[2];
                team.TeamLinkman = ss[3];
                team.TeamTel = ss[4];
                team.TeamAddress = ss[5];
                team.JoinTime = ss[6];
                team.PolicyModCar = Int32.Parse(ss[7]);
                team.PolicyOrder = Int32.Parse(ss[8]);
                team.policyRegion = Int32.Parse(ss[9]);
                team.PolicyRegionAlarm = Int32.Parse(ss[10]);
            }
            catch { return null; }
            return team;
        }
    }

    public class Position
    {
        public static String[] DIR = { "正北", "东北", "正东", "东南", "正南", "西南", "正西", "西北" };
        public static String[] POINTED = { "未定位", "正常" };
        public static String[] ALARM_HANDLE = { "无报警", "未解除", "已解除" };

        private String gpsTime = "";

        public String GpsTime
        {
            get { return gpsTime; }
            set { gpsTime = value; }
        }
        private int pointed;

        public int Pointed
        {
            get { return pointed; }
            set { pointed = value; }
        }
        private double lo;

        public double Lo
        {
            get { return lo; }
            set { lo = value; }
        }
        private double la;

        public double La
        {
            get { return la; }
            set { la = value; }
        }
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private int direction;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        private String status = "";

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private String alarm = "";

        public String Alarm
        {
            get { return alarm; }
            set { alarm = value; }
        }
        private int alarmHandle;

        public int AlarmHandle
        {
            get { return alarmHandle; }
            set { alarmHandle = value; }
        }

        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(gpsTime).Append(Constant.SPLIT2);
            stb.Append(pointed).Append(Constant.SPLIT2).Append(lo).Append(Constant.SPLIT2);
            stb.Append(la).Append(Constant.SPLIT2).Append(speed).Append(Constant.SPLIT2);
            stb.Append(direction).Append(Constant.SPLIT2).Append(status).Append(Constant.SPLIT2);
            stb.Append(alarm).Append(Constant.SPLIT2);
            stb.Append(alarmHandle);
            return stb.ToString();
        }

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
    }

    public class HisAlarmPosition : Position
    {
        private String remark = "";

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(GpsTime).Append(Constant.SPLIT2);
            stb.Append(Pointed).Append(Constant.SPLIT2).Append(Lo).Append(Constant.SPLIT2);
            stb.Append(La).Append(Constant.SPLIT2).Append(Speed).Append(Constant.SPLIT2);
            stb.Append(Direction).Append(Constant.SPLIT2).Append(Status).Append(Constant.SPLIT2);
            stb.Append(Alarm).Append(Constant.SPLIT2).Append(remark);
            return stb.ToString();
        }

        public static new HisAlarmPosition Parse(String s)
        {
            HisAlarmPosition pos = new HisAlarmPosition();
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
                pos.remark = ss[8];
                pos.AlarmHandle = Int32.Parse(ss[9]);
            }
            catch { return null; }
            return pos;
        }
    }
    public class AlarmPosition : Position
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int carID;

        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }

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

        public static new AlarmPosition Parse(String s)
        {
            AlarmPosition pos = new AlarmPosition();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                pos.id = Int32.Parse(ss[0]);
                pos.carID = Int32.Parse(ss[1]);
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

    public class Mileage
    {
        private int carID;

        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; }
        }
        private String miles;

        public String Miles
        {
            get { return miles; }
            set { miles = value; }
        }
        private String totalMileage;

        public String TotalMiles
        {
            get { return totalMileage; }
            set { totalMileage = value; }
        }
    }

    public class Place
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private double lo;

        public double Lo
        {
            get { return lo; }
            set { lo = value; }
        }
        private double la;

        public double La
        {
            get { return la; }
            set { la = value; }
        }

        public override String ToString()
        {
            StringBuilder stb = new StringBuilder(name).Append(Constant.SPLIT2);
            stb.Append(lo).Append(Constant.SPLIT2).Append(la);
            return stb.ToString();
        }

        public static Place Parse(String s)
        {
            Place place = new Place();
            String[] ss = s.Split(Constant.SPLIT2);
            try
            {
                place.name = ss[0];
                place.lo = Double.Parse(ss[1]);
                place.la = Double.Parse(ss[2]);
            }
            catch { return null; }
            return place;
        }
    }
}
