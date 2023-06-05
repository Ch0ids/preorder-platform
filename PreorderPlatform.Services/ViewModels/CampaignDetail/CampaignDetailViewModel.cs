using PreorderPlatform.Service.ViewModels.Business;
using PreorderPlatform.Service.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.CampaignDetail
{
    public class CampaignDetailViewModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? MinOrder { get; set; }
        public int? MaxOrder { get; set; }
        public int? CampaignId { get; set; }
        public decimal? Price { get; set; }
        public virtual ProductViewModel? Product { get; set; }

    }
}
