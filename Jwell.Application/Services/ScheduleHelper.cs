using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Domain.Entities;
using Quartz;
using Quartz.Impl;

namespace Jwell.Application.Services
{
    /// <summary>
    /// 任务调度帮助类
    /// </summary>
    public class ScheduleHelper : IScheduleHelper
    {
        /// <summary>
        /// 新增工作任务
        /// </summary>
        /// <param name="jobName">工作任务名称TaskCode</param>
        /// <param name="jobGroup">工作任务分组TeamCode</param>
        /// <param name="triggerName">触发器名称TaskCode</param>
        /// <param name="triggerGroup">触发器分组TeamCode</param>
        /// <param name="cron">任务执行周期cron</param>
        public  void AddJob(string jobName, string jobGroup, string triggerName, string triggerGroup, string cron, Tasks tasks)
        {
            try
            {
                //定义调度器
                IScheduler scheduler =  StdSchedulerFactory.GetDefaultScheduler().Result;
                JobDataMap jobData = new JobDataMap();
                jobData.Add("tasks", tasks);
                IJobDetail job = JobBuilder.Create<JobImpl>().WithIdentity(jobName, jobGroup).SetJobData(jobData).Build();
                ITrigger trigger = TriggerBuilder.Create().WithIdentity(triggerName, triggerGroup).StartNow().WithCronSchedule(cron).Build();
                 scheduler.ScheduleJob(job, trigger);
                
                if (!scheduler.IsStarted)
                {
                    scheduler.Start();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 修改任务执行时间
        /// </summary>
        /// <param name="jobName">任务名称TaskCode</param>
        /// <param name="jobGroup">任务分组TeamCode</param>
        /// <param name="triggerName">触发器名称</param>
        /// <param name="triggerGroup">触发器分组</param>
        /// <param name="cron">新的执行周期</param>
        public async void ModifyJob(string jobName, string jobGroup, string triggerName, string triggerGroup, string cron, Tasks tasks)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            //获取工作
            JobKey jobKey = new JobKey(jobName, jobGroup);
            IJobDetail job =await scheduler.GetJobDetail(jobKey);
            job.JobDataMap.Put("tasks", tasks);
            
            //获取触发器
            TriggerKey triggerKey = new TriggerKey(triggerName, triggerGroup);
            ICronTrigger trigger = (ICronTrigger)await scheduler.GetTrigger(triggerKey);
            if (trigger == null) {
                return;
            }
            String oldCron = trigger.CronExpressionString;
            if (cron != oldCron) {

                //设置新的触发器
                ITrigger newTrigger = TriggerBuilder.Create().WithIdentity(triggerName, triggerGroup).StartNow().WithCronSchedule(cron).Build();
                //更新触发器执行时间
                await scheduler.RescheduleJob(triggerKey, newTrigger);
            }
        }

        public async void RemoveJob(string jobName, string jobGroup, string triggerName, string triggerGroup)
        {
            try
            {
                IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                //获取工作
                JobKey jobKey = new JobKey(jobName, jobGroup);
                //获取触发器
                TriggerKey triggerKey = new TriggerKey(triggerName, triggerGroup);
                //暂停触发器
                await scheduler.PauseTrigger(triggerKey);
                //移除触发器
                await scheduler.UnscheduleJob(triggerKey);
                //暂停工作
                await scheduler.PauseJob(jobKey);
                //移除工作
                await scheduler.DeleteJob(jobKey);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 停止调度器
        /// </summary>
        public async void ShutDown()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            if (scheduler.IsStarted)
                await scheduler.Shutdown();

        }
        /// <summary>
        /// 启动调度器
        /// </summary>
        public async void Start() {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            if (scheduler.IsShutdown)
                await scheduler.Start();
        }
        /// <summary>
        /// 重启调度器
        /// </summary>
        public async void Restart()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
          
            await scheduler.ResumeAll();
        }
    }
}
