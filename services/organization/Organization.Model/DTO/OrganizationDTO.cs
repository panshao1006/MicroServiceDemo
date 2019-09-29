using Core.Common.FieldValidate;
using System.Collections.Generic;

namespace Organization.Model.DTO
{
    public class OrganizationDTO : BaseDTO
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        [FieldValidate(Length =200 ,Require =true)]
        public string DisplayName { set; get; }

        /// <summary>
        /// 法定名称
        /// </summary>
        public string LegalTradingName { set; get; }


        /// <summary>
        /// MRegionID
        /// </summary>		
        public string RegionId { get; set; }


        /// <summary>
        /// 创建组织的用户ID
        /// </summary>		
        public string MasterId { get; set; }


        /// <summary>
        /// 组织版本
        /// </summary>
        [FieldValidate(Require =true)]
        public int VersionId { get; set; }

        /// <summary>
        /// 组织类型
        /// </summary>		
        public string OrgTypeId { get; set; }

        /// <summary>
        /// 组织所属行业
        /// </summary>		
        public string IndustryId { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string StateId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostalNo { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { set; get; }


        /// <summary>
        /// 转换为DAO
        /// </summary>
        /// <returns></returns>
        public OrganizationDAO Convert()
        {
            OrganizationDAO dao = new OrganizationDAO();

            dao.MItemID = Id;
            dao.MName = DisplayName;
            dao.MLegalTradingName = LegalTradingName;
            dao.MMasterID = MasterId;
            dao.MVersionID = VersionId;
            dao.MOrgTypeID = OrgTypeId;
            dao.MPostalNo = PostalNo;
            dao.MRegionID = RegionId;
            dao.MStateID = StateId;
            dao.MCountryID = CountryId;
            dao.MCityID = CityId;
            dao.MStreet = Street;

            return dao;
        }


        /// <summary>
        /// 转换为DTO
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        public OrganizationDTO Convert(OrganizationDAO organization)
        {
            if(organization == null)
            {
                return null;
            }

            OrganizationDTO dto = new OrganizationDTO();

            dto.Id = organization.MItemID;
            dto.DisplayName = organization.MName;
            dto.LegalTradingName = organization.MLegalTradingName;
            dto.MasterId = organization.MMasterID;
            dto.VersionId = organization.MVersionID;
            dto.OrgTypeId = organization.MOrgTypeID;
            dto.PostalNo = organization.MPostalNo;
            dto.RegionId = organization.MRegionID;
            dto.StateId = organization.MStateID;
            dto.CountryId = organization.MCountryID;
            dto.CityId = organization.MCityID;
            dto.Street = organization.MStreet;
            dto.IsActive = organization.MIsActive;

            return dto;
        }

        /// <summary>
        /// 转为DTO
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        public List<OrganizationDTO> ConvertList(List<OrganizationDAO> organizations)
        {
            var result = new List<OrganizationDTO>();

            if(organizations==null || organizations.Count == 0)
            {
                return result;
            }

            organizations.ForEach(x =>
            {
               var tempDto = Convert(x);

                if (tempDto != null)
                {
                    result.Add(tempDto);
                }
            });

            return result;
        }
    }
}
