using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Tclass
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int Level { get; set; }
        public string ClassName { get; set; }
    }
}
