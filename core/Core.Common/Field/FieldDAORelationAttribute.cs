using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Field
{
    public class FieldDAORelationAttribute : Attribute
    {
        public string _daoFieldName { set; get; }

        public FieldDAORelationAttribute()
        {
        }
    }
}
