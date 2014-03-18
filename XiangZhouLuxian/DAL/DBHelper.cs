using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;


namespace DAL
{
    public class DBHelper
    {
        public static string DBConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            }
        }

        //添加 修改 删除
        public static int ExecuteNonQuery(CommandType cmdType, string sql, params OleDbParameter[] parms)
        {
            using (OleDbConnection conn = new OleDbConnection(DBConnString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                cmd.CommandType = cmdType;
                cmd.Parameters.AddRange(parms);
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(CommandType cmdType, string sql, params OleDbParameter[] parms)
        {
            using (OleDbConnection conn = new OleDbConnection(DBConnString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandType = cmdType;
                if (parms != null)
                {
                    cmd.Parameters.AddRange(parms);
                }
                return cmd.ExecuteScalar();
            }
        }

        //查询
        public static DataTable getDataTable(CommandType cmdType, string sql, params OleDbParameter[] parms)
        {
            return DBHelper.getDataSet(cmdType, sql, parms).Tables[0];
        }

        //查询返回DataSet
        public static DataSet getDataSet(CommandType cmdType, string sql, params OleDbParameter[] parms)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(DBConnString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
                da.SelectCommand.CommandType = cmdType;
                da.SelectCommand.Parameters.AddRange(parms);
                da.Fill(ds);
                return ds;
            }
        }
    }
}