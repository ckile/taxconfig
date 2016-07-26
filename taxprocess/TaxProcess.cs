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
                var trancd = row["trn_cd"].ToString().Trim();
                var trancddrpt = DbHelper.GetTranDesc(trancd, _db);
                ProcessSort(row["sort_typ"].ToString().Trim(),
                    Convert.ToDecimal(row["tax_per"]),
                      hotelDate, trancd, trancddrpt
                      );
            }
            _db.Close();
        }

        private void ProcessSort(string sorttyp, decimal taxper, DateTime hotelDate, string trncd, string trncdDrpt)
        {
            if (taxper == 0) return;

            var sql = $"select * from transact where trn_dt='{ hotelDate.ToString("yyyy-MM-dd") }' and sort_typ='{ sorttyp }' and folio_typ<>'V' and tax_split is null";
            var trans = DbHelper.GetData(sql, _db);

            foreach (DataRow row in trans.Rows)
            {
                ProcessTran(trans, row, taxper, trncd, trncdDrpt);
            }
        }

        private void ProcessTran(DataTable dt, DataRow row, decimal taxper, string trncd, string trncddrpt)
        {
            row["tax_split"] = true;

            var trnamt = Convert.ToDecimal(row["trn_amt"]);
            var taxamt = trnamt - trnamt / (Convert.ToDecimal(1) + taxper);

            var taxrows = new DataRow[2];
            taxrows[0] = GetTranTaxRow(dt, row, taxamt);
            taxrows[1] = GetTranTaxRow(dt, row, taxamt * -1);
            taxrows[0]["trn_cd"] = trncd;
            taxrows[0]["trn_drpt"] = trncddrpt;

            DbHelper.AddTransactRows(taxrows, _db);
            var sqlstr = $"update transact set tax_split='1',tax_amt={ taxamt } where trn_id=" + row["trn_id"].ToString();
            DbHelper.ExecSql(sqlstr, _db);
        }

        private DataRow GetTranTaxRow(DataTable dt, DataRow row, decimal taxamt)
        {
            var taxrow = dt.NewRow();
            taxrow.ItemArray = (object[])row.ItemArray.Clone();
            taxrow["trn_amt"] = taxamt;
            taxrow["pkg_amt"] = taxamt;
            taxrow["folio_typ"] = "V";
            taxrow["tax_trn_id"] = row["trn_id"];
            return taxrow;
        }
    }
}