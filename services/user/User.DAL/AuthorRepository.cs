using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model.Model.Auth;

namespace User.DAL
{
    /// <summary>
    /// 权限操作
    /// </summary>
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public bool AddAuthor(UserGroupRelationModel userGroupRelation, UserRoleRelationModel userRoleRelation)
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                dbContext.BeginTran();
                dbContext.Insertable<UserGroupRelationModel>(userGroupRelation);
                dbContext.Insertable<UserRoleRelationModel>(userRoleRelation);

                dbContext.CommitTran();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbContext.RollbackTran();
            }

        }
    }
}
