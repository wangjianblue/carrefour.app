
using Carrefour.Core;
using Carrefour.Core.Domain;
using Carrefour.Data.Dapper;
namespace Carrefour.Data
{
    public class BrowseRecordsReceives: IBrowseRecordsReceives
    {
        private readonly IDapperHelper _DapperHelper;
        public BrowseRecordsReceives(IDapperHelper DapperHelper)
        {
            _DapperHelper=DapperHelper;
        }

        public  int  Add(CustomerBrowseHistory Model)
        {

            var query ="insert into CustomerBrowseHistory values(@CustomerId,@Url,@ProductId,@Comment,@BrowseDate,@LeaveDate)";
           return _DapperHelper.Execute(query,Model);
        }

        public Customer GetCustomer()
        {
            return _DapperHelper.QueryFirst<Customer>("select TOP 100 id,Username,Email FROM Customer;");
        }
    }
}