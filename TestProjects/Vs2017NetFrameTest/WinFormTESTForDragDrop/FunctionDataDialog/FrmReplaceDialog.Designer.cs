
namespace WinFormTESTForDragDrop.FunctionDataDialog
{
    partial class frmReplace
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
            this.pnlMainPannel = new System.Windows.Forms.Panel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.cbkMatchCase = new System.Windows.Forms.CheckBox();
            this.cbkRExpression = new System.Windows.Forms.CheckBox();
            this.pnlMainPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainPannel
            // 
            this.pnlMainPannel.Controls.Add(this.cbkRExpression);
            this.pnlMainPannel.Controls.Add(this.cbkMatchCase);
            this.pnlMainPannel.Controls.Add(this.txtReplaceWith);
            this.pnlMainPannel.Controls.Add(this.txtFind);
            this.pnlMainPannel.Controls.Add(this.label2);
            this.pnlMainPannel.Controls.Add(this.label1);
            this.pnlMainPannel.Controls.Add(this.btnCancel);
            this.pnlMainPannel.Controls.Add(this.btnReplace);
            this.pnlMainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainPannel.Location = new System.Drawing.Point(0, 0);
            this.pnlMainPannel.Name = "pnlMainPannel";
            this.pnlMainPannel.Size = new System.Drawing.Size(595, 169);
            this.pnlMainPannel.TabIndex = 0;
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(414, 124);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 30);
            this.btnReplace.TabIndex = 0;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(500, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replace With:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(131, 19);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(444, 22);
            this.txtFind.TabIndex = 4;
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.Location = new System.Drawing.Point(131, 50);
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(444, 22);
            this.txtReplaceWith.TabIndex = 5;
            // 
            // cbkMatchCase
            // 
            this.cbkMatchCase.AutoSize = true;
            this.cbkMatchCase.Location = new System.Drawing.Point(27, 91);
            this.cbkMatchCase.Name = "cbkMatchCase";
            this.cbkMatchCase.Size = new System.Drawing.Size(104, 21);
            this.cbkMatchCase.TabIndex = 6;
            this.cbkMatchCase.Text = "Match Case";
            this.cbkMatchCase.UseVisualStyleBackColor = true;
            // 
            // cbkRExpression
            // 
            this.cbkRExpression.AutoSize = true;
            this.cbkRExpression.Location = new System.Drawing.Point(159, 91);
            this.cbkRExpression.Name = "cbkRExpression";
            this.cbkRExpression.Size = new System.Drawing.Size(153, 21);
            this.cbkRExpression.TabIndex = 7;
            this.cbkRExpression.Text = "Regular Expression";
            this.cbkRExpression.UseVisualStyleBackColor = true;
            // 
            // frmReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 169);
            this.Controls.Add(this.pnlMainPannel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReplace";
            this.ShowIcon = false;
            this.Text = "Replace ...";
            this.pnlMainPannel.ResumeLayout(false);
            this.pnlMainPannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainPannel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.CheckBox cbkMatchCase;
        private System.Windows.Forms.CheckBox cbkRExpression;
    }
}