using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.Campaign.Request
{
    public class CampaignSearchRequest
    {
        public string? Name { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public bool? Status { get; set; }
        public int? BusinessName { get; set; }
    }
}
