using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCoreProject.ClassExTest
{
    public class MyMemoryCacheTest : MemoryCache
    {
        public MyMemoryCacheTest(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {

        }
        ~MyMemoryCacheTest()
        {
            base.Dispose();
        }
    }
}
