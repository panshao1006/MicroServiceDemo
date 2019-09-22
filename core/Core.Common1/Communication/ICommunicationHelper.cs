using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Communication
{
    /// <summary>
    /// 通信接口类
    /// </summary>
    public interface ICommunicationHelper
    {
        T Get<T>(string url);

        T Post<T>(string url , Dictionary<string, string> formData = null);
    }
}
