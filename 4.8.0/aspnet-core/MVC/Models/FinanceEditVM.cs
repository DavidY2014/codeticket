using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class FinanceEditVM
    {
        public string custormname { get; set; }
        public string salename { get; set; }
        public string salecount { get; set; }
        public string innercount { get; set; }
        public string saleprice { get; set; }
        public string saletotalamount { get; set; }
        public string issigncontract { get; set; }
        public string contractname { get; set; }
        public string contractnumber { get; set; }
        public string returnpaymessage { get; set; }
        public string billtype { get; set; }
        public string billcontent { get; set; }
        public string billheader { get; set; }
        public string taxernumber { get; set; }
        public string openbank { get; set; }
        public string bankaccount { get; set; }

        public string address { get; set; }
        public string phonenumber { get; set; }
    }
}
