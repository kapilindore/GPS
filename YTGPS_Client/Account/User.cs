using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Client
{
    public class User : Account
    {
        public const int USER_ADMIN = 0;
        public const int USER_OP = 1;
        public const int USER_TEAM = 2;
        public const int USER_CAR = 3;
        public  double fuel = 0.000;    // 油耗放在用户端计算不进行服务端计算
        private String host = "";

        public String Host
        {
            get { return host; }
            set { host = value; }
        }
        private int port = 8088;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private List<Team> teamList = new List<Team>();
        internal List<Team> TeamList
        {
            get { return teamList; }
            set { teamList = value; }
        }

        public Car GetCarByID(int id)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarID == id)
                        return car;
            return null;
        }

        public Car GetCarByNO(String no)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarNO == no)
                        return car;
            return null;
        }

        public Team GetTeamByID(int id)
        {
            foreach(Team team in teamList)
                if(team.TeamID == id)
                    return team;
            return null;
        }

        public List<Car> GetCarsByTel(String tel)
        {
            List<Car> list = new List<Car>();
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.DriverMobile.IndexOf(tel) >= 0 || car.DriverTel.IndexOf(tel) >= 0 
                    || car.Driver2Mobile.IndexOf(tel) >= 0 || car.Driver2Tel.IndexOf(tel) >= 0)
                        list.Add(car);
            return list;
        }

        public List<Car> GetCarsByNO(String no)
        {
            no = no.ToLower();
            List<Car> list = new List<Car>();
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarNO.ToLower().IndexOf(no) >= 0)
                        list.Add(car);
            return list;
        }

        public void UpdateTeam(Team team)
        {
            for(int i = 0; i < teamList.Count; i++)
                if(teamList[i].TeamID == team.TeamID)
                {
                    teamList[i].Clone(team);
                    return;
                }
        }

        public void UpdateCar(Car car)
        {
            for(int i = 0; i < teamList.Count; i++)
                for(int j = 0; j < teamList[i].Cars.Count; j++)
                    if(teamList[i].Cars[j].CarID == car.CarID)
                    {
                        teamList[i].Cars[j].Clone(car);
                        teamList[i].Cars[j].Team = teamList[i];
                        return;
                    }
        }

        public String DeleteTeam(int tid)
        {
            foreach(Team t in teamList)
                if(t.TeamID == tid)
                {
                    teamList.Remove(t) ;
                    return t.TeamName;
                }
            return "";
        }

        public String DeleteCar(int cid)
        {
            foreach(Team team in teamList)
                foreach(Car car in team.Cars)
                    if(car.CarID == cid)
                    {
                        team.Cars.Remove(car);
                        return car.CarNO;
                    }
            return "";
        }
    }
}
