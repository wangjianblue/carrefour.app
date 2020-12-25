using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrefour.WebApp.Models.Request
{
    /// <summary>
    /// 浏览记录
    /// </summary>
    public class AddCustomerBrowseHistory
    {
        /// <summary>
        /// memid会员主键
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 关联的URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Comment { get; set; }

        
    }
}
