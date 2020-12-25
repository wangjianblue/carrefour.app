using System;

namespace Carrefour.Core
{
    public class CustomerBrowseHistory:MongoEntity
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

        /// <summary>
        /// 浏览时间
        /// </summary>
        public DateTime BrowseDate { get; set; }

        /// <summary>
        /// 离开时间
        /// </summary>
        public DateTime LeaveDate { get; set; }
    }
}
