using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using Core.Model.Model;

namespace User.Common.ServiceRegister
{
    public static class ConsulBuilderExtensions
    {
        public static IApplicationBuilder UserConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, IConfiguration configuration)
        {
            //初始化一些信息
            ServiceRegisterModel serviceEntity = new ServiceRegisterModel
            {
                ServiceIP = "127.0.0.1",
                ServicePort = Convert.ToInt32(configuration["Service:Port"]),
                ServiceName = configuration["Service:Name"],
                ConsulIP = configuration["Consul:IP"],
                ConsulPort = Convert.ToInt32(configuration["Consul:Port"])
            };

            //请求注册的 Consul 地址
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));
            var httpCheck = new AgentServiceCheck()
            {
                //服务启动多久后注册
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),

                //健康检查时间间隔，或者称为心跳间隔
                Interval = TimeSpan.FromSeconds(10),

                //健康检查地址
                HTTP = $"http://{serviceEntity.ServiceIP}:{serviceEntity.ServicePort}/api/health",
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.ServiceIP,
                Port = serviceEntity.ServicePort,
                //添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }
            };

            //服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            consulClient.Agent.ServiceRegister(registration).Wait();
            lifetime.ApplicationStopping.Register(() =>
            {
                //服务停止时取消注册
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }
}
