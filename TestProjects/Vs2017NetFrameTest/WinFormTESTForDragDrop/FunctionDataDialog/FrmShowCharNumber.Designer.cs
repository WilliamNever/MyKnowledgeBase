namespace WinFormTESTForDragDrop.FunctionDataDialog
{
    partial class FrmShowCharNumber
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
            this.txtMessageInformation = new System.Windows.Forms.TextBox();
            this.btnShowCharNumber = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpFunctionality = new System.Windows.Forms.GroupBox();
            this.btnMinMax = new System.Windows.Forms.Button();
            this.MSMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFunctions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCopyToMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAppToForm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAppAndClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.grpFunctionality.SuspendLayout();
            this.MSMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessageInformation
            // 
            this.txtMessageInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageInformation.Location = new System.Drawing.Point(12, 127);
            this.txtMessageInformation.MaxLength = 0;
            this.txtMessageInformation.Multiline = true;
            this.txtMessageInformation.Name = "txtMessageInformation";
            this.txtMessageInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageInformation.Size = new System.Drawing.Size(776, 311);
            this.txtMessageInformation.TabIndex = 0;
            // 
            // btnShowCharNumber
            // 
            this.btnShowCharNumber.Location = new System.Drawing.Point(6, 19);
            this.btnShowCharNumber.Name = "btnShowCharNumber";
            this.btnShowCharNumber.Size = new System.Drawing.Size(84, 23);
            this.btnShowCharNumber.TabIndex = 0;
            this.btnShowCharNumber.Text = "Char Number";
            this.btnShowCharNumber.UseVisualStyleBackColor = true;
            this.btnShowCharNumber.Click += new System.EventHandler(this.btnShowCharNumber_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpFunctionality);
            this.pnlMain.Controls.Add(this.txtMessageInformation);
            this.pnlMain.Controls.Add(this.MSMainMenu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 450);
            this.pnlMain.TabIndex = 1;
            // 
            // grpFunctionality
            // 
            this.grpFunctionality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFunctionality.Controls.Add(this.btnMinMax);
            this.grpFunctionality.Controls.Add(this.btnShowCharNumber);
            this.grpFunctionality.Location = new System.Drawing.Point(12, 40);
            this.grpFunctionality.Name = "grpFunctionality";
            this.grpFunctionality.Size = new System.Drawing.Size(776, 81);
            this.grpFunctionality.TabIndex = 1;
            this.grpFunctionality.TabStop = false;
            this.grpFunctionality.Text = "Functionality";
            // 
            // btnMinMax
            // 
            this.btnMinMax.Location = new System.Drawing.Point(6, 49);
            this.btnMinMax.Name = "btnMinMax";
            this.btnMinMax.Size = new System.Drawing.Size(84, 23);
            this.btnMinMax.TabIndex = 1;
            this.btnMinMax.Text = "MinMaxValue";
            this.btnMinMax.UseVisualStyleBackColor = true;
            this.btnMinMax.Click += new System.EventHandler(this.btnMinMax_Click);
            // 
            // MSMainMenu
            // 
            this.MSMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFunctions});
            this.MSMainMenu.Location = new System.Drawing.Point(0, 0);
            this.MSMainMenu.Name = "MSMainMenu";
            this.MSMainMenu.Size = new System.Drawing.Size(800, 24);
            this.MSMainMenu.TabIndex = 2;
            this.MSMainMenu.Text = "Main Menu";
            // 
            // tsmiFunctions
            // 
            this.tsmiFunctions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopyToMain,
            this.tsmiCopyClose,
            this.tsmAppToForm,
            this.tsmAppAndClose,
            this.toolStripSeparator1,
            this.tsmClose});
            this.tsmiFunctions.Name = "tsmiFunctions";
            this.tsmiFunctions.Size = new System.Drawing.Size(66, 20);
            this.tsmiFunctions.Text = "&Function";
            this.tsmiFunctions.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmiFunctions_DropDownItemClicked);
            // 
            // tsmCopyToMain
            // 
            this.tsmCopyToMain.Name = "tsmCopyToMain";
            this.tsmCopyToMain.Size = new System.Drawing.Size(193, 22);
            this.tsmCopyToMain.Text = "&Copy To Main Form";
            // 
            // tsmiCopyClose
            // 
            this.tsmiCopyClose.Name = "tsmiCopyClose";
            this.tsmiCopyClose.Size = new System.Drawing.Size(193, 22);
            this.tsmiCopyClose.Text = "Copy &and Close";
            // 
            // tsmAppToForm
            // 
            this.tsmAppToForm.Name = "tsmAppToForm";
            this.tsmAppToForm.Size = new System.Drawing.Size(193, 22);
            this.tsmAppToForm.Text = "&Append To Main Form";
            // 
            // tsmAppAndClose
            // 
            this.tsmAppAndClose.Name = "tsmAppAndClose";
            this.tsmAppAndClose.Size = new System.Drawing.Size(193, 22);
            this.tsmAppAndClose.Text = "Append and Close";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(193, 22);
            this.tsmClose.Text = "Cl&ose";
            // 
            // FrmShowCharNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.MainMenuStrip = this.MSMainMenu;
            this.Name = "FrmShowCharNumber";
            this.Text = "FrmShowCharNumber";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.grpFunctionality.ResumeLayout(false);
            this.MSMainMenu.ResumeLayout(false);
            this.MSMainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessageInformation;
        private System.Windows.Forms.Button btnShowCharNumber;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpFunctionality;
        private System.Windows.Forms.MenuStrip MSMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFunctions;
        private System.Windows.Forms.ToolStripMenuItem tsmCopyToMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyClose;
        private System.Windows.Forms.ToolStripMenuItem tsmAppToForm;
        private System.Windows.Forms.ToolStripMenuItem tsmAppAndClose;
        private System.Windows.Forms.Button btnMinMax;
    }
}