using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class SupplierCreateNewVM
    {
        public string suppliername { get; set; }
        public int? suppliertype { get; set; }
        public string companyname { get; set; }
        public string companyaddress { get; set; }
        public string financecontacter { get; set; }
        public string financephone { get; set; }
        public string deliveryname { get; set; }
        public string deliveryphone { get; set; }
        public string servicename { get; set; }
        public string servicephone { get; set; }
        public string taxpayernumber { get; set; }
        public string billheader { get; set; }
        public string openbank { get; set; }
        public string bankaccount { get; set; }
    }
}
