using Jwell.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Domain.Entities
{
    [Table("Tasks")]
  public  class Tasks:BaseEntity
    {
        /// <summary>
        /// 任务编号，自动guid生成
        /// </summary>
        [StringLength(36)]
        public String TaskNumber { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 任务名称
        /// </summary>
        [StringLength(64)]
        public string TaskName { get; set; }
        /// <summary>
        /// 任务备注
        /// </summary>
        [StringLength(256)]
        public string Remark { get; set; }
        /// <summary>
        /// 任务Url
        /// </summary>
        [Url]
        [StringLength(512)]
        public string Url { get; set; }
        /// <summary>
        /// 任务小组Leader
        /// </summary>
        [StringLength(16)]
        public string TeamLeader { get; set; }
        /// <summary>
        /// 小组编号
        /// </summary>
        [StringLength(36)]
        public string TeamCode { get; set; }
        /// <summary>
        /// 执行周期
        /// </summary>
        [Cron]
        [StringLength(64)]
        public string Cron { get; set; }
        /// <summary>
        /// 任务执行状态HttpCode 最近一次执行日志
        /// </summary>
        [StringLength(8)]
        public String State { get; set; }
        /// <summary>
        /// 任务首次执行时间
        /// </summary>
        public Nullable<DateTime> FirstStartTime { get; set; }
        /// <summary>
        /// 任务最新执行时间
        /// </summary>
        public Nullable<DateTime> LastStartTime { get; set; }
        /// <summary>
        /// 任务是否可用 0不可用 1可用 默认为可用
        /// </summary>
        public int IsEnable { get; set; } = 1;
        /// <summary>
        /// 任务创建人
        /// </summary>
        [StringLength(16)]
        public String CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(16)]
        public String ModifieBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifieTime { get; set; }

    }
}
