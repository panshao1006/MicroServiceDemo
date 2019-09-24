using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.Auth
{
    public class RolePermisionRelationModel
    {
        public string MItemID { set; get; }

        public string MRoleID { set; get; }

        public string MPermisonID { set; get; }

        /// <summary>
        /// 权限类型 例如：111111 表示有查看，新增，编辑，审核，导出权限
        /// </summary>
        public string MRigthType { set; get; }
    }
}
