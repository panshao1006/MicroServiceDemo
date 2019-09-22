using Core.Cache;
using Core.Cache.Redis;
using Core.ORM.Attribute;
using Core.ORM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        /// <summary>
        /// 获取新增的Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public CommandInfo GetInsertSqlCommandInfo<T>(T t) where T:class
        {
            return GetCommand<T>(t, 1);
        }

        /// <summary>
        /// 获取删除的Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public CommandInfo GetDeleteSqlCommandInfo<T>(T t) where T : class
        {
            return GetCommand<T>(t, 2);
        }

        /// <summary>
        /// 获取update的Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public CommandInfo GetUpdateSqlCommandInfo<T>(T t) where T : class
        {
            return GetCommand<T>(t, 3);
        }


        /// <summary>
        /// 获取update的Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public CommandInfo GetQuerySqlCommandInfo<T>(T t) where T : class
        {
            return GetCommand<T>(t, 4);
        }

        /// <summary>
        /// 获取command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="sqlType"></param>
        /// <returns></returns>
        public CommandInfo GetCommand<T>(T t, int sqlType) where T : class
        {
            Type type = t.GetType();

            var tableName = GetTableName(type);

            var propertyInfos = t.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var className = type.FullName;

            if (propertyInfos.Length == 0)
            {
                throw new ArgumentException($"class {className} not any attribute");
            }

            List<MySqlParameter> parameters;

            string sql = GetSQL<T>(t, tableName, className, propertyInfos, sqlType, out parameters);


            CommandInfo commandInfo = new CommandInfo(sql , parameters);


            return commandInfo;
        }


        private string GetTableName(Type t)
        {
            var attribute = t.GetCustomAttribute(typeof(TableNameAttribute)) as TableNameAttribute;

            var tableName = attribute==null ? null : attribute.GetTableName();

            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new Exception($"Class:{t.Name},must have TableNameAttribute");
            }

            return tableName;
        }

        /// <summary>
        /// 获取sql
        /// </summary>
        /// <param name="className"></param>
        /// <param name="propertyInfos"></param>
        /// <param name="sqlType">SQL 类型 1 insert 2 delete 3 update 4 select</param>
        /// <returns></returns>
        public string GetSQL<T>(T t , string tableName , string className , PropertyInfo[] propertyInfos ,
            int sqlType , out List<MySqlParameter> parameters) where T :class
        {
            string result = null;

            parameters = new List<MySqlParameter>();

            //去缓存查找一次是否存在该类名称的缓存的SQL
            List<SqlInfo> sqlInfoList = _cache.Query<List<SqlInfo>>(new CacheFilter() { Key = className + "_ORM" });

            //如果缓存中没有
            if (sqlInfoList == null || sqlInfoList.Count == 0)
            {
                sqlInfoList = InitSqlInfos<T>(t, tableName, className, propertyInfos);

                _cache.Add(new CacheModel() { Key = className + "_ORM", Data = sqlInfoList });
            }

            SqlInfo sqlInfo = sqlInfoList.FirstOrDefault(x => x.Type == sqlType);

            if (sqlInfo != null)
            {
                result = sqlInfo.SqlString;

                parameters = sqlInfo.Parameters;
            }


            return result;
        }


        /// <summary>
        /// 初始化SQL语句
        /// </summary>
        /// <param name="className"></param>
        /// <param name="propertyInfos"></param>
        /// <returns></returns>
        public List<SqlInfo> InitSqlInfos<T>(T t , string tableName , string className , PropertyInfo[] propertyInfos) where T:class
        {
            List<SqlInfo> result = new List<SqlInfo>();

            List<string> columns = new List<string>();

            Dictionary<string, object> paramtersDic = new Dictionary<string, object>();

            foreach(PropertyInfo propertyInfo in propertyInfos)
            {
                string name = GetPropertyInfoName(propertyInfo);
                if (name == null)
                {
                    continue;
                }

                object value = GetPropertyInfoValue<T>(t ,propertyInfo);

                columns.Add(name);

                paramtersDic.Add("@" + name, value);
            }

            string columnContactString = string.Join(",", columns);

            string columnParamterNameString = string.Join(",", paramtersDic.Keys.ToList());

            

            SqlInfo selectSqlInfo = new SqlInfo() { Type = 4 };
            selectSqlInfo.SqlString = string.Format("select {0} from {1}" , columnContactString, tableName);

            result.Add(selectSqlInfo);

            SqlInfo insertSqlInfo = new SqlInfo();
            insertSqlInfo.SqlString = string.Format("insert into {0}({1}) values({2})", tableName, columnContactString, columnParamterNameString);
            insertSqlInfo.Parameters = GetMySqlParameters(paramtersDic);
            insertSqlInfo.Type = 1;
            result.Add(insertSqlInfo);

            SqlInfo updateSqlInfo = new SqlInfo();
            result.Add(updateSqlInfo);

            return result;
        }

        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private string GetPropertyInfoName(PropertyInfo propertyInfo)
        {
            string result = propertyInfo.Name;

            var attribute = propertyInfo.GetCustomAttribute(typeof(ColumnNameAttribute)) as ColumnNameAttribute;
            
            if (attribute == null || !attribute.IsMapFiled())
            {
                return result;
            }

            result = attribute.GetFieldName();

            return result;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private object GetPropertyInfoValue<T>(T t , PropertyInfo propertyInfo)
        {
            var attribute = propertyInfo.GetCustomAttribute(typeof(ColumnNameAttribute)) as ColumnNameAttribute;

            if (attribute == null || !attribute.IsMapFiled())
            {
                return null;
            }

            return propertyInfo.GetValue(t);
        }

        /// <summary>
        /// 获取参数对象列表
        /// </summary>
        /// <param name="paramtersDic"></param>
        /// <returns></returns>
        private List<MySqlParameter> GetMySqlParameters(Dictionary<string, object> paramtersDic)
        {
            var result = new List<MySqlParameter>();

            foreach (string parameter in paramtersDic.Keys)
            {
                MySqlParameter tempParameter = new MySqlParameter(parameter , paramtersDic[parameter]);

                result.Add(tempParameter);
            }

            return result;
        }
    }
}
