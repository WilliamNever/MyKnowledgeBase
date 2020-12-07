namespace WinFormTools.ToolsForms
{
    partial class ReadExcelConvert
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
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtCSVPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtConvertPattern = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpSetting = new System.Windows.Forms.TabPage();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumOfParams = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtParamInLine = new System.Windows.Forms.TextBox();
            this.cbxIncludeHeaderLine = new System.Windows.Forms.CheckBox();
            this.tabMain.SuspendLayout();
            this.tpSetting.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(8, 13);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(47, 13);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "Csv File:";
            // 
            // txtCSVPath
            // 
            this.txtCSVPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSVPath.Location = new System.Drawing.Point(61, 9);
            this.txtCSVPath.Name = "txtCSVPath";
            this.txtCSVPath.Size = new System.Drawing.Size(449, 20);
            this.txtCSVPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(516, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtConvertPattern
            // 
            this.txtConvertPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertPattern.Location = new System.Drawing.Point(8, 75);
            this.txtConvertPattern.Multiline = true;
            this.txtConvertPattern.Name = "txtConvertPattern";
            this.txtConvertPattern.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConvertPattern.Size = new System.Drawing.Size(584, 248);
            this.txtConvertPattern.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(517, 329);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate!";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(8, 6);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(638, 381);
            this.txtResult.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(571, 393);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpSetting);
            this.tabMain.Controls.Add(this.tpResult);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(608, 386);
            this.tabMain.TabIndex = 8;
            // 
            // tpSetting
            // 
            this.tpSetting.Controls.Add(this.cbxIncludeHeaderLine);
            this.tpSetting.Controls.Add(this.txtParamInLine);
            this.tpSetting.Controls.Add(this.lblNumOfParams);
            this.tpSetting.Controls.Add(this.label1);
            this.tpSetting.Controls.Add(this.lblFilePath);
            this.tpSetting.Controls.Add(this.txtCSVPath);
            this.tpSetting.Controls.Add(this.btnBrowse);
            this.tpSetting.Controls.Add(this.txtConvertPattern);
            this.tpSetting.Controls.Add(this.btnGenerate);
            this.tpSetting.Location = new System.Drawing.Point(4, 22);
            this.tpSetting.Name = "tpSetting";
            this.tpSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpSetting.Size = new System.Drawing.Size(600, 360);
            this.tpSetting.TabIndex = 0;
            this.tpSetting.Text = "Setting";
            this.tpSetting.UseVisualStyleBackColor = true;
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.btnCopy);
            this.tpResult.Controls.Add(this.btnSelectAll);
            this.tpResult.Controls.Add(this.btnClear);
            this.tpResult.Controls.Add(this.txtResult);
            this.tpResult.Location = new System.Drawing.Point(4, 22);
            this.tpResult.Name = "tpResult";
            this.tpResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpResult.Size = new System.Drawing.Size(654, 424);
            this.tpResult.TabIndex = 1;
            this.tpResult.Text = "Result";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Convert Pattern:";
            // 
            // lblNumOfParams
            // 
            this.lblNumOfParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumOfParams.AutoSize = true;
            this.lblNumOfParams.Location = new System.Drawing.Point(243, 47);
            this.lblNumOfParams.Name = "lblNumOfParams";
            this.lblNumOfParams.Size = new System.Drawing.Size(130, 13);
            this.lblNumOfParams.TabIndex = 6;
            this.lblNumOfParams.Text = "Number of the Parameters";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(8, 393);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "Select ALL";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(95, 393);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtParamInLine
            // 
            this.txtParamInLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParamInLine.Location = new System.Drawing.Point(380, 43);
            this.txtParamInLine.Name = "txtParamInLine";
            this.txtParamInLine.Size = new System.Drawing.Size(53, 20);
            this.txtParamInLine.TabIndex = 7;
            this.txtParamInLine.Text = "0";
            this.txtParamInLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxIncludeHeaderLine
            // 
            this.cbxIncludeHeaderLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxIncludeHeaderLine.AutoSize = true;
            this.cbxIncludeHeaderLine.Checked = true;
            this.cbxIncludeHeaderLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeHeaderLine.Location = new System.Drawing.Point(469, 45);
            this.cbxIncludeHeaderLine.Name = "cbxIncludeHeaderLine";
            this.cbxIncludeHeaderLine.Size = new System.Drawing.Size(122, 17);
            this.cbxIncludeHeaderLine.TabIndex = 8;
            this.cbxIncludeHeaderLine.Text = "Include Header Line";
            this.cbxIncludeHeaderLine.UseVisualStyleBackColor = true;
            // 
            // ReadExcelConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 386);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(550, 350);
            this.Name = "ReadExcelConvert";
            this.Text = "ReadExcelConvert";
            this.tabMain.ResumeLayout(false);
            this.tpSetting.ResumeLayout(false);
            this.tpSetting.PerformLayout();
            this.tpResult.ResumeLayout(false);
            this.tpResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtCSVPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtConvertPattern;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpSetting;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.Label lblNumOfParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.CheckBox cbxIncludeHeaderLine;
        private System.Windows.Forms.TextBox txtParamInLine;
    }
}