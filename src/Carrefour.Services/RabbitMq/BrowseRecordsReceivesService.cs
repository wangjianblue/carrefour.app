using Carrefour.Core.Domain.RabbitMq;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Carrefour.Data;
using Carrefour.Core;

namespace Carrefour.Services.RabbitMq
{
    public class BrowseRecordsReceivesService : IBrowseRecordsReceivesService
    {
        private static readonly string workfair_Queue_Name = "browseRecords_workfair_queue";
        private static IConnection _connection;
        private readonly ILogger<BrowseRecordsReceivesService> _logger;
        private readonly IBrowseRecordsReceives _browseRecordsReceives;

        private readonly IRabbitMQHelper _RabbitmqHelper;
        public BrowseRecordsReceivesService(
            IRabbitMqConnectionFactory reRabbitMqConnectionFactory, 
            ILogger<BrowseRecordsReceivesService> logger,
            IBrowseRecordsReceives browseRecordsReceives,
            IRabbitMQHelper RabbitmqHelper)
        {
            _logger = logger;
            _browseRecordsReceives = browseRecordsReceives;
            _connection = reRabbitMqConnectionFactory.GetConnection();
            _RabbitmqHelper=RabbitmqHelper;
        }

        #region 浏览记录消息处理
        /// <summary>
        ///  消息一
        /// </summary>
        public void Receive1()
        {
            _logger.LogTrace("随时改动");
            _RabbitmqHelper.Receive(workfair_Queue_Name, item =>
            {
                _logger.LogInformation($"收到消息[browseRecords_Receive1]： {item}");
                    //var model=item.FromJSON<CustomerBrowseHistory>();
                    //var result = _browseRecordsReceives.Add(model);
            }); 
             

            // var channel = _connection.GetModel();
            // channel.QueueDeclare(workfair_Queue_Name, true, false, false, null);
            // channel.BasicQos(0, 1, false);
            // EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            // consumer.Received += (ch, ea) =>
            // {
               
            //     try
            //     {
            //         var sendBytes = Encoding.UTF8.GetString(ea.Body.ToArray());
            //         _logger.LogInformation($"收到消息[browseRecords_Receive1]： {sendBytes}");
            //         var model=sendBytes.FromJSON<CustomerBrowseHistory>();
            //         var result = _browseRecordsReceives.Add(model);
            //     }
            //     catch (Exception ex)
            //     {
            //         _logger.LogError($"[browseRecords_Receive1]{ex.Message}"); 
            //         channel.BasicReject(ea.DeliveryTag,false);
            //     } 
            //     channel.BasicAck(ea.DeliveryTag, false); 
            // };
            // //第五步：处理消息
            // channel.BasicConsume(workfair_Queue_Name, false, consumer); 
            // _logger.LogInformation($"[browseRecords_Receive1]消费者已启动");

        }
        /// <summary>
        ///  消息二
        /// </summary>
        public void Receive2()
        {
            _RabbitmqHelper.Receive(workfair_Queue_Name, item =>
            {
                _logger.LogInformation($"收到消息[browseRecords_Receive2]： {item}");
                    //var model=item.FromJSON<CustomerBrowseHistory>();
                    //var result = _browseRecordsReceives.Add(model);
            }); 
            // var channel = _connection.GetModel();
            // channel.QueueDeclare(workfair_Queue_Name, true, false, false, null);
            // channel.BasicQos(0, 1, false);
            // EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            // consumer.Received += (ch, ea) =>
            // {
            //     try
            //     {
            //         var sendBytes = Encoding.UTF8.GetString(ea.Body.ToArray()); 
            //         _logger.LogInformation($"收到消息[browseRecords_Receive2]： {sendBytes}");
            //         var model=sendBytes.FromJSON<CustomerBrowseHistory>();
            //         var result = _browseRecordsReceives.Add(model);
            //     }
            //     catch (Exception ex)
            //     {
            //         channel.BasicReject(ea.DeliveryTag,false);
            //         _logger.LogError($"[browseRecords_Receive2]{ex.Message}"); 
            //     } 
            //      channel.BasicAck(ea.DeliveryTag, false); 
            // };
            // channel.BasicConsume(workfair_Queue_Name, false, consumer); 
            // _logger.LogInformation($"[browseRecords_Receive2]消费者已启动");
        }
        #endregion

    }
}
