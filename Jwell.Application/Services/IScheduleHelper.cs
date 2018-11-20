using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public interface IScheduleHelper: IRepository
    {
        void AddJob(String jobName,String jobGroup,String triggerName,String triggerGroup,String cron, Tasks task);
        void ModifyJob(String jobName, String jobGroup, String triggerName, String triggerGroup, String cron, Tasks task);
        void RemoveJob(String jobName, String jobGroup, String triggerName, String triggerGroup);
        void ShutDown();
        void Start();
        void Restart();


    } 
}
