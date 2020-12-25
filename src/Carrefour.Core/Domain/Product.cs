using System;
using System.Collections.Generic;
using System.Text;

namespace Carrefour.Core.Domain
{
    public class Product
    {
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the parent product identifier. It's used to identify associated products (only with "grouped" products)
        /// </summary>
        public int ParentGroupedProductId { get; set; }

        /// <summary>
        /// Gets or sets the values indicating whether this product is visible in catalog or search results.
        /// It's used when this product is associated to some "grouped" one
        /// This way associated products could be accessed/added/etc only from a grouped product details page
        /// </summary>
        public bool VisibleIndividually { get; set; }
        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }

        /// <summary>
        /// Gets or sets the SKU
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 商品库存（从Ful档读入）   庫存 接口用
        /// </summary>
        public int StockQuantity { get; set; }

         

        /// <summary>
        /// 赠送方式
        /// </summary>
        public int? PresentGiftModeId { get; set; }
 

        /// <summary>
        /// 最后一次上架时间
        /// </summary>
        public DateTime? LastPublishDate { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool Recommend { get; set; }

        /// <summary>
        /// 推荐排序
        /// </summary>
        public int RecommendDisplayOrder { get; set; }
        /// <summary>
        /// 商品特色图片Id
        /// </summary>
        public int? ShortDescPictureId { get; set; }

 

        /// <summary>
        /// 是否平台运营方
        /// </summary>
        public bool? IsLocalVendor { get; set; }

        /// <summary>
        /// 是否是隱藏商品
        /// </summary>
        public bool? IsHiddenProduct { get; set; }



        ///// <summary>
        ///// Gets or sets the collection of ProductCategory
        ///// </summary>
        //public virtual ICollection<ProductBrandCategory> BrandCategories
        //{
        //    get { return _brandCategories ?? (_brandCategories = new List<ProductBrandCategory>()); }
        //    protected set { _brandCategories = value; }
        //}
        ///// <summary>
        ///// 商品分期集合
        ///// </summary>
        //public virtual ICollection<ProductStageType> ProductStageTypes
        //{
        //    get { return _productStageTypes ?? (_productStageTypes = new List<ProductStageType>()); }
        //    protected set { _productStageTypes = value; }
        //}
        public int SalesVolumeNumber { get; set; }
        #region 家乐福沿用字段
        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets the date and time of product update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 商品编码 单品内部代号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 單品長代號* （13）
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// 商品名称  40
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 英文名称 40
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// 副标题 中文副品名 100
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 產品規格 100
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// jl售价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品成本(含税)
        /// </summary>
        public decimal OldPrice { get; set; }

        /// <summary>
        /// 商品成本（不含税） jl进价（未税）
        /// </summary>
        public decimal ProductCost { get; set; }

        /// <summary>
        /// jl特价
        /// </summary>
        public decimal? SpecialPrice { get; set; }

        ///// <summary>
        ///// 特价是否有效
        ///// </summary>
        //public bool IsSpecialPriceValid
        //{
        //    get 
        //    {
        //        var dtNow = CommonHelper.GetDateTimeNow();
        //        if (SpecialPriceStartDateTimeUtc.HasValue && SpecialPriceEndDateTimeUtc.HasValue && SpecialPrice.HasValue)
        //        {
        //            return dtNow >= SpecialPriceStartDateTimeUtc.Value && dtNow <= SpecialPriceEndDateTimeUtc.Value;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //}

        /// <summary>
        /// jl促销开始时间
        /// </summary>
        public DateTime? SpecialPriceStartDateTimeUtc { get; set; }

        /// <summary>
        /// jl促销结束时间
        /// </summary>
        public DateTime? SpecialPriceEndDateTimeUtc { get; set; }

        /// <summary>
        /// 供应商Id  
        /// </summary>
        public int? VendorId { get; set; }

 

        /// <summary>
        /// 个人最大购买量
        /// </summary>
        public int? MaxNumberOnSale { get; set; }

        /// <summary>
        /// 赠品說明（富文本）100
        /// </summary>
        public string GiftDescription { get; set; }

        /// <summary>
        /// 运费說明 运送說明 100
        /// </summary>
        public string ShippingChargeDescription { get; set; }
        /// <summary>
        /// 售后服務說明 100
        /// </summary>
        public string ServiceDescription { get; set; }

        /// <summary>
        /// 审核状态Id
        /// </summary>
        public int ProductCheckStateId { get; set; }

      
        /// <summary>
        /// 购买說明 退换货說明 500
        /// </summary>
        public string BuyDescription { get; set; }
        /// <summary>
        /// 商品特色 說明 4096
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// 产品特色 商品完整說明4096
        /// </summary>
        public string FullDescription { get; set; }

        /// <summary>
        /// jlf长
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// jlf宽
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// jlf高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// jlf重量(含包装)
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        ///材积大小 颜色 40
        /// </summary>
        public string MaterialModel { get; set; }

        /// <summary>
        /// 规格值（颜色，尺寸等） 产品型号 100
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 创建用户Id
        /// </summary>
        public int? CreatedCustomerId { get; set; }
        /// <summary>
        /// 更新用户Id
        /// </summary>
        public int? UpdateCustomerId { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
  

        /// <summary>
        /// 1單品主要條碼* 13
        /// </summary>
        public string ItemMainBarcode { get; set; }
        /// <summary>
        ///2單品部門代號* 2 关联商品内部分类 存id
        /// </summary>
        public int DeptCodeId { get; set; }
        /// <summary>
        ///3單品小分類代號*
        /// </summary>
        public int SubFamilyId { get; set; }
        /// <summary>
        /// 4單品編號* 6
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        ///5單品細目編號* 3
        /// </summary>
        public string SubCode { get; set; }
        /// <summary>
        ///6單品銷售碼(入數)* 2
        /// </summary>
        public string UnitCode { get; set; }
        /// <summary>
        ///7英文副品名* 100
        /// </summary>
        public string ItemRefCodeDescEng { get; set; }
        /// <summary>
        ///8容量(重量)
        /// </summary>
        public decimal? ItemSellCapacity { get; set; }
        /// <summary>
        ///9容量單位 20
        /// </summary>
        public string ItemSellUnit { get; set; }
        /// <summary>
        ///10容量入數
        /// </summary>
        public int ItemCapacityMultiplier { get; set; }
        /// <summary>
        ///11庫存單位名稱* 10
        /// </summary>
        public string ItemStockUnitName { get; set; }
        /// <summary>
        ///12包裝入數
        /// </summary>
        public int ItemQtyPerPack { get; set; }
        /// <summary>
        ///13免稅*
        /// </summary>
        public int ItemVATFreeId { get; set; }
         
        /// <summary>
        ///14建議適用於網路關鍵字搜尋之中文品名(視需求修改) 100
        /// </summary>
        public string ItemSearchNameLocal { get; set; }
        /// <summary>
        ///15建議適用於網路關鍵字搜尋之中文副品名(視需求修改)100
        /// </summary>
        public string ItemSearchRefNameLocal { get; set; }
        /// <summary>
        ///16單品下架開始日期* （原始需求是：單品生效日期。業務已於02/06發生變更）
        /// </summary>
        public DateTime? ItemStartDate { get; set; }
        /// <summary>
        ///17單品下架結束日期*（原始需求是：單品下市日期。業務已於02/06發生變更）
        /// </summary>
        public DateTime? ItemStopDate { get; set; }
        /// <summary>
        ///18保存溫層*
        /// </summary>
        public int ItemTemperatureId { get; set; }
       
        /// <summary>
        ///19營養標示 1024
        /// </summary>
        public string ItemNutrition { get; set; }
        /// <summary>
        ///20保存期限20
        /// </summary>
        public string ItemStoreLimit { get; set; }
        /// <summary>
        ///21保存方式20
        /// </summary>
        public string ItemStoreWay { get; set; }
        /// <summary>
        ///22法律規定及注意事項1024
        /// </summary>
        public string LegalDesc { get; set; }
        /// <summary>
        ///23產品成分及食品添加物1024
        /// </summary>
        public string ItemComponent { get; set; }
        /// <summary>
        ///24若有影片檔提供時, 請貼上YOUTUBE之影音URL檔之複製碼1024
        /// </summary>
        public string ItemVideoURL { get; set; }
        /// <summary>
        ///25"產品核准字號(衛署妝廣字號)"20
        /// </summary>
        public string ItemApproveID { get; set; }
        /// <summary>
        ///26其他証明100
        /// </summary>
        public string ItemApproveOther { get; set; }
        /// <summary>
        ///27制造商地址
        /// </summary>
        public int? ItemProducerAddressId { get; set; }
        /// <summary>
        ///27制造商地址
        /// </summary>
 
        /// <summary>
        ///28商品來源(產地/國家)20
        /// </summary>
        public string ItemOriginalCountry { get; set; }
        /// <summary>
        ///29產品責任險1000
        /// </summary>
        public string ItemSafetyRule { get; set; }
        /// <summary>
        ///30電源規格20
        /// </summary>
        public string ItemPowerSpec { get; set; }
        /// <summary>
        ///31保固期限20
        /// </summary>
        public string ItemSalePromisePeriod { get; set; }
        /// <summary>
        ///32保固範圍20
        /// </summary>
        public string ItemPromiseScope { get; set; }
        /// <summary>
        /// 33设置加价购分类名称 商品页面风格1
        /// </summary>
        public string ItemFrameStype { get; set; }
        /// <summary>
        /// 34是否是廢四機
        /// </summary>
        public bool IsfourWaste { get; set; }
        /// <summary>
        /// 35是否英雄產品
        /// </summary>
        public bool IsItemBigHero { get; set; }
        /// <summary>
        /// 36售價百分比值範圍最大值
        /// </summary>
        public decimal? PriceRatioMaxRange { get; set; }
        /// <summary>
        /// 37售價百分比值範圍最低值
        /// </summary>
        public decimal? PriceRatioMinRange { get; set; }
        /// <summary>
        /// 38特價百分比值範圍最大值
        /// </summary>
        public decimal? SpecialPriceRatioMaxRange { get; set; }
        /// <summary>
        /// 39特價百分比值範圍最低值
        /// </summary>
        public decimal? SpecialPriceRatioMinRange { get; set; }
        ///// <summary>
        ///// 产品品牌
        ///// </summary>
        //public int? ManufacturerId { get; set; }
        ///// <summary>
        ///// 产品品牌
        ///// </summary>
        //public virtual Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// 商品內部分類
        /// </summary>
        public int? CommodityInternalCategoryId { get; set; }
 

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show the product on home page
        /// </summary>
        public bool ShowOnHomePage { get; set; }
        /// <summary>
        /// Gets or sets a display order.
        /// This value is used when sorting associated products (used with "grouped" products)
        /// This value is used when sorting home page products
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// 审核不通过原因
        /// </summary>
        public string ReasonForNopass { get; set; }
        #endregion

        /// <summary>
        /// 邏輯刪除類型Id
        /// </summary>
        public int DeletedTypeId { get; set; }

       

        /// <summary>
        /// 重量描述单位
        /// </summary>
        public string WeightDescription { get; set; }

        /// <summary>
        ///重量单位
        /// </summary>
        public int WeightUnitId { get; set; }
     

        /// <summary>
        /// 商品分级
        /// </summary>
        public int? ProductClassificationId { get; set; }

    

        /// <summary>
        /// 商品分类类型
        /// </summary>
        public int? CommodityClassificationId { get; set; }

      

        /// <summary>
        /// App標籤
        /// </summary>
        public string AppTag { get; set; }
        /// <summary>
        /// C_Des, 群組新增字段
        /// </summary>
        public string C_Des { get; set; }

        /// <summary>
        /// E_Des, 群組新增字段
        /// </summary>
        public string E_Des { get; set; }

        /// <summary>
        /// 自訂規格, 群組新增字段
        /// </summary>
        public string SelfSetting { get; set; }

        

        //private ICollection<RewardProduct> _rewardProducts;
        //public virtual ICollection<RewardProduct> RewardProducts
        //{
        //    get { return _rewardProducts ?? (_rewardProducts = new List<RewardProduct>()); }
        //    set
        //    {
        //        _rewardProducts = value;
        //    }
        //}

        //private ICollection<Reward> _rewards;
        //public virtual ICollection<Reward> Rewards
        //{
        //    get { return _rewards ?? (_rewards = new List<Reward>()); }
        //    protected set { _rewards = value; }
        //}
        /// <summary>
        /// 商品简介
        /// </summary>
        public string ProductIntro { get; set; }

        /// <summary>
        /// 贈品贈送方式 全部或多選一
        /// </summary>
        public int? GiftSendTypeId { get; set; }
    


        /// <summary>
        /// 控制是否前台顯示  加價購商品設置為false就不能當做普通商品了  搜索 詳情都不顯示
        /// </summary>
        public bool IsShowFront { get; set; }

        ///// <summary>
        ///// 是否加价购商品
        ///// </summary>
        //[NotMapped]
        //public bool IsIncreasePurchase { get; set; }
        ///// <summary>
        ///// 是否必选
        ///// </summary>
        //[NotMapped]
        //public bool IsNecessary { get; set; }
        ///// <summary>
        ///// 主商品id
        ///// </summary>
        //[NotMapped]
        //public int relatedMasterProductId { get; set; }
        ///// <summary>
        ///// 非必选的最大购买量
        ///// </summary>
        //[NotMapped]
        //public int IncreasePurchaseMaxNumberOnSale { get; set; }

     

        /// <summary>
        /// 商品是否可以参加站上行销活动
        /// </summary>
        public bool CanJoinPromotion { get; set; }

        /// <summary>
        /// 商品是否可以被折价券或折扣码抵折。
        /// </summary>
        public bool CanOffByDiscount { get; set; }

        /// <summary>
        /// 个人最小购买量
        /// </summary>
        public int MinNumberOnSale { get; set; }

        /// <summary>
        /// 是否可同時參加多個滿額折送活動
        /// </summary>
        public bool CanJoinMultipleFullDiscountSend { get; set; }

        #region 删除字段
        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books).
        /// </summary>
        public string Gtin { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is gift card
        /// </summary>
        public bool IsGiftCard { get; set; }
        /// <summary>
        /// Gets or sets a value of used product template identifier
        /// </summary>
        public int ProductTemplateId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product allows customer reviews
        /// </summary>
        public bool AllowCustomerReviews { get; set; }
        /// <summary>
        /// Gets or sets the rating sum (approved reviews)
        /// </summary>
        public int ApprovedRatingSum { get; set; }
        /// <summary>
        /// Gets or sets the rating sum (not approved reviews)
        /// </summary>
        public int NotApprovedRatingSum { get; set; }
        /// <summary>
        /// Gets or sets the total rating votes (approved reviews)
        /// </summary>
        public int ApprovedTotalReviews { get; set; }
        /// <summary>
        /// Gets or sets the total rating votes (not approved reviews)
        /// </summary>
        public int NotApprovedTotalReviews { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer part number
        /// </summary>
        public string ManufacturerPartNumber { get; set; }
        /// <summary>
        /// Gets or sets the gift card type identifier
        /// </summary>
        public int GiftCardTypeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product requires that other products are added to the cart (Product X requires Product Y)
        /// </summary>
        public bool RequireOtherProducts { get; set; }
        /// <summary>
        /// Gets or sets a required product identifiers (comma separated)
        /// </summary>
        public string RequiredProductIds { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether required products are automatically added to the cart
        /// </summary>
        public bool AutomaticallyAddRequiredProducts { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is download
        /// </summary>
        public bool IsDownload { get; set; }
        /// <summary>
        /// Gets or sets the download identifier
        /// </summary>
        public int DownloadId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this downloadable product can be downloaded unlimited number of times
        /// </summary>
        public bool UnlimitedDownloads { get; set; }
        /// <summary>
        /// Gets or sets the maximum number of downloads
        /// </summary>
        public int MaxNumberOfDownloads { get; set; }
        /// <summary>
        /// Gets or sets the number of days during customers keeps access to the file.
        /// </summary>
        public int? DownloadExpirationDays { get; set; }
        /// <summary>
        /// Gets or sets the download activation type
        /// </summary>
        public int DownloadActivationTypeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product has a sample download file
        /// </summary>
        public bool HasSampleDownload { get; set; }
        /// <summary>
        /// Gets or sets the sample download identifier
        /// </summary>
        public int SampleDownloadId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product has user agreement
        /// </summary>
        public bool HasUserAgreement { get; set; }
        /// <summary>
        /// Gets or sets the text of license agreement
        /// </summary>
        public string UserAgreementText { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is recurring
        /// </summary>
        public bool IsRecurring { get; set; }
        /// <summary>
        /// Gets or sets the cycle length
        /// </summary>
        public int RecurringCycleLength { get; set; }
        /// <summary>
        /// Gets or sets the cycle period
        /// </summary>
        public int RecurringCyclePeriodId { get; set; }
        /// <summary>
        /// Gets or sets the total cycles
        /// </summary>
        public int RecurringTotalCycles { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is ship enabled
        /// </summary>
        public bool IsShipEnabled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the entity is free shipping
        /// </summary>
        public bool IsFreeShipping { get; set; }
        /// <summary>
        /// Gets or sets the additional shipping charge
        /// </summary>
        public decimal AdditionalShippingCharge { get; set; }
        /// <summary>
        /// Gets or sets a delivery date identifier
        /// </summary>
        public int DeliveryDateId { get; set; }
        /// <summary>
        /// Gets or sets a warehouse identifier
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the product is marked as tax exempt
        /// </summary>
        public bool IsTaxExempt { get; set; }
        /// <summary>
        /// Gets or sets the tax category identifier
        /// </summary>
        public int TaxCategoryId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating how to manage inventory
        /// </summary>
        public int ManageInventoryMethodId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock availability
        /// </summary>
        public bool DisplayStockAvailability { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to display stock quantity
        /// </summary>
        public bool DisplayStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the minimum stock quantity
        /// </summary>
        public int MinStockQuantity { get; set; }
        /// <summary>
        /// Gets or sets the low stock activity identifier
        /// </summary>
        public int LowStockActivityId { get; set; }
        /// <summary>
        /// Gets or sets the quantity when admin should be notified
        /// </summary>
        public int NotifyAdminForQuantityBelow { get; set; }
        /// <summary>
        /// Gets or sets a value backorder mode identifier
        /// </summary>
        public int BackorderModeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to back in stock subscriptions are allowed
        /// </summary>
        public bool AllowBackInStockSubscriptions { get; set; }
        /// <summary>
        /// Gets or sets the order minimum quantity
        /// </summary>
        public int OrderMinimumQuantity { get; set; }
        /// <summary>
        /// Gets or sets the order maximum quantity
        /// </summary>
        public int OrderMaximumQuantity { get; set; }
        /// <summary>
        /// Gets or sets the comma seperated list of allowed quantities. null or empty if any quantity is allowed
        /// </summary>
        public string AllowedQuantities { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether we allow adding to the cart/wishlist only attribute combinations that exist and have stock greater than zero.
        /// This option is used only when we have "manage inventory" set to "track inventory by product attributes"
        /// </summary>
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to disable buy (Add to cart) button
        /// </summary>
        public bool DisableBuyButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to disable "Add to wishlist" button
        /// </summary>
        public bool DisableWishlistButton { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this item is available for Pre-Order
        /// </summary>
        public bool AvailableForPreOrder { get; set; }
        /// <summary>
        /// Gets or sets the start date and time of the product availability (for pre-order products)
        /// </summary>
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
        /// </summary>
        public bool CallForPrice { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether a customer enters price
        /// </summary>
        public bool CustomerEntersPrice { get; set; }
        /// <summary>
        /// Gets or sets the minimum price entered by a customer
        /// </summary>
        public decimal MinimumCustomerEnteredPrice { get; set; }
        /// <summary>
        /// Gets or sets the maximum price entered by a customer
        /// </summary>
        public decimal MaximumCustomerEnteredPrice { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this product has tier prices configured
        /// <remarks>The same as if we run TierPrices.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load tier prices navifation property
        /// </remarks>
        /// </summary>
        public bool HasTierPrices { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this product has discounts applied
        /// <remarks>The same as if we run AppliedDiscounts.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load Applied Discounts navifation property
        /// </remarks>
        /// </summary>
        public bool HasDiscountsApplied { get; set; }
         
        /// <summary>
        /// 是否赠送红利
        /// </summary>
        public bool IsPresentBonus { get; set; }
        /// <summary>
        /// 赠送红利点数
        /// </summary>
        public decimal? BonusCount { get; set; }
        /// <summary>
        /// 红利成本
        /// </summary>
        public decimal? BonusCost { get; set; }
        /// <summary>
        /// 物流方式Ids,eg 0 or 0,2
        /// </summary>
        public string ShippingModeIds { get; set; }
       
        /// <summary>
        /// 分类毛利率
        /// </summary>
        public decimal? Rate { get; set; }
        /// <summary>
        /// 字体大小
        /// </summary>
        public int? FontSize { get; set; }
         
        /// <summary>
        /// 字体颜色
        /// </summary>
        public int? FontColor { get; set; }
       
        /// <summary>
        /// 是否库存控制
        /// </summary>
        public bool ControlStock { get; set; }
        /// <summary>
        /// 安全库存
        /// </summary>
        public int? SafetyStockQuantity { get; set; }
        /// <summary>
        /// 贩售属性
        /// </summary>
        public string SaleAttributes { get; set; }
        /// <summary>
        /// 是否允许红利兑换
        /// </summary>
        public bool IsAllowExchange { get; set; }
        /// <summary>
        /// 兑换所需红利点数
        /// </summary>
        public decimal? ExchangeBonusCount { get; set; }
        /// <summary>
        /// 紅利成本
        /// </summary>
        public decimal? ExchangeBonusCost { get; set; }
        /// <summary>
        /// 紅利成本毛利率
        /// </summary>
        public decimal? ExchangeBonusInterestRate { get; set; }
        /// <summary>
        /// 紅利專區管理中的紅利成本毛利率
        /// </summary>
        public decimal? RedBonusInterestRate { get; set; }
        /// <summary>
        /// 红利兑换所在分类
        /// </summary>
        public int? ExchangeBonusCategoryId { get; set; }
        /// <summary>
        /// 下架原因
        /// </summary>
        public string BackReason { get; set; }
        /// <summary>
        /// 计算所得商品毛利率
        /// </summary>
        public decimal? InterestRate { get; set; }
        /// <summary>
        /// 商品样式
        /// </summary>
        public int? ProductStyles { get; set; }
        /// <summary>
        /// 全局加价购价格
        /// </summary>
        public decimal? GlobalIncreasePurchasePrice { get; set; }
        /// <summary>
        /// 商品退訂/退貨是否需要客服檢核
        /// </summary>
        public bool? IsNeedCheckForBack { get; set; }
        /// <summary>
        /// 同类折扣商品
        /// </summary>
        public int? SameDiscountProductId { get; set; }
        public bool? IsAllowSellerSend { get; set; }
        public bool? IsExchangeRecommend { get; set; }
        public string SetCateGoryName { get; set; }

        //有外鍵刪不掉 後面刪除 
        /// <summary>
        ///27制造商地址
        /// </summary>
        public int? ItemProducerId { get; set; }
 
        /// <summary>
        /// Gets or sets a value indicating whether the entity is subject to ACL
        /// </summary>
        public bool SubjectToAcl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is limited/restricted to certain stores
        /// </summary>
        public bool LimitedToStores { get; set; }
        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
        public DateTime? AvailableStartDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
        public DateTime? AvailableEndDateTimeUtc { get; set; }
        #endregion
    }
}
