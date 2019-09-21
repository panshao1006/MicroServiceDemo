using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.Attribute
{
    /// <summary>
    /// tableName 属性
    /// </summary>
    public class TableNameAttribute : System.Attribute
    {
        private string _tableName;

        public TableNameAttribute(string tableName)
        {
            _tableName = tableName;
        }

        public string GetTableName()
        {
            return _tableName;
        }
    }
}
