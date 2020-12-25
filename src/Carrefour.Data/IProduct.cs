using System.Collections.Generic;
using System.Threading.Tasks;
using Carrefour.Core;
using Carrefour.Core.Domain;

namespace Carrefour.Data
{
    public interface IProduct
    {
        Task<List<Carrefour.Core.Domain.Product>> Get();

        Core.Domain.Product GetById(int Id);
    }
}