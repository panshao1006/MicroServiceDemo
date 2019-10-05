using Core.Cache;
using Core.Cache.Redis;
using Core.Common;
using Core.ORM.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ORM.DBRouter
{
    /// <summary>
    /// 数据库路由
    /// </summary>
    public class DatabaseRouter
    {
        private static string _storageCacheKey = "StorageCache";

        /// <summary>
        /// 根据组织获取连接字符串
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public static string GetConnectionString(string organizationId)
        {
            string connectionString = ConfigurationManager.AppSetting("ConnectionString");

            IORM _orm = new SugarORM(connectionString);

            var client = _orm.GetSqlClient<SqlSugarClient>();

            string sql = GetQuerySql(organizationId);

            OrganizaitonStoreRelationDAO dbStore = client.SqlQueryable<OrganizaitonStoreRelationDAO>(sql).First();

            if(dbStore == null)
            {
                throw new Exception($"找不到组织{organizationId}对应的业务数据库");
            }

            return GetConnectionString(dbStore);            
        }


        /// <summary>
        /// 获取查询sql
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        private static string GetQuerySql(string organizationId)
        {
            string sql = string.Format(@"SELECT a.* , b.* FROM t_sys_orgstorage a
                                            INNER JOIN t_sys_storage b on a.MStorageID = b.MItemID and a.MIsDelete = b.MIsDelete
                                         WHERE a.MOrgID = '{0}' and a.MIsDelete = 0; " , organizationId);

            return sql;
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="dbStore"></param>
        /// <returns></returns>
        private static string GetConnectionString(OrganizaitonStoreRelationDAO dbStore)
        {
            return $"server={dbStore.MDBServerName};database={dbStore.MDBName};uid={dbStore.MUserName};pwd={dbStore.MPassword};" +
                $"Allow Zero Datetime=True;Port={dbStore.MDBServerPort};charset=utf8;pooling=true;Max Pool Size=100";
        }

        /// <summary>
        /// 设置组织的数据库
        /// </summary>
        /// <param name="organizationId"></param>
        public static void SetOrganizationStorageRelation(string organizationId)
        {
            var storageMaxOrganiztonCount = ConfigurationManager.AppSetting("StorageMaxOrganiztonCount");

            if (string.IsNullOrWhiteSpace(storageMaxOrganiztonCount))
            {
                throw new Exception("没有找到配置项StorageMaxOrganiztonCount");
            }

            int maxConfiguration = 0;

            if(!int.TryParse(storageMaxOrganiztonCount ,out maxConfiguration))
            {
                throw new Exception("配置项StorageMaxOrganiztonCount只能是整形数字");
            }

            var storages = GetStorages();

            if(storages==null || storages.Count == 0)
            {
                throw new Exception("没有找到任何的storeage");
            }

            var storage = storages.FirstOrDefault(x => x.MOrgCount < maxConfiguration);

            if(storage == null)
            {
                throw new Exception("没有找到合适的数据库，请确认数据库是否已满");
            }

            OrganizaitonStoreRelationDAO organizaitonStore = new OrganizaitonStoreRelationDAO()
            {
                MItemID = GuidUtility.GetGuid(),
                MOrgID = organizationId,
                MStorageID = storage.MItemID,
                MIsActive = true,
                MIsDelete = false
            };

            string connectionString = ConfigurationManager.AppSetting("ConnectionString");

            IORM _orm = new SugarORM(connectionString);

            var client = _orm.GetSqlClient<SqlSugarClient>();

            client.Insertable<OrganizaitonStoreRelationDAO>(organizaitonStore).ExecuteCommand();

        }


        /// <summary>
        /// 获取系统的所有storages
        /// </summary>
        /// <returns></returns>
        private static List<StorageDAO> GetStorages()
        {
            var cacheFilter = new CacheFilter(_storageCacheKey);
            var cacheClient = new RedisClientCache();

            List<StorageDAO> storages = cacheClient.Query<List<StorageDAO>>(cacheFilter);

            if(storages == null || storages.Count == 0)
            {
                string sql = "select * from t_sys_storage where misdelete=0 order by mitemid";

                string connectionString = ConfigurationManager.AppSetting("ConnectionString");

                IORM _orm = new SugarORM(connectionString);

                var client = _orm.GetSqlClient<SqlSugarClient>();

                storages = client.SqlQueryable<StorageDAO>(sql).ToList();

                CacheModel storageCache = new CacheModel()
                {
                    Key = _storageCacheKey,
                    Data = storages
                };

                if (cacheClient.IsExistCacheKey(cacheFilter))
                {
                    cacheClient.Delete(cacheFilter);
                }
                

                cacheClient.Add(storageCache);

            }
            return storages;
        }
    }
}
