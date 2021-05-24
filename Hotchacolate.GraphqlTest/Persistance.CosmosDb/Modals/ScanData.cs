using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.CosmosDb
{
    public class ScanData
    {
        public string CampaignId { get; set; }
        public Guid Id { get; set; }
        public string Locale { get; set; }
        public string DestinationId { get; set; }
        public string ConsumerId { get; set; }
        public string UUID { get; set; }
        public string RetailerId { get; set; }
        public bool EmailPreference { get; set; }
        public string[] BrandsIds { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
