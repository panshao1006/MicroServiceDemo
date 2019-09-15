using Core.ORM;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model;

namespace User.DAL
{
    /// <summary>
    /// 模块操作类
    /// </summary>
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        /// <summary>
        /// 用户权限查找
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<ModuleModel> GetModuleList(string userId , string orgId)
        {
            if(string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(orgId))
            {
                throw new ArgumentNullException("userId 和 orgId 不能为空");
            }

            string sql = string.Format(@"SELECT a.* from t_bas_module a
                            INNER JOIN t_bas_modulepermison b on a.MItemID=b.MModuleID
                            INNER JOIN t_sec_modulegroup d on d.MModuleID = a.MItemID
                            INNER JOIN t_sec_usergroup e on e.MGroupID = d.MGroupID and e.MUerID='{0}' and e.MOrgID='{1}'
                            INNER JOIN t_sec_grouprole f on f.MGroupID = e.MGroupID 
                            INNER JOIN t_sec_rolepermission g on g.MRoleID = f.MRoleID
                            INNER JOIN t_sec_permisionitem h on h.MPermisonID = g.MPermItemID" , userId , orgId);

            CommandInfo cmd = new CommandInfo();
            cmd.CommandText = sql;

            List<ModuleModel> modules = _orm.GetDataModelList<ModuleModel>(cmd);

            return modules;
        }
    }
}
