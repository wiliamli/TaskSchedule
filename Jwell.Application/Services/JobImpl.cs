using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jwell.Domain.Entities;
using Jwell.Framework.Ioc;
using Jwell.Repository.Context;
using Quartz;
using Autofac;
using Jwell.Repository.Repositories;

namespace Jwell.Application.Services
{
    /// <summary>
    /// 具体的任务实现类
    /// </summary>

    public class JobImpl : IJob
    {
        /// <summary>
        /// 具体任务实现
        /// 使用httpclient跑传入的Url,且记录运行日志
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {

                Tasks tasks = (Tasks)context.JobDetail.JobDataMap.Get("tasks");
                if (tasks != null)
                {
                    doJob(tasks);
                }

            });
        }

        public bool doJob(Tasks tasks)
        {
            ITaskRunLogService TaskRunLogService = IocContainer.Container.Resolve<ITaskRunLogService>();
            TaskRunLog taskRunLog = TaskRunLog.mapFromTask(tasks) == null ? new TaskRunLog() : TaskRunLog.mapFromTask(tasks);
            taskRunLog.HandleTime = DateTime.Now;
            taskRunLog.CreateBy = "任务服务";
            taskRunLog.CreateTime = DateTime.Now;
            try
            {
                HttpClient client = new HttpClient();
                //是否存在非get请求？
                //HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Delete,tasks.Url);
                //client.SendAsync(httpRequest);
                HttpResponseMessage responseMessage = client.GetAsync(tasks.Url).Result;
                taskRunLog.TimeStamp = DateTime.Now;
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    taskRunLog.State = "HTTP200";
                }
                else
                {
                    taskRunLog.State = "HTTP" + responseMessage.StatusCode.GetHashCode().ToString();
                    taskRunLog.Exception = responseMessage.ToString();
                }
            }
            catch (Exception ex)
            {
                taskRunLog.TimeStamp = DateTime.Now;
                taskRunLog.State = "HTTP500";
                taskRunLog.Exception = ex.ToString();
            }
            try
            {
                TaskRunLogService.add(taskRunLog);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }


    }
}
