namespace WinToolKit.FuncForms
{
    partial class WindowsList
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
            this.dgWindowList = new System.Windows.Forms.DataGridView();
            this.btnActivedWindow = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.RIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgWindowList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgWindowList
            // 
            this.dgWindowList.AllowUserToAddRows = false;
            this.dgWindowList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgWindowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWindowList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RIndex,
            this.WindowName});
            this.dgWindowList.Location = new System.Drawing.Point(12, 12);
            this.dgWindowList.Name = "dgWindowList";
            this.dgWindowList.ReadOnly = true;
            this.dgWindowList.RowTemplate.Height = 23;
            this.dgWindowList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWindowList.Size = new System.Drawing.Size(493, 221);
            this.dgWindowList.TabIndex = 0;
            // 
            // btnActivedWindow
            // 
            this.btnActivedWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivedWindow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnActivedWindow.Location = new System.Drawing.Point(523, 12);
            this.btnActivedWindow.Name = "btnActivedWindow";
            this.btnActivedWindow.Size = new System.Drawing.Size(75, 23);
            this.btnActivedWindow.TabIndex = 1;
            this.btnActivedWindow.Tag = "Actived";
            this.btnActivedWindow.Text = "激活";
            this.btnActivedWindow.UseVisualStyleBackColor = true;
            this.btnActivedWindow.Click += new System.EventHandler(this.btnWindowFunction_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(523, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Tag = "Closed";
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnWindowFunction_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnOk.Location = new System.Drawing.Point(523, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // RIndex
            // 
            this.RIndex.HeaderText = "序号";
            this.RIndex.Name = "RIndex";
            this.RIndex.ReadOnly = true;
            // 
            // WindowName
            // 
            this.WindowName.HeaderText = "名称";
            this.WindowName.Name = "WindowName";
            this.WindowName.ReadOnly = true;
            this.WindowName.Width = 300;
            // 
            // WindowsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 245);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActivedWindow);
            this.Controls.Add(this.dgWindowList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "WindowsList";
            this.ShowIcon = false;
            this.Text = "窗口";
            ((System.ComponentModel.ISupportInitialize)(this.dgWindowList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnActivedWindow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.DataGridView dgWindowList;
        private System.Windows.Forms.DataGridViewTextBoxColumn RIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowName;

    }
}