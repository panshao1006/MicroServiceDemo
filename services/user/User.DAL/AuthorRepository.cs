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
        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="userGroupRelation"></param>
        /// <param name="userRoleRelation"></param>
        /// <param name="rolePermisionRelations"></param>
        /// <param name="groupPermisionRelations"></param>
        /// <returns></returns>
        public bool AddAuthor(UserGroupRelationDAO userGroupRelation, UserRoleRelationDAO userRoleRelation ,
            List<RolePermisionRelationDAO> rolePermisionRelations, List<GroupPermissionRelationDAO> groupPermisionRelations)
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                dbContext.BeginTran();
                dbContext.Insertable<UserGroupRelationDAO>(userGroupRelation).ExecuteCommand();
                dbContext.Insertable<UserRoleRelationDAO>(userRoleRelation).ExecuteCommand();
                dbContext.GetSimpleClient<RolePermisionRelationDAO>().InsertRange(rolePermisionRelations);
                dbContext.GetSimpleClient<GroupPermissionRelationDAO>().InsertRange(groupPermisionRelations);
                dbContext.CommitTran();

                return true;
            }
            catch (Exception ex)
            {
                dbContext.RollbackTran();
                throw ex;
            }
        }

        /// <summary>
        /// 获取应用组
        /// </summary>
        /// <returns></returns>
        public List<GroupDAO> GetGroups()
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();

            return dbContext.GetSimpleClient<GroupDAO>().GetList(x => x.MIsDelete == false);
        }


        /// <summary>
        /// 获取权限项
        /// </summary>
        /// <returns></returns>
        public List<PermisionDAO> GetPermisions()
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();

            return dbContext.GetSimpleClient<PermisionDAO>().GetList(x => x.MIsDelete == false);
        }


        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public List<RoleDAO> GetRoles()
        {
            var dbContext = _orm.GetSqlClient<SqlSugarClient>();

            return dbContext.GetSimpleClient<RoleDAO>().GetList(x => x.MIsDelete == false);
        }
    }
}
