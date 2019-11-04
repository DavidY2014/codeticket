using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class TgiftCard
    {
        public TgiftCard()
        {
            TorderProduct = new HashSet<TorderProduct>();
        }

        public string GiftCardId { get; set; }
        public int? CustomerId { get; set; }
        public string TicketCode { get; set; }
        public string TicketSecret { get; set; }
        public int UsedCount { get; set; }
        public int TotalCount { get; set; }
        public string Record { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; }

        public virtual Tcustomer Customer { get; set; }
        public virtual ICollection<TorderProduct> TorderProduct { get; set; }
    }
}
