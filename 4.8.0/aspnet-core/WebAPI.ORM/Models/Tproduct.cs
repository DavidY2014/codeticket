using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tproduct
    {
        public Tproduct()
        {
            TproductImage = new HashSet<TproductImage>();
        }

        public int ProductId { get; set; }
        public string SkuCode { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<TproductImage> TproductImage { get; set; }
    }
}
