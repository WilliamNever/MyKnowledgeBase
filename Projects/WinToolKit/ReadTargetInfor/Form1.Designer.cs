namespace ReadTargetInfor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSearchPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtInfors = new System.Windows.Forms.TextBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbkIncludeSub = new System.Windows.Forms.CheckBox();
            this.grbBox = new System.Windows.Forms.GroupBox();
            this.cmbConditions = new System.Windows.Forms.ComboBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.btnDeleteCondition = new System.Windows.Forms.Button();
            this.grpSearchConditions = new System.Windows.Forms.GroupBox();
            this.chkbOnlyFile = new System.Windows.Forms.CheckBox();
            this.btnExportResult = new System.Windows.Forms.Button();
            this.lblFileOpenEncoding = new System.Windows.Forms.Label();
            this.lblSearchRegxTitle = new System.Windows.Forms.Label();
            this.cmbBoxEncodingSelect = new System.Windows.Forms.ComboBox();
            this.grbBox.SuspendLayout();
            this.grpSearchConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearchPath
            // 
            this.lblSearchPath.AutoSize = true;
            this.lblSearchPath.Location = new System.Drawing.Point(12, 263);
            this.lblSearchPath.Name = "lblSearchPath";
            this.lblSearchPath.Size = new System.Drawing.Size(77, 12);
            this.lblSearchPath.TabIndex = 0;
            this.lblSearchPath.Text = "Search Path:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtPath.Location = new System.Drawing.Point(12, 281);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(483, 21);
            this.txtPath.TabIndex = 4;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(10, 305);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 21);
            this.btnSelectPath.TabIndex = 5;
            this.btnSelectPath.Text = "Browse";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(339, 305);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtInfors
            // 
            this.txtInfors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfors.Location = new System.Drawing.Point(6, 18);
            this.txtInfors.Multiline = true;
            this.txtInfors.Name = "txtInfors";
            this.txtInfors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfors.Size = new System.Drawing.Size(471, 77);
            this.txtInfors.TabIndex = 7;
            // 
            // lblSearchFilter
            // 
            this.lblSearchFilter.AutoSize = true;
            this.lblSearchFilter.Location = new System.Drawing.Point(12, 240);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(77, 12);
            this.lblSearchFilter.TabIndex = 5;
            this.lblSearchFilter.Text = "Filter(*.*):";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(95, 236);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(400, 21);
            this.txtFilter.TabIndex = 3;
            // 
            // cbkIncludeSub
            // 
            this.cbkIncludeSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbkIncludeSub.AutoSize = true;
            this.cbkIncludeSub.Checked = true;
            this.cbkIncludeSub.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkIncludeSub.Location = new System.Drawing.Point(411, 261);
            this.cbkIncludeSub.Name = "cbkIncludeSub";
            this.cbkIncludeSub.Size = new System.Drawing.Size(84, 16);
            this.cbkIncludeSub.TabIndex = 6;
            this.cbkIncludeSub.Text = "IncludeSub";
            this.cbkIncludeSub.UseVisualStyleBackColor = true;
            // 
            // grbBox
            // 
            this.grbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbBox.Controls.Add(this.txtInfors);
            this.grbBox.Location = new System.Drawing.Point(12, 336);
            this.grbBox.Name = "grbBox";
            this.grbBox.Size = new System.Drawing.Size(483, 100);
            this.grbBox.TabIndex = 8;
            this.grbBox.TabStop = false;
            this.grbBox.Text = "Output Infors:";
            // 
            // cmbConditions
            // 
            this.cmbConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbConditions.FormattingEnabled = true;
            this.cmbConditions.Location = new System.Drawing.Point(6, 40);
            this.cmbConditions.Name = "cmbConditions";
            this.cmbConditions.Size = new System.Drawing.Size(471, 128);
            this.cmbConditions.TabIndex = 0;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(6, 169);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(75, 21);
            this.btnAddCondition.TabIndex = 1;
            this.btnAddCondition.Text = "Add";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // btnDeleteCondition
            // 
            this.btnDeleteCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCondition.Location = new System.Drawing.Point(399, 169);
            this.btnDeleteCondition.Name = "btnDeleteCondition";
            this.btnDeleteCondition.Size = new System.Drawing.Size(75, 21);
            this.btnDeleteCondition.TabIndex = 2;
            this.btnDeleteCondition.Text = "Delete";
            this.btnDeleteCondition.UseVisualStyleBackColor = true;
            this.btnDeleteCondition.Click += new System.EventHandler(this.btnDeleteCondition_Click);
            // 
            // grpSearchConditions
            // 
            this.grpSearchConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearchConditions.Controls.Add(this.cmbBoxEncodingSelect);
            this.grpSearchConditions.Controls.Add(this.lblSearchRegxTitle);
            this.grpSearchConditions.Controls.Add(this.lblFileOpenEncoding);
            this.grpSearchConditions.Controls.Add(this.cmbConditions);
            this.grpSearchConditions.Controls.Add(this.btnDeleteCondition);
            this.grpSearchConditions.Controls.Add(this.btnAddCondition);
            this.grpSearchConditions.Location = new System.Drawing.Point(12, 31);
            this.grpSearchConditions.Name = "grpSearchConditions";
            this.grpSearchConditions.Size = new System.Drawing.Size(483, 199);
            this.grpSearchConditions.TabIndex = 10;
            this.grpSearchConditions.TabStop = false;
            this.grpSearchConditions.Text = "File Search Options:";
            // 
            // chkbOnlyFile
            // 
            this.chkbOnlyFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbOnlyFile.AutoSize = true;
            this.chkbOnlyFile.Location = new System.Drawing.Point(345, 12);
            this.chkbOnlyFile.Name = "chkbOnlyFile";
            this.chkbOnlyFile.Size = new System.Drawing.Size(150, 16);
            this.chkbOnlyFile.TabIndex = 11;
            this.chkbOnlyFile.Text = "Only Search File Name";
            this.chkbOnlyFile.UseVisualStyleBackColor = true;
            this.chkbOnlyFile.CheckedChanged += new System.EventHandler(this.chkbOnlyFile_CheckedChanged);
            // 
            // btnExportResult
            // 
            this.btnExportResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportResult.Location = new System.Drawing.Point(420, 304);
            this.btnExportResult.Name = "btnExportResult";
            this.btnExportResult.Size = new System.Drawing.Size(75, 23);
            this.btnExportResult.TabIndex = 12;
            this.btnExportResult.Text = "导出结果";
            this.btnExportResult.UseVisualStyleBackColor = true;
            this.btnExportResult.Click += new System.EventHandler(this.btnExportResult_Click);
            // 
            // lblFileOpenEncoding
            // 
            this.lblFileOpenEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileOpenEncoding.AutoSize = true;
            this.lblFileOpenEncoding.Location = new System.Drawing.Point(260, 18);
            this.lblFileOpenEncoding.Name = "lblFileOpenEncoding";
            this.lblFileOpenEncoding.Size = new System.Drawing.Size(89, 12);
            this.lblFileOpenEncoding.TabIndex = 3;
            this.lblFileOpenEncoding.Text = "文件打开方式：";
            // 
            // lblSearchRegxTitle
            // 
            this.lblSearchRegxTitle.AutoSize = true;
            this.lblSearchRegxTitle.Location = new System.Drawing.Point(6, 22);
            this.lblSearchRegxTitle.Name = "lblSearchRegxTitle";
            this.lblSearchRegxTitle.Size = new System.Drawing.Size(173, 12);
            this.lblSearchRegxTitle.TabIndex = 4;
            this.lblSearchRegxTitle.Text = "查询条件[可用正则进行匹配]：";
            // 
            // cmbBoxEncodingSelect
            // 
            this.cmbBoxEncodingSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBoxEncodingSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxEncodingSelect.FormattingEnabled = true;
            this.cmbBoxEncodingSelect.Items.AddRange(new object[] {
            "自动选择",
            "Default[当前系统默认编码方式]",
            "UTF-8"});
            this.cmbBoxEncodingSelect.Location = new System.Drawing.Point(356, 14);
            this.cmbBoxEncodingSelect.Name = "cmbBoxEncodingSelect";
            this.cmbBoxEncodingSelect.Size = new System.Drawing.Size(121, 20);
            this.cmbBoxEncodingSelect.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 448);
            this.Controls.Add(this.btnExportResult);
            this.Controls.Add(this.chkbOnlyFile);
            this.Controls.Add(this.grpSearchConditions);
            this.Controls.Add(this.grbBox);
            this.Controls.Add(this.cbkIncludeSub);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblSearchFilter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblSearchPath);
            this.MinimumSize = new System.Drawing.Size(523, 474);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.grbBox.ResumeLayout(false);
            this.grbBox.PerformLayout();
            this.grpSearchConditions.ResumeLayout(false);
            this.grpSearchConditions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtInfors;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox cbkIncludeSub;
        private System.Windows.Forms.GroupBox grbBox;
        private System.Windows.Forms.ComboBox cmbConditions;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnDeleteCondition;
        private System.Windows.Forms.GroupBox grpSearchConditions;
        private System.Windows.Forms.CheckBox chkbOnlyFile;
        public System.Windows.Forms.Button btnExportResult;
        private System.Windows.Forms.Label lblSearchRegxTitle;
        private System.Windows.Forms.Label lblFileOpenEncoding;
        protected System.Windows.Forms.ComboBox cmbBoxEncodingSelect;
    }
}

