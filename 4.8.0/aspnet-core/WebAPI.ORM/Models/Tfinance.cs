using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tfinance
    {
        public int Id { get; set; }
        public string CustomerCode { get; set; }
        public string Batch { get; set; }
    }
}
