using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTESTForDragDrop.InterFace;

namespace WinFormTESTForDragDrop.FunctionDataDialog
{
    public partial class frmReplace : Form
    {
        private IFormFunctions _fFunction;
        public frmReplace(IFormFunctions fFunction)
        {
            _fFunction = fFunction;
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            var contentsBox = _fFunction.GetContentsBox();
            contentsBox.Text = Replace(contentsBox.Text, txtFind.Text, txtReplaceWith.Text
                , cbkMatchCase.Checked, cbkRExpression.Checked);
        }

        private string Replace(string text, string find, string replacement, bool mcase, bool regularEx)
        {
            string result = text;

            if (regularEx)
            {
                result = RegularReplace(result, find, replacement, mcase);
            }
            else
            {
                result = CommonReplace(result, find, replacement, mcase);
            }
            return result;
        }

        private string RegularReplace(string text, string find, string replacement, bool mcase)
        {
            Regex reg = new Regex(find, mcase ? RegexOptions.None : RegexOptions.IgnoreCase);
            return reg.Replace(text, replacement);
        }

        private string CommonReplace(string text, string find, string replacement, bool mcase)
        {
            string result = text;
            var mcaseOption = mcase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            int index = result?.IndexOf(find, mcaseOption) ?? -1;
            string ReplacedString;
            while (index > -1)
            {
                ReplacedString = $"{result.Substring(0, index)}{replacement}";
                result = $"{ReplacedString}{result.Substring(index + find.Length)}";
                index = result?.IndexOf(find, ReplacedString.Length, mcaseOption) ?? -1;
            }
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}