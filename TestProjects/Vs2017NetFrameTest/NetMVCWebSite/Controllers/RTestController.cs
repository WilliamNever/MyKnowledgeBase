using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NetMVCWebSite.Controllers
{
    public class RTestController : ApiController
    {
        // GET: api/RTest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RTest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RTest
        public async Task<IEnumerable<string>> Post([FromBody]string value)
        {
            return await Task.Run(() => { return new string[] { "PostValue1", "PostValue2" }; });
        }

        // PUT: api/RTest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RTest/5
        public void Delete(int id)
        {
        }
    }
}
