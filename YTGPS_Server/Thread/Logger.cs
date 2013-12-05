using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace YTGPS_Server
{
    /// <summary>
    /// ��־��¼�߳�
    /// </summary>
    public class Logger
    {
        //�쳣��¼
        private class ErrRecord
        {
            private DateTime dt;//ʱ��
            private Exception e;//�쳣
            private String remark;//��ע

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
        //��Ϣ��¼
        private class MsgRecord
        {
            private DateTime dt;//ʱ��
            private String remark;//��Ϣ

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
        
        private static int SLEEP_TIME = 1000 * 5;//�洢����

        private List<ErrRecord> errList = new List<ErrRecord>();//�쳣�б�
        private List<MsgRecord> msgList = new List<MsgRecord>();//��Ϣ�б�
        private Thread thread = null;//
        private bool active = false;
        private String errPath = "";//�쳣��־·��
        private String msgPath = "";//��Ϣ��־·��

        private object synErr = new object();
        /// <summary>
        /// ����쳣��¼
        /// </summary>
        /// <param name="e"></param>
        /// <param name="remark"></param>
        public void AddErr(Exception e, String remark)
        {
            lock(synErr)//�����쳣��¼�б�
            {
                errList.Add(new ErrRecord(e, remark));
            }
        }
        //ȡ���쳣��¼�б�
        private List<ErrRecord> GetErr()
        {
            lock(synErr)//�����쳣��¼�б�
            {
                List<ErrRecord> list = new List<ErrRecord>();
                list.AddRange(errList);
                errList.Clear();
                return list;
            }
        }

        private object synMsg = new object();
        /// <summary>
        /// �����Ϣ��¼
        /// </summary>
        /// <param name="remark"></param>
        public void AddMsg(String remark)
        {
            lock(synMsg)//������Ϣ��¼�б�
            {
                msgList.Add(new MsgRecord(remark));
            }
        }
        //ȡ����Ϣ��¼�б�
        private List<MsgRecord> GetMsg()
        {
            lock(synMsg)//������Ϣ��¼�б�
            {
                List<MsgRecord> list = new List<MsgRecord>();
                list.AddRange(msgList);
                msgList.Clear();
                return list;
            }
        }

        /// <summary>
        /// ������־�߳�
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            errPath = Config.APP_PATH + "err\\";
            msgPath = Config.APP_PATH + "log\\";
            thread = new Thread(new ThreadStart(LogInfo));
            //�߳�����������
            thread.Name = "logger_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// �ر���־�߳�
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            active = false;
        }
        //��־�߳�
        private void LogInfo()
        {
            while(active)
            {
                try
                {
                    //д���쳣����־�ļ�
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
                    //д����Ϣ����־�ļ�
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
