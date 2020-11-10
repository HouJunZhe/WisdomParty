using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Users.Dal
{
    public class DBHelper
    {
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        private static SqlDataReader sdr = null;

        private static readonly string DBConnString = ConfigurationManager.ConnectionStrings["userDb"].ConnectionString;
         //private static readonly string DBConnString = "Data Source=CC;Initial Catalog=1803A;Integrated Security=True";
        static DBHelper()
        {
            conn = new SqlConnection(DBConnString);
        }
     /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            SqlConnection conn=new SqlConnection(DBConnString);
            DataTable db = new DataTable();
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(db);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return db;
        }

/// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="strSqlList">多条SQL语句</param>		
        public static bool ExecuteSqlTran(List<string> strSqlList)
        {
            using (SqlConnection conns = new SqlConnection(DBConnString))
            {
                conns.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conns;
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    for (int n = 0; n < strSqlList.Count; n++)
                    {
                        string strsql = strSqlList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    trans.Rollback();
                    return false;
                    throw ex;
                }
                finally
                {
                    conns.Close();
                }
            }
        }

        /// <summary>
        ///  执行不带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, CommandType ct)
        {
            int res;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = ct;
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return res;
        }

        /// <summary>
        ///  执行带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns>int值</returns>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int res;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                res = cmd.ExecuteNonQuery();
            }
            return res;
        }

        /// <summary>
        ///  执行查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns>Table值</returns>
        public static DataTable ExecuteQuery(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = ct;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }

            return dt;
        }

        /// <summary>
        ///  执行带参数的查询SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns>Table值</returns>
        public static DataTable ExecuteQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = ct;
            cmd.Parameters.AddRange(paras);
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }


        /// <summary>
        /// 执行带参数的Scalar查询
        /// </summary>
        /// <param name="cmdText">查询SQL语句或存储过程</param>
        /// <param name="paras">参数集合</param>
        /// <param name="ct">命令类型</param>
        /// <returns>一个int型值</returns>
        public static int ExecuteCheck(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int result;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using (cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = ct;
                cmd.Parameters.AddRange(paras);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result;
        }

    }
}
