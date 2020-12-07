using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForDNetFrameWork.DBModels
{
    public class RInfDetails
    {
        [Key]
        public int ID { get; set; }
        public int RInfID { get; set; }
        [Required]
        [StringLength(1000)]
        public string BookName { get; set; }
        public string Author { get; set; }
        [StringLength(2000)]
        public string Briefs { get; set; }
        [Required]
        public bool IsRented { get; set; }
        [ForeignKey("RInfID")]
        [InverseProperty("RtDetails")]
        public RInfor RInfors { get; set; }
    }
}
