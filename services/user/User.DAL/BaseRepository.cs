using Core.ORM;
using Core.ORM.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.DAL
{
    public class BaseRepository
    {
        protected string _connectionString;

        protected IORM _orm;
        
        public BaseRepository()
        {
            SetConnectionString();

            _orm = new DapperORM(_connectionString);
        }

        protected virtual void SetConnectionString()
        {
            _connectionString = "server=127.0.0.1;database=JieNorSYS;uid=root;pwd=123456;Allow Zero Datetime=True;Port=3306;charset=utf8;pooling=true;Max Pool Size=100";
        }
    }
}
