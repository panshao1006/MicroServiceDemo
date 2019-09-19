using Core.EventBus.Model;
using System;
using System.Threading.Tasks;

namespace Core.EventBus
{
    public interface IEventBus : IEventPublisher, IEventSubscriber
    {
        ///// <summary>
        ///// 发布
        ///// </summary>
        ///// <typeparam name="TEvent"></typeparam>
        ///// <returns></returns>
        //Task PublishAsync<TEvent>(TEvent @event) where TEvent : IntegrationEvent;

        ///// <summary>
        ///// 订阅
        ///// </summary>
        //Task SubscribeAsync();

        ///// <summary>
        ///// 取消订阅
        ///// </summary>
        //void Unsubscribe();

        //void Handle(object @event);
    }
}
