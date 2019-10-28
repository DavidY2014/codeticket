using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tcoupon
    {
        public string CouponNumber { get; set; }
        public int? TicketId { get; set; }
        public int? UseCount { get; set; }
        public int? AvailableCount { get; set; }
        public int? ActiveStatus { get; set; }
        public int? ExchangeStatus { get; set; }
        public DateTime? ValidityTime { get; set; }

        public virtual Tticket Ticket { get; set; }
    }
}
