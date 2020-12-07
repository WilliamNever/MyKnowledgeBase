using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCoreTest.DBModels
{
    public partial class Addresses
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        public string Email { get; set; }
        [Column("addr")]
        public string Addr { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        public Guid AddIdentity { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Addresses")]
        public UserInfors User { get; set; }
    }
}
