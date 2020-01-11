using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.PO
{
    public class ContactGroupLanguagePO: BaseLanguagePO
    {
        public string MName { set; get; }

        public string MDesc { set; get; }

        public ContactGroupPO ContactGroup { set; get; }
    }
}
