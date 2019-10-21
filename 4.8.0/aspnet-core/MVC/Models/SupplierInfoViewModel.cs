using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class SupplierInfoViewModel
    {
        public int supplierid { get; set; }
        public string suppliername { get; set; }
        public string financecontacter { get; set; }
        public string financephone { get; set; }
        public string deliveryname { get; set; }
        public string deliveryphone { get; set; }
        public string operation { get; set; }
    }
}
