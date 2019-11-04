using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class TproductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string FilePath { get; set; }

        public virtual Tproduct Product { get; set; }
    }
}
