using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.DTO.EmailTemplate
{
    public class EmailTemplateDTO : BaseDTO
    {
        public int Type { set; get; }

        public string Content { set; get; }

        public List<LanguageDTO> Contents { set; get; }
    }
}
