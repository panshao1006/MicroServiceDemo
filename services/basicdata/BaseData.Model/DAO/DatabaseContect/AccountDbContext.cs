using BaseData.Model.DAO.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Model.DAO.DatabaseContect
{
    public class AccountDbContext : BaseDbContext
    {
        public DbSet<AccountDAO> Accounts { set; get; }


        
    }
}
