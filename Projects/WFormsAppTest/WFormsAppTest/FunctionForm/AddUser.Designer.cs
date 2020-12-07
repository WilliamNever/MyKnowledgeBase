namespace WFormsAppTest.FunctionForm
{
    partial class AddUser
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
            this.dgAddresses = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFsName = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtUsName = new System.Windows.Forms.TextBox();
            this.lblUsName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAddresses
            // 
            this.dgAddresses.AllowUserToAddRows = false;
            this.dgAddresses.AllowUserToDeleteRows = false;
            this.dgAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddresses.Location = new System.Drawing.Point(15, 158);
            this.dgAddresses.Name = "dgAddresses";
            this.dgAddresses.ReadOnly = true;
            this.dgAddresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAddresses.Size = new System.Drawing.Size(335, 194);
            this.dgAddresses.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(13, 392);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(75, 119);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(149, 20);
            this.txtLastName.TabIndex = 9;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 123);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(55, 13);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "LastName";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(75, 81);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(149, 20);
            this.txtFirstName.TabIndex = 7;
            // 
            // lblFsName
            // 
            this.lblFsName.AutoSize = true;
            this.lblFsName.Location = new System.Drawing.Point(12, 85);
            this.lblFsName.Name = "lblFsName";
            this.lblFsName.Size = new System.Drawing.Size(54, 13);
            this.lblFsName.TabIndex = 6;
            this.lblFsName.Text = "FirstName";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(75, 43);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(149, 20);
            this.txtPwd.TabIndex = 5;
            this.txtPwd.Text = "aaaa";
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(12, 47);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 4;
            this.lblPwd.Text = "Password";
            // 
            // txtUsName
            // 
            this.txtUsName.Location = new System.Drawing.Point(75, 5);
            this.txtUsName.Name = "txtUsName";
            this.txtUsName.Size = new System.Drawing.Size(149, 20);
            this.txtUsName.TabIndex = 3;
            // 
            // lblUsName
            // 
            this.lblUsName.AutoSize = true;
            this.lblUsName.Location = new System.Drawing.Point(12, 9);
            this.lblUsName.Name = "lblUsName";
            this.lblUsName.Size = new System.Drawing.Size(57, 13);
            this.lblUsName.TabIndex = 2;
            this.lblUsName.Text = "UserName";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(275, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Location = new System.Drawing.Point(194, 392);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Create";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 427);
            this.Controls.Add(this.dgAddresses);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFsName);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtUsName);
            this.Controls.Add(this.lblUsName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Name = "AddUser";
            this.Text = "Add User";
            ((System.ComponentModel.ISupportInitialize)(this.dgAddresses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUsName;
        private System.Windows.Forms.TextBox txtUsName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFsName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgAddresses;
    }
}