using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.DTO.Contact
{
    public class ContactGroupDTO : BaseDTO
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 分组名称多语言
        /// </summary>
        public List<LanguageDTO> Names { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 描述多语言
        /// </summary>
        public List<LanguageDTO> Descriptiones { set; get; }


    }
}
