using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForNodeJSTest.Models
{
    public class LoginClass
    {
        [Display(Name = "User Name")]
        public string UsName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}