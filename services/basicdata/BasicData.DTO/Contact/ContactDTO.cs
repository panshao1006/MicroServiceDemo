using BasicData.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicData.DTO.Contact
{
    /// <summary>
    /// 联系人DTO
    /// </summary>
    public class ContactDTO : BaseDTO
    {
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string Name { set; get; }


        public List<LanguageDTO> LanguageNames { set; get; }

        /// <summary>
        /// 联系人邮件地址
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 联系类型 1客户 2供应商 3其他,可进行组合用逗号隔开
        /// </summary>
        public string ContactTypeIds { set; get; }

        /// <summary>
        /// 科目Id
        /// </summary>
        public string AccountId { set; get; }

        /// <summary>
        /// 科目信息
        /// </summary>
        public AccountDTO Account { set; get; }
    }
}
