using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;
using WinFormTools.Models;
using WinFormTools.ToolsForms;

namespace WinFormTools
{
    public partial class MainForm : Form
    {
        private Configurations config;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuItemTools_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "MeItmConverTextForPostTestJsonToolStripMenuItem":
                    var form = new FrConvertPostManTestJson();
                    form.MdiParent = this;
                    form.Show();
                    form.WindowState = FormWindowState.Maximized;
                    break;
                case "MeItmConvertTextFromExcelToolStripMenuItem":
                    var exlform = new ReadExcelConvert();
                    exlform.MdiParent = this;
                    exlform.Show();
                    exlform.WindowState = FormWindowState.Maximized;
                    break;
                case "MeItmDBCommandToolStripMenuItem":
                    var DbcForm = new FrmExecDBCommand(config);
                    DbcForm.MdiParent = this;
                    DbcForm.Show();
                    DbcForm.WindowState = FormWindowState.Maximized;
                    //MessageBox.Show("MeItmDBCommandToolStripMenuItem");
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfigurationSettings();
        }

        private void LoadConfigurationSettings()
        {
            var configBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("ConfigSetting.json").Build();
            config = configBuilder.GetSection(nameof(Configurations)).Get<Configurations>();
        }
    }
}
