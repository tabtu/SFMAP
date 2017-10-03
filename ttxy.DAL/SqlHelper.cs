using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ttxy.DAL
{
    public class SqlHelper
    {
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql">sql查询字符串</param>
        /// <returns></returns>
        public static DataSet ExecuteReader(string sql)
        {
            SqlConnection conn = new SqlConnection(MyDataContext.db_monitor);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand con = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }

        /// <summary>
        /// 执行增加删除修改
        /// </summary>
        /// <param name="sql">sql查询字符串</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn = new SqlConnection(MyDataContext.db_monitor);
            try
            {
                SqlCommand con = new SqlCommand(sql, conn);
                conn.Open();
                int ret = 0;
                ret = con.ExecuteNonQuery();
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }
    }
}