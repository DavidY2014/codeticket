using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Tsupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FinanceContactor { get; set; }
        public string FinancePhone { get; set; }
        public string Sender { get; set; }
        public string SenderPhone { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
