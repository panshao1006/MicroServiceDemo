using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.DTO;

namespace User.BLL
{
    public class MenuBusiness : BaseBusiness, IMenuBusiness
    {
        private IMenuRepository _repository;

        public MenuBusiness(IMenuRepository menuRepository)
        {
            _repository = menuRepository;
        }

        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgnaizationId"></param>
        /// <returns></returns>
        public OperationResult GetMenus(string userId, string orgnaizationId)
        {
            OperationResult result = new OperationResult(true);

            if (string.IsNullOrWhiteSpace(userId))
            {
                result.Success = false;

                result.Messages.Add("参数 userId 为空");
            }

            if (string.IsNullOrWhiteSpace(orgnaizationId))
            {
                result.Success = false;

                result.Messages.Add("参数 orgnaizationId 为空");
            }

            if (!result.Success)
            {
                return result;
            }

            var modules = _repository.GetModules(userId, orgnaizationId);

            result.Success = modules != null;

            result.Data = modules;


            return result;
        }
    }
}
