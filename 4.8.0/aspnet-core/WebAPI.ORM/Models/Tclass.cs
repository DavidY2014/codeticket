using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tclass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
    }
}
