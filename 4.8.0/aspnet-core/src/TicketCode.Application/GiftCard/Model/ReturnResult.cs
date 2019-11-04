using System;
using System.Collections.Generic;
using System.Text;

namespace TicketCode.GiftCard.Model
{
    public class ReturnResult
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
    }
}
