using System.Threading.Tasks;
using Carrefour.Core;
using Carrefour.Core.Domain;

namespace Carrefour.Data
{
    public interface IBrowseRecordsReceives
    {
         int Add(CustomerBrowseHistory Model);

          Customer GetCustomer();

    }
}