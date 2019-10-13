using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Log.Model
{
    public enum LogType
    {
        /// <summary>
        /// 请求
        /// </summary>
        Request=1,
        
        /// <summary>
        /// 事件
        /// </summary>
        Event=2,

        /// <summary>
        /// 异常
        /// </summary>
        Exception=3,
    }
}
