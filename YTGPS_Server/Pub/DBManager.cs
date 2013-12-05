using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace YTGPS_Server
{
    /// <summary>
    /// sql���ݿ������
    /// </summary>
    class DBManager
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter dap;
        private SqlCommandBuilder cb;

        private String server = "";
        private String db = "";
        private String user = "";
        private String pw = "";

        public DBManager()
        {
        }
        /// <summary>
        /// ȡ��dbmʵ����ʧ�ܷ���null
        /// </summary>
        /// <param name="s1">������</param>
        /// <param name="s2">���ݿ�����</param>
        /// <param name="s3">�û���</param>
        /// <param name="s4">����</param>
        /// <returns></returns>
        public static DBManager GetInstance(String s1, String s2, String s3, String s4)
        {
            DBManager dbm = new DBManager();
            dbm.server = s1;
            dbm.db = s2;
            dbm.user = s3;
            dbm.pw = s4;
            StringBuilder sb = new StringBuilder("Server=");
            sb.Append(s1);
            sb.Append(";initial catalog=");
            sb.Append(s2);
            sb.Append(";UID=");
            sb.Append(s3);
            sb.Append(";PWD=");
            sb.Append(s4);
            sb.Append(";Connection Timeout=5");
            dbm.conn = new SqlConnection(sb.ToString());
            try
            {
                dbm.conn.Open();
                dbm.cmd = new SqlCommand("", dbm.conn);
                dbm.cmd.CommandTimeout = 120;
                dbm.dap = new SqlDataAdapter();
                dbm.dap.SelectCommand = dbm.cmd;
                dbm.cb = new SqlCommandBuilder(dbm.dap);
            }
            catch
            {
                return null;
            }
            return dbm;
        }
        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if(conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch{}
            }
        }
        /// <summary>
        /// ��ѯ���ݿ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(String sql)
        {
            DataTable dt = null;
            if(conn != null && conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    cmd.CommandTimeout = 120;
                }
                catch{}
            }
            if(conn != null && conn.State == ConnectionState.Open)
            {
                try
                {
                    DataSet ds = new DataSet();
                    cmd.CommandText = sql;
                    dap.Fill(ds, "table");
                    dt = ds.Tables[0];
                }
                catch(Exception e)
                {
                    conn.Close();
                    if(FormMain.LOG_ERR)
                        FormMain.logger.AddErr(e, "");
                }
            }
            return dt;
        }

       
        

        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteUpdate(String sql)
        {
            if(conn != null && conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    cmd.CommandTimeout = 120;
                }
                catch { }
            }
            if(conn != null && conn.State == ConnectionState.Open)
            {
                try
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch(Exception e)
                {
                    conn.Close();
                    if(FormMain.LOG_ERR)
                        FormMain.logger.AddErr(e, "");
                }
            }
            return false;
        }
    }
}
