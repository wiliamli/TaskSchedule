using System.Web.Mvc;
using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Application.Services.Params;
using Jwell.Framework.Mvc;
using Jwell.Framework.Paging;
using Jwell.Framework.Excel;

namespace Jwell.Schedule.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : BaseController
    {
        private IAdminUserService adminUserService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminUserService"></param>
        public HomeController(IAdminUserService adminUserService)
        {
            this.adminUserService = adminUserService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            int count = adminUserService.Count();

            ViewBag.Title = "Home Page";

            return View(111);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public StandardJsonResult<PageResult<AdminUserDto>> List(SearchAdminUserParam request)
        {
            StandardJsonResult<PageResult<AdminUserDto>> result = 
                base.StandardAction<PageResult<AdminUserDto>>(() =>
            {
                PageResult<AdminUserDto> pageResult = adminUserService.GetAdminUserDtos(request);
                return pageResult;
            });

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public StandardJsonResult Save(AdminUserDto dto)
        {
            return base.StandardAction(() =>{
                adminUserService.Count();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StandardJsonResult GetResult()
        {
            int result = 0;
            StandardJsonResult jsonResult=  base.StandardAction<int>(() =>
            {
                result = adminUserService.Count();
                return result;
            });
            jsonResult.Success = result > 0;
            jsonResult.Message = jsonResult.Success ? "成功" : "失败";
            return jsonResult;
        }

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="request"></param>
        public void Export(SearchAdminUserParam request)
        {
             DownloadFile("filename",adminUserService.GetAdminUserDtos(request).Pager.ToExcelContent("filename"));
        }
    }
}
