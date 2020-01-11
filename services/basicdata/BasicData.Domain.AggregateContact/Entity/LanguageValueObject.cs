using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Entity
{
    public class LanguageValueObject
    {
        /// <summary>
        /// 多语言类型Id 0x0009英文，0x7804中文
        /// </summary>
        public string LangId { set; get; }

        public string Value { set; get; }

        /// <summary>
        /// 多语言字段
        /// </summary>
        public string Field { set; get; }
    }
}
