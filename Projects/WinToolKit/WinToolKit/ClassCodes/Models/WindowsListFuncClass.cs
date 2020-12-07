using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinToolKit.ClassCodes.Models
{
    public delegate void ExecuteFunction(EnWinOperateCommand cmd, List<Guid> GidList);

    public class WindowsListFuncClass
    {
        public ExecuteFunction ExecuteFunc { get; set; }
        public List<WindowToolStripMenuItem> ShowedMenuItems { get; set; }

        public WindowsListFuncClass()
        {
            ExecuteFunc = null;
        }

        public WindowToolStripMenuItem GetActivedWindowMenu()
        {
            var itm = ShowedMenuItems.FirstOrDefault(x => x.Checked);
            return itm;
        }
    }
    public enum EnWinOperateCommand
    {
        ActiveWindow = 0,
        CloseWindow,
    }
}
