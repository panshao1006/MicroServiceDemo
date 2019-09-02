using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Model
{
    /// <summary>
    /// 服务注册类
    /// </summary>
    public class ServiceRegisterModel : ServiceModel
    {
        /// <summary>
        /// consul的ip
        /// </summary>
        public string ConsulIP { set; get; }

        /// <summary>
        /// consul的端口
        /// </summary>
        public int ConsulPort { set; get; }
    }
}
