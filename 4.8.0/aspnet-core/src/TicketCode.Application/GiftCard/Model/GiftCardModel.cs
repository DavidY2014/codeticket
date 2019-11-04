using System;
using System.Collections.Generic;
using System.Text;

namespace TicketCode.GiftCard.Model
{
    public class GiftCardModel
    {
        public string No { get; set; }
        public int TotalCount { get; set; }
        public int UsedCount { get; set; }
        public DateTime ValidityTime { get; set; }
        public string Description { get; set; }
    }
}
