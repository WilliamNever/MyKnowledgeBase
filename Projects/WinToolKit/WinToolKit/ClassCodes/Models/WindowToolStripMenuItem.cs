using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinToolKit.ClassCodes.Models
{
    public class WindowToolStripMenuItem : ToolStripMenuItem
    {
        public Guid WindowGuid { get; set; }
        public WindowToolStripMenuItem(Guid WGuid):base()
        {
            WindowGuid = WGuid;
        }
    }
}
