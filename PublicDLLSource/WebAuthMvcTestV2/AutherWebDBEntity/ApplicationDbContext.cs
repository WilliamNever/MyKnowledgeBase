using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutherWebDBEntity
{
    /*
 * Here is the DbContext of the Entities
 */
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public ApplicationDbContext(string ConnectStringName)
            : base(ConnectStringName, false)
        { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Enable-Migarte to add new table
        //public virtual System.Data.Entity.DbSet<EFClassLib.TableModel.UserInfor> UserInfors { get; set; }
    }

}
