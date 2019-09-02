using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Model
{
    /// <summary>
    /// 配置文件类
    /// </summary>
    public class FileConfiguration
    {
        public List<RouteContext> Routes { get; set; }

        public FileConfiguration()
        {
            Routes = new List<RouteContext>();
        }
    }
}
