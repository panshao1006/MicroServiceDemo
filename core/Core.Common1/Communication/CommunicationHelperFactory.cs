using Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Communication
{
    /// <summary>
    /// 通信帮助类工厂
    /// </summary>
    public class CommunicationHelperFactory
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="type">1 http</param>
        /// <returns></returns>
        public static ICommunicationHelper GetInstance(int type)
        {
            ICommunicationHelper communicationHelper = null;

            switch (type)
            {
                //http通信请求
                case (int)CommunicationType.HTTP:
                    communicationHelper = new HttpClientHelper();
                    break;
            }

            //没有找到，向外面抛出异常
            if(communicationHelper == null)
            {
                throw new Exception("can instance communicationhelper for type:" + type);
            }

            return communicationHelper;
        }
    }
}
