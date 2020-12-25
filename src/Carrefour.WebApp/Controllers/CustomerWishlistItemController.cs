using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrefour.Core;
using Carrefour.Core.Domain;
using Carrefour.Core.Mongodb;
using Carrefour.Core.Redis;
using Carrefour.Data;
using Carrefour.Web.Framework;
using Carrefour.WebApp.Models.Request;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Carrefour.WebApp.Controllers
{
    /// <summary>
    /// 我的最爱处理
    /// </summary>
    [ApiController]
    [SkipUserAuthorize]
    [Route("api/[controller]/[action]")]
    public class CustomerWishlistItemController : Controller
    {
        private readonly ICacheService _cacheService;
        private readonly IMongoRepository _mongoRepository;
        private readonly IProduct _product;
        private static readonly string Rediskey = "redis-customerWish-listItem-{0}";

        public CustomerWishlistItemController(ICacheService cacheService, IProduct product, IMongoRepository mongoRepository)
        {
            _cacheService = cacheService;
            _product = product;
            _mongoRepository = mongoRepository;
        }

        [HttpPost]
        public async Task<ResponseResult<CustomerWishlistItem>> Add(AddCustomerWishlistItem requestItem)
        {
            if (requestItem == null)
            {
                return ResponseResult<CustomerWishlistItem>.GenFaildResponse(message: "AddCustomerWishlistItem is null");
            }
            var product = _product.GetById(requestItem.ProductId);
            if (product == null)
            {
                return ResponseResult<CustomerWishlistItem>.GenFaildResponse(message: "product is null");
            }

            var wishlistItem = _mongoRepository.ToListAsync<CustomerWishlistItem>(p => p.CustomerId == requestItem.CustomerId && p.ProductId == requestItem.ProductId).Result;
            if (wishlistItem != null && wishlistItem.Count > 0)
            {
                return ResponseResult<CustomerWishlistItem>.GenFaildResponse(message: "CustomerWishlistItem is at list");
            }
            CustomerWishlistItem model = new CustomerWishlistItem();
            model.ProductId = requestItem.ProductId;
            model.CreatedOnUtc = DateTime.Now;
            model.CustomerId = requestItem.CustomerId;
            model.CustomerWishlistTypeItemId = requestItem.CustomerWishlistTypeItemId;
            model.CustomerUserName = requestItem.CustomerUserName;
            model.IsArrivalNotice = requestItem.IsArrivalNotice;
            model.UpdatedOnUtc = DateTime.Now;
            model.AttributeValues = requestItem.AttributeValues;
            await _mongoRepository.AddAsync(model);


            _cacheService.Remove(string.Format(Rediskey, requestItem.CustomerId));
            return ResponseResult<CustomerWishlistItem>.GenSuccessResponse();
        }
        [HttpDelete]
        public async Task<ResponseResult<CustomerWishlistItem>> Delete(string id)
        {
            ObjectId existingOid;
            ObjectId.TryParse(id, objectId: out existingOid);
 
            if (existingOid.ToString()== "000000000000000000000000")
            {
                return ResponseResult<CustomerWishlistItem>.GenFaildResponse(message: "id is error");
            } 
            var result = await _mongoRepository.GetAsync<CustomerWishlistItem>(p => p.Id == id);
            if (result == null)
            {
                return ResponseResult<CustomerWishlistItem>.GenFaildResponse(message: "CustomerWish listItem is null");
            }
            await _mongoRepository.DeleteAsync<CustomerWishlistItem>(p => p.Id == id);

            _cacheService.Remove(string.Format(Rediskey, result.CustomerId));
            return ResponseResult<CustomerWishlistItem>.GenSuccessResponse();
        }

        [HttpGet]
        public async Task<ResponseResult<List<CustomerWishlistItem>>> GetAll(int? customerId)
        {
            if (null == customerId)
            {
                return ResponseResult<List<CustomerWishlistItem>>.GenFaildResponse(message: "customerId is null");
            }
            var result = _cacheService.Get(string.Format(Rediskey, customerId),
             () =>
             {
                 return _mongoRepository.ToListAsync<CustomerWishlistItem>(p => p.CustomerId == customerId).Result;
             });


            return ResponseResult<List<CustomerWishlistItem>>.GenSuccessResponse(data: result);
        }
    }
}
