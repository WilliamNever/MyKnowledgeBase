using EFClassLib.ContentText;
using EFClassLib.TableModel;
using LDB;
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
using WFormsAppTest.FunctionForm;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Linq;

namespace WFormsAppTest
{
    public partial class MainFrm : PWinForm
    {
        private bool isEFRun;
        public MainFrm()
        {
            InitInfo();
            InitializeComponent();
            isEFRun = true;
        }

        private void InitInfo()
        {
        }

        private void btnInitDBFirst_Click(object sender, EventArgs e)
        {
            RefreshDataByEF();
        }
        private void AddAndShowMessages(string Message)
        {
            txtInfors.Text += string.Format("{0} \t {1}\r\n", DateTime.Now.ToString(), string.IsNullOrEmpty(Message) ? "Over" : Message);
        }
        private void RefreshDataByEF()
        {
            isEFRun = true;
            using (DBCTxt db = GetEFContext())
            {
                var list = (from x in db.UserInfor
                            select new
                            {
                                id = x.id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                LoginDate = x.LoginDate,
                                Password = x.Password,
                                UserName = x.UserName
                            }).ToList();
                dgvList.Columns.Clear();
                dgvList.DataSource = list;
            }
            AddAndShowMessages("EF load finished");

            this.btnDelete.Text = "EF-Delete";
        }

        private void btnCheckShowInfor_Click(object sender, EventArgs e)
        {
            //AddAndShowMessages(AddManyTestRecordsByLinq().ToString());

            int modiID = 22;
            if (int.TryParse(txtModiUsIDForLinq.Text, out modiID))
            {
                ModifyConflictTestByLinq(modiID);
                RefreshDataByLinq();
            }
            
        }

        private void btnModiAddrByID_Click(object sender, EventArgs e)
        {
            int addrID;
            int modiCount = 2;
            var rnd = (new Random()).Next(1000, 9999).ToString();
            
            if (int.TryParse(txtAddrID.Text, out addrID))
            {
                AddAndShowMessages(addrID.ToString() + "/" + rnd.ToString());

                #region linq modify part
                using (var ldb = GetLinqContext())
                {
                    var addrList = ldb.Addresses.Where(x => x.UserID == addrID).OrderByDescending(x=>x.id).ToList();
                    if (addrList.Count >= modiCount)
                    {
                        foreach (var addr in addrList)
                        {
                            addr.addr = string.Format("{0}_{1}", "Addr", rnd);
                            //addr.Email = string.Format("{0}_{1}", "Email", rnd);
                            addr.phone = string.Format("{0}_{1}", "Phone", rnd);
                            modiCount--;
                            if (modiCount <= 0)
                                break;
                        }
                        ldb.SubmitChanges();
                    }
                }
                RefreshDataByLinq();
                #endregion

                #region EF modify part
                //using (var db = GetEFContext())
                //{
                //    var addr = db.Address.Where(x => x.id == addrID).FirstOrDefault();
                //    if (addr != null)
                //    {
                //        addr.addr = string.Format("{0}_{1}", "Addr", rnd);
                //        addr.Email = string.Format("{0}_{1}", "Email", rnd);
                //        addr.phone = string.Format("{0}_{1}", "Phone", rnd);
                //        db.SaveChanges();
                //    }
                //}
                //RefreshDataByEF();
                #endregion
            }
        }

