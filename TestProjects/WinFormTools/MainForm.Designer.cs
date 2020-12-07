namespace WinFormTools
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.MeItmConverTextForPostTestJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MeItmConvertTextFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MeItmDBCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTools});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(1067, 28);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MenuItemTools
            // 
            this.MenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MeItmConverTextForPostTestJsonToolStripMenuItem,
            this.MeItmConvertTextFromExcelToolStripMenuItem,
            this.MeItmDBCommandToolStripMenuItem});
            this.MenuItemTools.Name = "MenuItemTools";
            this.MenuItemTools.Size = new System.Drawing.Size(58, 24);
            this.MenuItemTools.Text = "Tools";
            this.MenuItemTools.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuItemTools_DropDownItemClicked);
            // 
            // MeItmConverTextForPostTestJsonToolStripMenuItem
            // 
            this.MeItmConverTextForPostTestJsonToolStripMenuItem.Name = "MeItmConverTextForPostTestJsonToolStripMenuItem";
            this.MeItmConverTextForPostTestJsonToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.MeItmConverTextForPostTestJsonToolStripMenuItem.Text = "ConverTextForPostTestJson";
            // 
            // MeItmConvertTextFromExcelToolStripMenuItem
            // 
            this.MeItmConvertTextFromExcelToolStripMenuItem.Name = "MeItmConvertTextFromExcelToolStripMenuItem";
            this.MeItmConvertTextFromExcelToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.MeItmConvertTextFromExcelToolStripMenuItem.Text = "ConvertTextFromExcel";
            // 
            // MeItmDBCommandToolStripMenuItem
            // 
            this.MeItmDBCommandToolStripMenuItem.Name = "MeItmDBCommandToolStripMenuItem";
            this.MeItmDBCommandToolStripMenuItem.Size = new System.Drawing.Size(267, 26);
            this.MeItmDBCommandToolStripMenuItem.Text = "Exec DB Command";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTools;
        private System.Windows.Forms.ToolStripMenuItem MeItmConverTextForPostTestJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MeItmConvertTextFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MeItmDBCommandToolStripMenuItem;
    }
}

