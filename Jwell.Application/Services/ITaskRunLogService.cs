using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public interface ITaskRunLogService: IApplicationService
    {
        string add(TaskRunLog taskRunLog);
    }
}
