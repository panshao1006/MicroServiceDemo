using BaseData.Model.DAO.Account;
using BaseData.Model.Filter.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Interface.DAL
{
    public interface IAccountRepository
    {
        List<AccountDAO> GetAccounts(AccountFilter filter);

        AccountDAO GetAccount(AccountFilter filter);
    }
}
