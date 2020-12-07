using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTools.Utilities;

namespace WinFormTools.ToolsForms
{
    public partial class FrConvertPostManTestJson : Form
    {
        public FrConvertPostManTestJson()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            txtDesti.Text = TextConvert.PostManTestJsonConvert(txtOri.Text, txtNewObjectName.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOri.Text = "";
            txtDesti.Text = "";
        }
    }
}
