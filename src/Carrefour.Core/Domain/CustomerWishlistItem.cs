using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Core.Domain
{
    public class CustomerWishlistItem: MongoEntity
    {
        
        /// <summary>
        /// 客户Id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户账户
        /// </summary>
        public string CustomerUserName { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 最爱清单Id
        /// </summary>
        public int CustomerWishlistTypeItemId { get; set; }

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
