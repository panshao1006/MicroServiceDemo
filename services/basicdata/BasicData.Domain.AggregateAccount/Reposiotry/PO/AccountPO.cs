using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateAccount.Reposiotry.PO
{
    /// <summary>
    /// 科目持久模型
    /// </summary>
    public class AccountPO : BasePO
    {

        public string MNumber { set; get; }

        public int MDC { set; get; }
    }
}
