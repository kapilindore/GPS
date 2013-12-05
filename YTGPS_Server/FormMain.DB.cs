using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace YTGPS_Server
{
    public partial class FormMain : Form
    {
        /*
         * 系统信息操作函数
         */
        /*
        private Region GetRegionByID(int id)
        {
            foreach(Region rg in regionList)
                if(rg.RegionID == id)
                    return rg;
            return null;
        }*/
        private Team GetTeamByID(int id)
        {
            foreach(Team team in teamList)
                if(team.TeamID == id)
                    return team;
            return null;
        }
        private User GetUserByID(int id)
        {
            foreach(User user in userList)
                if(user.UserID == id)
                    return user;
            return null;
        }
        private User GetUserByName(String uname)
        {
            foreach(User user in userList)
                if(user.UserName == uname)
                    return user;
            return null;
        }
        private Team GetTeamByName(String s)
        {
            foreach(Team t in teamList)
                if(s == t.TeamName)
                    return t;
            return null;
        }
        private int CheckUserNameCount(String uname)
        {
            int i = 0;
            foreach(User user in userList)
                if(user.UserName == uname)
                    i++;
            return i;
        }
        private Car GetCarByID(int id)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarID == id)
                        return car;
            return null;
        }
        private Car GetCarByNO(String no)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarNO == no)
                        return car;
            return null;
        }
        private Car GetCarByMNO(String mno)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.MachineNO == mno)
                        return car;
            return null;
        }

        private Car GetCarBySNO(String sim)
        {
            foreach(Team team in teamList)
                foreach (Car car in team.Cars)
                {
                    if (car.SimNO == sim)
                        return car;
                }
            return null;
        }
        private Car CheckCarInfo(Car c)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarID != c.CarID && (car.CarNO == c.CarNO || car.SimNO == c.SimNO || car.MachineNO == c.MachineNO))
                        return car;
            return null;
        }
        //初始化系统数据
        private bool LoadInfoFromDB()
        {
            bool ret = false;
            dbm = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
            if(dbm != null)
            {
                try
                {
                    //regionList.Clear();
                    teamList.Clear();
                    userList.Clear();
                    DataTable dt = null;
                    /*dbm.ExecuteQuery("select_region");
                    foreach(DataRow dr in dt.Rows)
                    {
                        int id = Int32.Parse(dr[0].ToString());
                        String s = dr[1].ToString();
                        Region region = new Region(dr[2].ToString());
                        region.RegionID = id;
                        region.RegionName = s;
                        regionList.Add(region);
                    }*/
                    dt = dbm.ExecuteQuery("select_team");
                    foreach(DataRow dr in dt.Rows)
                    {
                        Team team = new Team();
                        team.TeamID = Int32.Parse(dr[0].ToString());
                        team.Password = dr[1].ToString();
                        team.TeamName = dr[2].ToString();
                        team.TeamLinkman = dr[3].ToString();
                        team.TeamTel = dr[4].ToString();
                        team.TeamAddress = dr[5].ToString();
                        team.JoinTime = dr[6].ToString();
                        team.PolicyModCar = Int32.Parse(dr[7].ToString());
                        team.PolicyOrder = Int32.Parse(dr[8].ToString());
                        team.PolicyRegion = Int32.Parse(dr[9].ToString());
                        team.PolicyRegionAlarm = Int32.Parse(dr[10].ToString());
                        teamList.Add(team);
                    }
                    dt = dbm.ExecuteQuery("select_car");
                    foreach(DataRow dr in dt.Rows)
                    {
                        Car car = Car.ParseWithPosition(dr);
                        if(car != null)
                        {
                            //if(car.RegionID != 0)
                                //car.Region = GetRegionByID(car.RegionID);
                            car.Team = GetTeamByID(car.TeamID);
                            car.Team.Cars.Add(car);
                        }
                    }
                    dt = dbm.ExecuteQuery("select_user");
                    foreach(DataRow dr in dt.Rows)
                    {
                        User user = new User();
                        user.UserID = Int32.Parse(dr[0].ToString());
                        user.UserName = dr[1].ToString();
                        user.Password = dr[2].ToString();
                        user.UserType = Int32.Parse(dr[3].ToString());
                        user.Tel = dr[4].ToString();
                        user.Email = dr[5].ToString();
                        user.JoinTime = dr[6].ToString();
                        if(user.UserType != User.USER_ADMIN)
                        {
                            user.Teams = new List<Team>();
                            String ts = dr[7].ToString();
                            if(ts.Length > 0)
                            {
                                if(ts[0] == Constant.SPLIT_EX_1)
                                    ts = ts.Substring(1);
                                if(ts[ts.Length - 1] == Constant.SPLIT_EX_1)
                                    ts = ts.Substring(0, ts.Length - 1);
                            }
                            if(ts != null && ts != "")
                            {
                                user.TeamStr = ts;
                                String[] temp = ts.Split(Constant.SPLIT_EX_1);
                                foreach(String s in temp)
                                {
                                    if(s == null || s == "")
                                        continue;
                                    try
                                    {
                                        Team team = GetTeamByID(Int32.Parse(s));
                                        if(team != null)
                                            user.Teams.Add(team);
                                    }
                                    catch { }
                                }
                            }
                            else user.TeamStr = "";
                            user.PolicyModTeam = Int32.Parse(dr[8].ToString());
                            user.PolicyModCar = Int32.Parse(dr[9].ToString());
                            user.PolicyOrder = Int32.Parse(dr[10].ToString());
                            user.PolicyExportCars = Int32.Parse(dr[11].ToString());
                            user.PolicyDeclare = Int32.Parse(dr[12].ToString());
                            user.PolicyAlarmList = Int32.Parse(dr[13].ToString());
                            user.PolicyOverTime = Int32.Parse(dr[14].ToString());
                            user.PolicyNotify = Int32.Parse(dr[15].ToString());
                        }
                        else
                        {
                            user.Teams = teamList;
                        }
                        userList.Add(user);
                    }
                    dt = dbm.ExecuteQuery("select_alarm");
                    foreach(DataRow dr in dt.Rows)
                    {
                        AlarmPosition apos = new AlarmPosition();
                        apos.Id = Int32.Parse(dr[0].ToString());
                        apos.CarID = Int32.Parse(dr[1].ToString());
                        apos.GpsTime = dr[2].ToString();
                        apos.Pointed = Int32.Parse(dr[3].ToString());
                        apos.Lo = Double.Parse(dr[4].ToString());
                        apos.La = Double.Parse(dr[5].ToString());
                        apos.Speed = Int32.Parse(dr[6].ToString());
                        apos.Direction = Int32.Parse(dr[7].ToString());
                        apos.Status = dr[8].ToString();
                        apos.Alarm = dr[9].ToString();
                        //GetCarByID(apos.CarID).AlarmPos.Add(apos); 启动弹出对话框
                    }
                    dt = dbm.ExecuteQuery("select carID from tDeclare where opUser=''");
                    foreach(DataRow dr in dt.Rows)
                    {
                        try
                        {
                            GetCarByID(Int32.Parse(dr[0].ToString())).DeclareCount++;
                        }
                        catch{}
                    }
                    ret = true;
                }
                catch(Exception e)
                {
                    if(FormMain.LOG_ERR)
                        logger.AddErr(e, "");
                }
            }
            inited = ret;
            return ret;
        }
    }
}
