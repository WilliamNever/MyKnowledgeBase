using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTools.Models;

namespace WinFormTools.ToolsForms
{
    public partial class ReadExcelConvert : Form
    {
        public ReadExcelConvert()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            //ofd.Filter = "Txt|*.txt|*.*|*.*";
            if (!string.IsNullOrWhiteSpace(txtCSVPath.Text))
            {
                ofd.InitialDirectory = txtCSVPath.Text.Substring(0, txtCSVPath.Text.LastIndexOf('\\'));
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtCSVPath.Text = ofd.FileName;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCSVPath.Text))
            {
                txtResult.Text = "";
                ReadExcelConvertModel rcm = new ReadExcelConvertModel
                {
                    ConvertPattern = txtConvertPattern.Text,
                    CSVPath = txtCSVPath.Text,
                    IsIncludeHeaderLine = cbxIncludeHeaderLine.Checked,
                    NumberOfParamPerLine = int.TryParse(txtParamInLine.Text, out int temp) ? temp : 0,
                };
                DoConvert(rcm);
            }
            else
            {
                txtResult.Text = "Please select a CSV file to Convert!";
            }
            tabMain.SelectedIndex = tabMain.TabPages.IndexOf(tpResult);
        }

        private void DoConvert(ReadExcelConvertModel RCM)
        {
            List<string[]> Lines = new List<string[]>();
            List<string> line;

            var fsOri = File.Open(RCM.CSVPath, FileMode.OpenOrCreate);
            var sr = new StreamReader(fsOri);

            using (var csv = new CsvReader(sr, RCM.IsIncludeHeaderLine))
            {
                //if (csv.HasHeaders) csv.ReadNextRecord();
                while (csv.ReadNextRecord())
                {
                    line = new List<string>();
                    for (int i = 0; i < csv.FieldCount; i++)
                    {
                        line.Add(csv[i].Replace("'", "''"));
                    }
                    Lines.Add(line.ToArray());
                }
            }

            sr.Close();
            fsOri.Close();

            OutPutToView(RCM, Lines);
        }

        private void OutPutToView(ReadExcelConvertModel RCM, List<string[]> lines)
        {
            int ErrorLines = 0;
            foreach (var line in lines)
            {
                if (RCM.NumberOfParamPerLine > 0)
                {
                    if (line.Length != RCM.NumberOfParamPerLine)
                    {
                        txtResult.Text += $"\r\n/* Error!!! There should be {RCM.NumberOfParamPerLine} Parameters, actually be {line.Length}*/\r\n";
                        txtResult.Text += $"/* {string.Join(", ", line)} */\r\n";
                        ErrorLines++;
                    }
                    else
                    {
                        txtResult.Text += string.Format(RCM.ConvertPattern, line);
                    }
                }
                else
                {
                    txtResult.Text += string.Format(RCM.ConvertPattern, line);
                }
                txtResult.Text += "\r\n";
                txtResult.Text += "\r\n";
            }

            txtResult.Text += $"/* convert {lines.Count} lines in total... Error Parameters Lines is {ErrorLines}. */";
            txtResult.Text += "\r\n";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            txtResult.Select();
            txtResult.SelectAll();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtResult.Copy();
            txtResult.Select();
        }
    }
}
