namespace WinToolKit.FuncForms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblInfors = new System.Windows.Forms.Label();
            this.lblPublishInfor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfors
            // 
            this.lblInfors.AutoSize = true;
            this.lblInfors.Location = new System.Drawing.Point(298, 113);
            this.lblInfors.Name = "lblInfors";
            this.lblInfors.Size = new System.Drawing.Size(125, 12);
            this.lblInfors.TabIndex = 0;
            this.lblInfors.Text = "CC2016版权归王琪所有";
            // 
            // lblPublishInfor
            // 
            this.lblPublishInfor.AutoSize = true;
            this.lblPublishInfor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPublishInfor.Location = new System.Drawing.Point(164, 46);
            this.lblPublishInfor.Name = "lblPublishInfor";
            this.lblPublishInfor.Size = new System.Drawing.Size(112, 16);
            this.lblPublishInfor.TabIndex = 1;
            this.lblPublishInfor.Text = "版本信息 V1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(77, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "小工具集";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPublishInfor);
            this.Controls.Add(this.lblInfors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "关于";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfors;
        private System.Windows.Forms.Label lblPublishInfor;
        private System.Windows.Forms.Label label1;
    }
}