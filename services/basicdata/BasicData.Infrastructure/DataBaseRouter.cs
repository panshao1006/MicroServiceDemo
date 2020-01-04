using BasicData.Infrastructure.Model;
using Core.CustomException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Infrastructure
{
    /// <summary>
    /// 数据库路由，更加请求的组织Id获取数据的联接字符串
    /// </summary>
    public class DataBaseRouter
    {
        private static object _lock = new object();

        private static Hashtable _databaseContannier = new Hashtable();

        public static string GetConnectionString(string organizationId)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(organizationId))
            {
                throw new DatabaseRouterException("在查找数据库路由时组织Id为空");
            }

            lock (_lock)
            {
                //如果有，直接取
                if (_databaseContannier.ContainsKey(organizationId))
                {
                    result = _databaseContannier[organizationId].ToString();
                }
                else
                {
                    //从数据库取
                    result = GetContectionFromDB(organizationId);

                    _databaseContannier.Add(organizationId, result);
                }
            }

            return result;
        }

        private static string GetContectionFromDB(string organizationId)
        {
            var dbContext = new MysqlSysDBContext();

            var databaseStorage = dbContext.DatabaseStorages.Include(x => x.StorageRelations).AsNoTracking().Single(x => x.StorageRelations.Select(y => y.MOrgID).Contains(organizationId) && x.MIsDelete == false);

            if (databaseStorage == null)
            {
                throw new DatabaseRouterException($"未能找到组织Id：{organizationId}对应的数据库连接");
            }


            return $"server={databaseStorage.MDBServerName};user={databaseStorage.MUserName};database={databaseStorage.MBDName};port={databaseStorage.MDBServerPort};password={databaseStorage.MPassword};SslMode=None";
        }
    }
}
