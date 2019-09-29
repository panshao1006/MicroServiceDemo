using Core.Common;
using Core.ORM.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.DBRouter
{
    /// <summary>
    /// 数据库路由
    /// </summary>
    public class DBRouteUtility
    {
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

            DBStoreDAO dbStore = client.SqlQueryable<DBStoreDAO>(sql).First();

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
        private static string GetConnectionString(DBStoreDAO dbStore)
        {
            return $"server={dbStore.MDBServerName};database={dbStore.MDBName};uid={dbStore.MUserName};pwd={dbStore.MPassword};" +
                $"Allow Zero Datetime=True;Port={dbStore.MDBServerPort};charset=utf8;pooling=true;Max Pool Size=100";
        }
    }
}
