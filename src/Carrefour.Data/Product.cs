
using System.Collections.Generic;
using System.Threading.Tasks;
using Carrefour.Core;
using Carrefour.Core.Domain;
using Carrefour.Data.Dapper;
namespace Carrefour.Data
{
    public class Product : IProduct
    {
        private readonly IDapperHelper _DapperHelper;

        public Product(IDapperHelper dapperHelper)
        {
            _DapperHelper = dapperHelper;
        }
        public async Task<List<Carrefour.Core.Domain.Product>> Get()
        {
            return await _DapperHelper.QueryAsync<Carrefour.Core.Domain.Product>("select top 100 ProductTypeId,ProductNumber,Code,Name,SubTitle,Price,Width,Height,AdminComment FROM Product p with(nolock)  where p.deleted=0;");
        }

        public Core.Domain.Product GetById(int Id)
        {
            return _DapperHelper.QueryFirst<Core.Domain.Product>($"select top 1 ProductTypeId,ProductNumber,Code,Name,SubTitle,Price,Width,Height,AdminComment FROM Product p with(nolock)  where p.deleted=0 and Id={Id};");
        }
    }
}