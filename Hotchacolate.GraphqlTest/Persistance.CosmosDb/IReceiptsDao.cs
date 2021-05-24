using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.CosmosDb
{
    public interface IReceiptsDao
    {
        IQueryable<Receipt> GetReceipts();
    }
}
