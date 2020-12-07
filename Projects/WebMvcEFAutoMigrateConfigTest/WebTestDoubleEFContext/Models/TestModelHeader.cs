using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTestDoubleEFContext.Models
{
    public class TestModelHeader
    {
        [Key]
        [System.Web.Mvc.HiddenInput]
        public int ID { get; set; }
    }
}