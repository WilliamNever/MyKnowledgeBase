namespace ScreenShotCut.UserCtrols
{
    partial class MskUctrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MskUctrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Name = "MskUctrol";
            this.Size = new System.Drawing.Size(297, 240);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskUctrol_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MskUctrol_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MskUctrol_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MskUctrol_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
