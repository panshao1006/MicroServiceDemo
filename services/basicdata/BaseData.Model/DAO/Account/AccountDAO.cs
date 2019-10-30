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
    public class AccountDAO
    {
        [Key]
        [Column("MItemID")]
        public string MItemID { set; get; }

        public string MName { set; get; }


    }
}
