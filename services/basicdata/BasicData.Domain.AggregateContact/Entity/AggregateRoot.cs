using BasicData.Infrastructure.Data;
using Core.Common;
using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Entity
{
    public class AggregateRoot : BaseEntity
    {
        /// <summary>
        /// 创建一个Id
        /// </summary>
        protected string NewId
        {
            get
            {
                return GuidUtility.GetGuid();
            }
        }

        /// <summary>
        /// 当前token上下文
        /// </summary>
        public TokenContext CurrentTokenContext
        {
            get { return TokenContext.CurrentContext; }
        }
    }
}
