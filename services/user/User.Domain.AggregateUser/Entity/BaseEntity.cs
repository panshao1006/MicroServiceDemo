using Core.Common;
using System;

namespace User.Domain.AggregateUser.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity
    {
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
            CreatorID = Id;
            CreateDate = DateTime.Now;
            ModifierID = CreatorID;
            ModifyDate = CreateDate;
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
