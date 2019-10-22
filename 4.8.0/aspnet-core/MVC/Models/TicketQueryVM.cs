using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TicketQueryVM
    {
        public string customername { get; set; }
        public string batchnumber { get; set; }
        public string ticketnumber { get; set; }
        public string ticketstatus { get; set; }
        public string ordertime { get; set; }
    }
}
