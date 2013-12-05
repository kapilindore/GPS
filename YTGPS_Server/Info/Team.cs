using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// 车辆列表
    /// </summary>
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
    /// <summary>
    /// 车辆
    /// </summary>
    public class Team : CarList
    {
        private int teamID;
        private String password = "";
        private String teamName = "";
        private String teamAddress = "";
        private String teamTel = "";
        private String teamLinkman = "";
        private String joinTime = "";
        private int policyModCar = 0;
        private int policyOrder = 0;
        private int policyRegion = 1;
        private int policyRegionAlarm = 1;


        private bool hasLogin = false;


        #region get/set
        public int TeamID
        {
            get { return teamID; }
            set { teamID = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }
        public String TeamAddress
        {
            get { return teamAddress; }
            set { teamAddress = value; }
        }
        public String TeamTel
        {
            get { return teamTel; }
            set { teamTel = value; }
        }
        public String TeamLinkman
        {
            get { return teamLinkman; }
            set { teamLinkman = value; }
        }
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
        public bool HasLogin
        {
            get { return hasLogin; }
            set { hasLogin = value; }
        }
        #endregion

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

        public String SqlInsertStr()
        {
            StringBuilder stb = new StringBuilder("insert_team '");
            stb.Append(password).Append("','");
            stb.Append(teamName).Append("','").Append(teamLinkman).Append("','");
            stb.Append(teamTel).Append("','").Append(teamAddress).Append("',");
            stb.Append(PolicyModCar).Append(",").Append(PolicyOrder).Append(",");
            stb.Append(policyRegion).Append(",").Append(PolicyRegionAlarm);
            return stb.ToString();
        }

        public String SqlUpdateStr()
        {
            StringBuilder stb = new StringBuilder("update_team ");
            stb.Append(teamID).Append(",'").Append(password).Append("','");
            stb.Append(teamName).Append("','").Append(teamLinkman).Append("','");
            stb.Append(teamTel).Append("','").Append(teamAddress).Append("',");
            stb.Append(PolicyModCar).Append(",").Append(PolicyOrder).Append(",");
            stb.Append(policyRegion).Append(",").Append(PolicyRegionAlarm);
            return stb.ToString();
        }

        public String SqlDeleteStr()
        {
            return "delete_team " + teamID.ToString();
        }
    }
}
