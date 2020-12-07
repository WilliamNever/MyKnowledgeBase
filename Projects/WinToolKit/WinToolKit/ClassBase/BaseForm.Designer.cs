namespace WinToolKit.ClassBase
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.stpStatuBar = new System.Windows.Forms.StatusStrip();
            this.tslMainFormExecuteResult = new System.Windows.Forms.ToolStripStatusLabel();
            this.stpStatuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpStatuBar
            // 
            this.stpStatuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMainFormExecuteResult});
            this.stpStatuBar.Location = new System.Drawing.Point(0, 251);
            this.stpStatuBar.Name = "stpStatuBar";
            this.stpStatuBar.Size = new System.Drawing.Size(292, 22);
            this.stpStatuBar.TabIndex = 0;
            // 
            // tslMainFormExecuteResult
            // 
            this.tslMainFormExecuteResult.Name = "tslMainFormExecuteResult";
            this.tslMainFormExecuteResult.Size = new System.Drawing.Size(0, 17);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.stpStatuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.stpStatuBar.ResumeLayout(false);
            this.stpStatuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.StatusStrip stpStatuBar;
        protected System.Windows.Forms.ToolStripStatusLabel tslMainFormExecuteResult;

    }
}