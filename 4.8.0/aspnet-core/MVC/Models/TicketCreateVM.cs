using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TicketCreateVM
    {
        public string custormername { get; set; }

        public string saleman { get; set; }
        public int salecount { get; set; }
        public int couponcount { get; set; }
        public float price { get; set; }
        public float saleamount { get; set; }
        public bool issigncontract { get; set; }
        public string contractname { get; set; }
        public string contractcode { get; set; }
        public string couponstarttime { get; set; }
        public string couponendtime { get; set; }
        public string activemethod { get; set; }
        public string activetime { get; set; }
        public string receiver { get; set; }
        public string contact { get; set; }
        public string receiveraddress { get; set; }
        public string productpool { get; set; }
        public string pagetitle { get; set; }
        public string headerbanner { get; set; }
        public string returnmonenymethod { get; set; }
        public string returnmonenydate { get; set; }
        public string isbilling { get; set; }
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
