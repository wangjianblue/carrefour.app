using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Carrefour.Core.Domain.RabbitMq
{
    public class RabbitMQHelper:IRabbitMQHelper
    {    
        private readonly ConnectionFactory connectionFactory;
        private readonly IConnection connection;
        private readonly IModel channel; 
        public RabbitMQHelper(Action<RabbitOptions> configure)
        {
            var options = new RabbitOptions();
            configure(options);
            connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = options.HostName;
            connectionFactory.Port = options.Port;
            connectionFactory.UserName = options.UserName;
            connectionFactory.Password = options.Password;
            connectionFactory.VirtualHost = options.VirtualHost; 
            connection = connectionFactory.CreateConnection(); 
            channel = connection.CreateModel();  
            channel.BasicQos(0, 1, false);

        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exchangeName"></param>
        /// <param name="queName"></param>
        /// <param name="msg"></param>
        public void SendMsg<T>(string exchangeName,string queName,T msg)where T:class
        {
            channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            //声明一个队列
            channel.QueueDeclare(queName, true, false, false, null);
            //绑定队列，交换机，路由键
            channel.QueueBind(queName, exchangeName, "");
    
            var basicProperties = channel.CreateBasicProperties();
            //1：非持久化 2：可持久化
            basicProperties.DeliveryMode = 2;
            string value = JsonConvert.SerializeObject(msg);
            var payload = Encoding.UTF8.GetBytes(value);
            var address = new PublicationAddress(ExchangeType.Direct, exchangeName, queName);
            channel.BasicPublish(address, basicProperties, payload);
        }

        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="queName"></param>
        /// <param name="exchangeName"></param>
        /// <param name="received"></param>
        public void Receive(string queName,Action<string> received,string exchangeName="defExchangeName")
        {
            channel.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            //声明一个队列
            channel.QueueDeclare(queName, true, false, false, null);
            //绑定队列，交换机，路由键
            channel.QueueBind(queName, exchangeName, "");
            //事件基本消费者
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                string message = Encoding.UTF8.GetString(ea.Body.ToArray());
                received(message);
                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            channel.BasicConsume(queName, false, consumer);
        }
 
    }
}