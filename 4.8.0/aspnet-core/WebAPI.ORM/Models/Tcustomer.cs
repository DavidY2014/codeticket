using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tcustomer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SaleMan { get; set; }
        public int? SaleCount { get; set; }
        public double? Price { get; set; }
        public double? SaleAmount { get; set; }
        public int? IsSignContract { get; set; }
        public string ContractName { get; set; }
        public string ContractCode { get; set; }
    }
}
