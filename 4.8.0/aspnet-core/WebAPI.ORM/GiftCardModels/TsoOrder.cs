using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class TsoOrder
    {
        public TsoOrder()
        {
            TorderProduct = new HashSet<TorderProduct>();
        }

        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }
        public string ContactorName { get; set; }
        public string ContactorPhone { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Tcustomer Customer { get; set; }
        public virtual ICollection<TorderProduct> TorderProduct { get; set; }
    }
}
