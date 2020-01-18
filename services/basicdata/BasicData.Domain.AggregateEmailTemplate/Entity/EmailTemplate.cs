using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Entity
{
    public class EmailTemplate:BaseEntity
    {
        /// <summary>
        /// 类型 1 注册激活 2 邀请注册激活 3邀请
        /// </summary>
        public string Type { set; get; }

        private string content;

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content
        {
            set
            {
                content = value;
            }
            get
            {
                if (Contents != null && Contents.Count > 0)
                {
                    var currentName = CurrentLanguageId ==null ? Contents.FirstOrDefault() : Contents.FirstOrDefault(x => x.LangId == CurrentLanguageId);

                    content = currentName == null ? null : currentName.Value;
                }

                return content;
            }
        }

        /// <summary>
        /// 多语言
        /// </summary>
        public List<LanguageValueObject> Contents { set; get; }
    }
}
