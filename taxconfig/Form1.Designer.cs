namespace taxconfig
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.taxCfgDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.taxPerNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.sortTypComboBox = new System.Windows.Forms.ComboBox();
            this.flgCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trnCdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sort_typ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flg = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.trn_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.taxCfgDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxPerNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(410, 43);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "保存(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(410, 75);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "关闭";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // taxCfgDataGridView
            // 
            this.taxCfgDataGridView.AllowUserToAddRows = false;
            this.taxCfgDataGridView.AllowUserToDeleteRows = false;
            this.taxCfgDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taxCfgDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sort_typ,
            this.tax_per,
            this.flg,
            this.trn_cd});
            this.taxCfgDataGridView.Location = new System.Drawing.Point(12, 134);
            this.taxCfgDataGridView.Name = "taxCfgDataGridView";
            this.taxCfgDataGridView.ReadOnly = true;
            this.taxCfgDataGridView.RowTemplate.Height = 23;
            this.taxCfgDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.taxCfgDataGridView.Size = new System.Drawing.Size(473, 258);
            this.taxCfgDataGridView.TabIndex = 2;
            this.taxCfgDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taxCfgDataGridView_CellContentClick);
            this.taxCfgDataGridView.SelectionChanged += new System.EventHandler(this.taxCfgDataGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "税金比率(&P)";
            // 
            // taxPerNumber
            // 
            this.taxPerNumber.DecimalPlaces = 4;
            this.taxPerNumber.Location = new System.Drawing.Point(79, 54);
            this.taxPerNumber.Name = "taxPerNumber";
            this.taxPerNumber.Size = new System.Drawing.Size(288, 21);
            this.taxPerNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "费用分类(&C)";
            // 
            // sortTypComboBox
            // 
            this.sortTypComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortTypComboBox.FormattingEnabled = true;
            this.sortTypComboBox.Location = new System.Drawing.Point(78, 28);
            this.sortTypComboBox.Name = "sortTypComboBox";
            this.sortTypComboBox.Size = new System.Drawing.Size(289, 20);
            this.sortTypComboBox.TabIndex = 6;
            // 
            // flgCheckBox
            // 
            this.flgCheckBox.AutoSize = true;
            this.flgCheckBox.Checked = true;
            this.flgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flgCheckBox.Location = new System.Drawing.Point(265, 81);
            this.flgCheckBox.Name = "flgCheckBox";
            this.flgCheckBox.Size = new System.Drawing.Size(102, 16);
            this.flgCheckBox.TabIndex = 7;
            this.flgCheckBox.Text = "夜审时拆分(&X)";
            this.flgCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trnCdTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.flgCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sortTypComboBox);
            this.groupBox1.Controls.Add(this.taxPerNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 116);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // trnCdTextBox
            // 
            this.trnCdTextBox.Location = new System.Drawing.Point(79, 82);
            this.trnCdTextBox.Name = "trnCdTextBox";
            this.trnCdTextBox.Size = new System.Drawing.Size(134, 21);
            this.trnCdTextBox.TabIndex = 8;
            this.trnCdTextBox.Text = "800";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "税金代码";
            // 
            // sort_typ
            // 
            this.sort_typ.DataPropertyName = "sortTyp";
            this.sort_typ.HeaderText = "费用分类";
            this.sort_typ.Name = "sort_typ";
            this.sort_typ.ReadOnly = true;
            // 
            // tax_per
            // 
            this.tax_per.DataPropertyName = "taxPer";
            this.tax_per.HeaderText = "税金比率";
            this.tax_per.Name = "tax_per";
            this.tax_per.ReadOnly = true;
            // 
            // flg
            // 
            this.flg.DataPropertyName = "flg";
            this.flg.HeaderText = "夜审拆分";
            this.flg.Name = "flg";
            this.flg.ReadOnly = true;
            // 
            // trn_cd
            // 
            this.trn_cd.DataPropertyName = "trnCd";
            this.trn_cd.HeaderText = "税金代码";
            this.trn_cd.Name = "trn_cd";
            this.trn_cd.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 400);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.taxCfgDataGridView);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增值税配置程序 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taxCfgDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxPerNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridView taxCfgDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown taxPerNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sortTypComboBox;
        private System.Windows.Forms.CheckBox flgCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort_typ;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_per;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flg;
        private System.Windows.Forms.DataGridViewTextBoxColumn trn_cd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox trnCdTextBox;
    }
}

