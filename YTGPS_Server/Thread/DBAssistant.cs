using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace YTGPS_Server
{
    /// <summary>
    /// �������ݿ�����߳�
    /// ����ϵͳ������¼��ָ���·���¼ ��¼��
    /// </summary>
    public class DBAssistant
    {
        private static int SLEEP_TIME = 1000 * 3;//�洢����

        private List<String> opList = new List<String>();//������¼���ݿ��������б�
        private List<String> odList = new List<String>();//ָ���¼���ݿ��������б�
        private List<String> ptList = new List<String>();//�ޱ�����λ��Ϣ���ݿ��������б�

        private Thread thread = null;//
        private bool active = false;

        private object synOp = new object();
        /// <summary>
        /// ��Ӳ�����¼
        /// </summary>
        /// <param name="ou">������</param>
        /// <param name="re">��ע</param>
        public void AddOperation(String ou, String re)
        {
            lock(synOp)//����������¼�б�
            {
                StringBuilder stb = new StringBuilder("insert_operation '").Append(ou);
                stb.Append("','").Append(re).Append("'");
                opList.Add(stb.ToString());
            }
        }
        //ȡ�ò�����¼�б�
        private List<String> GetOperation()
        {
            lock(synOp)//����������¼�б�
            {
                List<String> list = new List<String>();
                list.AddRange(opList);
                opList.Clear();
                return list;
            }
        }

        private object synOd = new object();
        /// <summary>
        /// ���ָ���¼
        /// </summary>
        /// <param name="cn">����</param>
        /// <param name="ou">������</param>
        /// <param name="od">ָ��</param>
        /// <param name="re">��ע</param>
        /// <param name="dt">����</param>
        public void AddOrder(String cn, String ou, String od, String re, DateTime dt)
        {
            lock(synOd)//����ָ���¼�б�
            {
                StringBuilder stb = new StringBuilder("insert_order_ex '").Append(cn);
                stb.Append("','").Append(ou).Append("','").Append(od).Append("','");
                stb.Append(re).Append("','").Append(dt).Append("'");
                odList.Add(stb.ToString());
            }
        }
        //ȡ��ָ���¼�б�
        private List<String> GetOrder()
        {
            lock(synOd)//����ָ���¼�б�
            {
                List<String> list = new List<String>();
                list.AddRange(odList);
                odList.Clear();
                return list;
            }
        }

        private object synPt = new object();
        /// <summary>
        /// ��Ӷ�λ��Ϣ��¼
        /// </summary>
        /// <param name="pts">��λ��Ϣ��¼</param>
        public void AddPosition(String pts)
        {
            lock(synPt)//����������¼�б�
            {
                ptList.Add(pts);
            }
        }
        //ȡ�ò�����¼�б�
        private List<String> GetPosition()
        {
            lock(synPt)//����������¼�б�
            {
                List<String> list = new List<String>();
                list.AddRange(ptList);
                ptList.Clear();
                return list;
            }
        }

        /// <summary>
        /// �����������ݿ�����߳�
        /// </summary>
        public void Start()
        {
            if(thread != null)
                return;
            thread = new Thread(new ThreadStart(UpdateDB));
            //�߳�����������
            thread.Name = "dbassistant_thread";
            //thread.IsBackground = true;
            active = true;
            thread.Start();
        }
        /// <summary>
        /// �رո������ݿ�����߳�
        /// </summary>
        public void Stop()
        {
            if(thread == null)
                return;
            active = false;
        }
        //�������ݿ�����߳�
        private void UpdateDB()
        {
            while(active)
            {
                try
                {
                    //д�������¼�����ݿ�
                    List<String> list = GetPosition();
                    list.AddRange(GetOrder());
                    list.AddRange(GetOperation());
                    //д���¼�����ݿ�
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
