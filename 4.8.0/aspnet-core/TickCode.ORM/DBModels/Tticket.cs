using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tticket
    {
        public Tticket()
        {
            Tcoupon = new HashSet<Tcoupon>();
        }

        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string Batch { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ValidityStartTime { get; set; }
        public DateTime? ValidityEndTime { get; set; }
        public string CouponRange { get; set; }
        public int? Status { get; set; }
        public string Operator { get; set; }
        public int? ActiveMethod { get; set; }
        public DateTime? ActiveTime { get; set; }
        public string Receiver { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverAddress { get; set; }
        public string ProductIdPool { get; set; }

        public virtual ICollection<Tcoupon> Tcoupon { get; set; }
    }
}
