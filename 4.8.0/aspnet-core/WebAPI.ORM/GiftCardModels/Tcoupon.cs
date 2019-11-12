using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Tcoupon
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int CustomerId { get; set; }
        public string BelongBatch { get; set; }
        public DateTime VerifyTime { get; set; }
        public int AviableTimes { get; set; }
        public int TotalTimes { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Tcustomer Customer { get; set; }
    }
}
