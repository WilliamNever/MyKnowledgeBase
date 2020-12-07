namespace HtmlToPdf
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
            this.btnHtmlToPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHtmlToPDF
            // 
            this.btnHtmlToPDF.Location = new System.Drawing.Point(13, 13);
            this.btnHtmlToPDF.Name = "btnHtmlToPDF";
            this.btnHtmlToPDF.Size = new System.Drawing.Size(75, 23);
            this.btnHtmlToPDF.TabIndex = 0;
            this.btnHtmlToPDF.Text = "HtmlToPDF";
            this.btnHtmlToPDF.UseVisualStyleBackColor = true;
            this.btnHtmlToPDF.Click += new System.EventHandler(this.btnHtmlToPDF_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnHtmlToPDF);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHtmlToPDF;
    }
}

