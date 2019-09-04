using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Filter
{
    public class UserFilter : BaseFilter
    {
        public string Email { set; get; }

        public string Password { set; get; }
    }
}
