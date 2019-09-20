using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.Model
{
    public class SqlInfo
    {
        public string Id { set; get; }

        /// <summary>
        /// sql 类型 1 insert 2 update 3 select 4 delete
        /// </summary>
        public int Type { set; get; }
    }
}
