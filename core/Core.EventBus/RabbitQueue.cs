using System;
using System.Collections.Generic;
using System.Text;
using Core.EventBus.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Core.EventBus
{
    public class RabbitQueue : IEventQueue
    {
        protected ConnectionFactory _factory;

        public delegate void ReceviedHandler(object sender , EventProcessedEventArgs e);
        public ReceviedHandler ReceivedEvent;

        public delegate void FailHandler(object sender);
        public FailHandler FailEvent;

        protected string _hostName { set; get; }

        protected string _userName { set; get; }

        protected string _password { set; get; }


        protected string _queueName { set; get; }

        public void Send<TEvent>(TEvent @event) where TEvent : class , IEvent
        {
            if (@event == null)
            {
                throw new NullReferenceException("message is null");
            }

            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //channel.QueueDeclare(_queueName, false, false, false, null);
                    //var body = Encoding.UTF8.GetBytes(@event.Data);
                    //channel.BasicPublish("", _queueName, null, body);
                }
            }
        }


        /// <summary>
        /// 接受到事件的处理
        /// </summary>
        public void Receive()
        {
            var connection = _factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ackEventArgs) =>
            {
                var body = ackEventArgs.Body;
                var message = Encoding.UTF8.GetString(body);
                EventProcessedEventArgs e = new EventProcessedEventArgs();
                try
                {
                    ReceivedEvent?.Invoke(message , e);
                    channel.BasicAck(ackEventArgs.DeliveryTag, false);

                }
                catch (Exception ex)
                {
                   

                }
                

            };

            channel.BasicConsume(_queueName, false, consumer);
        }
    }
}
