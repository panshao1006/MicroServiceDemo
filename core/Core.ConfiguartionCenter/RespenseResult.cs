﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ConfigurationCenter
{
    public class RespenseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object Data { set; get; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { set; get; }
    }
}