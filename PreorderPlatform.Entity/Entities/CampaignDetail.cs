using System;
using System.Collections.Generic;

namespace PreorderPlatform.Entity.Entities
{
    public partial class CampaignDetail
    {
        public CampaignDetail()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? MinOrder { get; set; }
        public int? MaxOrder { get; set; }
        public int? CampaignId { get; set; }
        public decimal? Price { get; set; }

        public virtual Campaign? Campaign { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
