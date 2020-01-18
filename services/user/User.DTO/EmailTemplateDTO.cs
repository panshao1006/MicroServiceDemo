using System;
using System.Collections.Generic;
using System.Text;

namespace User.DTO
{
    public class EmailTemplateDTO
    {
        public int Type { set; get; }

        public string Content { set; get; }

        public List<LanguageDTO> Contents { set; get; }
    }
}
