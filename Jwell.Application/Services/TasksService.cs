using Jwell.Application.Services.Params;
using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Paging;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
    public class TasksService : ApplicationService, ITasksService
    {
        private  ITasksRepository tasksRepository;

        private  IScheduleHelper scheduleHelper;

        private ITaskRunLogRepository taskRunLogRepository;


        public TasksService(ITasksRepository repository, ITaskRunLogRepository runLogRepository, IScheduleHelper schedule) {
            tasksRepository = repository;
            scheduleHelper = schedule;
            taskRunLogRepository = runLogRepository;
        }

        public PageResult<Tasks> GetList(TasksParams taskParams)
        {

            var tasks = tasksRepository.Queryable().Where(a => a.TaskName.Contains(taskParams.TaskName) 
                                                            && (a.TeamCode==taskParams.TeamCode || (taskParams.TeamCode=="" || 1==1) )
                                                            &&(a.IsEnable==taskParams.isEnalbed || taskParams.isEnalbed==-1)
            ).ToPageResult<Tasks>(taskParams);
            foreach (var item in tasks.Pager)
            {
                TaskRunLog lastRunLog = taskRunLogRepository.Queryable().OrderByDescending(a => a.CreateTime).FirstOrDefault(a => a.TaskNumber == item.TaskNumber);
                TaskRunLog firstRunLog = taskRunLogRepository.Queryable().OrderBy(a => a.CreateTime).FirstOrDefault(a => a.TaskNumber == item.TaskNumber);
                item.State = lastRunLog == null ? "" : lastRunLog.State;
                item.LastStartTime = lastRunLog == null ? null : lastRunLog.HandleTime;
                item.FirstStartTime = firstRunLog == null ? null : firstRunLog.HandleTime;
            }
            return tasks;

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public string Add(Tasks tasks) {
            try
            {
               
                tasks.TaskNumber = Guid.NewGuid().ToString();
               
                if (tasksRepository.Add(tasks) > 0) {
                    if (tasks.IsEnable == 1)
                    {
                        scheduleHelper.AddJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode, tasks.Cron, tasks);
                    }
                    return "sucess";
                }
                else {
                    scheduleHelper.RemoveJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode);
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                scheduleHelper.RemoveJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode);
                return ex.Message;
            }
        }
        /// <summary>
        /// 编辑,如何保证数据统一
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public string Update(Tasks tasks)
        {
            try
            {
                tasks.ModifieTime = DateTime.Now;
                if (tasksRepository.Update(tasks) > 0)
                {
                    try
                    {
                        scheduleHelper.RemoveJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode);
                        if (tasks.IsEnable == 1) {
                            scheduleHelper.AddJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode, tasks.Cron, tasks);
                        }
                        return "sucess";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else {
                    return "fail";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public string Delete(Tasks tasks)
        {
            try
            {
                if (tasksRepository.Delete(tasks) > 0)
                {
                    try
                    {
                        scheduleHelper.RemoveJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode);
                        return "sucess";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                return "fail";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        /// <summary>
        /// 任务暂停或者恢复
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public string StopOrRenew(Tasks tasks) {
            try
            {
                int isEnalbe = tasks.IsEnable == 0 ? 1 : 0;
                tasks.IsEnable = isEnalbe;
                if (tasksRepository.Update(tasks) > 0) {
                    try
                    {
                        //停止
                        if (isEnalbe == 0)
                        {
                            scheduleHelper.RemoveJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode);
                        }
                        else {
                            scheduleHelper.AddJob(tasks.TaskNumber, tasks.TeamCode, tasks.TaskNumber, tasks.TeamCode, tasks.Cron, tasks);
                        }
                        return "success";
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }
                }
                return "fail";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        /// <summary>
        /// 获取任务执行日志异常详细信息
        /// </summary>
        /// <param name="taskNumber">任务编号</param>
        /// <returns></returns>
        public TaskRunLog GetException(String taskNumber)
        {
            try
            {
                TaskRunLog lastRunLog = taskRunLogRepository.Queryable().OrderByDescending(a => a.CreateTime).FirstOrDefault(a => a.TaskNumber == taskNumber);
                return lastRunLog;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
       
        /// <summary>
        /// 手动触发任务
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public string Handle(Tasks tasks)
        {
            try
            {
                TaskRunLog taskRunLog = TaskRunLog.mapFromTask(tasks) == null ? new TaskRunLog() : TaskRunLog.mapFromTask(tasks);
                taskRunLog.HandleTime = DateTime.Now;
                taskRunLog.CreateBy = string.IsNullOrEmpty( tasks.CreateBy)? "手动触发":tasks.CreateBy;
                taskRunLog.CreateTime = DateTime.Now;
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage responseMessage = client.GetAsync(tasks.Url).Result;
                    taskRunLog.TimeStamp = DateTime.Now;
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        taskRunLog.State = "HTTP200";
                    }
                    else
                    {
                        taskRunLog.State = "HTTP" + responseMessage.StatusCode.ToString();
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
                    taskRunLogRepository.Add(taskRunLog);
                    return "success";
                }
                catch (Exception ex)
                {
                    return "fail";

                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        /// <summary>
        /// 初始化数据库中所有任务
        /// </summary>
        public void InitTasks()
        {
            var tasks = tasksRepository.Queryable().Where(a => a.IsEnable == 1);
            foreach (var task in tasks)
            {
                scheduleHelper.AddJob(task.TaskNumber, task.TeamCode, task.TaskNumber, task.TeamCode, task.Cron, task);
            }
        }

        /// <summary>
        /// 获取所有有效任务
        /// </summary>
        /// <returns></returns>
        public List<Tasks> GetEnalbeList()
        {
           return tasksRepository.Queryable().Where(a => a.IsEnable == 1).ToList();
        }
    }
}
