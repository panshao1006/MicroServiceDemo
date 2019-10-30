using BaseData.Model;
using BaseData.Model.DAO.Account;
using BaseData.Model.Filter.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Interface.BLL
{
    public interface IAccountBusiness
    {
        OperationResult CreateDefaultAccount(int accountStandard, string organizationId);

        List<AccountDAO> GetAccounts(AccountFilter filter);
    }
}
