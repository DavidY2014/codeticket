using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ProductInfoViewModel
    {
        public string productname { get; set; }
        public string title { get; set; }
        public string productid { get; set; }
        public string suppliername { get; set; }
        public string class1 { get; set; }
        public string class2 { get; set; }
        public double? saleprice { get; set; }
        public int? avaiablestock { get; set; }
        public int? saleamount { get; set; }
        public int? currentremain { get; set; }
        public string status { get; set; }
        public string operation { get; set; }
        public int? productstatus { get; set; }
    }

    public class ProductDetailViewModel
    {
        public int productid { get; set; }

        public string productpicturepath { get; set; }

        public string productdescription { get; set; }
    }

    public class CreateNewProductViewModel
    {
        public string productname { get; set; }

        public string title { get; set; }

        public string class1 { get; set; }

        public string class2 { get; set; }
        public string deliveryarea { get; set; }
        public string supplier { get; set; }
        public double? cost { get; set; }
        public double? saleprice { get; set; }
        public int? avaliablestock { get; set; }
        public int? totalsale { get; set; }
        public string productpicturepath { get; set; }
        public string description { get; set; }
    }

    public class ProductStatus
    {
        public string name { get; set; }
        public int status { get; set; }
    }

}
