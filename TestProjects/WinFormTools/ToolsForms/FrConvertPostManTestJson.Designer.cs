namespace WinFormTools.ToolsForms
{
    partial class FrConvertPostManTestJson
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
            this.txtOri = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtDesti = new System.Windows.Forms.TextBox();
            this.pnBaseLayout = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtNewObjectName = new System.Windows.Forms.TextBox();
            this.pnBaseLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOri
            // 
            this.txtOri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOri.Location = new System.Drawing.Point(12, 12);
            this.txtOri.Multiline = true;
            this.txtOri.Name = "txtOri";
            this.txtOri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOri.Size = new System.Drawing.Size(776, 170);
            this.txtOri.TabIndex = 0;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(590, 190);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtDesti
            // 
            this.txtDesti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesti.Location = new System.Drawing.Point(12, 217);
            this.txtDesti.Multiline = true;
            this.txtDesti.Name = "txtDesti";
            this.txtDesti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesti.Size = new System.Drawing.Size(776, 221);
            this.txtDesti.TabIndex = 2;
            // 
            // pnBaseLayout
            // 
            this.pnBaseLayout.Controls.Add(this.txtNewObjectName);
            this.pnBaseLayout.Controls.Add(this.btnClear);
            this.pnBaseLayout.Controls.Add(this.txtOri);
            this.pnBaseLayout.Controls.Add(this.txtDesti);
            this.pnBaseLayout.Controls.Add(this.btnConvert);
            this.pnBaseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBaseLayout.Location = new System.Drawing.Point(0, 0);
            this.pnBaseLayout.Name = "pnBaseLayout";
            this.pnBaseLayout.Size = new System.Drawing.Size(800, 450);
            this.pnBaseLayout.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(713, 190);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtNewObjectName
            // 
            this.txtNewObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewObjectName.Location = new System.Drawing.Point(12, 191);
            this.txtNewObjectName.Name = "txtNewObjectName";
            this.txtNewObjectName.Size = new System.Drawing.Size(572, 20);
            this.txtNewObjectName.TabIndex = 4;
            // 
            // FrConvertPostManTestJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnBaseLayout);
            this.Name = "FrConvertPostManTestJson";
            this.Text = "FrConvertPostManTestJson";
            this.pnBaseLayout.ResumeLayout(false);
            this.pnBaseLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtOri;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtDesti;
        private System.Windows.Forms.Panel pnBaseLayout;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtNewObjectName;
    }
}