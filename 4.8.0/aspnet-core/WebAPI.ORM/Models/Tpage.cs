using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tpage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? HeaderBanner { get; set; }
        public string TicketId { get; set; }
    }
}
