using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Repository
{
    public class EmailTemplateLanguagePO:BaseLanguagePO
    {
        public string MContent { set; get; }

        public EmailTemplatePO EmailTemplate { set; get; }
    }
}
