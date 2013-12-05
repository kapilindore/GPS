

    public class Position
    {
        public static String[] DIR = { "正北", "东北", "正东", "东南", "正南", "西南", "正西", "西北" };
        public static String[] POINTED = { "未定位", "正常" };

        private String mNO = "";
        private int carID;
        private String gpsTime = "";
        private int pointed = 0;
        private double lo = 113.33;
        private double la = 23.33;
        private int speed = 0;
        private int direction = 0;
        private String status = "";
        private String alarm = "";
        private int alarmHandle = 0;
        private int mileage = 0;

        private GprsClient gprsClient = null;
        private bool hasPoint = false;//是否保护定位信息，登陆、获取设置等不一定有定位信息在内
        private bool isPointMsg = false;//定位返回信息
        private bool isGetSetMsg = false;//获取设置返回信息
        private bool isLoginMsg = false;//登陆信息
        private String settingStr = "";


        public GprsClient GprsClient
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

        public override String  ToString()
        {
            StringBuilder stb = new StringBuilder(gpsTime).Append(Constant.SPLIT2);
            stb.Append(pointed).Append(Constant.SPLIT2).Append(lo).Append(Constant.SPLIT2);
            stb.Append(la).Append(Constant.SPLIT2).Append(speed).Append(Constant.SPLIT2);
            stb.Append(direction).Append(Constant.SPLIT2).Append(status).Append(Constant.SPLIT2);
            stb.Append(alarm).Append(Constant.SPLIT2).Append(alarmHandle);
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