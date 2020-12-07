using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsAppTest.DomainModel
{
    public partial class PWinForm : Form
    {
        public PWinForm()
        {
            InitializeComponent();
        }

        protected LDB.LDBContextDataContext GetLinqContext()
        {
            return new LDB.LDBContextDataContext(ConfigurationManager.ConnectionStrings["DBCTxt"].ConnectionString);
        }

        protected EFClassLib.ContentText.DBCTxt GetEFContext()
        {
            return new EFClassLib.ContentText.DBCTxt("DBCTxt");
        }
    }
}
