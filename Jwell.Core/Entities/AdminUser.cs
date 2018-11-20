using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Jwell.Domain.Entities.Base;

namespace Jwell.Domain.Entities
{
   [Table("AdminUser")]
    public class AdminUser : BaseEntity
    {
        /// <summary>
        /// 帐号.
        /// </summary>
        [StringLength(64)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(128)]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [StringLength(16)]
        public string Code { get; set; }

        /// <summary>
        /// 员工头像
        /// </summary>
        [StringLength(256)]
        public string Img { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [StringLength(15)]
        public string QQ { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [StringLength(11)]
        public string Phone { get; set; }

        /// <summary>
        /// 手机号验证码
        /// </summary>
        [StringLength(8)]
        public string PhoneCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
