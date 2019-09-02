using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Model
{
    public class ServiceModel
    {
        /// <summary>
        /// 服务的ip
        /// </summary>
        public string ServiceIP { set; get; }

        /// <summary>
        /// 服务的端口
        /// </summary>
        public int ServicePort { set; get; }

        /// <summary>
        /// 服务的名称
        /// </summary>
        public string ServiceName { set; get; }
    }
}
