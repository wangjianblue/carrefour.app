USE [NewUI_Trunk]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 2020/12/25 13:09:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[ParentGroupedProductId] [int] NOT NULL,
	[VisibleIndividually] [bit] NOT NULL,
	[ProductTemplateId] [int] NOT NULL,
	[MetaKeywords] [nvarchar](400) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](400) NULL,
	[AllowCustomerReviews] [bit] NOT NULL,
	[ApprovedRatingSum] [int] NOT NULL,
	[NotApprovedRatingSum] [int] NOT NULL,
	[ApprovedTotalReviews] [int] NOT NULL,
	[NotApprovedTotalReviews] [int] NOT NULL,
	[SubjectToAcl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[Sku] [nvarchar](400) NULL,
	[ManufacturerPartNumber] [nvarchar](400) NULL,
	[Gtin] [nvarchar](400) NULL,
	[IsGiftCard] [bit] NOT NULL,
	[GiftCardTypeId] [int] NOT NULL,
	[RequireOtherProducts] [bit] NOT NULL,
	[RequiredProductIds] [nvarchar](1000) NULL,
	[AutomaticallyAddRequiredProducts] [bit] NOT NULL,
	[IsDownload] [bit] NOT NULL,
	[DownloadId] [int] NOT NULL,
	[UnlimitedDownloads] [bit] NOT NULL,
	[MaxNumberOfDownloads] [int] NOT NULL,
	[DownloadExpirationDays] [int] NULL,
	[DownloadActivationTypeId] [int] NOT NULL,
	[HasSampleDownload] [bit] NOT NULL,
	[SampleDownloadId] [int] NOT NULL,
	[HasUserAgreement] [bit] NOT NULL,
	[UserAgreementText] [nvarchar](max) NULL,
	[IsRecurring] [bit] NOT NULL,
	[RecurringCycleLength] [int] NOT NULL,
	[RecurringCyclePeriodId] [int] NOT NULL,
	[RecurringTotalCycles] [int] NOT NULL,
	[IsShipEnabled] [bit] NOT NULL,
	[IsFreeShipping] [bit] NOT NULL,
	[AdditionalShippingCharge] [decimal](18, 4) NOT NULL,
	[DeliveryDateId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[IsTaxExempt] [bit] NOT NULL,
	[TaxCategoryId] [int] NOT NULL,
	[ManageInventoryMethodId] [int] NOT NULL,
	[StockQuantity] [int] NOT NULL,
	[DisplayStockAvailability] [bit] NOT NULL,
	[DisplayStockQuantity] [bit] NOT NULL,
	[MinStockQuantity] [int] NOT NULL,
	[LowStockActivityId] [int] NOT NULL,
	[NotifyAdminForQuantityBelow] [int] NOT NULL,
	[BackorderModeId] [int] NOT NULL,
	[AllowBackInStockSubscriptions] [bit] NOT NULL,
	[OrderMinimumQuantity] [int] NOT NULL,
	[OrderMaximumQuantity] [int] NOT NULL,
	[AllowedQuantities] [nvarchar](1000) NULL,
	[AllowAddingOnlyExistingAttributeCombinations] [bit] NOT NULL,
	[DisableBuyButton] [bit] NOT NULL,
	[DisableWishlistButton] [bit] NOT NULL,
	[AvailableForPreOrder] [bit] NOT NULL,
	[PreOrderAvailabilityStartDateTimeUtc] [datetime] NULL,
	[CallForPrice] [bit] NOT NULL,
	[CustomerEntersPrice] [bit] NOT NULL,
	[MinimumCustomerEnteredPrice] [decimal](18, 4) NOT NULL,
	[MaximumCustomerEnteredPrice] [decimal](18, 4) NOT NULL,
	[HasTierPrices] [bit] NOT NULL,
	[HasDiscountsApplied] [bit] NOT NULL,
	[AvailableStartDateTimeUtc] [datetime] NULL,
	[AvailableEndDateTimeUtc] [datetime] NULL,
	[IsPresentBonus] [bit] NOT NULL,
	[BonusCount] [decimal](18, 2) NULL,
	[BonusCost] [decimal](18, 4) NULL,
	[ShippingModeIds] [nvarchar](20) NULL,
	[PresentGiftModeId] [int] NULL,
	[Rate] [decimal](18, 4) NULL,
	[FontSize] [int] NULL,
	[FontColor] [int] NULL,
	[LastPublishDate] [datetime] NULL,
	[InterestRate] [decimal](18, 4) NULL,
	[Recommend] [bit] NOT NULL,
	[RecommendDisplayOrder] [int] NOT NULL,
	[ProductStyles] [int] NULL,
	[ShortDescPictureId] [int] NULL,
	[IsAllowExchange] [bit] NOT NULL,
	[ExchangeBonusCount] [decimal](18, 4) NULL,
	[ExchangeBonusCost] [decimal](18, 4) NULL,
	[ExchangeBonusInterestRate] [decimal](18, 4) NULL,
	[RedBonusInterestRate] [decimal](18, 4) NULL,
	[ExchangeBonusCategoryId] [int] NULL,
	[BackReason] [nvarchar](max) NULL,
	[GlobalIncreasePurchasePrice] [decimal](18, 4) NULL,
	[IsLocalVendor] [bit] NULL,
	[IsHiddenProduct] [bit] NULL,
	[IsNeedCheckForBack] [bit] NULL,
	[SameDiscountProductId] [int] NULL,
	[IsAllowSellerSend] [bit] NULL,
	[IsExchangeRecommend] [bit] NULL,
	[SetCateGoryName] [nvarchar](max) NULL,
	[Published] [bit] NOT NULL,
	[UpdatedOnUtc] [datetime] NOT NULL,
	[Code] [nvarchar](20) NULL,
	[ProductNumber] [nvarchar](20) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[EnglishName] [nvarchar](100) NULL,
	[SubTitle] [nvarchar](100) NULL,
	[Specification] [nvarchar](max) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[OldPrice] [decimal](18, 4) NOT NULL,
	[ProductCost] [decimal](18, 4) NOT NULL,
	[SpecialPrice] [decimal](18, 4) NULL,
	[SpecialPriceStartDateTimeUtc] [datetime] NULL,
	[SpecialPriceEndDateTimeUtc] [datetime] NULL,
	[VendorId] [int] NULL,
	[MaxNumberOnSale] [int] NULL,
	[GiftDescription] [nvarchar](100) NULL,
	[ShippingChargeDescription] [nvarchar](100) NULL,
	[ServiceDescription] [nvarchar](100) NULL,
	[ProductCheckStateId] [int] NOT NULL,
	[BuyDescription] [nvarchar](500) NULL,
	[ShortDescription] [nvarchar](4000) NULL,
	[FullDescription] [nvarchar](4000) NULL,
	[Length] [decimal](18, 2) NOT NULL,
	[Width] [decimal](18, 2) NOT NULL,
	[Height] [decimal](18, 2) NOT NULL,
	[Weight] [decimal](18, 3) NOT NULL,
	[MaterialModel] [nvarchar](50) NULL,
	[Model] [nvarchar](100) NULL,
	[CreatedCustomerId] [int] NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOnUtc] [datetime] NOT NULL,
	[ItemMainBarcode] [nvarchar](20) NULL,
	[DeptCodeId] [int] NOT NULL,
	[SubFamilyId] [int] NOT NULL,
	[ItemCode] [nvarchar](20) NULL,
	[SubCode] [nvarchar](20) NULL,
	[UnitCode] [nvarchar](10) NULL,
	[ItemRefCodeDescEng] [nvarchar](100) NULL,
	[ItemSellCapacity] [decimal](18, 2) NULL,
	[ItemSellUnit] [nvarchar](20) NULL,
	[ItemCapacityMultiplier] [int] NOT NULL,
	[ItemStockUnitName] [nvarchar](20) NULL,
	[ItemQtyPerPack] [int] NOT NULL,
	[ItemVATFreeId] [int] NOT NULL,
	[ItemVATFree] [int] NOT NULL,
	[ItemSearchNameLocal] [nvarchar](100) NULL,
	[ItemSearchRefNameLocal] [nvarchar](100) NULL,
	[ItemStartDate] [datetime] NULL,
	[ItemStopDate] [datetime] NULL,
	[ItemTemperatureId] [int] NOT NULL,
	[ItemNutrition] [nvarchar](4000) NULL,
	[ItemStoreLimit] [nvarchar](50) NULL,
	[ItemStoreWay] [nvarchar](2000) NULL,
	[LegalDesc] [nvarchar](2000) NULL,
	[ItemComponent] [nvarchar](4000) NULL,
	[ItemVideoURL] [nvarchar](2000) NULL,
	[ItemApproveID] [nvarchar](2000) NULL,
	[ItemApproveOther] [nvarchar](2000) NULL,
	[ItemProducerAddressId] [int] NULL,
	[ItemOriginalCountry] [nvarchar](100) NULL,
	[ItemSafetyRule] [nvarchar](2000) NULL,
	[ItemPowerSpec] [nvarchar](50) NULL,
	[ItemSalePromisePeriod] [nvarchar](50) NULL,
	[ItemPromiseScope] [nvarchar](2000) NULL,
	[ItemFrameStype] [nvarchar](10) NULL,
	[IsfourWaste] [bit] NOT NULL,
	[IsItemBigHero] [bit] NOT NULL,
	[PriceRatioMaxRange] [decimal](18, 2) NULL,
	[PriceRatioMinRange] [decimal](18, 2) NULL,
	[SpecialPriceRatioMaxRange] [decimal](18, 2) NULL,
	[SpecialPriceRatioMinRange] [decimal](18, 2) NULL,
	[ManufacturerId] [int] NULL,
	[CommodityInternalCategoryId] [int] NULL,
	[AdminComment] [nvarchar](max) NULL,
	[ShowOnHomePage] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[ItemProducerId] [int] NULL,
	[WeightDescription] [nvarchar](50) NULL,
	[WeightUnitId] [int] NOT NULL,
	[DeletedTypeId] [int] NOT NULL,
	[AppTag] [nvarchar](50) NULL,
	[C_Des] [nvarchar](200) NULL,
	[E_Des] [nvarchar](200) NULL,
	[SelfSetting] [nvarchar](200) NULL,
	[ControlStock] [bit] NOT NULL,
	[SafetyStockQuantity] [int] NULL,
	[UpdateCustomerId] [int] NULL,
	[SaleAttributes] [varchar](20) NULL,
	[GiftSendTypeId] [int] NULL,
	[IsShowFront] [bit] NOT NULL,
	[ProductIntro] [nvarchar](500) NULL,
	[ProductClassificationId] [int] NULL,
	[CommodityClassificationId] [int] NULL,
	[TempSpecialPrice] [decimal](18, 4) NULL,
	[TempSpecialPriceStartDateTimeUtc] [datetime] NULL,
	[TempSpecialPriceEndDateTimeUtc] [datetime] NULL,
	[MinNumberOnSale] [int] NOT NULL,
	[CanJoinPromotion] [bit] NOT NULL,
	[CanOffByDiscount] [bit] NOT NULL,
	[CanJoinMultipleFullDiscountSend] [bit] NOT NULL,
	[MultipleSelectValue] [int] NOT NULL,
	[IsControlStoreFrontStock] [bit] NOT NULL,
	[TempPrice] [decimal](18, 4) NULL,
	[CanSynchronize] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70) ON [FG_Data]
) ON [FG_Data] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [WeightUnitId]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [C_Des]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [E_Des]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('') FOR [SelfSetting]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [ControlStock]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [IsShowFront]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [MinNumberOnSale]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [CanJoinPromotion]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [CanOffByDiscount]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [CanJoinMultipleFullDiscountSend]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [MultipleSelectValue]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [IsControlStoreFrontStock]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ((1)) FOR [CanSynchronize]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_CommodityInternalCategory] FOREIGN KEY([CommodityInternalCategoryId])
REFERENCES [dbo].[CommodityInternalCategory] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_CommodityInternalCategory]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_ItemProducer] FOREIGN KEY([ItemProducerId])
REFERENCES [dbo].[ManufacturerImporter] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_ItemProducer]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_ItemProducerAddress] FOREIGN KEY([ItemProducerAddressId])
REFERENCES [dbo].[ManufacturerImporterAddress] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_ItemProducerAddress]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_Manufacturer] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_Manufacturer]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_ShortDescPicture] FOREIGN KEY([ShortDescPictureId])
REFERENCES [dbo].[Picture] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_ShortDescPicture]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [Product_Vendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendor] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [Product_Vendor]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'…Ã∆∑ºÚΩÈ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductIntro'
GO


