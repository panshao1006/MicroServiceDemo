using Consul;
using System;
using Microsoft.Extensions.Configuration;
using Core.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Core.Common.ServiceFinder
{
    public class ConsulServiceFinder
    {
        /// <summary>
        /// consul的ip地址
        /// </summary>
        private string _consulIP;

        /// <summary>
        /// consul的端口
        /// </summary>
        private string _consulPort;

        private string _consulUri;

        public ConsulServiceFinder()
        {
            _consulIP ="127.0.0.1";
            _consulPort = "8500";

            _consulUri = string.Format("http://{0}:{1}" , _consulIP , _consulPort);
        }


        /// <summary>
        /// 获取所有的服务
        /// </summary>
        /// <returns></returns>
        public List<ServiceModel> GetServices()
        {
            List<ServiceModel> result = new List<ServiceModel>();

            using (var consulClient = new ConsulClient(c => c.Address = new Uri(_consulUri)))
            {
                var services = consulClient.Agent.Services().Result.Response;
                foreach (var service in services.Values)
                {
                    ServiceModel serviceModel = new ServiceModel()
                    {
                        ServiceIP = service.Address,
                        ServiceName = service.Service,
                        ServicePort = service.Port
                    };

                    result.Add(serviceModel);
                }
            }

            return result;
        }


        /// <summary>
        /// 获取当个服务
        /// </summary>
        /// <param name="servicesName"></param>
        /// <returns></returns>
        public ServiceModel GetService(string serviceName)
        {
            ServiceModel result = null;
                
            using (var consulClient = new ConsulClient(c => c.Address = new Uri(_consulUri)))
            {
                var services = consulClient.Agent.Services().Result.Response.Values.Where(s => s.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase));

                if (services == null || services.Count() == 0)
                {
                    return result;
                }

                var service = services.ElementAt(Environment.TickCount % services.Count());


                result = new ServiceModel()
                {
                    ServiceIP = service.Address,
                    ServiceName = service.Service,
                    ServicePort = service.Port
                };
            }

            return result;
        }


        /// <summary>
        /// 获取服务http地址
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public string GetServiceHttpAddress(string serviceName)
        {
            ServiceModel result = GetService(serviceName);

            if(result == null)
            {
                throw new NullReferenceException("无法找到服务：" + serviceName);
            }

            return $"http://{result.ServiceIP}:{result.ServicePort}";
        }
    }
}
