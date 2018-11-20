using Jwell.Application.Services.Dtos;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Domain.Uow;
using Jwell.Framework.Paging;

namespace Jwell.Application.Services
{
    public interface IAdminUserService: IApplicationService
    {
        int Count();

        PageResult<AdminUserDto> GetAdminUserDtos(PageParam page);
    }
}
