﻿using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicData.Infrastructure.Data
{
    public class BaseLanguagePO
    {
        public string MPKID { set; get; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool MIsActive { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool MIsDelete { set; get; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string MCreatorID { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime MCreateDate { set; get; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string MModifierID { set; get; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime MModifyDate { set; get; }

        /// <summary>
        /// 联系人的Id
        /// </summary>
        public string MParentID { set; get; }

        /// <summary>
        /// 多语言类型 0x0009 英文 0x7804简体中文 0x7C04
        /// </summary>
        public string MLocaleID { set; get; }
    }
}
