using Core.Common;
using Organization.Interface.DAL;
using Organization.Model;
using Organization.Model.DAO;
using Organization.Model.DTO;
using Organization.Model.Enum;
using Organization.Model.Filter;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace Organization.DAL
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        /// <summary>
        /// 创建一个组织
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public OrganizationDTO CreateOrganization(OrganizationDTO organization)
        {
            OrganizationDAO dao = organization.Convert();
            dao.MItemID = GuidUtility.GetGuid();
            dao.MIsActive = false;
            dao.MIsDelete = false;

            OrganizationAttributeDAO attributeDao = new OrganizationAttributeDAO();
            attributeDao.MItemID = GuidUtility.GetGuid();
            attributeDao.MOrgID = dao.MItemID;
            attributeDao.MConversionDate = DateTime.Now;
            attributeDao.MExpiredDate = DateTime.Now.AddDays(30);
            attributeDao.MRegProgress = (int)WizardStepType.Created;
            attributeDao.MIsActive = true;

            var client = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                client.BeginTran();

                client.Insertable(dao).ExecuteCommand();
                client.Insertable(attributeDao).ExecuteCommand();
                client.CommitTran();
                organization.Id = dao.MItemID;

                return organization;
            }
            catch (Exception ex)
            {
                client.RollbackTran();

                throw ex;
            }
        }


        /// <summary>
        /// 获取一个组织
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationDTO GetOrganization(OrganizationFilter filter)
        {
            var organization = _sugarClient.GetSimpleClient<OrganizationDAO>().GetSingle(x => x.MItemID == filter.Id && x.MIsActive == true);

            return new OrganizationDTO().Convert(organization);
        }


        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<OrganizationDAO> GetOrganizations(OrganizationFilter filter)
        {
            var organizations = _sugarClient.GetSimpleClient<OrganizationDAO>().GetList(x => x.MItemID == filter.Id && x.MIsActive == true);

            return organizations;
        }


        /// <summary>
        /// 根据Id获取组织
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationDAO GetOrgnazaitonById(OrganizationFilter filter)
        {
            return _sugarClient.GetSimpleClient<OrganizationDAO>().GetSingle(x => x.MItemID == filter.Id && x.MIsActive == true);
        }


        /// <summary>
        /// 获取组织的属性
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationAttributeDAO GetOrganizationAttribute(OrganizationFilter filter)
        {
            return _sugarClient.GetSimpleClient<OrganizationAttributeDAO>().GetSingle(x => x.MOrgID == filter.Id && x.MIsActive == true);
        }

        /// <summary>
        /// 删除组织(物理删除)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteOrganziton(string id)
        {
            return _sugarClient.GetSimpleClient<OrganizationDAO>().Delete(x => x.MItemID == id);
        }

        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public bool Update(OrganizationDAO organization)
        {
            var result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<OrganizationDAO>().Update(organization);

            return result;
        }


        /// <summary>
        /// 更新组织信息
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="organizationAttribute"></param>
        /// <returns></returns>
        public bool Update(OrganizationDAO organization, OrganizationAttributeDAO organizationAttribute)
        {
            var client = _orm.GetSqlClient<SqlSugarClient>();
            try
            {
                client.BeginTran();

                client.GetSimpleClient<OrganizationDAO>().Update(organization);
                client.GetSimpleClient<OrganizationAttributeDAO>().Update(organizationAttribute);

                client.CommitTran();

                return true;
            }
            catch (Exception ex)
            {
                client.RollbackTran();

                throw ex;
            }
        }
    }
}
