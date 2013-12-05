using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    public class Account
    {
        public const int ADMIN = 0;
        public const int OPERATOR = 1;

        public static String[] TYPE = { "系统管理员", "分控管理员" };
        public static String[] POLICY = { "编辑车队信息", "编辑车辆信息", "下发指令", "导出车辆列表", "处理投诉、故障", "处理报警", "处理服务过期" };

        private int id;
        private String name = "";
        private String pw = "";
        private int type;
        private String tel = "";
        private String email = "";
        private String joinTime = "";
        private int policyModTeam = 1;
        private int policyModCar = 1;
        private int policyOrder = 1;
        private int policyExportCars = 1;
        private int policyDeclare = 1;
        private int policyAlarmList = 1;
        private int policyOverTime = 1;
        private int policyNotify = 1;

        private List<int> teams = new List<int>();
        #region get/set
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Pw
        {
            get { return pw; }
            set { pw = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
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
        public List<int> Teams
        {
            get { return teams; }
            set { teams = value; }
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
#endregion
        public Account()
        {
        }
        public Account(Account at)
        {
            Clone(at);
        }
        public void Clone(Account at)
        {
            id = at.id;
            name = at.name;
            pw = at.pw;
            type = at.type;
            tel = at.tel;
            email = at.email;
            joinTime = at.joinTime;
            foreach(int i in at.teams)
                teams.Add(i);
            policyModTeam = at.policyModTeam;
            policyModCar = at.policyModCar;
            policyOrder = at.policyOrder;
            policyExportCars = at.policyExportCars;
            policyDeclare = at.policyDeclare;
            policyAlarmList = at.policyAlarmList;
            policyOverTime = at.policyOverTime;
            policyNotify = at.policyNotify;
        }

        public override string ToString()
        {
            StringBuilder stb = new StringBuilder(id.ToString()).Append(Constant.SPLIT2);
            stb.Append(name).Append(Constant.SPLIT2).Append(pw).Append(Constant.SPLIT2);
            stb.Append(type).Append(Constant.SPLIT2).Append(tel).Append(Constant.SPLIT2);
            stb.Append(email).Append(Constant.SPLIT2).Append(joinTime).Append(Constant.SPLIT2);
            if(teams.Count > 0)
            {
                foreach(int tid in teams)
                    stb.Append(tid).Append(Constant.SPLIT_EX_1);
                stb.Remove(stb.Length - 1, 1);
            }
            stb.Append(Constant.SPLIT2).Append(policyModTeam).Append(Constant.SPLIT2).Append(policyModCar).Append(Constant.SPLIT2);
            stb.Append(policyOrder).Append(Constant.SPLIT2).Append(policyExportCars).Append(Constant.SPLIT2);
            stb.Append(policyDeclare).Append(Constant.SPLIT2).Append(policyAlarmList).Append(Constant.SPLIT2);
            stb.Append(policyOverTime).Append(Constant.SPLIT2).Append(policyNotify);
            return stb.ToString();
        }

        public static Account Parse(String s)
        {
            Account accout = new Account();
            String[] ss = s.Split(Constant.SPLIT2);
            accout.id = Int32.Parse(ss[0]);
            accout.name = ss[1];
            accout.pw = ss[2];
            accout.type = Int32.Parse(ss[3]);
            accout.tel = ss[4];
            accout.email = ss[5];
            accout.joinTime = ss[6];
            if(ss[7].Length > 0)
            {
                String[] sss = ss[7].Split(Constant.SPLIT_EX_1);
                foreach(String temp in sss)
                    try
                    {
                        accout.teams.Add(Int32.Parse(temp));
                    }
                    catch { }
            }
            accout.policyModTeam = Int32.Parse(ss[8]);
            accout.policyModCar = Int32.Parse(ss[9]);
            accout.policyOrder = Int32.Parse(ss[10]);
            accout.policyExportCars = Int32.Parse(ss[11]);
            accout.policyDeclare = Int32.Parse(ss[12]);
            accout.policyAlarmList = Int32.Parse(ss[13]);
            accout.policyOverTime = Int32.Parse(ss[14]);
            accout.policyNotify = Int32.Parse(ss[15]);
            return accout;
        }

        public void Update(String s)
        {
            String[] ss = s.Split(Constant.SPLIT2);
            id = Int32.Parse(ss[0]);
            name = ss[1];
            pw = ss[2];
            type = Int32.Parse(ss[3]);
            tel = ss[4];
            email = ss[5];
            joinTime = ss[6];
            teams.Clear();
            if(ss[7].Length > 0)
            {
                String[] sss = ss[7].Split(Constant.SPLIT_EX_1);
                foreach(String temp in sss)
                    teams.Add(Int32.Parse(temp));
            }
            policyModTeam = Int32.Parse(ss[8]);
            policyModCar = Int32.Parse(ss[9]);
            policyOrder = Int32.Parse(ss[10]);
            policyExportCars = Int32.Parse(ss[11]);
            policyDeclare = Int32.Parse(ss[12]);
            policyAlarmList = Int32.Parse(ss[13]);
            policyOverTime = Int32.Parse(ss[14]);
            policyNotify = Int32.Parse(ss[15]);
        }
    }
}
