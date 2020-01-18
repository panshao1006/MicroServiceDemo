using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BasePO
    {
        protected DbContext _dbContext;

        protected DbSet<T> DbSet { get; }

        public Repository(MysqlDbContext mysqlDbContext)
        {
            _dbContext = mysqlDbContext;
            DbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void AddEntity(T entity)
        {
            DbSet.Add(entity);
        }

        public void UpdateEntity(T entity)
        {
            DbSet.Update(entity);
        }


        /// <summary>
        /// 处理并发问题
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
