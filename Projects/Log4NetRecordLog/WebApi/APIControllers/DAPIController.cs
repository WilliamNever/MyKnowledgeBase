using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.APIControllers
{
    public class DAPIController : ApiController
    {
        // GET: api/DAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DAPI/5
        public void Delete(int id)
        {
        }
    }
}
