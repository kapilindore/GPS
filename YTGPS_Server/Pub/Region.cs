using System;
using System.Collections.Generic;
using System.Text;

namespace YTGPS_Server
{
    /// <summary>
    /// 经纬点
    /// </summary>
    public class DPoint
    {
        private double lo;
        /// <summary>
        /// 经度
        /// </summary>
        public double Lo
        {
            get { return lo; }
            set { lo = value; }
        }
        private double la;
        /// <summary>
        /// 纬度
        /// </summary>
        public double La
        {
            get { return la; }
            set { la = value; }
        }
        /// <summary>
        /// 构造经纬点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public DPoint(double x, double y)
        {
            this.lo = x;
            this.la = y;
        }
        /// <summary>
        /// 比较两个点是否在同一位置
        /// </summary>
        /// <param name="dpt"></param>
        /// <returns></returns>
        public bool Equals(DPoint dpt)
        {
            return (this.la == dpt.la && this.lo == dpt.lo);
        }
    }
    /// <summary>
    /// 区域
    /// </summary>
    public class Region
    {
        private int regionID;
        private String regionName = "";
        private String pts = "";
        private List<DPoint> points = new List<DPoint>();

        /// <summary>
        /// 名称
        /// </summary>
        public String RegionName
        {
            get { return regionName; }
            set { regionName = value; }
        }
        /// <summary>
        /// ID
        /// </summary>
        public int RegionID
        {
            get { return regionID; }
            set { regionID = value; }
        }
        /// <summary>
        /// 经纬点字符串
        /// </summary>
        public String Pts
        {
            get { return pts; }
            set { pts = value; }
        }
        /// <summary>
        /// 经纬度列表
        /// </summary>
        public List<DPoint> Points
        {
            get { return points; }
            set { points = value; }
        }
        /// <summary>
        /// 通过经纬点字符串构造区域
        /// </summary>
        /// <param name="s"></param>
        public Region(String s)
        {
            this.pts = s;
            String[] temp = s.Split(Constant.SPLIT_EX_1);
            for(int i = 0; i < temp.Length-1; i += 2)
            {
                this.points.Add(new DPoint(Double.Parse(temp[i]), Double.Parse(temp[i+1])));
            }
        }
        //
        private bool Between(double x, double x1, double x2)
        {
            if(x > x1 && x < x2)
                return true;
            return x > x2 && x < x1;
        }

        private double CalY(DPoint p1, DPoint p2, double x)
        {
            double y = (x - p1.Lo) / (p2.Lo - p1.Lo);
            y *= p2.La - p1.La;
            y += p1.La;
            return y;
        }
        /// <summary>
        /// 添加经纬点
        /// </summary>
        /// <param name="p"></param>
        public void AddPoint(DPoint p)
        {
            points.Add(p);
        }
        /// <summary>
        /// 经纬点是否包含在区域中
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool InRegion(DPoint p)
        {
            if(this.points.Count < 3)
                return false;
            DPoint[] ps = new DPoint[this.points.Count + 1];
            ps = this.points.ToArray();
            ps[ps.Length - 1] = new DPoint(this.points[0].Lo, this.points[0].La);
            List<DPoint> tmpY = new List<DPoint>();
            for(int i = 0; i < ps.Length - 1; i++)
            {
                if(ps[i].Equals(p))
                    return true;
                if(p.Lo == ps[i].Lo)
                    tmpY.Add(new DPoint(p.Lo, ps[i].La));
                else if(Between(p.Lo, ps[i].Lo, ps[i + 1].Lo))
                    tmpY.Add(new DPoint(p.Lo, CalY(ps[i], ps[i + 1], p.Lo)));
            }

            for(int i = 0; i < tmpY.Count - 1; i++)
            {
                if(p.Equals(tmpY[i]))
                    return true;
                if(Between(p.La, tmpY[i].La, tmpY[i+1].La))
                    return i % 2 == 0;
            }
            return false;
        }
    }
}
