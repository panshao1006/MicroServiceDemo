using Core.Common;
using Core.ORM;
using Core.ORM.Sugar;
using SqlSugar;
using System;

namespace BaseData.DAL
{
    public class BaseRepository
    {
        protected string _sysConnectionString;

        protected IORM _orm;

        protected SqlSugarClient _sugarClient;

        public BaseRepository()
        {
            SetConnectionString();

            _orm = new SugarORM(_sysConnectionString);

            _sugarClient = _orm.GetSqlClient<SqlSugarClient>();
        }

        

        protected virtual void SetConnectionString()
        {
            _sysConnectionString = ConfigurationManager.AppSetting("ConnectionString");
        }

        protected virtual T ORMClient<T>() where T : class
        {
            return _orm.GetSqlClient<T>();
        }
    }
}
