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
        public bool AddAuthor(UserGroupRelationModel userGroupRelation, UserRoleRelationModel userRoleRelation , List<RolePermisionRelationModel> rolePermisionRelations, GroupRoleRealtionModel groupRoleRealtion)
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                dbContext.BeginTran();
                dbContext.Insertable<UserGroupRelationModel>(userGroupRelation).ExecuteCommand();
                dbContext.Insertable<UserRoleRelationModel>(userRoleRelation).ExecuteCommand();
                dbContext.Insertable<List<RolePermisionRelationModel>>(rolePermisionRelations).ExecuteCommand();
                dbContext.Insertable<GroupRoleRealtionModel>(groupRoleRealtion).ExecuteCommand();
                dbContext.CommitTran();

                return true;
            }
            catch (Exception ex)
            {
                dbContext.RollbackTran();
                throw ex;
            }
        }
    }
}
