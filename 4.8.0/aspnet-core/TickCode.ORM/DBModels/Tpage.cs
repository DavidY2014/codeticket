using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tpage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? HeaderBanner { get; set; }
        public string TicketId { get; set; }
    }
}
