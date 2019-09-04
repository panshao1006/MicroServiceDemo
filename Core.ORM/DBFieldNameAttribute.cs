using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM
{
    public class DBFieldNameAttribute : Attribute
    {
        private string _fieldName;

        /// <summary>
        /// 是否映射数据库字段
        /// </summary>
        private bool _isMapField;

        public DBFieldNameAttribute(string fieldName)
        {
            _fieldName = fieldName;
        }


        public DBFieldNameAttribute(bool isMapField)
        {
            _isMapField = isMapField;
        }


        public string GetFieldName()
        {
            return _fieldName.Trim();
        }
    }
}
