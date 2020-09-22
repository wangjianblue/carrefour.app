using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Carrefour.Core.Domain.RabbitMq
{
    public class RabbitMqConnectionFactory : IRabbitMqConnectionFactory
    {
        private readonly Action<RabbitOptions> _configure;

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name = "configure" ></param >
        public RabbitMqConnectionFactory(Action<RabbitOptions> configure)
        {
            _configure = configure;
     
        } 
        /// <summary>
        /// 獲取連接
        /// </summary>
        /// <returns></returns>
        public IConnection GetConnection()
        {
            var options = new RabbitOptions();
            _configure(options);
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = options.HostName;
            factory.Port = options.Port;
            factory.UserName = options.UserName;
            factory.Password = options.Password;
            factory.VirtualHost = options.VirtualHost;
            return factory.CreateConnection();
        }
        
   


    }
}
