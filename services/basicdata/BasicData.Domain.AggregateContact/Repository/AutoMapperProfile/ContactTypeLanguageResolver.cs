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
    public class ContactTypeLanguageResolver : IValueResolver<ContactGroup, ContactGroupPO, List<ContactGroupLanguagePO>>
    {
        public List<ContactGroupLanguagePO> Resolve(ContactGroup source, ContactGroupPO destination, List<ContactGroupLanguagePO> destMember, ResolutionContext context)
        {
            var result = new List<ContactGroupLanguagePO>();
            //名称以多语言为主
            if(source.Names!=null && source.Names.Count > 0)
            {
                foreach(var nameLanguage in source.Names)
                {
                    ContactGroupLanguagePO contactGroupLanguage = new ContactGroupLanguagePO()
                    {
                        MLocaleID = nameLanguage.LangId,
                        MName = nameLanguage.Value,
                        MParentID = source.Id,
                        MOrgID = source.OrganizationId
                };

                    result.Add(contactGroupLanguage);
                }
            }

            if(source.Descriptiones!=null && source.Descriptiones.Count > 0)
            {
                foreach(var descLanguage in source.Descriptiones)
                {
                    var contactGroupLanguage = result.FirstOrDefault(x => x.MLocaleID == descLanguage.LangId);

                    contactGroupLanguage = contactGroupLanguage ?? new ContactGroupLanguagePO();

                    contactGroupLanguage.MLocaleID = descLanguage.LangId;
                    contactGroupLanguage.MParentID = source.Id;
                    contactGroupLanguage.MOrgID = source.OrganizationId;
                    contactGroupLanguage.MDesc = descLanguage.Value;   
                }
            }

            return result;
        }
    }
}
