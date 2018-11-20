using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Framework.Mvc;
using System.Web.Http;

namespace Jwell.Schedule.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ValuesController : BaseApiController
    {
        private IAdminUserService adminUserService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminUserService"></param>
        public ValuesController(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }


        // GET api/<controller>/5
        /// <summary>
        /// 获取接口
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        // [ApiIgnore]
        public StandardJsonResult<AdminUserDto> GetValueById(int id)
        {
            return base.StandardAction<AdminUserDto>(() =>
             {
                 AdminUserDto admin = new AdminUserDto
                 {
                     ID = adminUserService.Count()
                 };
                 return admin;
             });
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="value">value</param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult<int> Save(string value)
        {
            return base.StandardAction<int>(() =>
            {
                return adminUserService.Count();
            });
        }
    }
}