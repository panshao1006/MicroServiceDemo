using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BaseData.Model.DAO.Account
{
    /// <summary>
    /// 会计科目DAO
    /// </summary>
    [Table("t_bd_account")]
    public class AccountDAO : BaseDAO
    {
        [Key]
        [Column("MItemID")]
        public string MItemID { set; get; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }

        /// <summary>
        /// 科目名称
        /// </summary>
        public string MName { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool MIsDelete { set; get; }
    }
}
