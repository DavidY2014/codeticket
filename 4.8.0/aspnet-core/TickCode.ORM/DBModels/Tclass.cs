using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tclass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
    }
}
