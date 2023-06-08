﻿using PreorderPlatform.Service.ViewModels.Business;
using PreorderPlatform.Service.ViewModels.CampaignDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.Campaign.Response
{
    public class CampaignInforResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? DepositPercent { get; set; }
        public DateTime? ExpectedShippingDate { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? Status { get; set; }
        public int? OwnerId { get; set; }
        public int? BusinessId { get; set; }

        public string? BusinessName { get; set; }

        public virtual BusinessViewModel? Business { get; set; }

        public virtual ICollection<CampaignDetailViewModel> CampaignDetails { get; set; }
    }
}
