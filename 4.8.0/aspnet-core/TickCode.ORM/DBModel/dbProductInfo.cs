using System;
using System.Collections.Generic;
using System.Text;

namespace TickCode.ORM.DBModel
{
    public class dbProductInfo
    {
        public string productname { get; set; }
        public string title { get; set; }
        public int productid { get; set; }
        public int supplier { get; set; }
        public string firstclass { get; set; }
        public string secondclass { get; set; }
        public string price { get; set; }
        public string totalremain { get; set; }
        public string totalsaled { get; set; }
        public string currentremain { get; set; }
        public int status { get; set; }
        public string operation { get; set; }
    }
}
