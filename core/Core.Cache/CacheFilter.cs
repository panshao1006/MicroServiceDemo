using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cache
{
    public class CacheFilter
    {
        public string Key { set; get; }

        public CacheFilter()
        {

        }

        public CacheFilter(string key)
        {
            this.Key = key;
        }

        
    }
}
