using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormTools.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

namespace WinFormTools.ToolsForms
{
    public partial class FrmExecDBCommand : Form
    {
        private Configurations config;
        private const int PageSize = 50;
        private DataTable CurrentTable = null;

        public FrmExecDBCommand(Configurations config)
        {
            this.config = config;
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCommand.Text = "";
            txtConnectionString.Text = "";
        }

        private void cmbConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbConnections.SelectedIndex;
            txtConnectionString.Text = cmbConnections.SelectedItem.ToString();
            var DB_Execution = cmbConnections.SelectedItem as DBExecution;
            if (DB_Execution != null)
            {
                var dbcmds = DB_Execution.Commands;
                if (dbcmds == null) dbcmds = new List<DBExeCommand>();
                var cmds = dbcmds.Select(x => x).ToList();
                cmds.Insert(0, new DBExeCommand { Name = "------", Command = "" });
                cmbCommands.DisplayMember = "Name";
                cmbCommands.ValueMember = "Command";
                cmbCommands.DataSource = cmds;
                cmbCommands.SelectedIndex = 0;
                txtCommand.Text = cmbCommands.SelectedItem.ToString();
            }
        }

        private void cmbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCommand.Text = cmbCommands.SelectedItem.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "Running ...";
            if (!string.IsNullOrEmpty(txtConnectionString.Text) && !string.IsNullOrEmpty(txtCommand.Text))
            {
                ThreadRunTemplate trt = new ThreadRunTemplate(
                    new ThreadRunParamsModel
                    {
                        form = this,
                        delgate = new DelegateMethod(RunExecuteResult)
                    ,
                        Connection = txtConnectionString.Text
                    ,
                        Command = txtCommand.Text
                    }
                    );


                ThreadStart st = new ThreadStart(trt.Run);

                Thread thr = new Thread(st);
                thr.Start();
            }
            else
            {
                txtStatus.Text = "Error - No connection or command to run.";
            }

        }



        private void RunExecuteResult(DataSet ds, string Error)
        {
            if (!string.IsNullOrEmpty(Error))
            {
                txtStatus.Text = Error;
                return;
            }
            if (ds.Tables.Count > 0)
            {
                CurrentTable = ds.Tables[0];

                SetPaging(CurrentTable);
                BindGridView(CurrentTable);

                txtStatus.Text = "Returned records ...";
                tabBackGround.SelectedTab = tpResults;
            }
            else
            {
                txtStatus.Text = "Not returned selected records";
            }
        }

        private void BindGridView(DataTable table, bool isCleanColumns = true)
        {
            if (isCleanColumns)
            {
                dgResults.Columns.Clear();
                dgResults.AutoGenerateColumns = true;
            }
            dgResults.DataSource = GetPagedTable(table, cmbPages.SelectedIndex);
        }

        private void SetPaging(DataTable table)
        {
            var totalRow = table.Rows.Count;
            lblTotalRows.Text = $"Total Rows: {totalRow}";

            var tpage = totalRow / PageSize;
            tpage = totalRow % PageSize > 0 ? tpage + 1 : tpage;
            lblTotalPage.Text = $" / {tpage}";
            cmbPages.Items.Clear();
            for (int i = 0; i < tpage; i++)
            {
                cmbPages.Items.Add((i + 1).ToString());
            }
            if (tpage > 0)
                cmbPages.SelectedIndex = 0;
        }

        private DataTable GetPagedTable(DataTable table, int page/* the page is actual page, first page number is 0 */)
        {
            var selectedRow = table.Rows.OfType<DataRow>().Skip(page * PageSize).Take(PageSize);

            DataTable dt = new DataTable();
            foreach (var col in table.Columns.OfType<DataColumn>())
                dt.Columns.Add(new DataColumn(col.ColumnName, col.DataType, col.Expression, col.ColumnMapping));
            foreach (var row in selectedRow)
            {
                var NR = dt.NewRow();
                foreach (var col in dt.Columns.OfType<DataColumn>())
                    NR[col] = row[col.ColumnName];
                dt.Rows.Add(NR);
            }
            return dt;
        }

        private void FrmExecDBCommand_Load(object sender, EventArgs e)
        {
            var Executions = config?.DBConfigs?.Executions;
            if (Executions != null)
            {
                var connections = Executions.Select(x => x).ToList();
                connections.Insert(0, new DBExecution { Name = "------", ConnectionString = "" });
                cmbConnections.DisplayMember = "Name";
                cmbConnections.ValueMember = "ConnectionString";
                cmbConnections.DataSource = connections;
                cmbConnections.SelectedIndex = 0;
            }
            lblPageSize.Text = $"Page Size: {PageSize}";
        }

        private void dgResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dgResults.Rows.Count; i++)
            {
                DataGridViewRow r = this.dgResults.Rows[i];
                r.HeaderCell.Value = string.Format("{0}", PageSize * cmbPages.SelectedIndex + i + 1);
            }
            dgResults.Refresh();
        }

        private void dgResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = "NULL";
            }
        }

        private void cmbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentTable != null)
                BindGridView(CurrentTable, isCleanColumns: false);
        }

        private void llPrePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbPages.SelectedIndex > 0)
            {
                cmbPages.SelectedIndex--;
            }
        }

        private void llNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbPages.SelectedIndex < cmbPages.Items.Count - 1)
            {
                cmbPages.SelectedIndex++;
            }
        }
    }
}
