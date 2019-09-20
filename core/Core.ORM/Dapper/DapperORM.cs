using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Core.ORM.Dapper
{
    public class DapperORM : IORM
    {
        private string _connectionString;

        private IDbConnection _connection;

        

        public DapperORM(string connectionString)
        {
            _connectionString = connectionString;

            _connection = new MySqlConnection(_connectionString);
        }

        #region 自定义sql

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T GetDataModel<T>(CommandInfo commandInfo)
        {
            if (commandInfo == null)
            {
                throw new ArgumentNullException("commandInfo");
            }
            var command = new CommandDefinition(commandInfo.CommandText);

            return _connection.Query<T>(command).FirstOrDefault();
        }


        public List<T> GetDataModelList<T>(CommandInfo commandInfo)
        {
            if (commandInfo == null)
            {
                throw new ArgumentNullException("commandInfo");
            }

            var command = new CommandDefinition();



            return _connection.Query<T>(command).ToList();
        }

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="commandInfo"></param>
        /// <returns></returns>
        public int Execute(CommandInfo commandInfo)
        {
            if (commandInfo == null)
            {
                throw new ArgumentNullException("commandInfo");
            }

            var command = new CommandDefinition(commandInfo.CommandText);
            return _connection.Execute(command);
        }

        #endregion


        #region
        public T GetDataModel<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataModelList<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> UpdateModels<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T UpdateModel<T>()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
