using AutoMapper;
using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregateUser.Entity;
using User.Domain.AggregateUser.Repository.PO;

namespace User.Domain.AggregateUser.Repository.AutomapperProfile
{
    /// <summary>
    /// 用户创建的激活信息的转换
    /// </summary>
    public class DoUserActiveInfoResolver : IValueResolver<User.Domain.AggregateUser.Entity.User, UserPO, List<UserActiveInfoPO>>
    {
        public List<UserActiveInfoPO> Resolve(Entity.User source, UserPO destination, List<UserActiveInfoPO> destMember, ResolutionContext context)
        {
            if (source.UserActiveInfo == null)
            {
                return null;
            }

            var result = new List<UserActiveInfoPO>();

            var po = new UserActiveInfoPO()
            {
                MItemID = source.UserActiveInfo.Id,
                MUserID = source.Id,
                MEmail = source.UserActiveInfo.Email,
                MPhone = source.UserActiveInfo.Phone,
                MCreateDate = DateTime.Now,
                MLinkType = source.UserActiveInfo.LinkType,
                MCreatorID = source.CreatorID,
                MExpireDate = source.CreateDate.AddHours(12),
                MIsDelete = source.UserActiveInfo.IsDelete,
                MIsActive = source.UserActiveInfo.IsActive
            };

            result.Add(po);

            return result;
        }
    }
}
