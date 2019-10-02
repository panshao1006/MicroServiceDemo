using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Model.Filter.Account
{
    public class AccountFilter: BaseFilter
    {
        public string OrganizationId { set; get; }

        public bool? IsActive { set; get; }
    }
}
