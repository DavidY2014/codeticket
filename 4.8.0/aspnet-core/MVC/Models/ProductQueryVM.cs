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
        public string suppliername { get; set; }
        public int? status { get; set; }
        public string class1 { get; set; }
        public string class2 { get; set; }
    }
}
