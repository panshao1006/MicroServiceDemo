using BasicData.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateContact.Entity
{
    /// <summary>
    /// 联系人分组领域实体
    /// </summary>
    public class ContactGroup : BaseEntity
    {
        private string name;
        /// <summary>
        /// 当前语言名称
        /// </summary>
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                if (Names != null && Names.Count > 0)
                {
                    var currentName = Names.FirstOrDefault(x => x.LangId == CurrentLanguageId);

                    name = currentName == null ? null : currentName.Value;
                }

                return name;
            }
        }

        /// <summary>
        /// 名称多语言
        /// </summary>
        public List<LanguageValueObject> Names { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 描述多语言
        /// </summary>
        public List<LanguageValueObject> Descriptiones { set; get; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 创建联系人分组
        /// </summary>
        /// <returns></returns>

        public ContactGroup CreateContactGroup()
        {
            Id = GetGuid();
            OrganizationId = GetOrganizationId();
            base.Create();

            return this;
        }


        public OperationResult Validate()
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(OrganizationId))
            {
                result.Messages.Add("联系人类型的组织Id不能为空");
                result.Success = false;
            }

            if(Names == null || Names.Count == 0)
            {
                result.Messages.Add("联系人类型名称不能为空");
                result.Success = false;
            }

            result.Success = true;


            return result;
        }
    }
}
