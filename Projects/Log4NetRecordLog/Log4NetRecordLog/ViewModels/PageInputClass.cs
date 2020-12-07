using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Log4NetRecordLog.ViewModels
{
    public class PageInputClass
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayName("User Name")]
        public string Name { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Password")]
        public string PWD { get; set; }
        [DisplayName("Current Age")]
        public int Age { get; set; }
        [DisplayName("Oter Infor")]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[\\d]+$")]
        public string IInfor { get; set; }
    }
}