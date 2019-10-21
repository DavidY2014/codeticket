using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class CatelogViewModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public int parentid { get; set; }
    }

   
}
