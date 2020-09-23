using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Carrefour.Services.RabbitMq;

namespace Carrefour.WebApp
{
    public class WebHostGroundService : BackgroundService
    {
        private readonly IBrowseRecordsReceivesService _receives;
        private readonly ILogger _logger;
        public WebHostGroundService(IBrowseRecordsReceivesService receives, ILogger<WebHostGroundService> logger)
        {
            _receives = receives;
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            #region RabbitMQ  
            DoWorkRabbitTask(null); 
            #endregion
            return Task.CompletedTask;
        }
        public void DoWorkRabbitTask(object state)
        {
            _logger.LogTrace("执行BrowseRecords_Receive1");
            _receives.Receive1();
            //_logger.LogTrace("执行BrowseRecords_Receive2"); 
            //_receives.Receive2(); 
        }
        public override void Dispose()
        {
            base.Dispose(); 
        }
    }
}
