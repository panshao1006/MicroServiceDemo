using System;
using System.Collections.Generic;
using System.Text;
using Cache.Model;

namespace Cache.BLL
{
    public class CacheBusinessBase : ICacheBusiness
    {
        public virtual CacheResultModel Delete(string key)
        {
            throw new NotImplementedException();
        }

        public virtual T GetValue<T>(string key)
        {
            throw new NotImplementedException();
        }

        public virtual CacheResultModel SetValue(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
