using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Core.Mongodb
{
    /// <summary>
    /// Mongo参数配置实体（从配置文件加载）
    /// </summary>
    public class MongoOption
    {
        /// <summary> 
        /// </summary>
        public string HostName { get; set; } = "localhost";

        /// <summary>
        ///  
        /// </summary>
        public string Password { get; set; }  

        /// <summary>
        ///  
        /// </summary>
        public string UserName { get; set; }

        public string DatabaseName { get; set; }
         

        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; } = -1;
    }
}
