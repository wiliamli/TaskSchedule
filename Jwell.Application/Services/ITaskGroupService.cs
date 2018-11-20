using Jwell.Application.Services.Params;
using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public interface ITaskGroupService: IApplicationService
    {
        PageResult<TaskGroup> GetList(TaskGroupParams page);

        //新增
        String Add(TaskGroup entity);
        String Update(TaskGroup entity);
        String Delete(TaskGroup entity);

    }
}
