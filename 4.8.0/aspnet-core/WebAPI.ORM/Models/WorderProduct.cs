using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class WorderProduct
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
