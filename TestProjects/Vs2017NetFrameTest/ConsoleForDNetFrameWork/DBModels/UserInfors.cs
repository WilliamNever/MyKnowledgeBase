using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleForDNetFrameWork.DBModels
{
    public partial class UserInfors
    {
        public UserInfors()
        {
            Addresses = new HashSet<Addresses>();
            RentInfors = new HashSet<RInfor>();
        }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LoginDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Addresses> Addresses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<RInfor> RentInfors { get; set; }
    }
}
