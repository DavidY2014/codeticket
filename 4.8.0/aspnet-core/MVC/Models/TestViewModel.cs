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
        public int productid { get; set; }
        public string supplier { get; set; }
        public string firstclass { get; set; }
        public string secondclass { get; set; }
        public string price { get; set; }
        public string totalremain { get; set; }
        public string totalsaled { get; set; }
        public string currentremain { get; set; }
        public string status { get; set; }
        public string operation { get; set; }
        public int productstatus { get; set; }
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

        public string firstclass { get; set; }

        public string secondclass { get; set; }
        public string sendarea { get; set; }
        public string supplier { get; set; }
        public string cost { get; set; }
        public string saleprice { get; set; }
        public string currentremain { get; set; }
        public string totalsale { get; set; }
        public string productpicturepath { get; set; }
        public string productdescription { get; set; }
    }

    public class ProductStatus
    {
        public string name { get; set; }
        public int status { get; set; }
    }

}