        private void ModifyConflictTestByLinq(int UserID)
        {
            var rnd = (new Random()).Next(1000, 9999).ToString();
            AddAndShowMessages(UserID.ToString() + "/" + rnd.ToString());
            using (var ldb = GetLinqContext())
            {
                var uInfor = ldb.UserInfors.Where(x => x.id == UserID).FirstOrDefault();
                if (uInfor != null)
                {
                    AddAndShowMessages(uInfor.UserName);
                    uInfor.FirstName = string.Format("{0}_{1}", "Fs", rnd);
                    uInfor.LastName = string.Format("{0}_{1}", "Ls", rnd);
                    uInfor.Password = string.Format("{0}_{1}", "Pw", rnd);
                    uInfor.UserName = string.Format("{0}_{1}", "Us", rnd);
                    var addrList = uInfor.Addresses.ToList();
                    foreach (var addr in addrList)
                    {
                        addr.addr = string.Format("{0}_{1}", "Addr", rnd);
                        addr.Email = string.Format("{0}_{1}", "Email", rnd);
                        //addr.phone = string.Format("{0}_{1}", "Phone", rnd);
                        //addr.UserID = ui.id;
                    }
                    try
                    {
                        ldb.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (ChangeConflictException ExC)
                    {
                        AddAndShowMessages(ExC.Message);
                        foreach (var confliction in ldb.ChangeConflicts)
                        {
                            confliction.Resolve(RefreshMode.KeepChanges, true);
                        }
                        ldb.SubmitChanges();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private int AddManyTestRecordsByLinq()
        {
            #region add many records to test
            int rValue = 0;
            int ix = 5;
            var rnd = (new Random()).Next(1000, 9999).ToString();
            AddAndShowMessages(rnd.ToString());
            using (var ldb = GetLinqContext())
            {
                var ui = new LDB.UserInfor();
                ui.FirstName = string.Format("{0}_{1}", "Fs", rnd);
                ui.LastName = string.Format("{0}_{1}", "Ls", rnd);
                ui.Password = string.Format("{0}_{1}", "Pw", rnd);
                ui.UserName = string.Format("{0}_{1}", "Us", rnd);
                ldb.UserInfors.InsertOnSubmit(ui);
                ldb.SubmitChanges();
                rValue = ui.id;
                List<LDB.Address> addrList = new List<LDB.Address>();
                for (int i = 0; i < ix; i++)
                {
                    var addr = new LDB.Address();
                    addr.addr = string.Format("{0}_{1}", "Addr", rnd);
                    addr.Email = string.Format("{0}_{1}", "Email", rnd);
                    addr.phone = string.Format("{0}_{1}", "Phone", rnd);
                    addr.UserID = ui.id;
                    addrList.Add(addr);
                }
                ldb.Addresses.InsertAllOnSubmit(addrList);
                ldb.SubmitChanges();
            }
            return rValue;
            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EFAddOrModifyUser(null);
        }

        private void EFAddOrModifyUser(EFClassLib.TableModel.UserInfor UserInf)
        {
            isEFRun = true;
            AddUser addusFrm = new AddUser();
            addusFrm.SetEFModiInfor(UserInf);

            if (UserInf == null)
            {
                if (addusFrm.ShowDialog() == DialogResult.OK)
                {
                    var usInfor = addusFrm.GetEFUserInfor();
                    usInfor.Address = new List<EFClassLib.TableModel.Address>();
                    usInfor.Address.Add(new EFClassLib.TableModel.Address { addr = "yyyy", Email = "yyyy@.test.com", phone = "000000" });
                    usInfor.Address.Add(new EFClassLib.TableModel.Address { addr = "yyyy", Email = "yyyy@.test.com", phone = "000000" });
                    usInfor.Address.Add(new EFClassLib.TableModel.Address { addr = "yyyy", Email = "yyyy@.test.com", phone = "000000" });
                    if (usInfor != null)
                    {
                        using (DBCTxt db = GetEFContext())
                        {
                            db.UserInfor.Add(usInfor);
                            db.SaveChanges();
                        }
                        RefreshDataByEF();
                    }
                    else
                    {
                        AddAndShowMessages("Nothing is Add");
                    }
                }
            }
            else
            {
                //addusFrm.SetEFModiInfor(UserInf);
                switch (addusFrm.ShowDialog())
                {
                    case DialogResult.OK:
                        var usInfor = addusFrm.GetEFUserInfor();
                        if (usInfor != null)
                        {
                            using (DBCTxt db = GetEFContext())
                            {
                                var uif = db.UserInfor.Where(x => x.id == UserInf.id).FirstOrDefault();
                                if (uif != null)
                                {
                                    uif.FirstName = usInfor.FirstName;
                                    uif.LastName = usInfor.LastName;
                                    uif.Password = usInfor.Password;
                                    uif.UserName = usInfor.UserName;
                                    foreach (var addr in uif.Address)
                                    {
                                        addr.Email = "1005@test.com";
                                    }
                                    db.SaveChanges();
                                }
                            }
                            RefreshDataByEF();
                        }
                        else
                        {
                            AddAndShowMessages("Nothing is Modify");
                        }
                        break;
                    case DialogResult.No:
                        using (DBCTxt db = GetEFContext())
                        {
                            db.Database.ExecuteSqlCommand("delete from UserInfors where id=@id"
                                , new SqlParameter("@id",UserInf.id)
                                );
                        }
                        RefreshDataByEF();
                        break;
                    default:
                        break;
                }
            }
        }
        private void LinqAddOrModifyUser(LDB.UserInfor UserInf)
        {
            isEFRun = false;
            AddUser addusFrm = new AddUser();
            addusFrm.SetLinqModiInfor(UserInf);
            if (UserInf == null)
            {
                if (addusFrm.ShowDialog() == DialogResult.OK)
                {
                    var usInfor = addusFrm.GetLinqUserInfor();

                    usInfor.Addresses = new EntitySet<LDB.Address>();
                    usInfor.Addresses.Add(new LDB.Address { addr = "xxx", Email = "xxx@.test.com", phone = "000000" });
                    usInfor.Addresses.Add(new LDB.Address { addr = "xxx", Email = "xxx@.test.com", phone = "000000" });
                    usInfor.Addresses.Add(new LDB.Address { addr = "xxx", Email = "xxx@.test.com", phone = "000000" });

                    if (usInfor != null)
                    {
                        using (LDB.LDBContextDataContext db = GetLinqContext())
                        {
                            db.UserInfors.InsertOnSubmit(usInfor);
                            db.SubmitChanges();
                        }
                        RefreshDataByLinq();
                    }
                    else
                    {
                        AddAndShowMessages("Nothing is Add");
                    }
                }
            }
            else
            {
                //addusFrm.SetLinqModiInfor(UserInf);
                switch (addusFrm.ShowDialog())
                {
                    case DialogResult.OK:
                        var uinf = addusFrm.GetLinqUserInfor();
                        using (var ldb = GetLinqContext())
                        {
                            var uif = ldb.UserInfors.Where(x => x.id == UserInf.id).FirstOrDefault();
                            if (uif != null)
                            {
                                uif.FirstName = uinf.FirstName;
                                uif.LastName = uinf.LastName;
                                uif.Password = uinf.Password;
                                uif.UserName = uinf.UserName;
                                foreach (var addr in uif.Addresses)
                                {
                                    addr.Email = "911@test.com";
                                }
                                try
                                {
                                    ldb.SubmitChanges();
                                }
                                catch (ChangeConflictException e)
                                {
                                    AddAndShowMessages(e.Message);
                                }
                                catch
                                { }
                            }
                        }
                        RefreshDataByLinq();
                        break;
                    case DialogResult.No:
                        using (var db = GetLinqContext())
                        {
                            db.ExecuteCommand("delete from UserInfors where id={0}"
                                , UserInf.id.ToString()
                                );
                        }
                        RefreshDataByLinq();
                        break;
                    default:
                        break;
                }
            }
        }
        private void dgvList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id;
            if (int.TryParse(dgvList.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out id))
            {
                if (isEFRun)
                {
                    EFClassLib.TableModel.UserInfor usInfor = null;
                    using (DBCTxt db = GetEFContext())
                    {
                        usInfor = db.UserInfor.Where(x => x.id == id).FirstOrDefault();

                        if (usInfor != null)
                        {
                            EFAddOrModifyUser(usInfor);
                        }
                        else
                        {
                            txtInfors.Text = "The User is not exists.";
                        }
                    }
                }
                else
                {
                    LDB.UserInfor usInfor = null;
                    using (var ldb = GetLinqContext())
                    {
                        usInfor = ldb.UserInfors.Where(x => x.id == id).FirstOrDefault();
                        if (usInfor != null)
                        {
                            LinqAddOrModifyUser(usInfor);
                        }
                        else
                        {
                            txtInfors.Text = "The User is not exists.";
                        }
                    }
                }
            }
        }

        private void btnLinqList_Click(object sender, EventArgs e)
        {
            RefreshDataByLinq();
        }

        private void RefreshDataByLinq()
        {
            isEFRun = false;
            using (LDBContextDataContext ldb = GetLinqContext())
            {
                var ulist = (from x in ldb.UserInfors
                            select new
                            {
                                id = x.id,
                                FirstName = x.FirstName,
                                LastName = x.LastName,
                                LoginDate = x.LoginDate,
                                UserName = x.UserName,
                                Password = x.Password
                            }).ToList();
                dgvList.Columns.Clear();
                dgvList.DataSource = ulist;
            }
            AddAndShowMessages("Linq load finished");

            this.btnDelete.Text = "LQ-Delete";
        }

        private void btnNewLinqUser_Click(object sender, EventArgs e)
        {
            LinqAddOrModifyUser(null);
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {
            txtInfors.Text = "";
        }

        private void btnAddSomeRecords_Click(object sender, EventArgs e)
        {
            AddManyTestRecordsByLinq();
            RefreshDataByLinq();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idNum;
            if (!int.TryParse(txtModiUsIDForLinq.Text, out idNum))
            {
                idNum = 0;
            }
            if (isEFRun)
            {
                var db = GetEFContext();
                db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.EnsureTransaction, "delete from UserInfors where id=@id"
                    , new SqlParameter("id", idNum));
            }
            else
            {
                var db = GetLinqContext();
                db.ExecuteCommand("delete from UserInfors where id={0}", idNum);
            }
            MessageBox.Show("deleted!");
        }
    }
}
