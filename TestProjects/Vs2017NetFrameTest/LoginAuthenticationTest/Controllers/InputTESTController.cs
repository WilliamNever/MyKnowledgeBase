using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LoginAuthenticationTest.Controllers
{
    public class InputTESTController : Controller
    {
        public IActionResult Index()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(ViewModel vm)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
                ViewBag.ModelState = ModelState;
            }
            var list = ModelState.ToList();
            return View(vm);
        }

        public IActionResult CVMT()
        {
            var jsObj = new VMComplicatedViewModel
            {
                Name = "aaaaaaaa",
                VM = new ViewModel { Name = "aaaaaaaabbb" },
                ListViewModel = new List<ViewModel> {
                    new ViewModel{Name="", Age= 10}
                }
            };
            object json = Newtonsoft.Json.JsonConvert.SerializeObject(jsObj);
            return View(json);
        }
        [HttpPost]
        public IActionResult CVMT([FromBody]VMComplicatedViewModel cvm)
        {
            var isValid = ModelState.IsValid;

            #region two methods to read error messages are both ok.
            var modelErrors =
                ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                .SelectMany(x => x.Value.Errors.Select(y => $"{x.Key} - {y.ErrorMessage}")).ToList();
            //var modelErrors = 
            //    ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
            //    .SelectMany(x => x.Value.Errors.Select(y => new { x.Key, y.ErrorMessage })).ToList();
            #endregion

            return Json(new { IsValid = isValid, Errors = modelErrors });
        }
    }

    public class ViewModel
    {
        [Required]
        [StringLength(maximumLength: 5, MinimumLength = 3)]
        public string Name { get; set; }
        public int Age { get; set; }
        [Range(20, 40, ErrorMessage = "Age is wrong!")]
        public int UserAge { get { return Age; } }
    }

    public class VMComplicatedViewModel
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        [Range(20, 40, ErrorMessage = "Age is wrong!")]
        public int UserAge { get { return Age; } }
        public ViewModel VM { get; set; }
        public List<ViewModel> ListViewModel { get; set; }
    }
}