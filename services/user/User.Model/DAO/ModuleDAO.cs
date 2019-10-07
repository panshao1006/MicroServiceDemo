using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO
{
    [SugarTable("t_bas_module")]
    public class ModuleDAO
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string MItemID { set; get; }

        public string MAppID { set; get; }

        public string MName { set; get; }

        public string MLink { set; get; }

        public int MIndex { set; get; }

        public bool MIsActive { set; get; }

        public bool MIsDelete { set; get; }


    }
}
