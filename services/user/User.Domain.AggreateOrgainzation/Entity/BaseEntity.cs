using Core.Common;
using Core.Context;
using Core.CustomException;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggreateOrgainzation.Entity
{
    public class BaseEntity
    {
        protected TokenContext TokenContext = TokenContext.CurrentContext;

        public string Id { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { set; get; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { set; get; }


        /// <summary>
        /// 创建者
        /// </summary>
        public string CreatorID { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { set; get; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string ModifierID { set; get; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModifyDate { set; get; }


        public virtual void Create()
        {
            if (TokenContext == null)
            {
                throw new TokenContextNullException("无法获取登录信息");
            }

            Id = GuidUtility.GetGuid();

            CreatorID = TokenContext.GetUserId();
            CreateDate = DateTime.Now;
            ModifierID = CreatorID;
            ModifyDate = CreateDate;
            IsActive = true;
            IsDelete = false;
        }
    }
}
