using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.Models
{
    public class ComponentModel
    {
        public Guid Guid { get; set; }
        //this can't be 0 (if we're saying no line numbe can be 0 - we should start line numbers at 1)
        public int line_number { get; set; }
        public int parent_line_number { get; set; } //this can't be 0 either
    }

    public class IncludedCpontModel
    {
        public Guid Guid { get; set; }
        public ComponentModel CpModel { get; set; }
        public IncludedCpontModel()
        {
            Guid = Guid.NewGuid();
            CpModel = new ComponentModel() { Guid = Guid.NewGuid() };
        }
    }

    public class ReflectCreatedModel
    {
        public Guid Guid { get; set; }
        //this can't be 0 (if we're saying no line numbe can be 0 - we should start line numbers at 1)
        public int line_number { get; set; }
        public int parent_line_number { get; set; } //this can't be 0 either

        public ReflectCreatedModel()
        {
            Guid = Guid.NewGuid();
        }

        public ReflectCreatedModel(int lnumber, int pLnumber)
        {
            Guid = Guid.NewGuid();
            line_number = lnumber;
            parent_line_number = pLnumber;
        }
    }
}
