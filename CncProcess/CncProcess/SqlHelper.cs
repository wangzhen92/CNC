using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncProcess
{
    public class SqlHelper
    {
        //数据库连接字符串
        // data source=数据库地址
        // initial catalog=数据库名称
        // uid=用户
        // pwd=密码
        string _SqlConnectionStr = "data source=DESKTOP-O5CO2GK;initial catalog=2022CNCDATA;uid=wz;pwd=123456";

        #region 单值查询
        public string GetSingle(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    try
                    {
                        conn.Open();
                        return String.Format("{0}", cmd.ExecuteScalar());
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }

        public string GetSingle(string sqlStr, SqlParameter[] cmdParams)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = sqlStr;
                        return String.Format("{0}", cmd.ExecuteScalar());
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }


        #endregion

        #region 查询数据集
        public DataSet Query(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlDataAdapter ada = new SqlDataAdapter(sqlStr, conn))
                {
                    try
                    {
                        conn.Open();
                        DataSet ds = new DataSet();
                        ada.Fill(ds);
                        return ds;
                    }
                    catch (SqlException e)
                    {

                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }

        public DataSet Query(string sqlStr, SqlParameter[] cmdParams)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sqlStr;
                            cmd.Parameters.AddRange(cmdParams);

                            DataSet ds = new DataSet();
                            ada.Fill(ds);
                            return ds;
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

            }

        }
        #endregion

        #region 单表查询
        public DataTable GetQueryData(string sqlStr)
        {
            DataSet ds = Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        #endregion

        #region 单行查询
        public DataRow GetQueryRecord(string sqlStr)
        {
            DataTable dt = GetQueryData(sqlStr);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }


        #endregion


        #region 使用完  应关闭Reader
        public SqlDataReader ExecuteReader(string sqlStr)
        {
            SqlConnection conn = new SqlConnection(this._SqlConnectionStr);
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException e)
            {

                throw e;
            }
        }
        #endregion


        #region 执行Sql语句
        public int ExecuteSql(string sqlStr)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, conn))
                {
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                        throw e;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }


        #endregion


        #region 执行事务
        public int ExecuteSqlTran(List<string> sqlStrList)
        {
            using (SqlConnection conn = new SqlConnection(this._SqlConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = tran;
                            conn.Open();
                            int count = 0;
                            foreach (string sql in sqlStrList)
                            {
                                cmd.CommandText = sql;
                                count += cmd.ExecuteNonQuery();
                            }
                            tran.Commit();
                            return count;
                        }
                        catch (SqlException e)
                        {

                            throw e;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }

        }
        #endregion 判断 数据库与当前时间 日期是否一致


        public void CheckTabInDB()
        {


            string sqlStr = "SELECT * FROM dbo.Data_Check";
            DataSet ce = Query(sqlStr);
            int daData = Convert.ToInt32(ce.Tables[0].Rows[0]["Data"]);

            int wkd = (int)DateTime.Now.DayOfWeek;
            if (daData == wkd)
            {
                //不做改变
            }
            else
            {
                //修正日期
                sqlStr = string.Format("UPDATE dbo.Data_Check SET Data= '{0}';", wkd);
                int nExc = ExecuteSql(sqlStr);
                if (nExc > 0)
                {
                    nExc = 0;
                    // 进行数据清除
                    sqlStr = string.Format("delete from T{0};", wkd);
                    nExc = ExecuteSql(sqlStr);
                    if (nExc > 0)
                    {
                        LogHelper.Info(string.Format("{0} 成功", sqlStr));
                    }
                }

            }
        }




        #region Bulk插入

        public void BulkToDB(DataTable dt)
        {
            SqlConnection conn = new SqlConnection(this._SqlConnectionStr);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
            int nWkd = Convert.ToInt32(DateTime.Now.DayOfWeek);
            string wkd = string.Format("T{0}", nWkd);
            bulkCopy.DestinationTableName = wkd;
            bulkCopy.BatchSize = dt.Rows.Count;

            try
            {
                conn.Open();
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (SqlException e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }
        #endregion


    }
}
