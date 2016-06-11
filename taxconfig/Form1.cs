using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taxconfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var typs = DbHelper.GetSortTyps();
            sortTypComboBox.DataSource = typs;
            sortTypComboBox.ValueMember = "cd";
            sortTypComboBox.DisplayMember = "desc";
            UpdateData();
        }

        private void UpdateData()
        {
            var taxCfgs = DbHelper.GetTaxcfgs();
            taxCfgDataGridView.DataSource = taxCfgs;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var taxcfg = new taxcfg()
            {
                sortTyp = sortTypComboBox.SelectedValue.ToString(),
                flg = flgCheckBox.Checked,
                taxPer = taxPerNumber.Value,
                trnCd = trnCdTextBox.Text,
            };

            DbHelper.AddTaxcfg(taxcfg);
            UpdateData();
        }

        private void taxCfgDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void taxCfgDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var sele = taxCfgDataGridView.CurrentRow;
            if (sele != null)
            {
                sortTypComboBox.SelectedValue = sele.Cells["sort_typ"].Value.ToString().Trim();
                taxPerNumber.Value = Convert.ToDecimal(sele.Cells["tax_per"].Value);
                flgCheckBox.Checked = Convert.ToBoolean(sele.Cells["flg"].Value);
                trnCdTextBox.Text = sele.Cells["trn_cd"].Value.ToString().Trim();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}