using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace YTGPS_Server
{
    /// <summary>
    /// 日志记录线程
    /// </summary>
    public class Logger
    {
        //异常记录
        private class ErrRecord
        {
            private DateTime dt;//时间
            private Exception e;//异常
            private String remark;//备注

            public DateTime Dt
            {
                get { return dt; }
                set { dt = value; }
            }
            public Exception E
            {
                get { return e; }
                set { e = value; }
            }
            public String Remark
            {
                get { return remark; }
                set { remark = value; }
            }
            public ErrRecord(Exception ex, String re)
            {
                dt = DateTime.Now;
                e = ex;
                remark = re;
            }
        }
        //信息记录
        private class MsgRecord
        {
            private DateTime dt;//时间
            private String remark;//信息

            public DateTime Dt
            {
                get { return dt; }
                set { dt = value; }
            }
            public String Remark
            {
                get { return remark; }
                set { remark = value; }
            }

            public MsgRecord(String re)
            {
                dt = DateTime.Now;
                remark = re;
            }
        }
        
        private static int SLEEP_TIME = 1000 * 5;//存储周期

        private List<ErrRecord> errList = new List<ErrRecord>();//异常列表
        private List<MsgRecord> msgList = new List<MsgRecord>();//信息列表
        private Thread thread = null;//
        private bool active = false;
        private String errPath = "";//异常日志路径
        private String msgPath = "";//信息日志路径

        private object synErr = new object();
        /// <summary>
        /// 添加异常记录
        /// </summary>
        /// <param name="e"></param>
        /// <param name="remark"></param>
        public void AddErr(Exception e, String remark)
        {
            lock(synErr)//锁定异常记录列表
            {
                errList.Add(new ErrRecord(e, remark));
            }
        }
        //取得异常记录列表
        private List<ErrRecord> GetErr()
        {
            lock(synErr)//锁定异常记录列表
            {
                List<ErrRecord> list = new List<ErrRecord>();
                list.AddRange(errList);
                errList.Clear();
                return list;
            }
        }

        private object synMsg = new object();
        /// <summary>
        /// 添加信息记录
        /// </summary>
        /// <param name="remark"></param>
        public void AddMsg(String remark)
        {
            lock(synMsg)//锁定信息记录列表
            {
                msgList.Add(new MsgRecord(remark));
            }
        }
        //取得信息记录列表
        private List<MsgRecord> GetMsg()
        {
            lock(synMsg)//锁定信息记录列表
            {
                List<MsgRecord> list = new List<MsgRecord>();
                list.AddRange(msgList);
                msgList.Clear();
                return list;
            }
        }

        /// <summary>
        /// 启动日志线程
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            errPath = Config.APP_PATH + "err\\";
            msgPath = Config.APP_PATH + "log\\";
            thread = new Thread(new ThreadStart(LogInfo));
            //线程名，调试用
            thread.Name = "logger_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// 关闭日志线程
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            active = false;
        }
        //日志线程
        private void LogInfo()
        {
            while(active)
            {
                try
                {
                    //写入异常到日志文件
                    List<ErrRecord> list = GetErr();
                    if(list.Count > 0)
                    {
                        FileInfo fi = new FileInfo(errPath + Pub.DateStr + ".log");
                        StreamWriter sw = fi.AppendText();
                        foreach(ErrRecord er in list)
                        {
                            try
                            {
                                sw.WriteLine("");
                                sw.WriteLine(er.Dt.ToString("[HH:mm:ss]"));
                                sw.WriteLine(er.E.Source);
                                sw.WriteLine(er.E.Message);
                                sw.WriteLine(er.E.ToString());
                                sw.WriteLine(er.Remark);
                            }
                            catch { }
                        }
                        sw.Close();
                    }
                }
                catch { }
                try
                {
                    //写入信息到日志文件
                    List<MsgRecord> list = GetMsg();
                    if(list.Count > 0)
                    {
                        FileInfo fi = new FileInfo(msgPath + Pub.DateStr + ".log");
                        StreamWriter sw = fi.AppendText();
                        foreach(MsgRecord mr in list)
                        {
                            try
                            {
                                sw.WriteLine(mr.Dt.ToString("[HH:mm:ss]") + mr.Remark);
                            }
                            catch { }
                        }
                        sw.Close();
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
