using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance.CosmosDb.Implementation
{
    public class ReceiptsDao : IReceiptsDao
    {
        private readonly Container _container;
        public ReceiptsDao(Database database, string containerName)
        {
            _container = database.GetContainer(containerName);
        }
        public IQueryable<Receipt> GetReceipts()
        {
            return _container
                .GetItemLinqQueryable<Receipt>(true);
        }
    }
}
