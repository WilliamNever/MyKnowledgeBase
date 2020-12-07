namespace WinFormTools.ToolsForms
{
    partial class FrmExecDBCommand
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
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.tabBackGround = new System.Windows.Forms.TabControl();
            this.tpSetting = new System.Windows.Forms.TabPage();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.cmbCommands = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.tpResults = new System.Windows.Forms.TabPage();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.cmbPages = new System.Windows.Forms.ComboBox();
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.llPrePage = new System.Windows.Forms.LinkLabel();
            this.llNextPage = new System.Windows.Forms.LinkLabel();
            this.pnlBackGround.SuspendLayout();
            this.tabBackGround.SuspendLayout();
            this.tpSetting.SuspendLayout();
            this.tpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Controls.Add(this.tabBackGround);
            this.pnlBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackGround.Location = new System.Drawing.Point(0, 0);
            this.pnlBackGround.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(800, 450);
            this.pnlBackGround.TabIndex = 0;
            // 
            // tabBackGround
            // 
            this.tabBackGround.Controls.Add(this.tpSetting);
            this.tabBackGround.Controls.Add(this.tpResults);
            this.tabBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBackGround.Location = new System.Drawing.Point(0, 0);
            this.tabBackGround.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabBackGround.Name = "tabBackGround";
            this.tabBackGround.SelectedIndex = 0;
            this.tabBackGround.Size = new System.Drawing.Size(800, 450);
            this.tabBackGround.TabIndex = 0;
            // 
            // tpSetting
            // 
            this.tpSetting.Controls.Add(this.txtStatus);
            this.tpSetting.Controls.Add(this.btnClear);
            this.tpSetting.Controls.Add(this.btnExecute);
            this.tpSetting.Controls.Add(this.txtCommand);
            this.tpSetting.Controls.Add(this.cmbCommands);
            this.tpSetting.Controls.Add(this.label2);
            this.tpSetting.Controls.Add(this.txtConnectionString);
            this.tpSetting.Controls.Add(this.label1);
            this.tpSetting.Controls.Add(this.cmbConnections);
            this.tpSetting.Location = new System.Drawing.Point(4, 25);
            this.tpSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpSetting.Name = "tpSetting";
            this.tpSetting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpSetting.Size = new System.Drawing.Size(792, 421);
            this.tpSetting.TabIndex = 0;
            this.tpSetting.Text = "Settings";
            this.tpSetting.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.Location = new System.Drawing.Point(11, 362);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(671, 54);
            this.txtStatus.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(709, 362);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(709, 391);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(11, 192);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommand.Size = new System.Drawing.Size(773, 154);
            this.txtCommand.TabIndex = 5;
            // 
            // cmbCommands
            // 
            this.cmbCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommands.FormattingEnabled = true;
            this.cmbCommands.Location = new System.Drawing.Point(139, 161);
            this.cmbCommands.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCommands.Name = "cmbCommands";
            this.cmbCommands.Size = new System.Drawing.Size(645, 24);
            this.cmbCommands.TabIndex = 4;
            this.cmbCommands.SelectedIndexChanged += new System.EventHandler(this.cmbCommands_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Command Name:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(11, 39);
            this.txtConnectionString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(773, 95);
            this.txtConnectionString.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection Name:";
            // 
            // cmbConnections
            // 
            this.cmbConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.Location = new System.Drawing.Point(139, 8);
            this.cmbConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(645, 24);
            this.cmbConnections.TabIndex = 0;
            this.cmbConnections.SelectedIndexChanged += new System.EventHandler(this.cmbConnections_SelectedIndexChanged);
            // 
            // tpResults
            // 
            this.tpResults.Controls.Add(this.llNextPage);
            this.tpResults.Controls.Add(this.llPrePage);
            this.tpResults.Controls.Add(this.lblTotalRows);
            this.tpResults.Controls.Add(this.lblPageSize);
            this.tpResults.Controls.Add(this.lblTotalPage);
            this.tpResults.Controls.Add(this.cmbPages);
            this.tpResults.Controls.Add(this.dgResults);
            this.tpResults.Location = new System.Drawing.Point(4, 25);
            this.tpResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpResults.Name = "tpResults";
            this.tpResults.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpResults.Size = new System.Drawing.Size(792, 421);
            this.tpResults.TabIndex = 1;
            this.tpResults.Text = "Results";
            this.tpResults.UseVisualStyleBackColor = true;
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Location = new System.Drawing.Point(3, 394);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(40, 17);
            this.lblTotalRows.TabIndex = 5;
            this.lblTotalRows.Text = "1000";
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(680, 394);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(104, 17);
            this.lblPageSize.TabIndex = 4;
            this.lblPageSize.Text = "Page Size: 100";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(408, 394);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(40, 17);
            this.lblTotalPage.TabIndex = 3;
            this.lblTotalPage.Text = "/ 100";
            // 
            // cmbPages
            // 
            this.cmbPages.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPages.FormattingEnabled = true;
            this.cmbPages.Location = new System.Drawing.Point(277, 390);
            this.cmbPages.Name = "cmbPages";
            this.cmbPages.Size = new System.Drawing.Size(121, 24);
            this.cmbPages.TabIndex = 1;
            this.cmbPages.SelectedIndexChanged += new System.EventHandler(this.cmbPages_SelectedIndexChanged);
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.AllowUserToOrderColumns = true;
            this.dgResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.Location = new System.Drawing.Point(3, 2);
            this.dgResults.Name = "dgResults";
            this.dgResults.ReadOnly = true;
            this.dgResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgResults.RowTemplate.Height = 24;
            this.dgResults.Size = new System.Drawing.Size(786, 379);
            this.dgResults.TabIndex = 0;
            this.dgResults.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgResults_CellFormatting);
            this.dgResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgResults_DataBindingComplete);
            // 
            // llPrePage
            // 
            this.llPrePage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.llPrePage.AutoSize = true;
            this.llPrePage.Location = new System.Drawing.Point(159, 394);
            this.llPrePage.Name = "llPrePage";
            this.llPrePage.Size = new System.Drawing.Size(86, 17);
            this.llPrePage.TabIndex = 6;
            this.llPrePage.TabStop = true;
            this.llPrePage.Text = "<< Pre page";
            this.llPrePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPrePage_LinkClicked);
            // 
            // llNextPage
            // 
            this.llNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.llNextPage.AutoSize = true;
            this.llNextPage.Location = new System.Drawing.Point(490, 394);
            this.llNextPage.Name = "llNextPage";
            this.llNextPage.Size = new System.Drawing.Size(88, 17);
            this.llNextPage.TabIndex = 7;
            this.llNextPage.TabStop = true;
            this.llNextPage.Text = "Next page>>";
            this.llNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNextPage_LinkClicked);
            // 
            // FrmExecDBCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBackGround);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmExecDBCommand";
            this.Text = "Exec DB Command";
            this.Load += new System.EventHandler(this.FrmExecDBCommand_Load);
            this.pnlBackGround.ResumeLayout(false);
            this.tabBackGround.ResumeLayout(false);
            this.tpSetting.ResumeLayout(false);
            this.tpSetting.PerformLayout();
            this.tpResults.ResumeLayout(false);
            this.tpResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackGround;
        private System.Windows.Forms.TabControl tabBackGround;
        private System.Windows.Forms.TabPage tpSetting;
        private System.Windows.Forms.TabPage tpResults;
        protected System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.ComboBox cmbCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.ComboBox cmbPages;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.LinkLabel llNextPage;
        private System.Windows.Forms.LinkLabel llPrePage;
    }
}