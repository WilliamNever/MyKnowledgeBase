using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinToolKit.ClassBase;
using WinToolKit.ClassCodes;
using WinToolKit.ClassCodes.Models;
using WinToolKit.FuncForms;
using WinToolKit.ExtendedForms;
using CommonClasses.ClassesBase.Models;

namespace WinToolKit
{
    public partial class MainForm : BaseMenuForm
    {
        /// <summary>
        /// 打开窗口的序号
        /// </summary>
        private int num = 1;
        /// <summary>
        /// 当前已打开窗口集合
        /// </summary>
        public Dictionary<Guid, FormTemplate> WinList;
        public MainForm()
        {
            InitializeComponent();
            WinList = new Dictionary<Guid, FormTemplate>();
        }

        protected override void miFileTools_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            base.miFileTools_DropDownItemClicked(sender, e);
            switch (e.ClickedItem.Name.Trim())
            {
                case "fmiSearchFiles":
                    ReadTargetInfor.MainForm mf = new ReadTargetInfor.MainForm();
                    mf.ChangeNameHandler += new ChangeMenuItemName(SaveOKAndChangeShortCutName);
                    mf.Show();
                    AddToWinList(mf);
                    mf.WindowState = FormWindowState.Maximized;
                    break;
                case "fmiBase64Connect":
                    var base64Connect = new Base64DeEncodersExt();
                    base64Connect.InitExtForm();
                    base64Connect.ChangeNameHandler += new ChangeMenuItemName(SaveOKAndChangeShortCutName);
                    base64Connect.Show();
                    AddToWinList(base64Connect);
                    base64Connect.WindowState = FormWindowState.Maximized;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 注册已打开窗口
        /// </summary>
        /// <param name="form"></param>
        private void AddToWinList(Form form)
        {
            Guid gid = Guid.NewGuid();
            int winnum = num++;
            form.Text += winnum;
            form.Tag = gid;
            form.MdiParent = this;
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            FormTemplate ft = new FormTemplate(form, gid, winnum);
            this.WinList.Add(gid, ft);
            AddNewShortCutWindow(gid, true);
            ActiveWindowByShortCut();
        }

        private void AddNewShortCutWindow(Guid gid, bool IsSetTopToActive)
        {
            var ShortCuts = GetWindowShortCuts();

            var formObj = WinList[gid];
            var frmShortCutItem = new WindowToolStripMenuItem(gid);
            frmShortCutItem.Text = formObj.VForm.Text;
            frmShortCutItem.Click += new EventHandler(frmShortCutItem_Click);

            if (IsSetTopToActive)
            {
                ShortCuts.ForEach(x => x.Checked = false);
                tsmWindowInfor.DropDownItems.Insert(tsmWindowInfor.DropDownItems.Count - 1 - ShortCuts.Count, frmShortCutItem);
            }
            else
            {
                tsmWindowInfor.DropDownItems.Insert(tsmWindowInfor.DropDownItems.Count - 1, frmShortCutItem);
            }

            if ((ShortCuts.Count + 1) > ShortCutWindowsNum)
            {
                tsmWindowInfor.DropDownItems.RemoveAt(tsmWindowInfor.DropDownItems.Count - 1 - 1);
            }
        }
        private List<WindowToolStripMenuItem> GetWindowShortCuts()
        {
            var ShortCuts = (from x in this.tsmWindowInfor.DropDownItems.OfType<WindowToolStripMenuItem>()
                             where x != null
                             select x).ToList();
            return ShortCuts;
        }
        virtual protected void frmShortCutItem_Click(object sender, EventArgs e)
        {
            var itm = sender as WindowToolStripMenuItem;
            if (itm != null)
            {
                var frm = WinList[itm.WindowGuid];
                frm.VForm.Activate();
                tsmWindowInfor.DropDownItems.Remove(itm);
                var ShortCuts = GetWindowShortCuts();
                ShortCuts.ForEach(x => x.Checked = false);
                itm.Checked = true;
                tsmWindowInfor.DropDownItems.Insert(tsmWindowInfor.DropDownItems.Count - 1 - ShortCuts.Count, itm);
            }
        }
        /// <summary>
        /// 注销已关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isform = sender as Form;
            Guid gid;
            if (Guid.TryParse(isform.Tag.ToString(), out gid))
            {
                WinList.Remove(gid);
                RemoveFromDropDownListItem(gid);
                AddANewShortCutToEndOfList();
                ActiveWindowByShortCut();
            }
        }

