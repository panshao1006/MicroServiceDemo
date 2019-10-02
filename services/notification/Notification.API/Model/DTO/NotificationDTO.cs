using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.API.Model.DTO
{
    public class NotificationDTO
    {
        public string Id { set; get; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public int NotificationType { set; get; }

        /// <summary>
        /// 通知来源
        /// </summary>
        public string From { set; get; }

        /// <summary>
        /// 通知去处
        /// </summary>
        public string To { set; get; }

        /// <summary>
        /// 抄送
        /// </summary>
        public List<string> CopyFor { set; get; }
    }
}
