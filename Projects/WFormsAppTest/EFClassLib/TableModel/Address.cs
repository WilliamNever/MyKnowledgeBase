using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFClassLib.TableModel
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int UserID { get; set; }

        public string Email { get; set; }
        public string addr { get; set; }
        public string phone { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddIdentity { get; private set; }
        [ForeignKey("UserID")]
        public virtual UserInfor UserInfor { get; set; }
    }
}
