using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.CosmosDb
{
    public class Receipt
    {
        public string CampaignId { get; set; }
        public Guid Id { get; set; }
        public ScanData SrcReceiptScan { get; set; }
        public DateTime CreationTime { get; set; }
        public ProcessingStatus? ProcessingStatus { get; set; }
        public bool HasOffensiveContent { get; set; }
    }

}
