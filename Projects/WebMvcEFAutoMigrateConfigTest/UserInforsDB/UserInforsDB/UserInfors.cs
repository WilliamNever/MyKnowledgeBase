using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserInforsDB
{
    public class UserInfors
    {
        [Key]
        public int ID { get; set; }

        [Index(IsUnique = true, IsClustered = false)]
        [MaxLength(255)]
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "Age is a Integer")]
        [Range(1, int.MaxValue, ErrorMessage = "The number must be bigger than 0")]
        [DataType(DataType.Text)]
        public int? Age { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(max)")]
        public string Email { get; set; }
    }
}