using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class TproductImage
    {
        public int Id { get; set; }
        public int Class1 { get; set; }
        public int Class2 { get; set; }
        public string Code { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
