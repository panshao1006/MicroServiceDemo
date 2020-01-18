using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggregateUser.Entity
{
    public class EmailTemplate: ValueObject
    {
        public string Id { set; get; }

        /// <summary>
        /// 类型 1 注册激活 2 邀请注册激活 3邀请
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content
        {
            set;get;
        }

        public List<LanguageValueObject> Contents { set; get; }
    }
}
