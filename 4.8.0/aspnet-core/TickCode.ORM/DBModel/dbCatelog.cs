using System;
using System.Collections.Generic;
using System.Text;

namespace TickCode.ORM.DBModel
{
    public class dbCatelog
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
    }
}
