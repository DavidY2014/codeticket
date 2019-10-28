using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class WproductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
