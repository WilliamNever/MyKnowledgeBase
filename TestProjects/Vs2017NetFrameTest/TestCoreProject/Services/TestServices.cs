using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.Services
{
    public class TestServices : BaseService
    {
        public override string GetClassName()
        {
            return this.GetType().FullName;
        }
    }

    public class BaseService
    {
        public virtual string GetClassName()
        {
            return this.GetType().FullName;
        }
    }
}
