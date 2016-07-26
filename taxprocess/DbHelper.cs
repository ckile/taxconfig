using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace taxprocess
{
    /// <summary>
    /// tax_split = '1'
    /// </summary>
    internal class DbHelper
    {
        public static DateTime GetHotelDate(SqlConnection db)
        {
            var sqlstr = @"select * from htldt";

            var dt = GetData(sqlstr, db);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDateTime(dt.Rows[0]["htl_dt"]);
            }
            return DateTime.Today;
        }

        public static string GetTranDesc(string trancd, SqlConnection db)
        {
            var sqlstr = $"select para_drpt from sysconf where para_typ='01' and para_cd='{ trancd }'";
            var dt = GetData(sqlstr, db);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["para_drpt"].ToString().Trim();
            }
            return "";
        }

        public static DataTable GetTaxcfgs(SqlConnection db)
        {
            var sqlstr = @"select * from taxconfig where flg='1'";
            return GetData(sqlstr, db);
        }

        public static void ExecSql(string sqlstr, SqlConnection db)
        {
            var dc = new SqlCommand(sqlstr, db);
            dc.ExecuteNonQuery();
        }

        public static void AddTransactRows(DataRow[] rows, SqlConnection db)
        {
            var ds = new DataSet();
            var da = new SqlDataAdapter("select * from transact where 1<>1", db);
            da.Fill(ds);
            foreach (DataRow row in rows)
            {
                var newrow = ds.Tables[0].NewRow();
                newrow.ItemArray = (object[])row.ItemArray.Clone();
                //newrow.SetAdded();
                ds.Tables[0].Rows.Add(newrow);
            }
            var scb = new SqlCommandBuilder(da);
            da.UpdateCommand = scb.GetUpdateCommand();
            da.InsertCommand = scb.GetInsertCommand();
            da.Update(ds);
        }

        public static DataTable GetData(string sqlstr, SqlConnection db)
        {
            var result = new DataTable();
            var da = new SqlDataAdapter(sqlstr, db);
            da.Fill(result);
            return result;
        }
    }
}