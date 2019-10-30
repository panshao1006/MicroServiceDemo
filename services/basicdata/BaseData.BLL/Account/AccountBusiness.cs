using BaseData.Interface.BLL;
using BaseData.Interface.DAL;
using BaseData.Model;
using BaseData.Model.DAO.Account;
using BaseData.Model.Filter.Account;
using Core.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.BLL.Account
{
    public class AccountBusiness : IAccountBusiness
    {
        private IEventBus _eventBus;

        private IAccountRepository _dal;

        public AccountBusiness(IEventBus evnetBus , IAccountRepository accountRepository)
        {
            _eventBus = evnetBus;
            _dal = accountRepository;
        }

        public OperationResult CreateDefaultAccount(int accountStandard, string organizationId)
        {
            throw new NotImplementedException();
        }

        public List<AccountDAO> GetAccounts(AccountFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
