using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tfinance
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string Batch { get; set; }
    }
}
