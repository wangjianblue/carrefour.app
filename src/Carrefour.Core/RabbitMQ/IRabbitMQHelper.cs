using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Carrefour.Core.Domain.RabbitMq
{
    public interface IRabbitMQHelper
    {  
        void SendMsg<T>(string exchangeName,string queName,T msg)where T:class;
        void Receive(string queName,Action<string> received,string exchangeName="defExchangeName");
    }


}