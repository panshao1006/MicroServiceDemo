using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.Model
{
    public class SqlInfo
    {
        /// <summary>
        /// sql字符串
        /// </summary>
        public string SqlString { set; get; }

        /// <summary>
        /// sql 类型 1 insert 2 update 3 select 4 delete
        /// </summary>
        public int Type { set; get; }


        public List<MySqlParameter> Parameters { set; get; }

        public SqlInfo()
        {
            Parameters = new List<MySqlParameter>();
        }
    }
}
