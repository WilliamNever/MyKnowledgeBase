using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebMVCAuth.Controllers
{
    public class DAPIController : ApiController
    {
        // GET: api/DAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        public string XGetInfors()
        {
            return "Hello World!";
        }

        [HttpPost]
        public string XPostInfor(dynamic FormObject)
        {
            string Name = FormObject.Name;
            int Age = FormObject.Age;

            return string.Format("return XPostInfor-{0}-{1}-{2}!", Name, Age, DateTime.Now.ToString());
        }

        [HttpPost]
        public string ZPInfor(dynamic FormObject)
        {
            string Name = FormObject.Name;
            int Age = FormObject.Age;

            return string.Format("return ZPInfor-{0}-{1}-{2}!", Name, Age, DateTime.Now.ToString());
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
