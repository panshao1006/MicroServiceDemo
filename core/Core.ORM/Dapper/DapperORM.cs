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

        private BaseORMUtility _ormUtility;


        public DapperORM(string connectionString)
        {
            _connectionString = connectionString;

            _connection = new MySqlConnection(_connectionString);

            _ormUtility = new BaseORMUtility();
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


        #region ORM
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


        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert<T>(T t) where T : class
        {
            if(t == null)
            {
                throw new ArgumentNullException("T is null");
            }

            CommandInfo commandInfo = _ormUtility.GetInsertSqlCommandInfo<T>(t);

            return Execute(commandInfo);
        }
        #endregion
    }
}
