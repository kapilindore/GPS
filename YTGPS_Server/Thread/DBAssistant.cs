using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace YTGPS_Server
{
    /// <summary>
    /// 辅助数据库更新线程
    /// 处理系统操作记录、指令下发记录 的录入
    /// </summary>
    public class DBAssistant
    {
        private static int SLEEP_TIME = 1000 * 3;//存储周期

        private List<String> opList = new List<String>();//操作记录数据库插入语句列表
        private List<String> odList = new List<String>();//指令记录数据库插入语句列表
        private List<String> ptList = new List<String>();//无报警定位信息数据库插入语句列表

        private Thread thread = null;//
        private bool active = false;

        private object synOp = new object();
        /// <summary>
        /// 添加操作记录
        /// </summary>
        /// <param name="ou">操作人</param>
        /// <param name="re">备注</param>
        public void AddOperation(String ou, String re)
        {
            lock(synOp)//锁定操作记录列表
            {
                StringBuilder stb = new StringBuilder("insert_operation '").Append(ou);
                stb.Append("','").Append(re).Append("'");
                opList.Add(stb.ToString());
            }
        }
        //取得操作记录列表
        private List<String> GetOperation()
        {
            lock(synOp)//锁定操作记录列表
            {
                List<String> list = new List<String>();
                list.AddRange(opList);
                opList.Clear();
                return list;
            }
        }

        private object synOd = new object();
        /// <summary>
        /// 添加指令记录
        /// </summary>
        /// <param name="cn">车牌</param>
        /// <param name="ou">操作人</param>
        /// <param name="od">指令</param>
        /// <param name="re">备注</param>
        /// <param name="dt">日期</param>
        public void AddOrder(String cn, String ou, String od, String re, DateTime dt)
        {
            lock(synOd)//锁定指令记录列表
            {
                StringBuilder stb = new StringBuilder("insert_order_ex '").Append(cn);
                stb.Append("','").Append(ou).Append("','").Append(od).Append("','");
                stb.Append(re).Append("','").Append(dt).Append("'");
                odList.Add(stb.ToString());
            }
        }
        //取得指令记录列表
        private List<String> GetOrder()
        {
            lock(synOd)//锁定指令记录列表
            {
                List<String> list = new List<String>();
                list.AddRange(odList);
                odList.Clear();
                return list;
            }
        }

        private object synPt = new object();
        /// <summary>
        /// 添加定位信息记录
        /// </summary>
        /// <param name="pts">定位信息记录</param>
        public void AddPosition(String pts)
        {
            lock(synPt)//锁定操作记录列表
            {
                ptList.Add(pts);
            }
        }
        //取得操作记录列表
        private List<String> GetPosition()
        {
            lock(synPt)//锁定操作记录列表
            {
                List<String> list = new List<String>();
                list.AddRange(ptList);
                ptList.Clear();
                return list;
            }
        }

        /// <summary>
        /// 启动辅助数据库更新线程
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            thread = new Thread(new ThreadStart(UpdateDB));
            //线程名，调试用
            thread.Name = "dbassistant_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// 关闭辅助数据库更新线程
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            active = false;
        }
        //辅助数据库更新线程
        private void UpdateDB()
        {
            while(active)
            {
                try
                {
                    //写入操作记录到数据库
                    List<String> list = GetPosition();
                    list.AddRange(GetOrder());
                    list.AddRange(GetOperation());
                    //写入记录到数据库
                    if(list.Count > 0)
                    {
                        DBManager dbm = DBManager.GetInstance(Config.DbHost, Config.DbName, Config.DbUser, Config.DbPw);
                        foreach(String s in list)
                            dbm.ExecuteUpdate(s);
                        dbm.Close();
                    }
                }
                catch { }
                try
                {
                    System.Threading.Thread.Sleep(SLEEP_TIME);
                }
                catch { }
            }
            thread = null;
        }

    }
}
