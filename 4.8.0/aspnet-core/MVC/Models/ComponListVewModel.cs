using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ComponListVewModel
    {
        public string componnumber { get; set; }
        public string batchnumber { get; set; }
        public int componusecount { get; set; }
        public int componremaincount { get; set; }
        public string activestatus { get; set; }
        public string exchangestatus { get; set; }
        public string validitytime { get; set; }
        public string operation { get; set; }
    }
}
