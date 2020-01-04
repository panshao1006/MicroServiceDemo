using System;

namespace BasicData.Domain.AggregateAccount.Entity
{
    public class Account : AggregateRoot
    {
        public string OrganizationId { set; get; }

        /// <summary>
        /// 科目编码
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 内部编码
        /// </summary>
        public string Code { set; get; }

        /// <summary>
        /// 科目方向
        /// </summary>
        public int Direction { set; get; }
    }
}
