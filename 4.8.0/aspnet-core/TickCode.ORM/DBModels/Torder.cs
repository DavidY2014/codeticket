using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Torder
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string SupplierId { get; set; }
        public int BuyCount { get; set; }
        public string CouponNumber { get; set; }
        public string Batch { get; set; }
        public DateTime Createtime { get; set; }
        public int Status { get; set; }
        public string Phone { get; set; }
        public string Receiver { get; set; }
        public string ReceiverAddress { get; set; }
        public string DeliveryNumber { get; set; }
    }
}
