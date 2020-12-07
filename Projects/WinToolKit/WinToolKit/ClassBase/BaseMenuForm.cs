using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinToolKit.FuncForms;

namespace WinToolKit.ClassBase
{
    public partial class BaseMenuForm : BaseForm
    {
        /// <summary>
        /// 显示窗口快捷方式的个数
        /// </summary>
        protected readonly int ShortCutWindowsNum = 5;
        public BaseMenuForm()
        {
            InitializeComponent();
        }

        virtual protected void miFileTools_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.Trim())
            {
                case "fmiSearchFiles":
                    break;
                case "fmiBase64Connect":
                    break;
                default:
                    break;
            }
        }

        virtual protected void stpMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.Trim())
            {
                case "miAbout":
                    var aboutForm = new AboutForm();
                    aboutForm.ShowDialog();
                    break;
                case "miFileTools":
                    break;
                default:
                    break;
            }
        }

        private void toolStripMenuItem1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                //case "tsmIconArrange":
                //    this.LayoutMdi(MdiLayout.ArrangeIcons);
                //    break;
                case "tsmCaseCade":
                    this.LayoutMdi(MdiLayout.Cascade);
                    break;
                case "tsmHorizonList":
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    break;
                case "tsmVertically":
                    this.LayoutMdi(MdiLayout.TileVertical);
                    break;
                default:
                    break;
            }
        }

        virtual protected void tsFuncWindowList_Click(object sender, EventArgs e)
        {

        }

        virtual protected void tsmFileOper_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
