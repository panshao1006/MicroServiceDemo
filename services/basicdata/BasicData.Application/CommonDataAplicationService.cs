using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Service;
using BasicData.DTO.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Application
{
    /// <summary>
    /// 公共的基础资料应用服务
    /// </summary>
    public class CommonDataAplicationService
    {
        public EmailTemplateDomainService _emailTemplateDomainService;
        public IMapper _mapper;

        public CommonDataAplicationService(EmailTemplateDomainService emailTemplateDomainService , IMapper mapper)
        {
            _emailTemplateDomainService = emailTemplateDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取邮件模板
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public EmailTemplateDTO GetEmailTemplate(int type)
        {
            var @do = _emailTemplateDomainService.GetEmailTemplate(type);

            return @do == null ? null : _mapper.Map<EmailTemplateDTO>(@do);
        }
    }
}
