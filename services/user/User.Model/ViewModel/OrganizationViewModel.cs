using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.ViewModel
{
    public class OrganizationViewModel
    {
        public string Id { set; get; }

        public string DisplayName { set; get; }

        /// <summary>
        /// 向导步骤
        /// </summary>
        public string WizardStep { set; get; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { set; get; }
    }
}
