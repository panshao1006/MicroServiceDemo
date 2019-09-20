using System;
using System.Collections.Generic;
using System.Text;
using Core.EventBus.Model;
using Newtonsoft.Json;
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

        public RabbitQueue(string hostName , string userName , string password)
        {
            _hostName = hostName;
            _userName = userName;
            _password = password;

            _factory = new ConnectionFactory();

            _factory.HostName = _hostName;
            _factory.UserName = _userName;
            _factory.Password = _password;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : class , IEvent
        {
            if (@event == null)
            {
                throw new NullReferenceException("message is null");
            }

            var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var queueName = @event.GetType().FullName;

            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    var body = Encoding.UTF8.GetBytes(data);
                    channel.BasicPublish("", queueName, null, body);
                }
            }
        }


        /// <summary>
        /// 接受到事件的处理
        /// </summary>
        public void Receive<TEvent>(string queueName) where TEvent : IEvent
        {
            var connection = _factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ackEventArgs) =>
            {
                var body = ackEventArgs.Body;
                var message = Encoding.UTF8.GetString(body);
                EventProcessedEventArgs e = new EventProcessedEventArgs()
                {
                    Event = JsonConvert.DeserializeObject<TEvent>(message)
                };
                try
                {
                    ReceivedEvent?.Invoke(message, e);
                    channel.BasicAck(ackEventArgs.DeliveryTag, false);

                }
                catch (Exception ex)
                {


                }
            };

            channel.BasicConsume(queueName, false, consumer);
        }
    }
}
