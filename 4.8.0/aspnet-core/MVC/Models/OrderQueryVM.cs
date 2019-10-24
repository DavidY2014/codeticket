using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class OrderQueryVM
    {
        public string orderid { get; set; }

        public string productname { get; set; }
        public string productid { get; set; }
        public string supplierid { get; set;}
        public string contact { get; set; }
        public string couponnumber { get; set; }
        public string batchnumber { get; set; }
        public DateTime createtime { get; set; }
        public string logisticsnumber { get; set; }
        public int? orderstatus { get;set; }
    }
}
