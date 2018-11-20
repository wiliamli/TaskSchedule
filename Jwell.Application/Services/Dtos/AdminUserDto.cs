using System;
using System.Linq;
using Jwell.Domain.Entities;
using Jwell.Framework.Paging;
using Jwell.Framework.Excel;
using Newtonsoft.Json;

namespace Jwell.Application.Services.Dtos
{
    //[Statistics(Name = "合计", Formula = "SUM", Columns = new[] { 6, 7 })]
    [Filter(FirstCol = 0, FirstRow = 0, LastCol = 5)]
    //[Freeze(ColSplit = 2, RowSplit = 1, LeftMostColumn = 2, TopRow = 1)]
    public class AdminUserDto
    {
        [Column(Index = 0, Title = "ID", AllowMerge = false)]
        [JsonIgnore]
        public long ID { get; set; }

        [Column(Index = 1, Title = "账户", AllowMerge = false)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column(Index = 2, Title = "密码", AllowMerge = false)]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column(Index = 3, Title = "姓名", AllowMerge = false)]
        public string Name { get; set; }

        /// <summary>
        /// 员工编号
        /// </summary>
        [Column(Index = 4, Title = "员工编号", AllowMerge = false)]
        public string Code { get; set; }

        /// <summary>
        /// 员工头像
        /// </summary>
        [Column(IsIgnored = true)]
        public string Img { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [Column(Index = 5, Title = "QQ", AllowMerge = false)]
        public string QQ { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column(Index = 6, Title = "手机号", AllowMerge = false)]
        public string Phone { get; set; }

        /// <summary>
        /// 手机号验证码
        /// </summary>
        [Column(Index = 7, Title = "手机号验证码", AllowMerge = false)]
        public string PhoneCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Index = 8, Title = "手机号验证码", AllowMerge = false)]
        public DateTime CreateDate { get; set; }
    }

    /// <summary>
    /// Mapper
    /// </summary>
    public static class AdminUserDtoExt
    {
        public static IQueryable<AdminUserDto> ToDtos(this IQueryable<AdminUser> query)
        {
            return from a in query
                   select new AdminUserDto()
                   {
                       ID = a.ID,
                       Account = a.Account,
                       Name = a.Name,
                       Code = a.Code,
                       Img = a.Img,
                       QQ = a.QQ,
                       Phone = a.Phone,
                       PhoneCode = a.PhoneCode,
                       CreateDate = a.CreateDate
                   };
        }

        public static PageResult<AdminUserDto> ToDtos(this PageResult<AdminUser> query)
        {
            var queryDto = (from a in query.Pager
                            select new AdminUserDto()
                            {
                                ID = a.ID,
                                Account = a.Account,
                                Name = a.Name,
                                Code = a.Code,
                                Img = a.Img,
                                QQ = a.QQ,
                                Phone = a.Phone,
                                PhoneCode = a.PhoneCode,
                                CreateDate = a.CreateDate
                            }).ToList();

            return new PageResult<AdminUserDto>(queryDto, query.PageIndex, query.PageSize, query.TotalCount);
        }

        public static AdminUserDto ToDto(this AdminUser entity)
        {
            AdminUserDto dto = null;
            if (entity != null)
            {
                dto = new AdminUserDto()
                {
                    Account = entity.Account,
                    Code = entity.Code,
                    CreateDate = entity.CreateDate,
                    ID = entity.ID,
                    Img = entity.Img,
                    Name = entity.Name,
                    Password = entity.Password,
                    Phone = entity.Phone,
                    PhoneCode = entity.PhoneCode,
                    QQ = entity.QQ
                };
            }
            return dto;
        }

        public static AdminUser ToEntity(this AdminUserDto dto)
        {
            AdminUser entity = null;
            if (dto != null)
            {
                entity = new AdminUser()
                {
                    Account = dto.Account,
                    Code = dto.Code,
                    CreateDate = dto.CreateDate,
                    ID = dto.ID,
                    Img = dto.Img,
                    Name = dto.Name,
                    Password = dto.Password,
                    Phone = dto.Phone,
                    PhoneCode = dto.PhoneCode,
                    QQ = dto.QQ
                };
            }
            return entity;
        }
    }
}