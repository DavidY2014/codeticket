using System;
using System.Collections.Generic;
using System.Text;

namespace TickCode.ORM.DBModel
{
    public class dbTicket
    {
        public int saledticketid { get; set; }
        public string customername { get; set; }
        public string saleman { get; set; }
        public string batchnumber { get; set; }
        public int salecount { get; set; }
        public float price { get; set; }
        public float amount { get; set; }
        public DateTime ordertime { get; set; }
        public DateTime validitytime{ get; set; }
        public string ticketnumbers { get; set; }
        public int ticketstatus { get; set; }
        public string operatorname { get; set; }

    }
}
