using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM
{
    public class CommandInfo
    {
        /// <summary>
        /// 执行Sql脚本
        /// </summary>
        public string CommandText { set; get; }

        /// <summary>
        /// 参数
        /// </summary>
        public dynamic Parameters { set; get; }

        /// <summary>
        /// 超时时间（ms）
        /// </summary>
        public int? CommandTimeout { set; get; }
    }
}
