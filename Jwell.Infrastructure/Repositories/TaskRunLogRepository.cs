using Jwell.Domain.Entities;
using Jwell.Framework.Application.Service;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    class TaskRunLogRepository : RepositoryBase<TaskRunLog, JwellDbContext, long>, ITaskRunLogRepository
    {
        public TaskRunLogRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }
        public override int Add(TaskRunLog entity)
        {
            //do nothing
            return base.Add(entity);
        }

        public override IQueryable<TaskRunLog> Queryable()
        {
            return DbContext.TaskRunLog.AsQueryable();
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

        public override async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
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

        public override int Update(TaskRunLog entity)
        {
            return base.Update(entity);
        }

        public override int Delete(TaskRunLog entity)
        {
            return base.Delete(entity);
        }

    }
}
