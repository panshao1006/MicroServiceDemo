using Core.ORM;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model;
using User.Model.DAO;
using User.Model.DTO.Author;

namespace User.DAL
{
    /// <summary>
    /// 模块操作类
    /// </summary>
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        /// <summary>
        /// 用户权限查找
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<ModuleDTO> GetModules(string userId , string orgnazitionId)
        {
            List<ModuleDTO> result = new List<ModuleDTO>();

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(orgnazitionId))
            {
                throw new ArgumentNullException("userId 和 orgId 不能为空");
            }

            string sql = string.Format(@"
                            SELECT a.* from t_bas_module a
                                INNER JOIN t_sec_permissionitem b on a.MPermissonID = b.MItemID
                                INNER JOIN t_sec_rolepermission c on c.MPermissionID = b.MItemID and c.MRightType='11111' and c.MOrgID='{1}'
                                INNER JOIN t_sec_userrole d on d.MRoleID = c.MRoleID and d.MUserID='{0}' and d.MOrgID='{1}'
                            ORDER BY a.MIndex", userId , orgnazitionId);

            List<ModuleDAO> modules = _orm.GetSqlClient<SqlSugarClient>().SqlQueryable<ModuleDAO>(sql).ToList();

            return new ModuleDTO().Convert(modules);
        }
    }
}
