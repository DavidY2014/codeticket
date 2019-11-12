using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class TorderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
        public string DeliveryNumber { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual TsoOrder Order { get; set; }
    }
}
