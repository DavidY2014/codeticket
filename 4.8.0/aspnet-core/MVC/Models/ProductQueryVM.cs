using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ProductQueryVM
    {
        public string productname { get; set; }
        public string productid { get; set; }
        public string supplier { get; set; }
        public string status { get; set; }
        public string firstclass { get; set; }
        public string secondclass { get; set; }
    }
}
