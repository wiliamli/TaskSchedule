using Jwell.Framework.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Application.Services.Params
{
  public  class TaskGroupParams: PageParam
    {
        /// <summary>
        /// 日志执行时间
        /// </summary>
        public String BeginDate { get; set; }

        public String EndDate { get; set; }
    }
}