        private void ActiveWindowByShortCut()
        {
            var shortcuts = GetWindowShortCuts();
            if (shortcuts.Count > 0 && (!shortcuts[0].Checked))
            {
                shortcuts[0].Checked = true;
                WinList[shortcuts[0].WindowGuid].VForm.Activate();
            }
        }

        protected void RemoveFromDropDownListItem(Guid gid)
        {
            var ShortCuts = GetWindowShortCuts();
            var ClosedWindows = (from x in ShortCuts
                                 where x.WindowGuid == gid
                                 select x).ToList();

            if (ClosedWindows.Count > 0)
            {
                var itm = ClosedWindows[0];
                tsmWindowInfor.DropDownItems.Remove(itm);
            }
        }

        protected void AddANewShortCutToEndOfList()
        {
            var ShortCuts = GetWindowShortCuts();
            var CanUsed = (from x in WinList.Reverse()
                           where !(ShortCuts.FindIndex(y => y.WindowGuid == x.Key) > -1)
                           select x).ToList();

            if (CanUsed.Count > 0)
            {
                AddNewShortCutWindow(CanUsed[0].Key, false);
            }
        }

        protected override void tsFuncWindowList_Click(object sender, EventArgs e)
        {
            base.tsFuncWindowList_Click(sender, e);
            WindowsListFuncClass pamaClass = GetWinListParam();
            WindowsList WinExistList = new WindowsList(WinList, pamaClass);
            WinExistList.BindWindowInfors();

            WinExistList.ShowDialog(this);
            GetWindowShortCuts().ForEach(x => x.Checked = false);
            ActiveWindowByShortCut();
        }

        private WindowsListFuncClass GetWinListParam()
        {
            WindowsListFuncClass pamaClass = new WindowsListFuncClass();
            pamaClass.ExecuteFunc += new ExecuteFunction(ExecuteWindow);
            pamaClass.ShowedMenuItems = GetWindowShortCuts();
            return pamaClass;
        }

        virtual protected void ExecuteWindow(EnWinOperateCommand cmd, List<Guid> GidList)
        {
            if (GidList != null && GidList.Count > 0)
            {
                switch (cmd)
                {
                    case EnWinOperateCommand.ActiveWindow:
                        RemoveFromDropDownListItem(GidList[0]);
                        AddNewShortCutWindow(GidList[0], true);
                        break;
                    case EnWinOperateCommand.CloseWindow:
                        foreach (var gid in GidList)
                        {
                            WinList[gid].VForm.Close();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        protected void SaveOKAndChangeShortCutName(string name,Guid gid)
        {
            var scuts = GetWindowShortCuts();
            var itm = scuts.FirstOrDefault(x => x.WindowGuid == gid);
            if (itm != null)
            {
                itm.Text = name;
            }
            tslMainFormExecuteResult.Text = "Saved for " + name + "";
        }
        protected override void tsmFileOper_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var prntContentMenu = e.ClickedItem.GetCurrentParent();
            prntContentMenu.Visible = false;
            try
            {
                base.tsmFileOper_DropDownItemClicked(sender, e);
                ISaveForFile iSave;
                switch (e.ClickedItem.Name.Trim())
                {
                    case "tsmiSaved":
                        iSave = this.ActiveMdiChild as ISaveForFile;
                        if (iSave != null)
                        {
                            iSave.Save();
                        }
                        break;
                    case "tsmiSavedALL":
                        foreach (var itm in WinList)
                        {
                            iSave = itm.Value.VForm as ISaveForFile;
                            if (iSave != null)
                            {
                                iSave.Save();
                            }
                        }
                        break;
                    case "tsmiSaveAnother":
                        iSave = this.ActiveMdiChild as ISaveForFile;
                        if (iSave != null)
                        {
                            iSave.SaveAnother();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
            finally
            {
                prntContentMenu.Visible = true;
            }
        }
    }
}
