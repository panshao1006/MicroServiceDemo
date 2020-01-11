using Core.Common;
using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity
    {
        protected TokenContext TokenContext= TokenContext.CurrentContext;

        protected string CurrentLanguageId
        {
            get { return TokenContext.GetLangId(); }
        }

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


        protected void Create()
        {
            IsDelete = false;
            IsActive = true;

            CreatorID = TokenContext.GetUserId();
            CreateDate = DateTime.Now;
            ModifierID = CreatorID;
            ModifyDate = CreateDate;
        }


        protected virtual string GetOrganizationId()
        {
            if(TokenContext != null)
            {
                return TokenContext.GetOrganizationId();
            }

            return "";
        }

        /// <summary>
        /// 获取一个GUID
        /// </summary>
        /// <returns></returns>
        protected virtual string GetGuid()
        {
            return GuidUtility.GetGuid();
        }

        
    }
}
