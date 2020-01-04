using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity
    {
        public string Id { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { set; get; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { set; get; }
    }
}
