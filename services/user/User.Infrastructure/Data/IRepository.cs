using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User.Infrastructure.Data
{
    public interface IRepository<T> where T: BasePO
    {
        void AddEntity(T entity);

        void UpdateEntity(T entity);

        int SaveChanges();

        IQueryable<T> Query();
    }
}
