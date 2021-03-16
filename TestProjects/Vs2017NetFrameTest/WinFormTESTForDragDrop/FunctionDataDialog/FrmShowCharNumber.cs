using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTESTForDragDrop.InterFace;

namespace WinFormTESTForDragDrop.FunctionDataDialog
{
    public partial class FrmShowCharNumber : Form
    {
        private IFormFunctions _fFunction;
        public FrmShowCharNumber(IFormFunctions fFunction)
        {
            _fFunction = fFunction;
            InitializeComponent();
        }

        private void btnShowCharNumber_Click(object sender, EventArgs e)
        {
            int begin = 'A';
            txtMessageInformation.Text = $"Char \t No. \t ASCII \r\n";
            txtMessageInformation.Text += $"----------------------------------------------------\r\n";
            for (int i = 0; i < 26; i++)
            {
                txtMessageInformation.Text += $"{(char)(begin + i)} \t {i + 1} \t {begin + i} \r\n";
            }
            txtMessageInformation.Text += $"----------------------------------------------------\r\n";
            txtMessageInformation.Text += $"Char \t No. \t ASCII \r\n";
            txtMessageInformation.Text += $"----------------------------------------------------\r\n";
            begin = 'a';
            for (int i = 0; i < 26; i++)
            {
                txtMessageInformation.Text += $"{(char)(begin + i)} \t {i + 1} \t {begin + i} \r\n";
            }
            txtMessageInformation.Text += $"----------------------------------------------------\r\n";
            txtMessageInformation.Text += $"Char \t No. \t ASCII \r\n";
            txtMessageInformation.Text += $"----------------------------------------------------\r\n";
            begin = '0';
            for (int i = 0; i < 10; i++)
            {
                txtMessageInformation.Text += $"{(char)(begin + i)} \t {i + 1} \t {begin + i} \r\n";
            }
        }

        private void tsmiFunctions_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CloseAllMenu();
            switch (e.ClickedItem.Name)
            {
                case "tsmCopyToMain":
                    _fFunction.CopyTextToForm(txtMessageInformation.Text, false);
                    break;
                case "tsmiCopyClose":
                    _fFunction.CopyTextToForm(txtMessageInformation.Text, false);
                    Close();
                    break;
                case "tsmAppToForm":
                    _fFunction.CopyTextToForm(txtMessageInformation.Text, true);
                    break;
                case "tsmAppAndClose":
                    _fFunction.CopyTextToForm(txtMessageInformation.Text, true);
                    Close();
                    break;
                case "tsmClose":
                    Close();
                    break;
            }
        }
        private void CloseAllMenu()
        {
            foreach (var item in MSMainMenu.Items)
            {
                if (item is ToolStripMenuItem tmp)
                {
                    tmp.DropDown.Close();
                }
            }
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            txtMessageInformation.Text = $"Type \t\t\t Min \t\t\t Max \r\n";
            txtMessageInformation.Text += $"--------------------------------------------------------------------------------------------------------\r\n";
            txtMessageInformation.Text += $"SByte\t\t{sbyte.MinValue.ToString("N0")}\t\t{sbyte.MaxValue.ToString("N0")} [0x{sbyte.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"Byte\t\t{byte.MinValue.ToString("N0")} [0x{byte.MinValue.ToString("X")}]\t\t" +
                $"{byte.MaxValue.ToString("N0")} [0x{byte.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"Short\t\t{short.MinValue.ToString("N0")}\t\t{short.MaxValue.ToString("N0")} [0x{short.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"UShort\t\t{ushort.MinValue.ToString("N0")} [0x{ushort.MinValue.ToString("X")}]\t\t" +
                $"{ushort.MaxValue.ToString("N0")} [0x{ushort.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"Int\t\t{int.MinValue.ToString("N0")}\t\t{int.MaxValue.ToString("N0")} [0x{int.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"UInt\t\t{uint.MinValue.ToString("N0")} [0x{uint.MinValue.ToString("X")}]\t\t" +
                $"{uint.MaxValue.ToString("N0")} [0x{uint.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"Long\t\t{long.MinValue.ToString("N0")}\t\t{long.MaxValue.ToString("N0")} [0x{long.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"ULong\t\t{ulong.MinValue.ToString("N0")} [0x{ulong.MinValue.ToString("X")}]\t\t" +
                $"{ulong.MaxValue.ToString("N0")} [0x{ulong.MaxValue.ToString("X")}]  \r\n";
            txtMessageInformation.Text += $"Decimal\t\t{decimal.MinValue.ToString("N")}\t\t{decimal.MaxValue.ToString("N")}  \r\n";
            txtMessageInformation.Text += "\r\n";
            txtMessageInformation.Text += "\r\n";
            txtMessageInformation.Text += $"DateTime\t\t{DateTime.MinValue.ToString()}\t\t{DateTime.MaxValue.ToString()}\r\n";
        }

        private void btnGeneralNewGuid_Click(object sender, EventArgs e)
        {
            txtMessageInformation.Text += Guid.NewGuid().ToString();
            txtMessageInformation.Text += "\r\n";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessageInformation.Text = "";
        }
    }
}
