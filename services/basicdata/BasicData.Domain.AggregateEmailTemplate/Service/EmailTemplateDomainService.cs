using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Entity;
using BasicData.Domain.AggregateEmailTemplate.Repository;
using BasicData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Service
{
    public class EmailTemplateDomainService
    {
        private IRepository<EmailTemplatePO> _repository;
        private IMapper _mapper;

        public EmailTemplateDomainService(IRepository<EmailTemplatePO> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取邮件模板
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public EmailTemplate GetEmailTemplate(int type)
        {
           var po = _repository.Query().Include(x=>x.Languages).AsNoTracking().FirstOrDefault(x => x.MType == type);

            return po != null ? _mapper.Map<EmailTemplate>(po) : null;
        }
    }
}
