using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Jwell.Application.Services;
using Jwell.Application.Services.Params;
using Jwell.Domain.Entities;
using Jwell.Framework.Mvc;
using Jwell.Framework.Paging;

namespace Jwell.Schedule.Controllers
{
    /// <summary>
    /// 任务运行日志相关接口
    /// </summary>
    public class TaskGroupController : BaseApiController
    {
        private ITaskGroupService taskGroupService;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="itaskGroupService"></param>
        public TaskGroupController(ITaskGroupService itaskGroupService) {
            taskGroupService = itaskGroupService;
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public StandardJsonResult<PageResult<TaskGroup>> GetList([FromUri]TaskGroupParams param) {
            return base.StandardAction<PageResult<TaskGroup>>(() =>
            {
               return taskGroupService.GetList(param);
            });
        }
        /// <summary>
        /// 新增分组
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public StandardJsonResult Add([FromBody] TaskGroup taskGroup) {
            return base.StandardAction(() =>
            {
                return taskGroupService.Add(taskGroup);
            });
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpPut]
        public StandardJsonResult Update([FromBody] TaskGroup taskGroup) {
            return base.StandardAction(() =>
            {
                return taskGroupService.Update(taskGroup);
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpDelete]
        public StandardJsonResult Delete([FromBody] TaskGroup taskGroup) {
            return base.StandardAction(() =>
            {
                return taskGroupService.Delete(taskGroup);
            });
        }

    }
}
