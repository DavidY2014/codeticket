using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
{
    public partial class Tbill
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SupplierId { get; set; }
        public int? TicketId { get; set; }
        public int? ReturnType { get; set; }
        public int? IsBill { get; set; }
        public int? BillType { get; set; }
        public string BillContent { get; set; }
        public string BillHeader { get; set; }
        public string TaxNumber { get; set; }
        public string Openbank { get; set; }
        public string BankAccount { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
