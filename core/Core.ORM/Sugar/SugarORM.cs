using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ORM.Sugar
{
    public class SugarORM : IORM
    {
        private SqlSugarClient _dbContext;

        public SugarORM(string connectionString)
        {
            _dbContext = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.MySql,
                ConnectionString = connectionString,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                AopEvents = new AopEvents
                {
                    OnLogExecuting = (sql, p) =>
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(string.Join(",", p?.Select(it => it.ParameterName + ":" + it.Value)));
                    }
                }
            });
        }

        public int Execute(CommandInfo commandInfo)
        {
            throw new NotImplementedException();
        }

        public T GetDataModel<T>(CommandInfo commandInfo)
        {
            throw new NotImplementedException();
        }

        public T GetDataModel<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataModelList<T>(CommandInfo commandInfo)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataModelList<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public SqlSugarClient GetSqlClient<SqlSugarClient>() where SqlSugarClient: class
        {
            return _dbContext as SqlSugarClient;
        }

        public T Insert<T>(T t) where T : class , new()
        {
           return _dbContext.Insertable<T>(t).ExecuteReturnEntity();
        }

        public T UpdateModel<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> UpdateModels<T>() where T : class
        {
            throw new NotImplementedException();
        }
    }
}
