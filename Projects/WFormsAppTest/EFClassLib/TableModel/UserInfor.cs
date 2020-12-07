using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace EFClassLib.TableModel
{
    public class UserInfor
    {
        [Key]
        public int id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime LoginDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }

        public UserInfor()
        {
            LoginDate = DateTime.Now;
        }
    }
}
