using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Tcustomer
    {
        public Tcustomer()
        {
            Tcoupon = new HashSet<Tcoupon>();
            TsoOrder = new HashSet<TsoOrder>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SaleManId { get; set; }
        public int SaleCount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<Tcoupon> Tcoupon { get; set; }
        public virtual ICollection<TsoOrder> TsoOrder { get; set; }
    }
}
