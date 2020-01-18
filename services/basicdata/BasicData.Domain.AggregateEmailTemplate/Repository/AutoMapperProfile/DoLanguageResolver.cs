using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Repository.AutoMapperProfile
{
    /// <summary>
    /// 多语言转换
    /// </summary>
    public class DoLanguageResolver : IValueResolver<EmailTemplatePO, EmailTemplate, List<LanguageValueObject>>
    {
        public List<LanguageValueObject> Resolve(EmailTemplatePO source, EmailTemplate destination, List<LanguageValueObject> destMember, ResolutionContext context)
        {
            if(source.Languages==null || source.Languages.Count == 0)
            {
                return new List<LanguageValueObject>();
            }

            List<LanguageValueObject> result = new List<LanguageValueObject>();

            foreach (var language in source.Languages)
            {
                var doLanguageValue = new LanguageValueObject()
                {
                    Field = "Content",
                    LangId = language.MLocaleID,
                    Value = language.MContent
                };

                result.Add(doLanguageValue);
            }

            return result;
        }
    }
}
