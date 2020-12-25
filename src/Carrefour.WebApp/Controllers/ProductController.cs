using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrefour.Core;
using Carrefour.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product = Carrefour.Core.Domain.Product;

namespace Carrefour.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SkipUserAuthorize]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<ResponseResult<List<Product>>> Get()
        {
            //http://surveyback.ehuatek.com/jeecg-boot//sys/login



            var result = await _product.Get();
            if (result == null)
            {
                return ResponseResult<List<Product>>.GenFaildResponse();
            }
            return ResponseResult<List<Product>>.GenSuccessResponse(data: result);
        }
    }
}
