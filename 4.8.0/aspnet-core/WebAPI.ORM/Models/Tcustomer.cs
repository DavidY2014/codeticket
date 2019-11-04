using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Tcustomer
    {
        public Tcustomer()
        {
            TdeliveryAddress = new HashSet<TdeliveryAddress>();
            TgiftCard = new HashSet<TgiftCard>();
        }

        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<TdeliveryAddress> TdeliveryAddress { get; set; }
        public virtual ICollection<TgiftCard> TgiftCard { get; set; }
    }
}
