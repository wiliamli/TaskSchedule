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
    public interface ITasksService : IApplicationService
    {
        PageResult<Tasks> GetList(TasksParams taskParams);
        List<Tasks> GetEnalbeList();
        string Add(Tasks tasks);
        String Update(Tasks tasks);
        string Delete(Tasks tasks);
        string StopOrRenew(Tasks tasks);
        TaskRunLog GetException(String taskNumber);
        void InitTasks();
        string Handle(Tasks tasks);
     }
}
