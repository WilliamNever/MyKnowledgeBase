using EFClassLib.TableModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFClassLib.ContentText
{
    public class DBCTxt : DbContext
    {
        public DBCTxt() : base("name=DBCTxt")
        {
        }
        public DBCTxt(string connectionStringName) : base("name="+connectionStringName)
        { }

        public System.Data.Entity.DbSet<UserInfor> UserInfor { get; set; }

        public System.Data.Entity.DbSet<Address> Address { get; set; }

    }
}
