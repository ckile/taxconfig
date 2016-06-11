using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace taxprocess
{
    internal class TaxProcess
    {
        private SqlConnection _db;

        public TaxProcess()
        {
            _db = new SqlConnection(new Cdb.Data.CUDL().GetConnectionText());
        }

        public void Process()
        {
            _db.Open();
            var hotelDate = DbHelper.GetHotelDate(_db);
            var taxcfgs = DbHelper.GetTaxcfgs(_db);
            foreach (DataRow row in taxcfgs.Rows)
            {
                ProcessSort(row["sort_typ"].ToString().Trim(),
                    Convert.ToDecimal(row["tax_per"]),
                      hotelDate,
                      row["trn_cd"].ToString().Trim());
            }
            _db.Close();
        }

        private void ProcessSort(string sorttyp, decimal taxper, DateTime hotelDate, string trncd)
        {
            if (taxper == 0) return;

            var sql = $"select * from transact where trn_dt='{ hotelDate.ToString("yyyy-MM-dd") }' and sort_typ='{ sorttyp }' and tax_split is null";
            var trans = DbHelper.GetData(sql, _db);

            foreach (DataRow row in trans.Rows)
            {
                ProcessTran(trans, row, taxper, trncd);
            }
        }

        private void ProcessTran(DataTable dt, DataRow row, decimal taxper, string trncd)
        {
            row["tax_split"] = true;

            var trnamt = Convert.ToDecimal(row["trn_amt"]);
            var taxamt = trnamt - trnamt / (Convert.ToDecimal(1) + taxper);

            var taxrows = new DataRow[2];
            taxrows[0] = GetTranTaxRow(dt, row, taxamt);
            taxrows[1] = GetTranTaxRow(dt, row, taxamt * -1);
            taxrows[0]["trn_cd"] = trncd;
            taxrows[0]["trn_drpt"] = "增值税金";
            DbHelper.AddTransactRows(taxrows, _db);
            var sqlstr = "update transact set tax_split='1' where trn_id=" + row["trn_id"].ToString();
            DbHelper.ExecSql(sqlstr, _db);
        }

        private DataRow GetTranTaxRow(DataTable dt, DataRow row, decimal taxamt)
        {
            var taxrow = dt.NewRow();
            taxrow.ItemArray = (object[])row.ItemArray.Clone();
            taxrow["trn_amt"] = taxamt;
            taxrow["pkg_amt"] = taxamt;
            taxrow["folio_typ"] = "V";
            return taxrow;
        }
    }
}