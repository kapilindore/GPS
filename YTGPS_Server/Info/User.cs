using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// ’ ªß
    /// </summary>
    public class User
    {
        public const int USER_ADMIN = 0;
        public const int USER_OP = 1;
        public const int USER_TEAM = 2;
        public const int USER_CAR = 3;
        public const int USER_WEB = 4;

        private int userID;
        private String userName = "";
        private int userType;
        private String password = "";
        private String tel = "";
        private String email = "";
        private String joinTime;
        private String teamStr;
        private int policyModTeam = 1;
        private int policyModCar = 1;
        private int policyOrder = 1;
        private int policyExportCars = 1;
        private int policyDeclare = 1;
        private int policyAlarmList = 1;
        private int policyOverTime = 1;
        private int policyNotify = 1;

        private List<Team> teams = new List<Team>();
        private bool hasLogin = false;


        #region get/set
        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String JoinTime
        {
            get { return joinTime; }
            set { joinTime = value; }
        }
        public int PolicyModTeam
        {
            get { return policyModTeam; }
            set { policyModTeam = value; }
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
        public int PolicyExportCars
        {
            get { return policyExportCars; }
            set { policyExportCars = value; }
        }
        public int PolicyDeclare
        {
            get { return policyDeclare; }
            set { policyDeclare = value; }
        }
        public int PolicyAlarmList
        {
            get { return policyAlarmList; }
            set { policyAlarmList = value; }
        }
        public int PolicyOverTime
        {
            get { return policyOverTime; }
            set { policyOverTime = value; }
        }
        public int PolicyNotify
        {
            get { return policyNotify; }
            set { policyNotify = value; }
        }

        public String TeamStr
        {
            get { return teamStr; }
            set { teamStr = value; }
        }
        internal List<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }
        public bool HasLogin
        {
            get { return hasLogin; }
            set { hasLogin = value; }
        }
        #endregion
        public Car GetCarByID(int id)
        {
            foreach(Team team in teams)
                foreach(Car car in team.Cars)
                    if(car.CarID == id)
                        return car;
            return null;
        }

        public Team GetTeamByID(int id)
        {
            foreach(Team team in teams)
                if(team.TeamID == id)
                    return team;
            return null;
        }

        public override string ToString()
        {
            StringBuilder stb = new StringBuilder(userID.ToString()).Append(Constant.SPLIT2);
            stb.Append(userName).Append(Constant.SPLIT2).Append(password).Append(Constant.SPLIT2);
            stb.Append(userType).Append(Constant.SPLIT2).Append(tel).Append(Constant.SPLIT2);
            stb.Append(email).Append(Constant.SPLIT2).Append(joinTime).Append(Constant.SPLIT2);
            stb.Append(teamStr).Append(Constant.SPLIT2);
            stb.Append(policyModTeam).Append(Constant.SPLIT2).Append(policyModCar).Append(Constant.SPLIT2);
            stb.Append(policyOrder).Append(Constant.SPLIT2).Append(policyExportCars).Append(Constant.SPLIT2);
            stb.Append(policyDeclare).Append(Constant.SPLIT2).Append(policyAlarmList).Append(Constant.SPLIT2);
            stb.Append(policyOverTime).Append(Constant.SPLIT2).Append(policyNotify);
            return stb.ToString();
        }

        public static User Parse(String s)
        {
            User user = new User();
            String[] ss = s.Split(Constant.SPLIT2);
            user.userID = Int32.Parse(ss[0]);
            user.userName = ss[1];
            user.password = ss[2];
            user.userType = Int32.Parse(ss[3]);
            user.tel = ss[4];
            user.email = ss[5];
            if(ss[6] == "")
                user.joinTime = Pub.DateTimeStr;
            else
                user.joinTime = ss[6];
            user.teamStr = ss[7];
            user.policyModTeam = Int32.Parse(ss[8]);
            user.policyModCar = Int32.Parse(ss[9]);
            user.policyOrder = Int32.Parse(ss[10]);
            user.policyExportCars = Int32.Parse(ss[11]);
            user.policyDeclare = Int32.Parse(ss[12]);
            user.policyAlarmList = Int32.Parse(ss[13]);
            user.policyOverTime = Int32.Parse(ss[14]);
            user.policyNotify = Int32.Parse(ss[15]);
            return user;
        }

        public void Clone(User user)
        {
            userID = user.userID;
            userName = user.userName;
            password = user.password;
            userType = user.userType;
            tel = user.tel;
            email = user.email;
            joinTime = user.joinTime;
            teamStr = user.teamStr;
            teams = user.teams;
            policyModTeam = user.policyModTeam;
            policyModCar = user.policyModCar;
            policyOrder = user.policyOrder;
            policyExportCars = user.policyExportCars;
            policyDeclare = user.policyDeclare;
            policyAlarmList = user.policyAlarmList;
            policyOverTime = user.policyOverTime;
            policyNotify = user.policyNotify;
        }

        public String SqlInsertStr()
        {
            StringBuilder stb = new StringBuilder("insert_user '");
            stb.Append(userName).Append("','").Append(password).Append("','");
            stb.Append(userType).Append("','").Append(tel).Append("','");
            stb.Append(email).Append("','").Append(teamStr).Append("',");
            stb.Append(policyModTeam).Append(",").Append(policyModCar).Append(",");
            stb.Append(policyOrder).Append(",").Append(policyExportCars).Append(",");
            stb.Append(policyDeclare).Append(",").Append(policyAlarmList).Append(",");
            stb.Append(policyOverTime).Append(",").Append(policyNotify);
            return stb.ToString();
        }

        public String SqlUpdateStr()
        {
            StringBuilder stb = new StringBuilder("update_user ").Append(userID).Append(",'");
            stb.Append(userName).Append("','").Append(password).Append("','");
            stb.Append(userType).Append("','").Append(tel).Append("','");
            stb.Append(email).Append("','").Append(teamStr).Append("',");
            stb.Append(policyModTeam).Append(",").Append(policyModCar).Append(",");
            stb.Append(policyOrder).Append(",").Append(policyExportCars).Append(",");
            stb.Append(policyDeclare).Append(",").Append(policyAlarmList).Append(",");
            stb.Append(policyOverTime).Append(",").Append(policyNotify);
            return stb.ToString();
        }

        public String SqlDeleteStr()
        {
            return "delete_user " + userID.ToString();
        }
    }
}
