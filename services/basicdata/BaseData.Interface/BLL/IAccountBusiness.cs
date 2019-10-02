using BaseData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Interface.BLL
{
    public interface IAccountBusiness
    {
        OperationResult CreateDefaultAccount(int accountStandard, string organizationId);
    }
}
