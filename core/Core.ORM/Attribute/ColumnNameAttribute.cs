using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.Attribute
{
    public class ColumnNameAttribute : System.Attribute
    {
        private string _fieldName;

        /// <summary>
        /// 是否映射数据库字段
        /// </summary>
        private bool _isMapField;

        public ColumnNameAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }


        public ColumnNameAttribute(bool isMapField)
        {
            _isMapField = isMapField;
        }


        public string GetFieldName()
        {
            return _fieldName.Trim();
        }
    }
}
