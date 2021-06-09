using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorTest.Pages
{
    public class actModel : PageModel
    {
        public int StartIndex { get; set; } = 100;
        public void OnGet()
        {
        }
    }
}
