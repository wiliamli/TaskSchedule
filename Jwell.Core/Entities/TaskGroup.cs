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
    [Table("TaskGroup")]
   public class TaskGroup:BaseEntity
    {
        /// <summary>
        /// 小组负责人
        /// </summary>
        [StringLength(16)]
        public String TeamLeader { get; set; }
        /// <summary>
        /// 小组编号
        /// </summary>
        [StringLength(36)]
        public String TeamCode { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(16)]
        public String CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
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
