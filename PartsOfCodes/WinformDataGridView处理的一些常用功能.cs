using EFDBTest.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDBTest
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //数据库读取用EF或LinqToSql均可以
            attestEntities ae = new attestEntities("attestDB");
            var listInfors = ae.ExtendUsers.ToList();
            var myTable = GetDefinedDataTable();
            FillDataIntoTable(myTable, listInfors);
            /*
                用DataSource的优点是可以直接从数据库中取出数据框架，便于建立相应DataGridView。
                像这篇代码中自己手写约束可以在编辑后映射到DataTable检查数据是否正确。
                直接绑定List也可以，那样无法在编辑后数据映射时记录下哪些是修改的，哪些是未修改的。
                这里用的是：System.Windows.Forms.BindingSource，
                private System.Windows.Forms.DataGridView dgList;
            */
            extendUserBindingSource.DataSource = myTable;
        }

        private void FillDataIntoTable(DataTable myTable, List<ExtendUser> listInfors)
        {
            DataRow row;
            foreach (var itm in listInfors)
            {
                row = myTable.NewRow();
                row["UserName"] = itm.UserName;
                row["id"] = itm.id;
                row["Password"] = itm.Password;
                row["FirstName"] = itm.FirstName;
                row["LastName"] = itm.LastName;
                row["Age"] = itm.Age;
                myTable.Rows.Add(row);
            }
            myTable.AcceptChanges();
        }

        private DataTable GetDefinedDataTable()
        {
            /*
             * 做的List to DataTable映射，网上有现成方法，这里为测试。
             * 如果没有自己写数据约束，那数据约束就不存在。
             * */
            DataTable myTable = new DataTable();
            
            #region UserName
            var UserName = new DataColumn("UserName", typeof(string));
            UserName.Unique = true;
            UserName.MaxLength = 8;
            UserName.AutoIncrement = false;
            UserName.AllowDBNull = false;
            myTable.Columns.Add(UserName);
            #endregion

            #region id
            var id = new DataColumn("id", typeof(int));
            id.ReadOnly = true;
            myTable.Columns.Add(id);
            #endregion

            #region Password
            var Password = new DataColumn("Password", typeof(string));
            Password.MaxLength = 8;
            Password.AutoIncrement = false;
            Password.AllowDBNull = false;
            myTable.Columns.Add(Password);
            #endregion

            #region FirstName
            var FirstName = new DataColumn("FirstName", typeof(string));
            FirstName.MaxLength = 8;
            FirstName.AutoIncrement = false;
            FirstName.AllowDBNull = false;
            myTable.Columns.Add(FirstName);
            #endregion

            #region LastName
            var LastName = new DataColumn("LastName", typeof(string));
            LastName.MaxLength = 8;
            LastName.AutoIncrement = false;
            LastName.AllowDBNull = false;
            myTable.Columns.Add(LastName);
            #endregion

            #region Age
            var Age = new DataColumn("Age", typeof(int));
            Age.AllowDBNull = true;
            myTable.Columns.Add(Age);
            #endregion

            return myTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt = extendUserBindingSource.DataSource as DataTable;
            //datatable 会保存所有行的数据记录的更新状态，包括：未改变，添加，修改，删除。。。。。
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*
             * 未读取数据库时绑定空表，可以直接进行添加操作。
             */
            var myTable = GetDefinedDataTable();
            extendUserBindingSource.DataSource = myTable;
        }

        private void dgList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /*
             * 此事件是截取编辑完DataGridView后数据错误产生的错误信息。否则会报出很不友好的错误方式。
             */
            MessageBox.Show(e.Exception.Message);
        }
    }
}
/*数据库结构
public partial class ExtendUser
{
    public string UserName { get; set; }
    public int id { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Nullable<int> Age { get; set; }
}

CREATE TABLE [dbo].[ExtendUsers] (
    [UserName]  NVARCHAR (20) NOT NULL,
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [Password]  NVARCHAR (32) NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    [Age]       INT           NULL
);
*/
