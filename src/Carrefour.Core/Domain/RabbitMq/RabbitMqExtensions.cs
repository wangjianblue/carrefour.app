using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Carrefour.Core.Domain.RabbitMq
{
    public static class RabbitMqExtensions
    {
        /// <summary>
        /// 获取信道
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static IModel GetModel(this IConnection connection)
        {
            return connection.CreateModel();
        }
    }
}
