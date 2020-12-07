namespace ScreenShotCut
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIconFunctions = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconCMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmToShotCutem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowConfigurations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenSavedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmitmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cbIsSaveToFile = new System.Windows.Forms.CheckBox();
            this.cbIsAutoSave = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAutoSavePreFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutoSavePath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grbSaveFileOptions = new System.Windows.Forms.GroupBox();
            this.grbAutoSaveOptions = new System.Windows.Forms.GroupBox();
            this.NotifyIconCMenuStrip.SuspendLayout();
            this.grbSaveFileOptions.SuspendLayout();
            this.grbAutoSaveOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIconFunctions
            // 
            this.NotifyIconFunctions.ContextMenuStrip = this.NotifyIconCMenuStrip;
            this.NotifyIconFunctions.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconFunctions.Icon")));
            this.NotifyIconFunctions.Text = "SnapScreen";
            this.NotifyIconFunctions.Visible = true;
            this.NotifyIconFunctions.DoubleClick += new System.EventHandler(this.NotifyIconFunctions_DoubleClick);
            // 
            // NotifyIconCMenuStrip
            // 
            this.NotifyIconCMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmToShotCutem,
            this.tsmShowConfigurations,
            this.tsmOpenSavedFolder,
            this.tsmitmExit});
            this.NotifyIconCMenuStrip.Name = "NotifyIconCMenuStrip";
            this.NotifyIconCMenuStrip.Size = new System.Drawing.Size(183, 92);
            this.NotifyIconCMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.NotifyIconCMenuStrip_Closed);
            this.NotifyIconCMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NotifyIconCMenuStrip_ItemClicked);
            // 
            // tsmToShotCutem
            // 
            this.tsmToShotCutem.Name = "tsmToShotCutem";
            this.tsmToShotCutem.Size = new System.Drawing.Size(182, 22);
            this.tsmToShotCutem.Text = "ToShotCut";
            // 
            // tsmShowConfigurations
            // 
            this.tsmShowConfigurations.Name = "tsmShowConfigurations";
            this.tsmShowConfigurations.Size = new System.Drawing.Size(182, 22);
            this.tsmShowConfigurations.Text = "ShowConfigurations";
            // 
            // tsmOpenSavedFolder
            // 
            this.tsmOpenSavedFolder.Name = "tsmOpenSavedFolder";
            this.tsmOpenSavedFolder.Size = new System.Drawing.Size(182, 22);
            this.tsmOpenSavedFolder.Text = "OpenSavedFolder";
            // 
            // tsmitmExit
            // 
            this.tsmitmExit.Name = "tsmitmExit";
            this.tsmitmExit.Size = new System.Drawing.Size(182, 22);
            this.tsmitmExit.Text = "Exit";
            // 
            // cbIsSaveToFile
            // 
            this.cbIsSaveToFile.AutoSize = true;
            this.cbIsSaveToFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsSaveToFile.Location = new System.Drawing.Point(47, 23);
            this.cbIsSaveToFile.Name = "cbIsSaveToFile";
            this.cbIsSaveToFile.Size = new System.Drawing.Size(99, 17);
            this.cbIsSaveToFile.TabIndex = 2;
            this.cbIsSaveToFile.Text = "Is Saved to file:";
            this.cbIsSaveToFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsSaveToFile.UseVisualStyleBackColor = true;
            this.cbIsSaveToFile.CheckedChanged += new System.EventHandler(this.cbIsSaveToFile_CheckedChanged);
            // 
            // cbIsAutoSave
            // 
            this.cbIsAutoSave.AutoSize = true;
            this.cbIsAutoSave.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsAutoSave.Location = new System.Drawing.Point(44, 21);
            this.cbIsAutoSave.Name = "cbIsAutoSave";
            this.cbIsAutoSave.Size = new System.Drawing.Size(90, 17);
            this.cbIsAutoSave.TabIndex = 3;
            this.cbIsAutoSave.Text = "Is Auto Save:";
            this.cbIsAutoSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsAutoSave.UseVisualStyleBackColor = true;
            this.cbIsAutoSave.CheckedChanged += new System.EventHandler(this.cbIsAutoSave_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "AutoSavePreFileName:";
            // 
            // txtAutoSavePreFileName
            // 
            this.txtAutoSavePreFileName.Location = new System.Drawing.Point(130, 26);
            this.txtAutoSavePreFileName.Name = "txtAutoSavePreFileName";
            this.txtAutoSavePreFileName.Size = new System.Drawing.Size(137, 20);
            this.txtAutoSavePreFileName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "AutoSaveFilePath:";
            // 
            // txtAutoSavePath
            // 
            this.txtAutoSavePath.Location = new System.Drawing.Point(130, 55);
            this.txtAutoSavePath.Name = "txtAutoSavePath";
            this.txtAutoSavePath.Size = new System.Drawing.Size(100, 20);
            this.txtAutoSavePath.TabIndex = 7;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(247, 54);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 8;
            this.btnSelectPath.Text = "Path Select";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(308, 237);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grbSaveFileOptions
            // 
            this.grbSaveFileOptions.Controls.Add(this.grbAutoSaveOptions);
            this.grbSaveFileOptions.Controls.Add(this.cbIsAutoSave);
            this.grbSaveFileOptions.Location = new System.Drawing.Point(12, 57);
            this.grbSaveFileOptions.Name = "grbSaveFileOptions";
            this.grbSaveFileOptions.Size = new System.Drawing.Size(371, 160);
            this.grbSaveFileOptions.TabIndex = 10;
            this.grbSaveFileOptions.TabStop = false;
            this.grbSaveFileOptions.Text = "Save To File Options";
            // 
            // grbAutoSaveOptions
            // 
            this.grbAutoSaveOptions.Controls.Add(this.btnSelectPath);
            this.grbAutoSaveOptions.Controls.Add(this.label1);
            this.grbAutoSaveOptions.Controls.Add(this.txtAutoSavePath);
            this.grbAutoSaveOptions.Controls.Add(this.label2);
            this.grbAutoSaveOptions.Controls.Add(this.txtAutoSavePreFileName);
            this.grbAutoSaveOptions.Location = new System.Drawing.Point(18, 44);
            this.grbAutoSaveOptions.Name = "grbAutoSaveOptions";
            this.grbAutoSaveOptions.Size = new System.Drawing.Size(332, 93);
            this.grbAutoSaveOptions.TabIndex = 9;
            this.grbAutoSaveOptions.TabStop = false;
            this.grbAutoSaveOptions.Text = "AutoSave Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 283);
            this.Controls.Add(this.grbSaveFileOptions);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbIsSaveToFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Configurations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.NotifyIconCMenuStrip.ResumeLayout(false);
            this.grbSaveFileOptions.ResumeLayout(false);
            this.grbSaveFileOptions.PerformLayout();
            this.grbAutoSaveOptions.ResumeLayout(false);
            this.grbAutoSaveOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIconFunctions;
        private System.Windows.Forms.ContextMenuStrip NotifyIconCMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmToShotCutem;
        private System.Windows.Forms.ToolStripMenuItem tsmitmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmShowConfigurations;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenSavedFolder;
        private System.Windows.Forms.CheckBox cbIsSaveToFile;
        private System.Windows.Forms.CheckBox cbIsAutoSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAutoSavePreFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutoSavePath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grbSaveFileOptions;
        private System.Windows.Forms.GroupBox grbAutoSaveOptions;
    }
}

