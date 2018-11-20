using System.Linq;
using Jwell.Application.Services;
using Jwell.Application.Services.Dtos;
using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using Jwell.Framework.Paging;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Extensions;
using Jwell.Modules.Cache;

namespace Jwell.Application
{
    public class AdminUserService : ApplicationService, IAdminUserService
    {
        private IRepository<AdminUser,long> Repository { get; set; }
        private ICacheClient CacheClient { get; set; }


        public AdminUserService(IRepository<AdminUser,long> repository,ICacheClient cacheClient)
        {
            Repository = repository;
            CacheClient = cacheClient;
        }

        public int Count()
        {
            AdminUser adminUser = new AdminUser()
            {
                Account = "1234",
                Code = "12345"
            };

            AdminUser adminUser2 = adminUser.Clone<AdminUser>();
            adminUser2.Account = "adminUser2";

            bool success = CacheClient.SetCache("test", adminUser, 300);
            
            adminUser = CacheClient.GetCache<AdminUser>("test");

            adminUser2 = CacheClient.GetCache<AdminUser>("test2");
            return Repository.Queryable().Count();
        }

        public PageResult<AdminUserDto> GetAdminUserDtos(PageParam page)
        {
           return Repository.Queryable().ToPageResult(page).ToDtos();
        }
    }
}
