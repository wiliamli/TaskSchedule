using Jwell.Application.Services;
using Jwell.Application.Services.Params;
using Jwell.Domain.Entities;
using Jwell.Framework.Mvc;
using Jwell.Framework.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Jwell.Schedule.Controllers
{
    /// <summary>
    /// 定时任务相关接口
    /// </summary>
    public class TasksController : BaseApiController
    {
        private ITasksService tasksService;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="itaskService"></param>
        public TasksController(ITasksService itaskService)
        {
            tasksService = itaskService;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public StandardJsonResult<PageResult<Tasks>> GetList([FromUri]TasksParams param)
        {
            return base.StandardAction<PageResult<Tasks>>(() =>
            {
                return tasksService.GetList(param);
            });
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult Add([FromBody] Tasks Tasks)
        {
            return base.StandardAction(() =>
            {
                return tasksService.Add(Tasks);
            });
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpPut]
        public StandardJsonResult Update([FromBody] Tasks Tasks)
        {
           
            return base.StandardAction(() =>
            {
                return tasksService.Update(Tasks);
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpDelete]
        public StandardJsonResult Delete([FromBody] Tasks Tasks)
        {
            return base.StandardAction(() =>
            {
                return tasksService.Delete(Tasks);
            });
        }
        /// <summary>
        /// 暂停/恢复
        /// </summary>
        /// <param name="Tasks"></param>
        /// <returns></returns>
        [HttpPut]
        public StandardJsonResult StopOrRenew([FromBody] Tasks Tasks)
        {
            return base.StandardAction(() =>
            {
                return tasksService.StopOrRenew(Tasks);
            });
        }
        /// <summary>
        /// 获取任务运行详细异常信息
        /// </summary>
        /// <param name="taskNumber">任务编号</param>
        /// <returns></returns>
        [HttpGet]
        public StandardJsonResult GetException(string taskNumber) {
            return base.StandardAction(() =>
            {
                return tasksService.GetException(taskNumber);
            });
        }
      


        /// <summary>
        /// 手动执行某个任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult Handle([FromBody] Tasks Tasks) {

            return base.StandardAction(() =>
            {
                return tasksService.Handle(Tasks);
            });
        }

    }
}
