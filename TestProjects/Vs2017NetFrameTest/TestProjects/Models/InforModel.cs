using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjects.CustomValidAttributes;

namespace TestProjects.Models
{
    public class InforModel
    {
        [TextReplace]
        public string Messages { get; set; }
        [RangeStrong(1, 100, ErrorMessage = "Age should be between 1 - 100"
            , ErrorMessageResourceName = "Age", ErrorMessageResourceType = typeof(int))]
        public int Age { get; set; }
        [RangeStrong(typeof(decimal), "1500", "20000", ErrorMessage = "not valid Salary"
            , ErrorMessageResourceName = "ForSalary")]
        public decimal Salary { get; set; }
    }

    //[MetadataType(typeof(MainInforModel))]
    public class MainInforModel
    {
        [TextReplace]
        public string Messages { get; set; }
        public InforModel InforModel { get; set; }
        public List<InforModel> InforModelB { get; set; }
        public InforModel[] InforModelC { get; set; }
        public int Age { get; set; }
        public List<string> Jobs { get; set; }
        public List<int> YearsEachJob { get; set; }
    }

    public class MultiAttrTestModel
    {
        [MutipleRange(3, 5, EnWeekDay.Sunday, "{0} {1} {2} is wrong.")]
        [MutipleRange(5, 9, EnWeekDay.Friday, "{0} {1} {2} is wrong.")]
        [MutipleRange(4, 7, EnWeekDay.Saturday, "{0} {1} {2} is wrong.")]
        public virtual int? Age { get { return ProAge; } }

        public int? ProAge;

        [MutipleRange(3, 5, EnWeekDay.Sunday, "{0} {1} {2} is wrong.")]
        [MutipleRange(5, 9, EnWeekDay.Friday, "{0} {1} {2} is wrong.")]
        [MutipleRange(4, 7, EnWeekDay.Saturday, "{0} {1} {2} is wrong.")]
        public virtual int? ToggleAge { get { return ProAge; } }

        [MutipleRange(3, 5, EnWeekDay.Sunday, "{0} {1} {2} is wrong.")]
        public virtual int? ExInt { get; set; }
    }

    public class MultiAttrTestModelEx : MultiAttrTestModel
    {
        [Required]
        public override int? Age => base.Age;
        public new int? ToggleAge => base.ToggleAge;

        [Required]
        [MutipleRange(7, 9, EnWeekDay.Sunday, "{0} {1} {2} is wrong.")]
        public override int? ExInt { get; set; }
    }

    public class NullInClass
    {
        [Required]
        public MultiAttrTestModel multi { get; set; }
    }
}
