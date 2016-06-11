using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace taxconfig
{
    internal class DbHelper
    {
        public static IEnumerable<sortTyp> GetSortTyps()
        {
            var result = new List<sortTyp>();
            var sqlstr = @"select * from  sysconf where para_typ='33' order by para_cd";
            var dt = GetData(sqlstr);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new sortTyp
                {
                    cd = row["para_cd"].ToString().Trim(),
                    desc = row["para_drpt"].ToString().Trim()
                });
            }
            return result;
        }

        public static IEnumerable<taxcfg> GetTaxcfgs()
        {
            var result = new List<taxcfg>();
            var sqlstr = @"select * from taxconfig order by sort_typ";
            var dt = GetData(sqlstr);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new taxcfg
                {
                    sortTyp = row["sort_typ"].ToString().Trim(),
                    flg = Convert.ToBoolean(row["flg"]),
                    taxPer = Convert.ToDecimal(row["tax_per"]),
                    trnCd = row["trn_cd"].ToString().Trim(),
                });
            }
            return result;
        }

        public static void AddTaxcfg(taxcfg entity)
        {
            var sqlstr = $"delete taxconfig where sort_typ='{ entity.sortTyp }'";
            ExecSql(sqlstr);
            var flg = entity.flg ? "1" : "0";
            sqlstr = $"insert taxconfig (sort_typ, tax_per, flg, trn_cd) values('{entity.sortTyp}',{entity.taxPer},'{ flg }', '{ entity.trnCd }')";
            ExecSql(sqlstr);
        }

        private static void ExecSql(string sqlstr)
        {
            var db = new SqlConnection(new Cdb.Data.CUDL().GetConnectionText());
            db.Open();
            var dc = new SqlCommand(sqlstr, db);
            dc.ExecuteNonQuery();
            db.Close();
        }

        private static DataTable GetData(string sqlstr)
        {
            var result = new DataTable();
            var db = new SqlConnection(new Cdb.Data.CUDL().GetConnectionText());
            db.Open();
            var da = new SqlDataAdapter(sqlstr, db);
            da.Fill(result);
            db.Close();
            return result;
        }
    }
}