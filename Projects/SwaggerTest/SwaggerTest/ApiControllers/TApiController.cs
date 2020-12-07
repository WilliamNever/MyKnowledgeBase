using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerTest.ApiControllers
{
    public class TApiController : ApiController
    {
        // GET: api/TApi
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TApi/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TApi/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TApi/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
