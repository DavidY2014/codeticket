using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tsupplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string FinanceContactor { get; set; }
        public string FinancePhone { get; set; }
        public string Sender { get; set; }
        public string SenderPhone { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string AfterMarketer { get; set; }
        public string AfterMarketPhone { get; set; }
    }
}
