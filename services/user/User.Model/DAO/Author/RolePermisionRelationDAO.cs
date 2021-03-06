﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_rolepermission")]
    public class RolePermisionRelationDAO : BaseDAO
    {
        public string MOrgID { set; get; }

        public string MRoleID { set; get; }

        public string MPermissionID { set; get; }

        /// <summary>
        /// 权限类型 例如：111111 表示有查看，新增，编辑，审核，导出权限
        /// </summary>
        public string MRightType { set; get; }
    }
}
