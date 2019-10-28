using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Wcustomer
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ExchangeRecord { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Receiver { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
