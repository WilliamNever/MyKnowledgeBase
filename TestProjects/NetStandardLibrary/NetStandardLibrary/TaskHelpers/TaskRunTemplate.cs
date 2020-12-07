using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetStandardLibrary.TaskHelpers
{
    public class TaskRunTemplate
    {
        public static async Task<T> RunAsync<T>(Func<T> func)
        {
            var tt = Task.Run(() => { return func(); });
            return await tt;
        }
    }
}
