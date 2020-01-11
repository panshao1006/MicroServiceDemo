using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.PO
{
    public class ContactGroupPO : BasePO
    {
        public List<ContactGroupLanguagePO> Languages { set; get; }
    }
}
