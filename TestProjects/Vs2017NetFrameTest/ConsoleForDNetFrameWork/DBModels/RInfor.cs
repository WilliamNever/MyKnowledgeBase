using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForDNetFrameWork.DBModels
{
    public class RInfor
    {
        public RInfor()
        {
            RtDetails = new HashSet<RInfDetails>();
        }
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        [StringLength(1000)]
        public string BookName { get; set; }
        public string Author { get; set; }
        [StringLength(2000)]
        public string Briefs { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RentDate { get; set; }
        [Required]
        public bool IsRented { get; set; }

        [ForeignKey("UserID")]
        [InverseProperty("RentInfors")]
        public UserInfors User { get; set; }

        [InverseProperty("RInfors")]
        public virtual ICollection<RInfDetails> RtDetails { get; set; }
    }
}
