using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Tproduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string SupplierName { get; set; }
        public string DeliveryAddress { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int Class1 { get; set; }
        public int Class2 { get; set; }
        public decimal SalePrice { get; set; }
        public int TotalStock { get; set; }
        public int SaledStock { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
