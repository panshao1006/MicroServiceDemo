using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Repository
{
    public class EmailTemplatePO : BasePO
    {
        public int MType { set; get; }

        public List<EmailTemplateLanguagePO> Languages { set; get; }
    }
}
