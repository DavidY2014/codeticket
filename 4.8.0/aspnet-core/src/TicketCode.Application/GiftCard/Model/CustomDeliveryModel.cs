using System;
using System.Collections.Generic;
using System.Text;

namespace TicketCode.GiftCard.Model
{
    public class CustomDeliveryModel
    {
        public CustomDeliveryModel()
        {
            Deliverys = new List<DeliveryInfo>();
        }
        public int CustomCode { get; set; }
        public List<DeliveryInfo> Deliverys { get; set; }
        public string Description { get; set; }
    }
    public class DeliveryInfo
    {
        public int DeliveryIndex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public string District { get; set; }
        public string Address { get; set; }

        public string ContactPhone { get; set; }
        public string BackupPhone { get; set; }
        public string ContactName { get; set; }
        public string BackupContactName { get; set; }
        public string Comment { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}
