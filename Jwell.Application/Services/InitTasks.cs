using Autofac;
using Jwell.Framework.Ioc;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public  class InitTasks
    {
        /// <summary>
        /// 程序启动时启动所有库中有效的任务
        /// </summary>
        /// <returns></returns>
        public static void statrAll()
        {
            ITasksService tasksRepository= IocContainer.Container.Resolve<ITasksService>();
            IScheduleHelper scheduleHelper= IocContainer.Container.Resolve<ScheduleHelper>();
            var tasks = tasksRepository.GetEnalbeList();
            foreach (var task in tasks)
            {
                scheduleHelper.AddJob(task.TaskNumber, task.TeamCode, task.TaskNumber, task.TeamCode, task.Cron, task);
            }

        }
    }
}
