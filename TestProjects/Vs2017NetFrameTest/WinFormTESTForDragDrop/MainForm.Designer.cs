namespace WinFormTESTForDragDrop
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
            this.pnlDeployment = new System.Windows.Forms.Panel();
            this.btnPaste = new System.Windows.Forms.Button();
            this.BtnCopySel = new System.Windows.Forms.Button();
            this.btnSelALL = new System.Windows.Forms.Button();
            this.chbAutoWrap = new System.Windows.Forms.CheckBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.TSMIFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISave = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveUTF8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MNISelectALL = new System.Windows.Forms.ToolStripMenuItem();
            this.MNICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MNIPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MNITrim = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIToolsWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.MNIShowCharNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFontBig = new System.Windows.Forms.Button();
            this.btnFontDefault = new System.Windows.Forms.Button();
            this.btnFontSmall = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MNIFontSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDeployment.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDeployment
            // 
            this.pnlDeployment.Controls.Add(this.btnPaste);
            this.pnlDeployment.Controls.Add(this.BtnCopySel);
            this.pnlDeployment.Controls.Add(this.btnSelALL);
            this.pnlDeployment.Controls.Add(this.chbAutoWrap);
            this.pnlDeployment.Controls.Add(this.MainMenu);
            this.pnlDeployment.Controls.Add(this.btnFontBig);
            this.pnlDeployment.Controls.Add(this.btnFontDefault);
            this.pnlDeployment.Controls.Add(this.btnFontSmall);
            this.pnlDeployment.Controls.Add(this.btnClear);
            this.pnlDeployment.Controls.Add(this.btnBrowse);
            this.pnlDeployment.Controls.Add(this.btnOpen);
            this.pnlDeployment.Controls.Add(this.txtContents);
            this.pnlDeployment.Controls.Add(this.txtPath);
            this.pnlDeployment.Controls.Add(this.label2);
            this.pnlDeployment.Controls.Add(this.label1);
            this.pnlDeployment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeployment.Location = new System.Drawing.Point(0, 0);
            this.pnlDeployment.Name = "pnlDeployment";
            this.pnlDeployment.Size = new System.Drawing.Size(800, 483);
            this.pnlDeployment.TabIndex = 0;
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaste.Location = new System.Drawing.Point(598, 72);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(86, 23);
            this.btnPaste.TabIndex = 14;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // BtnCopySel
            // 
            this.BtnCopySel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopySel.Location = new System.Drawing.Point(510, 72);
            this.BtnCopySel.Name = "BtnCopySel";
            this.BtnCopySel.Size = new System.Drawing.Size(86, 23);
            this.BtnCopySel.TabIndex = 13;
            this.BtnCopySel.Text = "Copy Selection";
            this.BtnCopySel.UseVisualStyleBackColor = true;
            this.BtnCopySel.Click += new System.EventHandler(this.BtnCopySel_Click);
            // 
            // btnSelALL
            // 
            this.btnSelALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelALL.Location = new System.Drawing.Point(448, 72);
            this.btnSelALL.Name = "btnSelALL";
            this.btnSelALL.Size = new System.Drawing.Size(60, 23);
            this.btnSelALL.TabIndex = 12;
            this.btnSelALL.Text = "Select All";
            this.btnSelALL.UseVisualStyleBackColor = true;
            this.btnSelALL.Click += new System.EventHandler(this.btnSelALL_Click);
            // 
            // chbAutoWrap
            // 
            this.chbAutoWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAutoWrap.AutoSize = true;
            this.chbAutoWrap.Checked = true;
            this.chbAutoWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAutoWrap.Location = new System.Drawing.Point(187, 76);
            this.chbAutoWrap.Name = "chbAutoWrap";
            this.chbAutoWrap.Size = new System.Drawing.Size(74, 17);
            this.chbAutoWrap.TabIndex = 10;
            this.chbAutoWrap.Text = "AutoWrap";
            this.chbAutoWrap.UseVisualStyleBackColor = true;
            this.chbAutoWrap.CheckedChanged += new System.EventHandler(this.chbAutoWrap_CheckedChanged);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIFile,
            this.TSMIEdit,
            this.TSMIToolsWindows});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 11;
            this.MainMenu.Text = "Main Menu";
            // 
            // TSMIFile
            // 
            this.TSMIFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMISave,
            this.TSMISaveAs,
            this.tsmiSaveUTF8,
            this.toolStripSeparator1,
            this.TSMIExit});
            this.TSMIFile.Name = "TSMIFile";
            this.TSMIFile.Size = new System.Drawing.Size(37, 20);
            this.TSMIFile.Text = "&File";
            this.TSMIFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSMIFile_DropDownItemClicked);
            // 
            // TSMISave
            // 
            this.TSMISave.Name = "TSMISave";
            this.TSMISave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.TSMISave.Size = new System.Drawing.Size(208, 22);
            this.TSMISave.Text = "&Save";
            // 
            // TSMISaveAs
            // 
            this.TSMISaveAs.Name = "TSMISaveAs";
            this.TSMISaveAs.Size = new System.Drawing.Size(208, 22);
            this.TSMISaveAs.Text = "Save &As Default Encoding";
            // 
            // tsmiSaveUTF8
            // 
            this.tsmiSaveUTF8.Name = "tsmiSaveUTF8";
            this.tsmiSaveUTF8.Size = new System.Drawing.Size(208, 22);
            this.tsmiSaveUTF8.Text = "Save As &UTF8 Encoding";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // TSMIExit
            // 
            this.TSMIExit.Name = "TSMIExit";
            this.TSMIExit.Size = new System.Drawing.Size(208, 22);
            this.TSMIExit.Text = "E&xit";
            // 
            // TSMIEdit
            // 
            this.TSMIEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNIFontSelect,
            this.toolStripSeparator3,
            this.MNISelectALL,
            this.MNICopy,
            this.MNIPaste,
            this.toolStripSeparator2,
            this.MNITrim});
            this.TSMIEdit.Name = "TSMIEdit";
            this.TSMIEdit.ShortcutKeyDisplayString = "";
            this.TSMIEdit.Size = new System.Drawing.Size(39, 20);
            this.TSMIEdit.Text = "&Edit";
            this.TSMIEdit.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSMIEdit_DropDownItemClicked);
            // 
            // MNISelectALL
            // 
            this.MNISelectALL.Name = "MNISelectALL";
            this.MNISelectALL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.MNISelectALL.Size = new System.Drawing.Size(195, 22);
            this.MNISelectALL.Text = "&Select All";
            // 
            // MNICopy
            // 
            this.MNICopy.Name = "MNICopy";
            this.MNICopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MNICopy.Size = new System.Drawing.Size(195, 22);
            this.MNICopy.Text = "&Copy Selection";
            // 
            // MNIPaste
            // 
            this.MNIPaste.Name = "MNIPaste";
            this.MNIPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MNIPaste.Size = new System.Drawing.Size(195, 22);
            this.MNIPaste.Text = "&Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // MNITrim
            // 
            this.MNITrim.Name = "MNITrim";
            this.MNITrim.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.MNITrim.Size = new System.Drawing.Size(195, 22);
            this.MNITrim.Text = "&Trim";
            // 
            // TSMIToolsWindows
            // 
            this.TSMIToolsWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNIShowCharNumber});
            this.TSMIToolsWindows.Name = "TSMIToolsWindows";
            this.TSMIToolsWindows.Size = new System.Drawing.Size(99, 20);
            this.TSMIToolsWindows.Text = "&Tools Windows";
            this.TSMIToolsWindows.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSMIToolsWindows_DropDownItemClicked);
            // 
            // MNIShowCharNumber
            // 
            this.MNIShowCharNumber.Name = "MNIShowCharNumber";
            this.MNIShowCharNumber.Size = new System.Drawing.Size(178, 22);
            this.MNIShowCharNumber.Text = "Show Char Number";
            // 
            // btnFontBig
            // 
            this.btnFontBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFontBig.Location = new System.Drawing.Point(380, 72);
            this.btnFontBig.Name = "btnFontBig";
            this.btnFontBig.Size = new System.Drawing.Size(52, 23);
            this.btnFontBig.TabIndex = 9;
            this.btnFontBig.Text = ">>";
            this.btnFontBig.UseVisualStyleBackColor = true;
            this.btnFontBig.Click += new System.EventHandler(this.btnFontBig_Click);
            // 
            // btnFontDefault
            // 
            this.btnFontDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFontDefault.Location = new System.Drawing.Point(322, 72);
            this.btnFontDefault.Name = "btnFontDefault";
            this.btnFontDefault.Size = new System.Drawing.Size(52, 23);
            this.btnFontDefault.TabIndex = 8;
            this.btnFontDefault.Text = "Default";
            this.btnFontDefault.UseVisualStyleBackColor = true;
            this.btnFontDefault.Click += new System.EventHandler(this.btnFontDefault_Click);
            // 
            // btnFontSmall
            // 
            this.btnFontSmall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFontSmall.Location = new System.Drawing.Point(264, 72);
            this.btnFontSmall.Name = "btnFontSmall";
            this.btnFontSmall.Size = new System.Drawing.Size(52, 23);
            this.btnFontSmall.TabIndex = 7;
            this.btnFontSmall.Text = "<<";
            this.btnFontSmall.UseVisualStyleBackColor = true;
            this.btnFontSmall.Click += new System.EventHandler(this.btnFontSmall_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(713, 72);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(599, 35);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AllowDrop = true;
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(713, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtContents
            // 
            this.txtContents.AllowDrop = true;
            this.txtContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContents.Location = new System.Drawing.Point(12, 101);
            this.txtContents.MaxLength = 0;
            this.txtContents.Multiline = true;
            this.txtContents.Name = "txtContents";
            this.txtContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContents.Size = new System.Drawing.Size(776, 370);
            this.txtContents.TabIndex = 3;
            this.txtContents.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtContents_DragDrop);
            this.txtContents.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtContents_DragEnter);
            // 
            // txtPath
            // 
            this.txtPath.AllowDrop = true;
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(54, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(538, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contents:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(192, 6);
            // 
            // MNIFontSelect
            // 
            this.MNIFontSelect.Name = "MNIFontSelect";
            this.MNIFontSelect.Size = new System.Drawing.Size(195, 22);
            this.MNIFontSelect.Text = "&Font Select";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.pnlDeployment);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlDeployment.ResumeLayout(false);
            this.pnlDeployment.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeployment;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFontBig;
        private System.Windows.Forms.Button btnFontDefault;
        private System.Windows.Forms.Button btnFontSmall;
        private System.Windows.Forms.CheckBox chbAutoWrap;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem TSMIToolsWindows;
        private System.Windows.Forms.ToolStripMenuItem MNIShowCharNumber;
        private System.Windows.Forms.ToolStripMenuItem TSMIFile;
        private System.Windows.Forms.ToolStripMenuItem TSMISave;
        private System.Windows.Forms.ToolStripMenuItem TSMISaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TSMIExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveUTF8;
        private System.Windows.Forms.Button BtnCopySel;
        private System.Windows.Forms.Button btnSelALL;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.ToolStripMenuItem TSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem MNISelectALL;
        private System.Windows.Forms.ToolStripMenuItem MNICopy;
        private System.Windows.Forms.ToolStripMenuItem MNIPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MNITrim;
        private System.Windows.Forms.ToolStripMenuItem MNIFontSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

