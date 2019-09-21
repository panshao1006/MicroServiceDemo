using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.Attribute
{
    public class ColumnNameAttribute : System.Attribute
    {
        private string _columnName;

        /// <summary>
        /// 是否映射数据库字段
        /// </summary>
        private bool _isMapField;

        public ColumnNameAttribute(string columnName)
        {
            _columnName = columnName;
        }


        public ColumnNameAttribute(bool isMapField)
        {
            _isMapField = isMapField;
        }


        public string GetFieldName()
        {
            return _columnName.Trim();
        }

        public bool IsMapFiled()
        {
            return _isMapField || !string.IsNullOrWhiteSpace(_columnName);
        }
    }
}
