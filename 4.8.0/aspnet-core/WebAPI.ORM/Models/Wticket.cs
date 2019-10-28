using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Wticket
    {
        public int Id { get; set; }
        public string TicketCode { get; set; }
        public string TicketSecret { get; set; }
        public int UsedCount { get; set; }
        public int TotalCount { get; set; }
    }
}
