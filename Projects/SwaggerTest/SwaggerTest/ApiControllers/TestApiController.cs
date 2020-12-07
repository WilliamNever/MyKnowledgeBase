using SwaggerTest.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerTest.ApiControllers
{
    /// <summary>
    /// To Test Api Functions
    /// </summary>
    /// <remarks>Header of remark messages.</remarks>
    public class TestApiController : ApiController
    {
        /// <summary>
        /// List For All /
        /// GET: api/TestApi
        /// </summary>
        /// <remarks>Here remark messages.</remarks>
        /// <returns>Return all List</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get one by id /
        /// GET: api/TestApi/5
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>a value</returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Send a value to server /
        /// POST: api/TestApi
        /// </summary>
        /// <param name="value">a value</param>
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// Get ParamModelInfor by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>return a ParamModelInfor Model</returns>
        public ParamModelInfor GetByID(int id)
        {
            var rValue = new ParamModelInfor();
            rValue.ID = id * 1000;
            rValue.Age = id / 2;
            rValue.TrueName = "True Name";
            rValue.UserName = "Login User Name";
            return rValue;
        }

        /// <summary>
        /// Save a PMInfor
        /// </summary>
        /// <param name="infor">a model to save</param>
        /// <returns>a bool to indicate that is saved or not</returns>
        /// <remarks>return whether the model is saved or not</remarks>
        [HttpPost]
        public bool SavePMInfor(ParamModelInfor infor)
        {
            bool rValue = true;
            return rValue;
        }
    }
}
