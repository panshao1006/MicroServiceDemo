using BaseData.Interface.BLL;
using BaseData.Interface.DAL;
using BaseData.Model;
using BaseData.Model.DAO.Account;
using BaseData.Model.DAO.DatabaseContect;
using BaseData.Model.Filter.Account;
using Core.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


        /// <summary>
        /// 创建预设科目
        /// </summary>
        /// <param name="accountStandard"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public OperationResult CreateDefaultAccount(int accountStandard, string organizationId)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 获取所有科目信息
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<AccountDAO> GetAccounts(AccountFilter filter)
        {
            List<AccountDAO> accounts = new List<AccountDAO>();

            using (AccountDbContext context = new AccountDbContext())
            {
                accounts = context.Accounts.AsEnumerable().Where(x => x.MIsDelete == false && x.MOrgID == "0").ToList();
            }

            return accounts;
        }
    }
}
