using Core.ORM;
using Core.ORM.Dapper;
using Core.ORM.Sugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.DAL
{
    public class BaseRepository
    {
        protected string _connectionString;

        protected IORM _orm;
        
        public BaseRepository()
        {
            SetConnectionString();

            _orm = new SugarORM(_connectionString);
        }

        protected virtual void SetConnectionString()
        {
            _connectionString = "server=127.0.0.1;database=JieNorSYS;uid=root;pwd=123456;Allow Zero Datetime=True;Port=3306;charset=utf8;pooling=true;Max Pool Size=100";
        }

        protected virtual T ORMClient<T>() where T : class
        {
            return _orm.GetSqlClient<T>();
        }
    }
}
