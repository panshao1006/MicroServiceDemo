using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Core.ORM.Dapper
{
    public class DapperUtility : IORM
    {
        private string _connectionString;

        private IDbConnection _connection;

        public DapperUtility(string connectionString)
        {
            _connection = new MySqlConnection(_connectionString);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T GetDataModel<T>(CommandInfo commandInfo)
        {
            var command = new CommandDefinition();

            return _connection.Query<T>(command).First();
        }


        public List<T> GetDataModelList<T>(CommandInfo commandInfo)
        {
            var command = new CommandDefinition();

            return _connection.Query<T>(command).ToList();
        }
    }
}
