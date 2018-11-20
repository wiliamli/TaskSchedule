using Jwell.Domain.Entities;
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
    public class TaskGroupRepository : RepositoryBase<TaskGroup, JwellDbContext, long>, ITaskGroupRepository
    {

        public TaskGroupRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }


        public override int Add(TaskGroup entity)
        {
            //do nothing
            return base.Add(entity);
        }

        public override IQueryable<TaskGroup> Queryable()
        {
            return DbContext.TaskGroup.AsQueryable();
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

        public override int Update(TaskGroup entity)
        {
            return base.Update(entity);
        }

        public override int Delete(TaskGroup entity)
        {
            return base.Delete(entity);
        }

        public TaskGroup getOne(int id)
        {
            return base.Queryable().FirstOrDefault(a => a.ID == id);
        }
    }
}
