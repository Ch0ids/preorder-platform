﻿using System;
using System.Collections.Generic;

namespace PreorderPlatform.Entity.Entities
{
    public partial class BusinessPaymentCredential
    {
        public int Id { get; set; }
        public int? BusinessId { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankRecipientName { get; set; }
        public string? MomoApiKey { get; set; }
        public string? MomoPartnerCode { get; set; }
        public string? MomoAccessToken { get; set; }
        public string? MomoSecretToken { get; set; }
        public bool? IsMomoActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Status { get; set; }

        public virtual Business? Business { get; set; }
    }
}
