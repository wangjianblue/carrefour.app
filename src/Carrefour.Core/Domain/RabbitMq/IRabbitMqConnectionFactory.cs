using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace Carrefour.Core.Domain.RabbitMq
{
    public interface IRabbitMqConnectionFactory
    {
        IConnection GetConnection();
 
    }
}
