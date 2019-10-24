using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
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
