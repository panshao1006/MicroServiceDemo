using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicData.DTO
{
    public class BaseDTO
    {
        public string Id { set; get; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public string OrganizationId { set; get; }
    }
}
