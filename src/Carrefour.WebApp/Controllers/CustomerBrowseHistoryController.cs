using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Carrefour.Core;
using Carrefour.Core.Domain;
using Carrefour.Core.Mongodb;
using Carrefour.Core.Redis;
using Carrefour.Data;
using Carrefour.WebApp.Models.Request;
using MongoDB.Bson;

namespace Carrefour.WebApp.Controllers
{
    /// <summary>
    /// 个人浏览记录
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [SkipUserAuthorize]
    public class CustomerBrowseHistoryController : Controller
    {

        private readonly ICacheService _cacheService;
        private readonly IMongoRepository _mongoRepository;
        private readonly IProduct _product;
        private static readonly string Rediskey = "redis-browse-history-{0}";

        public CustomerBrowseHistoryController(ICacheService cacheService, IProduct product, IMongoRepository mongoRepository)
        {
            _cacheService = cacheService;
            _product = product;
            _mongoRepository = mongoRepository;
        }
        /// <summary>
        /// 新增我的浏览记录
        /// </summary>
        /// <param name="requestItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseResult<CustomerBrowseHistory>> Add(AddCustomerBrowseHistory requestItem)
        {
            if (requestItem == null)
            {
                return ResponseResult<CustomerBrowseHistory>.GenFaildResponse(message: "AddCustomerBrowseHistory is null");
            }
            var product = _product.GetById(requestItem.ProductId);
            if (product == null)
            {
                return ResponseResult<CustomerBrowseHistory>.GenFaildResponse(message: "product is null");
            }

            var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute,0);
            var browseHistory = _mongoRepository.ToListAsync<CustomerBrowseHistory>(p =>
                p.CustomerId == requestItem.CustomerId &&
                p.ProductId == requestItem.ProductId &&
                p.BrowseDate > now &&
                p.BrowseDate < now.AddMinutes(1)
                ).Result;
            if (browseHistory != null && browseHistory.Count > 0)
            {
                return ResponseResult<CustomerBrowseHistory>.GenFaildResponse(message: "CustomerBrowseHistory is at list");
            }
            CustomerBrowseHistory model = new CustomerBrowseHistory();
            model.ProductId = requestItem.ProductId;
            model.BrowseDate = DateTime.Now;
            model.CustomerId = requestItem.CustomerId;
            model.Comment = requestItem.Comment;
            model.LeaveDate = DateTime.Now;
            model.Url = requestItem.Url;
            await _mongoRepository.AddAsync(model);


            _cacheService.Remove(string.Format(Rediskey, requestItem.CustomerId));
            return ResponseResult<CustomerBrowseHistory>.GenSuccessResponse();
        }
        /// <summary>
        /// 删除我的浏览记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ResponseResult<CustomerBrowseHistory>> Delete(string id)
        {
            ObjectId existingOid;
            ObjectId.TryParse(id, objectId: out existingOid);

            if (existingOid.ToString() == "000000000000000000000000")
            {
                return ResponseResult<CustomerBrowseHistory>.GenFaildResponse(message: "id is error");
            }
            var result = await _mongoRepository.GetAsync<CustomerBrowseHistory>(p => p.Id == id);
            if (result == null)
            {
                return ResponseResult<CustomerBrowseHistory>.GenFaildResponse(message: "CustomerBrowseHistory is null");
            }
            await _mongoRepository.DeleteAsync<CustomerBrowseHistory>(p => p.Id == id);

            _cacheService.Remove(string.Format(Rediskey, result.CustomerId));
            return ResponseResult<CustomerBrowseHistory>.GenSuccessResponse();
        }

        /// <summary>
        /// 获取我的浏览记录
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseResult<List<CustomerBrowseHistory>>> GetAll(int? customerId)
        {
            if (null == customerId)
            {
                return ResponseResult<List<CustomerBrowseHistory>>.GenFaildResponse(message: "customerId is null");
            }
            var result = _cacheService.Get(string.Format(Rediskey, customerId),
             () =>
             {
                 return _mongoRepository.ToListAsync<CustomerBrowseHistory>(p => p.CustomerId == customerId).Result;
             });


            return ResponseResult<List<CustomerBrowseHistory>>.GenSuccessResponse(data: result);
        }
    }
}
