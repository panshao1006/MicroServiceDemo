using BasicData.Domain.AggregateAccount.Entity;
using BasicData.Domain.AggregateAccount.Reposiotry.PO;
using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Context;
using AutoMapper;

namespace BasicData.Domain.AggregateAccount.Service
{
    public class AccountDomainService
    {
        IRepository<AccountPO> _repository;

        TokenContext _currentContext;

        IMapper _mapper;

        public AccountDomainService(IRepository<AccountPO> repository , IMapper mapper)
        {
            _repository = repository;
            _currentContext = TokenContext.CurrentContext;
            _mapper = mapper;
        }


        /// <summary>
        /// 获取所有的科目
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccounts()
        {
            List<AccountPO> accounts = _repository.Query().AsNoTracking().Where(x => x.MOrgID == _currentContext.GetOrganizationId() && x.MIsActive && !x.MIsDelete).ToList();

            var result = _mapper.Map<List<Account>>(accounts);

            return result;
        }
    }
}
