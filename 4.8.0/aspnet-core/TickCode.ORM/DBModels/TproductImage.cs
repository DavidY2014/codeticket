using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class TproductImage
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Path { get; set; }

        public virtual Tproduct Product { get; set; }
    }
}
