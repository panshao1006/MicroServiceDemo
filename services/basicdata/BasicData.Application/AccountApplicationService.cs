using BasicData.Domain.AggregateAccount.Entity;
using BasicData.Domain.AggregateAccount.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Application
{
    public class AccountApplicationService
    {
        private AccountDomainService _accountDomainService;
        public AccountApplicationService(AccountDomainService accountDomainService)
        {
            _accountDomainService = accountDomainService;
        }

        public List<Account> GetAccounts()
        {
            return _accountDomainService.GetAccounts();
        }
    }
}
