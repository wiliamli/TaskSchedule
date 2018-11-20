using Jwell.Domain;
using Jwell.Domain.Entities;
using Jwell.Repository.Context;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public class AdminUserRepository : RepositoryBase<AdminUser, JwellDbContext, long>, IAdminUserRepository
    {
        public AdminUserRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }

        public override int Add(AdminUser entity)
        {
            //do nothing

            return 1;
        }

        public override IQueryable<AdminUser> Queryable()
        {
            return null;
            //return DbContext.AdminUser.AsQueryable();
        }

        public override int ExecuteSqlCommand(string sql)
        {
            return base.ExecuteSqlCommand(sql);
        }


        public override async Task<int> ExecuteSqlCommandAsync(string sql)
        {
            return await base.ExecuteSqlCommandAsync(sql);
        }

        public override int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return base.ExecuteSqlCommand(sql, parameters);
        }

        public override async Task<int> ExecuteSqlCommandAsync(string sql,  params object[] parameters)
        {
            return await base.ExecuteSqlCommandAsync(sql, parameters);
        }

        public override IEnumerable<TElement> SqlQuery<TElement>(string sql)
        { 
            return base.SqlQuery<TElement>(sql);
        }

        public override IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return base.SqlQuery<TElement>(sql, parameters);
        }

        public override int Update(AdminUser entity)
        {
            return base.Update(entity);
        }

        public override int Delete(AdminUser entity)
        {
            return base.Delete(entity);
        }
    }
}
