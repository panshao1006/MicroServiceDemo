using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model.DAO.Author;

namespace User.DAL
{
    /// <summary>
    /// 权限操作
    /// </summary>
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public bool AddAuthor(UserGroupRelationDAO userGroupRelation, UserRoleRelationDAO userRoleRelation , List<RolePermisionRelationDAO> rolePermisionRelations, GroupRoleRealtionDAO groupRoleRealtion)
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                dbContext.BeginTran();
                dbContext.Insertable<UserGroupRelationDAO>(userGroupRelation).ExecuteCommand();
                dbContext.Insertable<UserRoleRelationDAO>(userRoleRelation).ExecuteCommand();
                dbContext.Insertable<List<RolePermisionRelationDAO>>(rolePermisionRelations).ExecuteCommand();
                dbContext.Insertable<GroupRoleRealtionDAO>(groupRoleRealtion).ExecuteCommand();
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
