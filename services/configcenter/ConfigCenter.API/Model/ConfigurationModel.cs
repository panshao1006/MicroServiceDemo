﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigCenter.API.Model
{
    [SugarTable("t_sys_config")]
    public class ConfigurationModel
    {
        /// <summary>
        /// 键
        /// </summary>
        [SugarColumn(ColumnName = "MKey")]
        public string Key { set; get; }

        /// <summary>
        /// 键值
        /// </summary>
        [SugarColumn(ColumnName = "MValue")]
        public string Value { set; get; }

        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnName = "MVersion")]
        public string Version { set; get; }

        /// <summary>
        /// 环境类型
        /// </summary>
        [SugarColumn(ColumnName = "MEnvironment")]
        public string Environment { set; get; }


        /// <summary>
        /// 应用ID
        /// </summary>
        [SugarColumn(ColumnName = "MAppID")]
        public string AppId { set; get; }

        [SugarColumn(ColumnName = "MIsActive")]
        public bool IsActive { set; get; }

        [SugarColumn(ColumnName = "MIsDelete")]
        public bool IsDelete { set; get; }
    }
}
