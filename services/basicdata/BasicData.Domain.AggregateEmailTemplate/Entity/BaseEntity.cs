using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Entity
{
    public class BaseEntity
    {
        protected TokenContext TokenContext = TokenContext.CurrentContext;

        protected string CurrentLanguageId
        {
            get { return TokenContext.GetLangId(); }
        }

        public string Id { set; get; }
    }
}
