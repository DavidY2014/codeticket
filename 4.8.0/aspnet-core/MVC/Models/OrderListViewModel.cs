using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class OrderListViewModel
    {
        public string orderid { get; set; }
        public string productname { get; set; }
        public string productid { get; set; }
        public string supplier { get; set; }
        public int buycount { get; set; }
        public string ticketnumber { get; set; }
        public string batchnumber { get; set; }
        public DateTime createtime { get; set; }
        public int orderstatus { get; set; }
        public string contact { get; set; }
        public string receiver { get; set; }
        public string receiveraddress { get; set; }
        public string logisticsnumber { get; set; }
    }
}
