using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TicketViewModel
    {
        public int saledticketid { get; set; }
        public string customername { get; set; }
        public string saleman { get; set; }
        public string batchnumber { get; set; }
        public string salecount { get; set; }
        public string price { get; set; }
        public string amount { get; set; }

        public string ordertime { get; set; }
        public string validitytime { get; set; }
        public string ticketnumbers { get; set; }
        public string ticketstatus { get; set; }
        public string operatorname { get;set;}
        public string operation { get; set; }
    }
}
