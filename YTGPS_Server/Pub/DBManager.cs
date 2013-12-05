using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace YTGPS_Server
{
    /// <summary>
    /// sql数据库操作类
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
        /// 取得dbm实例，失败返回null
        /// </summary>
        /// <param name="s1">服务器</param>
        /// <param name="s2">数据库名称</param>
        /// <param name="s3">用户名</param>
        /// <param name="s4">密码</param>
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
        /// 关闭数据库连接
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
        /// 查询数据库
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
        /// 更新数据库
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
