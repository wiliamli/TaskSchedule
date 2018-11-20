using Jwell.Framework.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Params
{
  public  class TasksParams: PageParam
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; } = "";

        public string TeamCode { get; set; } = "";

        public int isEnalbed { get; set; } = -1;
        


    }
}
