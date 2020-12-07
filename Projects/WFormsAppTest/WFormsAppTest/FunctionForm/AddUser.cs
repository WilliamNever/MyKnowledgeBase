using EFClassLib.ContentText;
using EFClassLib.TableModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFormsAppTest.DomainModel;

namespace WFormsAppTest.FunctionForm
{
    public partial class AddUser : PWinForm
    {
        private UserInfor ModiUser;
        private LDB.UserInfor ModiLinqUser;
        private bool isEFSearch;
        public AddUser()
        {
            InitializeComponent();
            ModiUser = null;
            ModiLinqUser = null;
            isEFSearch = true;
        }

        public UserInfor GetEFUserInfor()
        {
            UserInfor ui = null;
            if (isEFSearch && !string.IsNullOrEmpty(txtUsName.Text.Trim()))
            {
                ui = new UserInfor();
                ui.FirstName = txtFirstName.Text.Trim();
                ui.LastName = txtLastName.Text.Trim();
                ui.Password = txtPwd.Text.Trim();
                ui.UserName = txtUsName.Text.Trim();
            }
            return ui;
        }

        public LDB.UserInfor GetLinqUserInfor()
        {
            LDB.UserInfor ui = null;
            if (!isEFSearch && !string.IsNullOrEmpty(txtUsName.Text.Trim()))
            {
                ui = new LDB.UserInfor();
                ui.FirstName = txtFirstName.Text.Trim();
                ui.LastName = txtLastName.Text.Trim();
                ui.Password = txtPwd.Text.Trim();
                ui.UserName = txtUsName.Text.Trim();
            }
            return ui;
        }

        public void SetEFModiInfor(UserInfor userInf)
        {
            isEFSearch = true;
            Text = "Add/Modify User - EF";
            btnSubmit.Text = "Create";
            if (userInf != null)
            {
                btnSubmit.Text = "Modify";
                ModiUser = userInf;
                txtFirstName.Text = ModiUser.FirstName;
                txtLastName.Text = ModiUser.LastName;
                txtPwd.Text = ModiUser.Password.Trim();
                txtUsName.Text = ModiUser.UserName.Trim();

                btnDelete.Enabled = true;
                btnDelete.Visible = btnDelete.Enabled;

                var Addresses = userInf.Address.ToList();
                dgAddresses.DataSource = Addresses;
            }
        }

        public void SetLinqModiInfor(LDB.UserInfor userInf)
        {
            isEFSearch = false;
            Text = "Add/Modify User - Linq";
            btnSubmit.Text = "Create";
            if (userInf != null)
            {
                btnSubmit.Text = "Modify";
                ModiLinqUser = userInf;
                txtFirstName.Text = ModiLinqUser.FirstName;
                txtLastName.Text = ModiLinqUser.LastName;
                txtPwd.Text = ModiLinqUser.Password.Trim();
                txtUsName.Text = ModiLinqUser.UserName.Trim();

                btnDelete.Enabled = true;
                btnDelete.Visible = btnDelete.Enabled;

                var Addresses = userInf.Addresses.ToList();
                dgAddresses.DataSource = Addresses;
            }
        }
    }
}
