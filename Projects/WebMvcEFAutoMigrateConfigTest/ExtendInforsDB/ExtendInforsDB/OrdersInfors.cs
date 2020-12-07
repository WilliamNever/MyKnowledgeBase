using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExtendInforsDB
{
    public class OrdersInfors
    {
        [Key]
        //[ScaffoldColumn(false)]
        //[System.Web.Mvc.HiddenInput]
        public int ID { get; set; }

        [Index(IsClustered = false)]
        [MaxLength(255)]
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [MaxLength(255)]
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar")]
        [Index(IsUnique = true, IsClustered = false)]
        public string OrderNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        [UIHint("CtDateTime")]  //CustomerDateTime
        public DateTime StatusChangedDate { get; set; }

        [MaxLength(255)]
        [Required(AllowEmptyStrings = false)]
        [Column(TypeName = "varchar")]
        public string CheckedUserName { get; set; }

        public OrdersInfors()
        {
            CreateDate = DateTime.Now;
            StatusChangedDate = CreateDate;
        }
    }
}