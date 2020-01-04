using BasicData.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Infrastructure.Data
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    public class BaseRepository<T> : IRepository<T> where T : BasePO
    {
        protected DbContext DbContext { get; }

        protected DbSet<T> DbSet { get; }
        //EFCore上下文

        public BaseRepository(MysqlDbContext mysqlDbContext)
        {
            DbContext = mysqlDbContext;
            DbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T1 Get<T1>()
        {
            throw new NotImplementedException();
        }

        public T1 Gets<T1>()
        {
            throw new NotImplementedException();
        }

        public bool Remove<T1>(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Update<T1>(T1 entry)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public int SaveChange()
        {
           return DbContext.SaveChanges();
        }
    }
}
