using Core.Common.FieldValidate;
using Core.EventBus;
using Core.EventBus.Model.Organization;
using Organization.DAL;
using Organization.Model;
using Organization.Model.DAO;
using Organization.Model.DTO;
using Organization.Model.Enum;
using Organization.Model.Filter;
using Organization.Model.Model;
using Organization.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace Organization.BLL
{
    /// <summary>
    /// 组织业务
    /// </summary>
    public class OrganizationBusiness
    {
        OrganizationRepository _dal = new OrganizationRepository();

        IEnumerable<IEventHandler> _eventHandlers;

        IEventBus _eventBus;

        public OrganizationBusiness()
        {
            //_eventHandlers = new IEnumerable<IEventHandler>();

            _eventBus = new RabbitMQEventBus(_eventHandlers);
        }

        /// <summary>
        /// 创建一个组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public OperationResult CreateOrganization(OrganizationDTO organization)
        {
            //数据校验
            OperationResult result = Validate(organization);

            if (!result.Success)
            {
                return result;
            }

            organization = _dal.CreateOrganization(organization);

            if (organization != null)
            {
                OrganizationCreatedEvent @event = new OrganizationCreatedEvent()
                {
                    OrgId = organization.Id,
                    UserId = organization.MasterId
                };


                _eventBus.PublishAsync<OrganizationCreatedEvent>(@event);
            }

            result.Success = organization != null;
            result.ObjectId = organization.Id;

            return result;
        }

        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<OrganizationDTO> GetOrganizations(OrganizationFilter filter)
        {
            List<OrganizationDAO> organizationDaoList = _dal.GetOrganizations(filter);

            List<OrganizationDTO> result = new OrganizationDTO().ConvertList(organizationDaoList);

            return result;
        }

        

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationDTO GetOrganization(OrganizationFilter filter)
        {
            OrganizationDTO organization = _dal.GetOrganization(filter);

            return organization;
        }


        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public OperationResult DeleteOrganization(string id)
        {
            OperationResult result = new OperationResult();

            result.Success = _dal.DeleteOrganziton(id);

            return result;
        }


        /// <summary>
        /// 更新组织状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationResult UpdateOrganization(string id, bool isActive)
        {
            OperationResult result = new OperationResult();

            OrganizationDAO organization = _dal.GetOrgnazaitonById(new OrganizationFilter() { Id = id });

            if (organization == null)
            {
                result.Success = false;
                result.Messages.Add($"Organization is not exist:{id}");

                return result;
            }

            organization.MIsActive = isActive;

            result.Success = _dal.Update(organization);

            return result;
        }

        /// <summary>
        /// 更新组织信息，有值的才更新，不传值的不更新
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public OperationResult UpdateOrganization(DetailedOrganizationDTO organization)
        {
            OperationResult result = new OperationResult();

            OrganizationDAO organizationDao;
            OrganizationAttributeDAO organizationAttributeDao;
            //进行校验
            result = ValidateUpdate(organization, out organizationDao, out organizationAttributeDao);

            if (!result.Success)
            {
                return result;
            }

            //进行更新复制
            SetUpdateValue(organization, organizationDao, organizationAttributeDao);

            result.Success = _dal.Update(organizationDao, organizationAttributeDao);

            return result;
        }

        /// <summary>
        /// 设置更新的值
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <param name="organization"></param>
        private void SetUpdateValue(DetailedOrganizationDTO organization, OrganizationDAO organizationDao, OrganizationAttributeDAO organizationAttribute)
        {
            organizationDao.MName = string.IsNullOrWhiteSpace(organization.DisplayName) ? 
                organizationDao.MName : organization.DisplayName;

            organizationDao.MLegalTradingName = string.IsNullOrWhiteSpace(organization.LegalTradingName) ? 
                organizationDao.MLegalTradingName : organization.LegalTradingName;

            organizationAttribute.MBaseCurrencyID = string.IsNullOrWhiteSpace(organization.BaseCurrencyId) ? 
                organizationAttribute.MBaseCurrencyID : organization.BaseCurrencyId;
        }

        /// <summary>
        /// 升级的校验
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        private OperationResult ValidateUpdate(DetailedOrganizationDTO organization, out OrganizationDAO organizationDao,
            out OrganizationAttributeDAO organizationAttributeDao)
        {
            OperationResult result = new OperationResult(true);

            organizationDao = null;
            organizationAttributeDao = null;

            if(organization == null)
            {
                result.Success = false;
                result.Messages.Add("传入参数不能为空！");

                return result;
            }

            if (string.IsNullOrWhiteSpace(organization.Id))
            {
                result.Success = false;
                result.Messages.Add("id 不能为空");

                return result;
            }

            var filter = new OrganizationFilter();
            filter.Id = organization.Id;

            organizationDao = _dal.GetOrgnazaitonById(filter);
            organizationAttributeDao = _dal.GetOrganizationAttribute(filter);
            //组织不存在
            if (organizationDao == null || organizationAttributeDao == null)
            {
                result.Success = false;
                result.Messages.Add("组织不存在");

                return result;
            }

            OperationResult dataValidateResult = Validate(organization, true);
            
            if (!dataValidateResult.Success)
            {
                result.Success = false;
                result.Messages.AddRange(dataValidateResult.Messages);
            }

            #region 向导部分校验

            OperationResult validateWizardStepResult = ValidateWizardSetp(organization, organizationAttributeDao);
            if (!validateWizardStepResult.Success)
            {
                result.Success = false;
                result.Messages.AddRange(validateWizardStepResult.Messages);
            }

            #endregion



            return result;
        }


        /// <summary>
        /// 向导部分的逻辑校验
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="organizationAttributeDao"></param>
        /// <returns></returns>
        private OperationResult ValidateWizardSetp(DetailedOrganizationDTO organization , OrganizationAttributeDAO organizationAttributeDao)
        {
            OperationResult result = new OperationResult();

            if (organization.WizardStep != 0 && organizationAttributeDao.MRegProgress == (int)WizardStepType.Completed)
            {
                //如果步骤不是财务设置，并且本位币不为空
                result.Success = false;
                result.Messages.Add("组织已经完成了向导，不能进行向导操作");
            }

            //其他的校验
            if (organization.WizardStep != (int)WizardStepType.FinancialSetup && !string.IsNullOrWhiteSpace(organization.BaseCurrencyId))
            {
                //如果步骤不是财务设置，并且本位币不为空
                result.Success = false;
                result.Messages.Add("当前步骤不在财务设置，不能更改本位币");
            }

            return result;
        }


        /// <summary>
        /// 常规数据校验
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="isUpdate">是否更新时校验</param>
        /// <returns></returns>
        private OperationResult Validate<T>(T organization, bool isUpdate = false) where T : class
        {
            OperationResult result = new OperationResult(true);
            List<string> tempValidateMessages;

            //基本字段的校验
            var validateResult = isUpdate ? organization.ValidateNonNull<T>(out tempValidateMessages) : organization.Validate<T>(out tempValidateMessages);

            if (!validateResult)
            {
                result.Success = false;

                result.Messages.AddRange(tempValidateMessages);
            }

            //基础资料的存在性校验
            OperationResult baseDataValidateResult = BaseDataValidate(organization, isUpdate);

            if (!baseDataValidateResult.Success)
            {
                result.Success = false;

                result.Messages.AddRange(tempValidateMessages);
            }

            //一些其他业务逻辑的校验

            return result;
        }


        /// <summary>
        /// 基础资料存在性校验
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        private OperationResult BaseDataValidate<T>(T organization, bool isUpdate = false) where T : class
        {
            OperationResult result = new OperationResult(true);

            List<string> tempValidateMessages;

            var validateResult = organization.ValidateBaseData<T>(out tempValidateMessages);

            if (!validateResult)
            {
                result.Success = false;

                result.Messages.AddRange(tempValidateMessages);
            }

            return result;
        }
    }
}
