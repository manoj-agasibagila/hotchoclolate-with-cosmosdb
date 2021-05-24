using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Persistance.CosmosDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotchacolate.GraphqlTest.GraphQL
{
    public class ReceiptScanQueries
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Receipt> GetReceipts([Service] IReceiptsDao receiptsDao)
        {
            return receiptsDao.GetReceipts();
        }
    }
}
