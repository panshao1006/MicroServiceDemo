using Core.Common;
using Core.Context;
using Core.ORM;
using Core.ORM.Dapper;
using Core.ORM.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.DAL
{
    public class BaseRepository
    {
        protected string _connectionString;

        protected IORM _orm;

        protected SqlSugarClient _sugarClient;

        public BaseRepository()
        {
            SetConnectionString();

            _orm = new SugarORM(_connectionString);

            _sugarClient = _orm.GetSqlClient<SqlSugarClient>();
        }
        protected virtual void SetConnectionString()
        {
            _connectionString = ConfigurationManager.AppSetting("ConnectionString");
        }

        protected virtual T ORMClient<T>() where T : class
        {
            return _orm.GetSqlClient<T>();
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        protected string GetCurrentUserId()
        {
            return TokenContext.CurrentContext.GetUserId();
        }

    }
}
