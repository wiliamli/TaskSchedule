using Jwell.Application.Services.Params;
using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using Jwell.Framework.Domain.Repositories;
using Jwell.Framework.Paging;
using Jwell.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services
{
   public class TaskGroupService : ApplicationService,ITaskGroupService
    {
        private ITaskGroupRepository Repository { get; set; }

        //构造注入
        public TaskGroupService(ITaskGroupRepository repository) {
            Repository = repository;
        }

        public PageResult<TaskGroup> GetList(TaskGroupParams page)
        {
            DateTime bgDate = String.IsNullOrEmpty(page.BeginDate) ? DateTime.MinValue : Convert.ToDateTime(page.BeginDate);
            DateTime endDate= String.IsNullOrEmpty(page.EndDate) ? DateTime.MaxValue : Convert.ToDateTime(page.EndDate);

            return Repository.Queryable().Where(a=>a.CreateTime>= bgDate && a.CreateTime<= endDate).ToPageResult(page);
        }

        public String Add(TaskGroup entity)
        {
            try
            {
            return Repository.Add(entity)>0?"新增成功":"新增失败";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public String Update(TaskGroup entity)
        {
            try
            {
                return Repository.Update(entity) > 0 ? "修改成功" : "修改失败";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public String Delete(TaskGroup entity)
        {
            try
            {

            return Repository.Delete(entity) > 0 ? "删除成功" : "删除失败";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
