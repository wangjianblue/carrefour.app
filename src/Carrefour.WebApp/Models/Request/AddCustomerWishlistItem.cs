using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrefour.WebApp.Models.Request
{
    public class AddCustomerWishlistItem
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public int CustomerId { get; set; } 

        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; } 

        /// <summary>
        /// 最爱清单Id
        /// </summary>
        public int CustomerWishlistTypeItemId { get; set; }
        public string CustomerUserName { get; set; }

        /// <summary>
        /// 是否到货通知
        /// </summary>
        public bool IsArrivalNotice { get; set; }

        /// <summary>
        /// 加入我的最愛选择的子规格（属性值）集合
        /// </summary>
        public string AttributeValues { get; set; }
    }
}
