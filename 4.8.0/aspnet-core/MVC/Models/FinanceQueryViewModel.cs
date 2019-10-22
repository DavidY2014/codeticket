using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class FinanceQueryViewModel
    {
        public string customname { get; set; }
        public string batchnumber { get; set; }
        public int returnpaystatus { get; set; }
        public int billstatus { get; set; }
    }
}
