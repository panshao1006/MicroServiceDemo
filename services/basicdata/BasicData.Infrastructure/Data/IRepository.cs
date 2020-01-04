using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Infrastructure.Data
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository<TPO> where TPO: BasePO
    {
        void Add(TPO entry);

        bool Remove<T>(string Id);

        bool Update<T>(T entry);

        T Get<T>();

        T Gets<T>();

        IQueryable<TPO> Query();

        int SaveChange();

        
    }
}
