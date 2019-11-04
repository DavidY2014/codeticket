using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class TdeliveryAddress
    {
        public int DeliveryId { get; set; }
        public int? CustomId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Receiver { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual Tcustomer Custom { get; set; }
    }
}
