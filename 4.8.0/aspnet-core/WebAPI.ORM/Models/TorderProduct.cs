using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class TorderProduct
    {
        public int Id { get; set; }
        public string GiftCardId { get; set; }
        public string OriginPrice { get; set; }
        public string DiscountPrice { get; set; }
        public string Price { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual TgiftCard GiftCard { get; set; }
    }
}
