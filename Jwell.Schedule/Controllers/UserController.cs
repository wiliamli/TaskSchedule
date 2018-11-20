using Jwell.Modules.WebApi.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace Jwell.Schedule.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserController : BaseApiController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ApiIgnore]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiIgnore]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [ApiIgnore]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [ApiIgnore]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [ApiIgnore]
        public void Delete(int id)
        {
        }
    }
}