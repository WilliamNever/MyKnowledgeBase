namespace WFormsAppTest
{
    partial class MainFrm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInfors = new System.Windows.Forms.TextBox();
            this.btnCheckShowInfor = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnInitDBFirst = new System.Windows.Forms.Button();
            this.btnLinqList = new System.Windows.Forms.Button();
            this.btnNewLinqUser = new System.Windows.Forms.Button();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.txtModiUsIDForLinq = new System.Windows.Forms.TextBox();
            this.txtAddrID = new System.Windows.Forms.TextBox();
            this.btnModiAddrByID = new System.Windows.Forms.Button();
            this.btnAddSomeRecords = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(349, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "NewEFUser";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInfors
            // 
            this.txtInfors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfors.Location = new System.Drawing.Point(13, 256);
            this.txtInfors.Multiline = true;
            this.txtInfors.Name = "txtInfors";
            this.txtInfors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfors.Size = new System.Drawing.Size(411, 165);
            this.txtInfors.TabIndex = 3;
            // 
            // btnCheckShowInfor
            // 
            this.btnCheckShowInfor.Location = new System.Drawing.Point(119, 431);
            this.btnCheckShowInfor.Name = "btnCheckShowInfor";
            this.btnCheckShowInfor.Size = new System.Drawing.Size(75, 23);
            this.btnCheckShowInfor.TabIndex = 2;
            this.btnCheckShowInfor.Text = "MUsArByID";
            this.btnCheckShowInfor.UseVisualStyleBackColor = true;
            this.btnCheckShowInfor.Click += new System.EventHandler(this.btnCheckShowInfor_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvList.Location = new System.Drawing.Point(13, 42);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(411, 207);
            this.dgvList.TabIndex = 1;
            this.dgvList.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_RowHeaderMouseDoubleClick);
            // 
            // btnInitDBFirst
            // 
            this.btnInitDBFirst.Location = new System.Drawing.Point(13, 12);
            this.btnInitDBFirst.Name = "btnInitDBFirst";
            this.btnInitDBFirst.Size = new System.Drawing.Size(75, 23);
            this.btnInitDBFirst.TabIndex = 0;
            this.btnInitDBFirst.Text = "InitFirst";
            this.btnInitDBFirst.UseVisualStyleBackColor = true;
            this.btnInitDBFirst.Click += new System.EventHandler(this.btnInitDBFirst_Click);
            // 
            // btnLinqList
            // 
            this.btnLinqList.Location = new System.Drawing.Point(97, 12);
            this.btnLinqList.Name = "btnLinqList";
            this.btnLinqList.Size = new System.Drawing.Size(75, 23);
            this.btnLinqList.TabIndex = 5;
            this.btnLinqList.Text = "LinqList";
            this.btnLinqList.UseVisualStyleBackColor = true;
            this.btnLinqList.Click += new System.EventHandler(this.btnLinqList_Click);
            // 
            // btnNewLinqUser
            // 
            this.btnNewLinqUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewLinqUser.Location = new System.Drawing.Point(347, 430);
            this.btnNewLinqUser.Name = "btnNewLinqUser";
            this.btnNewLinqUser.Size = new System.Drawing.Size(75, 25);
            this.btnNewLinqUser.TabIndex = 6;
            this.btnNewLinqUser.Text = "NLinqUsr";
            this.btnNewLinqUser.UseVisualStyleBackColor = true;
            this.btnNewLinqUser.Click += new System.EventHandler(this.btnNewLinqUser_Click);
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Location = new System.Drawing.Point(265, 12);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(75, 23);
            this.btnClearMessages.TabIndex = 7;
            this.btnClearMessages.Text = "Clear";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // txtModiUsIDForLinq
            // 
            this.txtModiUsIDForLinq.Location = new System.Drawing.Point(13, 432);
            this.txtModiUsIDForLinq.MaxLength = 20;
            this.txtModiUsIDForLinq.Name = "txtModiUsIDForLinq";
            this.txtModiUsIDForLinq.Size = new System.Drawing.Size(100, 20);
            this.txtModiUsIDForLinq.TabIndex = 8;
            // 
            // txtAddrID
            // 
            this.txtAddrID.Location = new System.Drawing.Point(13, 458);
            this.txtAddrID.MaxLength = 20;
            this.txtAddrID.Name = "txtAddrID";
            this.txtAddrID.Size = new System.Drawing.Size(100, 20);
            this.txtAddrID.TabIndex = 9;
            // 
            // btnModiAddrByID
            // 
            this.btnModiAddrByID.Location = new System.Drawing.Point(118, 457);
            this.btnModiAddrByID.Name = "btnModiAddrByID";
            this.btnModiAddrByID.Size = new System.Drawing.Size(75, 23);
            this.btnModiAddrByID.TabIndex = 10;
            this.btnModiAddrByID.Text = "MAddrByID";
            this.btnModiAddrByID.UseVisualStyleBackColor = true;
            this.btnModiAddrByID.Click += new System.EventHandler(this.btnModiAddrByID_Click);
            // 
            // btnAddSomeRecords
            // 
            this.btnAddSomeRecords.Location = new System.Drawing.Point(181, 12);
            this.btnAddSomeRecords.Name = "btnAddSomeRecords";
            this.btnAddSomeRecords.Size = new System.Drawing.Size(75, 23);
            this.btnAddSomeRecords.TabIndex = 11;
            this.btnAddSomeRecords.Text = "AddRecs";
            this.btnAddSomeRecords.UseVisualStyleBackColor = true;
            this.btnAddSomeRecords.Click += new System.EventHandler(this.btnAddSomeRecords_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(211, 432);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 501);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddSomeRecords);
            this.Controls.Add(this.btnModiAddrByID);
            this.Controls.Add(this.txtAddrID);
            this.Controls.Add(this.txtModiUsIDForLinq);
            this.Controls.Add(this.btnClearMessages);
            this.Controls.Add(this.btnNewLinqUser);
            this.Controls.Add(this.btnLinqList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtInfors);
            this.Controls.Add(this.btnCheckShowInfor);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnInitDBFirst);
            this.Name = "MainFrm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitDBFirst;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnCheckShowInfor;
        private System.Windows.Forms.TextBox txtInfors;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLinqList;
        private System.Windows.Forms.Button btnNewLinqUser;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.TextBox txtModiUsIDForLinq;
        private System.Windows.Forms.TextBox txtAddrID;
        private System.Windows.Forms.Button btnModiAddrByID;
        private System.Windows.Forms.Button btnAddSomeRecords;
        private System.Windows.Forms.Button btnDelete;
    }
}

