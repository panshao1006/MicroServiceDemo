using Core.Common;
using Core.ORM;
using Core.ORM.Dapper;
using Core.ORM.Sugar;
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

            _orm = new SugarORM(_connectionString);
        }

        protected virtual void SetConnectionString()
        {
            _connectionString = ConfigurationManager.AppSetting("ConnectionString");
        }
    }
}
