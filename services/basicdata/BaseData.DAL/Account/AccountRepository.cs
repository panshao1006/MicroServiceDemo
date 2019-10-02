using BaseData.Interface.DAL;
using BaseData.Model.DAO.Account;
using BaseData.Model.Filter.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.DAL.Account
{
    public class AccountRepository : BaseRepository , IAccountRepository
    {
        public AccountDAO GetAccount(AccountFilter filter)
        {
            throw new NotImplementedException();
        }

        public List<AccountDAO> GetAccounts(AccountFilter filter)
        {
            List<AccountDAO> result = new List<AccountDAO>();

            if (string.IsNullOrWhiteSpace(filter.OrganizationId))
            {
                return result;
            }

            return result;
        }
    }
}
