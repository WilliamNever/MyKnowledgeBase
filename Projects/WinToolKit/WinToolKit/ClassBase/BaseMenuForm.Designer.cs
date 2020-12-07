namespace WinToolKit.ClassBase
{
    partial class BaseMenuForm
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
            this.stpMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmFileOper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaved = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSavedALL = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAnother = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileTools = new System.Windows.Forms.ToolStripMenuItem();
            this.fmiSearchFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.fmiBase64Connect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWindowInfor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIconArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCaseCade = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHorizonList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVertically = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsFuncWindowList = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.stpMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpMainMenu
            // 
            this.stpMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileOper,
            this.miFileTools,
            this.tsmWindowInfor,
            this.miAbout});
            this.stpMainMenu.Location = new System.Drawing.Point(0, 0);
            this.stpMainMenu.Name = "stpMainMenu";
            this.stpMainMenu.Size = new System.Drawing.Size(292, 24);
            this.stpMainMenu.TabIndex = 1;
            this.stpMainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stpMainMenu_ItemClicked);
            // 
            // tsmFileOper
            // 
            this.tsmFileOper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaved,
            this.tsmiSaveAnother,
            this.tsmiSavedALL});
            this.tsmFileOper.Name = "tsmFileOper";
            this.tsmFileOper.Size = new System.Drawing.Size(41, 20);
            this.tsmFileOper.Text = "文件";
            this.tsmFileOper.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmFileOper_DropDownItemClicked);
            // 
            // tsmiSaved
            // 
            this.tsmiSaved.Name = "tsmiSaved";
            this.tsmiSaved.Size = new System.Drawing.Size(152, 22);
            this.tsmiSaved.Text = "保存";
            // 
            // tsmiSavedALL
            // 
            this.tsmiSavedALL.Name = "tsmiSavedALL";
            this.tsmiSavedALL.Size = new System.Drawing.Size(152, 22);
            this.tsmiSavedALL.Text = "保存全部";
            // 
            // tsmiSaveAnother
            // 
            this.tsmiSaveAnother.Name = "tsmiSaveAnother";
            this.tsmiSaveAnother.Size = new System.Drawing.Size(152, 22);
            this.tsmiSaveAnother.Text = "另存为";
            // 
            // miFileTools
            // 
            this.miFileTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fmiSearchFiles,
            this.fmiBase64Connect});
            this.miFileTools.Name = "miFileTools";
            this.miFileTools.Size = new System.Drawing.Size(65, 20);
            this.miFileTools.Text = "文本工具";
            this.miFileTools.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miFileTools_DropDownItemClicked);
            // 
            // fmiSearchFiles
            // 
            this.fmiSearchFiles.Name = "fmiSearchFiles";
            this.fmiSearchFiles.Size = new System.Drawing.Size(148, 22);
            this.fmiSearchFiles.Text = "文件查询";
            // 
            // fmiBase64Connect
            // 
            this.fmiBase64Connect.Name = "fmiBase64Connect";
            this.fmiBase64Connect.Size = new System.Drawing.Size(148, 22);
            this.fmiBase64Connect.Text = "Base64Connect";
            // 
            // tsmWindowInfor
            // 
            this.tsmWindowInfor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.tsFuncWindowList});
            this.tsmWindowInfor.Name = "tsmWindowInfor";
            this.tsmWindowInfor.Size = new System.Drawing.Size(41, 20);
            this.tsmWindowInfor.Text = "窗口";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIconArrange,
            this.tsmCaseCade,
            this.tsmHorizonList,
            this.tsmVertically});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "布局";
            this.toolStripMenuItem1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenuItem1_DropDownItemClicked);
            // 
            // tsmIconArrange
            // 
            this.tsmIconArrange.Name = "tsmIconArrange";
            this.tsmIconArrange.Size = new System.Drawing.Size(118, 22);
            this.tsmIconArrange.Text = "图标排列";
            this.tsmIconArrange.Visible = false;
            // 
            // tsmCaseCade
            // 
            this.tsmCaseCade.Name = "tsmCaseCade";
            this.tsmCaseCade.Size = new System.Drawing.Size(118, 22);
            this.tsmCaseCade.Text = "层叠排列";
            // 
            // tsmHorizonList
            // 
            this.tsmHorizonList.Name = "tsmHorizonList";
            this.tsmHorizonList.Size = new System.Drawing.Size(118, 22);
            this.tsmHorizonList.Text = "水平排列";
            // 
            // tsmVertically
            // 
            this.tsmVertically.Name = "tsmVertically";
            this.tsmVertically.Size = new System.Drawing.Size(118, 22);
            this.tsmVertically.Text = "垂直排列";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(91, 6);
            // 
            // tsFuncWindowList
            // 
            this.tsFuncWindowList.Name = "tsFuncWindowList";
            this.tsFuncWindowList.Size = new System.Drawing.Size(94, 22);
            this.tsFuncWindowList.Text = "窗口";
            this.tsFuncWindowList.Click += new System.EventHandler(this.tsFuncWindowList_Click);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(41, 20);
            this.miAbout.Text = "关于";
            this.miAbout.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miFileTools_DropDownItemClicked);
            // 
            // BaseMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.stpMainMenu);
            this.MainMenuStrip = this.stpMainMenu;
            this.Name = "BaseMenuForm";
            this.Text = "BaseMenuForm";
            this.Controls.SetChildIndex(this.stpMainMenu, 0);
            this.stpMainMenu.ResumeLayout(false);
            this.stpMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.MenuStrip stpMainMenu;
        protected System.Windows.Forms.ToolStripMenuItem miAbout;
        protected System.Windows.Forms.ToolStripMenuItem miFileTools;
        protected System.Windows.Forms.ToolStripMenuItem fmiSearchFiles;
        private System.Windows.Forms.ToolStripMenuItem fmiBase64Connect;
        private System.Windows.Forms.ToolStripMenuItem tsmIconArrange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmCaseCade;
        private System.Windows.Forms.ToolStripMenuItem tsmHorizonList;
        private System.Windows.Forms.ToolStripMenuItem tsmVertically;
        protected System.Windows.Forms.ToolStripMenuItem tsmWindowInfor;
        protected System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsFuncWindowList;
        private System.Windows.Forms.ToolStripMenuItem tsmFileOper;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaved;
        private System.Windows.Forms.ToolStripMenuItem tsmiSavedALL;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAnother;
    }
}