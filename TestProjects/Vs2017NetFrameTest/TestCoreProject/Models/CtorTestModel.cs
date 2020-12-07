using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.Models
{
    public class CtorTestModel: ctBase
    {
        public Guid idex;
        public CtorTestModel():base()
        {
            idex = Guid.NewGuid();
        }
    }

    public class ctBase
    {
        protected Guid guid;
        public ctBase()
        {
            guid = Guid.NewGuid();
        }
    }
}
