﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.ViewModels.Payment
{
    public class PaymentCreateViewModel
    {
        public string? Method { get; set; }
        public decimal? Total { get; set; }
        public int? PaymentCount { get; set; }
        public DateTime? PayedAt { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
    }
}
