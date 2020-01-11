using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.AutoMapperProfile
{
    /// <summary>
    /// domain 多语言转换为po多语言
    /// </summary>
    public class ContactGroupLanguageResolver : IValueResolver<ContactGroupPO, ContactGroup, List<LanguageValueObject>>
    { 
        public List<LanguageValueObject> Resolve(ContactGroupPO source, ContactGroup destination, List<LanguageValueObject> destMember, ResolutionContext context)
        {
            List<LanguageValueObject> result = new List<LanguageValueObject>();

            if (source.Languages==null || source.Languages.Count == 0)
            {
                return result;
            }

            foreach(var language in source.Languages)
            {
                LanguageValueObject nameLanguage = new LanguageValueObject()
                {
                    Field = "Name",
                    LangId = language.MLocaleID,
                    Value = language.MName
                };
                result.Add(nameLanguage);

                if (!string.IsNullOrWhiteSpace(language.MDesc))
                {
                    LanguageValueObject descLanguage = new LanguageValueObject()
                    {
                        Field = "Desc",
                        LangId = language.MLocaleID,
                        Value = language.MDesc
                    };

                    result.Add(descLanguage);
                }
            }

            return result;
        }
    }
}
