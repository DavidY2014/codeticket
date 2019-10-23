using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tproduct
    {
        public Tproduct()
        {
            TproductImage = new HashSet<TproductImage>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string SupplierId { get; set; }
        public string DeliveryArea { get; set; }
        public string Class1 { get; set; }
        public string Class2 { get; set; }
        public double? SalePrice { get; set; }
        public int? TotalStock { get; set; }
        public int? SaleAmount { get; set; }
        public int? AvailableStock { get; set; }
        public int? Status { get; set; }
        public double? Cost { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TproductImage> TproductImage { get; set; }
    }
}
