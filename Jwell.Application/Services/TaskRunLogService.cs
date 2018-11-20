using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public class TaskRunLogService :ApplicationService, ITaskRunLogService
    {
        private ITaskRunLogRepository taskRunLogRepository;
        public TaskRunLogService(ITaskRunLogRepository _taskRunLogRepository) {
            taskRunLogRepository = _taskRunLogRepository;
        }

        public string add(TaskRunLog taskRunLog)
        {
            try
            {
                taskRunLogRepository.Add(taskRunLog);
                return "sucess";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
