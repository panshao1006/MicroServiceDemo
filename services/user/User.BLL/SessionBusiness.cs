using Core.Cache;
using Core.Common;
using Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using User.Interface.BLL;
using User.Model;
using User.Model.DTO;
using User.Model.ViewModel;

namespace User.BLL
{
    public class SessionBusiness : BaseBusiness, ISessionBusiness
    {
        private ICache _cacheClient;

        private string _requestOrganizationUrl = ConfigurationManager.AppSetting("GatewayHost") + $"/organizations";

        public SessionBusiness(ICache cache)
        {
            _cacheClient = cache;
        }

        /// <summary>
        /// 更改组织
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public OperationResult ChangeOrganization(string organizationId)
        {
            OperationResult result = new OperationResult();

            var token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
            {
                result.Success = false;
                result.Messages.Add("token 为空，请重新登录");
                return result;
            }

            var tokenDTO = _cacheClient.Query<TokenDTO>(new CacheFilter() { Key = token });

            if (tokenDTO == null)
            {
                result.Success = false;
                result.Messages.Add("token 为空，请重新登录");
                return result;
            }

            //查找组织信息
            HttpClientUtility httpClient = new HttpClientUtility();
            httpClient.SetRequestHeaders("token", token);
            var organization = httpClient.Get<List<OrganizationViewModel>>(_requestOrganizationUrl + "?id=" + organizationId).FirstOrDefault();

            if (organization == null)
            {
                result.Success = false;
                result.Messages.Add($"id为{organizationId}的组织不存在");
                return result;
            }

            if (!organization.IsActive)
            {
                result.Success = false;
                result.Messages.Add($"id为{organizationId}的组织不存在或者已经禁用");
                return result;
            }

            tokenDTO.OrganizationId = organizationId;

            _cacheClient.Update(new CacheModel() { Key = token, Data = tokenDTO });

            result.Success = true;

            result.Data = organization;

            return result;
        }
    }
}
