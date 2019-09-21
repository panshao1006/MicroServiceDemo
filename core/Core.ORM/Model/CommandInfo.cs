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
        public object Parameters { set; get; }

        /// <summary>
        /// 超时时间（ms）
        /// </summary>
        public int? CommandTimeout { set; get; }

        public CommandInfo(string sql , object paramters)
        {
            CommandText = sql;
            Parameters = paramters;
        }

        public CommandInfo()
        {
            
        }
    }
}
