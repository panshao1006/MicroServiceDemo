using Core.Cache;
using Core.Cache.Redis;
using Core.ORM.Attribute;
using Core.ORM.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Core.ORM
{
    /// <summary>
    /// ORM 基类
    /// </summary>
    public class BaseORMUtility
    {
        protected ICache _cache = new RedisClientCache();

        public CommandInfo GetCommand<T>(T t) where T : class
        {
            Type type = t.GetType();

            var propertyInfos = t.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var className = type.FullName;

            if (propertyInfos.Length == 0)
            {
                throw new ArgumentException($"class {className} not any attribute");
            }

            string sql = GetSQL(className, propertyInfos);


            CommandInfo commandInfo = new CommandInfo();


            return commandInfo;
        }


        public string GetSQL(string className , PropertyInfo[] propertyInfos)
        {
            string result = null;

            //去缓存查找一次是否存在该类名称的缓存的SQL
            List<SqlInfo> sqlInfoList = _cache.Query<List<SqlInfo>>(new CacheFilter() { Key = className + "_ORM" });

            //如果缓存中没有
            if(sqlInfoList == null)
            {

            }


            return result;
        }

        public List<SqlInfo> InitSqlInfos(string className , PropertyInfo[] propertyInfos)
        {
            List<SqlInfo> result = new List<SqlInfo>();

            List<string> columns = new List<string>();

            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                string name = propertyInfo.Name;
            }

            return result;
        }


        private string GetPropertyInfoName(PropertyInfo propertyInfo)
        {
            var attributeDataList = propertyInfo.GetCustomAttributesData();

            //if (attributeDataList == null || attributeDataList)
            //{

            //}

            return "";
        }
    }
}
