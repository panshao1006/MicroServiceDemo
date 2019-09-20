using Core.ORM;
using Organization.Model.Filter;
using Organization.Model.Model;
using Organization.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace Organization.DAL
{
    public class OrganizationRepository : BaseRepository
    {
        public int CreateOrganization(OrganizationModel org)
        {
            return 1;
        }

        public OrganizationModel GetOrganization(OrganizationFilter filter)
        {
            return new OrganizationModel();
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<OrganizationModel> GetList(OrganizationFilter filter)
        {
            string sql = string.Format(@"select a.* from t_bas_organization a 
                            inner join t_sec_orguser b on a.MOrgID=b.MUserID and b.MIsDelete=0 
                            where b.MUserID='{0}' and a.MIsDelete=0 ", filter.UserId);

            CommandInfo cmd = new CommandInfo();
            cmd.CommandText = sql;

            var result = _orm.GetDataModelList<OrganizationModel>(cmd);

            return result;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            string sql = string.Format(@"delete from t_bas_organization where MItemID='{0}'",id);
            CommandInfo cmd = new CommandInfo();
            cmd.CommandText = sql;

            var result = _orm.Execute(cmd);

            return result;
        }
    }
}
