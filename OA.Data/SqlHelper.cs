using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace OA.Data
{
    public abstract class SqlHelper
    {
        public static string CONN_Code = ConfigurationManager.ConnectionStrings["SqlOA"].ConnectionString;

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="connstring"></param>
        /// <param name="sql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string connstring, string sql, string tableName)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connstring))
            {
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                    System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand(sql, connection);
                    comm.CommandTimeout = 60;
                    da.SelectCommand = comm;
                    da.Fill(dt);
                    dt.TableName = tableName;
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    throw new Exception(ex.Message);
                }
                return dt;
            }
        }
        /// <summary>
        /// 维护操作
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

       /// <summary>
       /// 维护操作
       /// </summary>
       /// <param name="connection"></param>
       /// <param name="cmdType"></param>
       /// <param name="cmdText"></param>
       /// <param name="commandParameters"></param>
       /// <returns></returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 事务处理操作
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        
        /// <summary>
        /// 获得数据
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {

                throw;
            }
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

       
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 查询数据,直接填充数据表
        /// </summary>
        /// <param name="command">SQL命令</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable srcTable = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                dap.SelectCommand = cmd;
                dap.Fill(srcTable);
            }
            return srcTable;
        }

        /// <summary>
        /// 查询数据,直接填充数据表
        /// </summary>
        /// <param name="command">SQL命令</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable srcTable = new DataTable();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            dap.SelectCommand = cmd;
            dap.Fill(srcTable);
            return srcTable;
        }


        /// <summary>
        /// 查询数据信息并且输出结构
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="ds"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet FillDS(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                dap.SelectCommand = cmd;
                dap.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// 判断输出的值是否符合要求
        /// </summary>
        /// <param name="pars"></param>
        /// <param name="parsStr"></param>
        /// <returns></returns>
        public static bool WriteSqlParameter(SqlParameter[] pars, ref string parsStr)
        {
            bool isok = true;
            try
            {
                foreach (SqlParameter item in pars)
                {
                    if (item.Size != 0)
                    {
                        if (item.Value.ToString().Length > item.Size)
                        {
                            isok = false;
                            parsStr = parsStr + item.ParameterName + ",";
                        }
                    }
                }
                if (parsStr != "")
                    parsStr = parsStr.TrimEnd(',') + "等长度过长";
            }
            catch (Exception ex)
            {
                parsStr = ex.Message;
                isok = false;
            }
            return isok;
        }
    }


}
