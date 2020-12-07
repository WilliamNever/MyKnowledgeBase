using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReadTargetInfor.ClassCodes.Model;
using System.Text.RegularExpressions;

namespace ReadTargetInfor.ClassCodes.DomainModel
{
    public class SearchInforDomain : SearchInforModel
    {
        public List<Regex> Regs;
        public SearchInforDomain()
            : base()
        {
            this.Regs = new List<Regex>();
        }
        public bool TestAndAddReg(string RegPattern)
        {
            bool returnValue = true;
            try
            {
                Regex reg = new Regex(RegPattern);
                this.Regs.Add(reg);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }
    }
}
