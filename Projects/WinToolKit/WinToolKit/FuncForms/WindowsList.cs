using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinToolKit.ClassCodes.Models;

namespace WinToolKit.FuncForms
{
    public partial class WindowsList : Form
    {
        private Dictionary<Guid, ClassCodes.FormTemplate> WinList;
        private WindowsListFuncClass pamaClass;

        protected WindowsList()
        {
            InitializeComponent();
            dgWindowList.AutoGenerateColumns = false;
        }

        public WindowsList(Dictionary<Guid, ClassCodes.FormTemplate> WinList, WindowsListFuncClass pamaClass)
            : this()
        {
            this.WinList = WinList;
            this.pamaClass = pamaClass;
        }

        public void BindWindowInfors()
        {
            int rowIndex = 1;
            var list = (from x in WinList
                        select new DataGridViewBindModel { Num = rowIndex++, gid = x.Value.GKey, WinTitle = x.Value.VForm.Text }
                        ).ToList();
            dgWindowList.Columns[0].DataPropertyName = "Num";
            dgWindowList.Columns[1].DataPropertyName = "WinTitle";
            dgWindowList.DataSource = list;

            var checkedItm = pamaClass.GetActivedWindowMenu();
            if (checkedItm != null)
            {
                var gvList = (from x in dgWindowList.Rows.OfType<DataGridViewRow>()
                              select x
                    ).ToList();
                var ActiveRow = gvList.FirstOrDefault(x => CompareIsActiveRow(x, checkedItm.WindowGuid));
                if (ActiveRow != null)
                {
                    dgWindowList.CurrentCell = ActiveRow.Cells[0];
                }
            }
        }

        private bool CompareIsActiveRow(DataGridViewRow x, Guid guid)
        {
            bool rValue = false;
            var dataItm = x.DataBoundItem as DataGridViewBindModel;
            if (dataItm != null)
            {
                rValue = guid == dataItm.gid;
            }
            return rValue;
        }

        virtual protected void btnWindowFunction_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                List<Guid> list = (from x in dgWindowList.SelectedRows.OfType<DataGridViewRow>()
                                   let tmp = x.DataBoundItem as DataGridViewBindModel
                                   where tmp != null
                                   select tmp.gid
                            ).ToList();
                switch (btn.Tag.ToString().Trim())
                {
                    case "Actived":
                        pamaClass.ExecuteFunc(EnWinOperateCommand.ActiveWindow, list);
                        break;
                    case "Closed":
                        pamaClass.ExecuteFunc(EnWinOperateCommand.CloseWindow, list);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
