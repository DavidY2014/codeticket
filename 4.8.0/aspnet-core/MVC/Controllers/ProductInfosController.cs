using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using TickCode.ORM;
using TickCode.ORM.DBModels;

namespace MVC.Controllers
{
    public class ProductInfosController : Controller
    {
        // GET: ProductInfos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryProductList(ProductQueryVM queryModel)
        {
            var result = new List<ProductInfoViewModel>();

            using (var dbContext = new TicketCodeTestDBContext())
            {
                var efProducts = dbContext.Tproduct.ToList();
                if (queryModel.productname != null)
                {
                    efProducts = efProducts.Where(item => item.Name == queryModel.productname).ToList();
                }
                if (queryModel.productid != null)
                {
                    efProducts = efProducts.Where(item => item.Id == queryModel.productid).ToList();
                }
                if (queryModel.suppliername != null)
                {
                }
                if (queryModel.status != null)
                {
                    efProducts = efProducts.Where(item => item.Status == queryModel.status).ToList();
                }
                if (queryModel.class1 != null)
                {
                    efProducts = efProducts.Where(item => item.Class1 == queryModel.class1).ToList();
                }
                if (queryModel.class2 != null)
                {
                    efProducts = efProducts.Where(item => item.Class2 == queryModel.class2).ToList();
                }
                foreach (var item in efProducts)
                {
                    var productInfoVM = new ProductInfoViewModel();
                    #region convert db to viewmodel
                    productInfoVM.productname = item.Name;
                    productInfoVM.title = item.Title;
                    productInfoVM.productid = item.Id;
                    var efSupplier = dbContext.Tsupplier.Find(item.SupplierId);
                    if (efSupplier != null)
                    {
                        productInfoVM.suppliername = efSupplier.Name;
                    }
                    productInfoVM.class1 = item.Class1;
                    productInfoVM.class2 = item.Class2;
                    productInfoVM.saleprice = item.SalePrice;
                    productInfoVM.avaiablestock = item.AvailableStock;
                    productInfoVM.saleamount = item.SaleAmount;
                    productInfoVM.currentremain = item.AvailableStock;
                    productInfoVM.productstatus = item.Status;
                    #endregion

                    var checkrow = "<a href=\"#\" onclick=\"checkProduct(this)\">查看</a>";
                    var editrow = "<a href=\"#\" onclick=\"editProduct(this)\">编辑</a>";
                    var deleterow = "<a href=\"#\" onclick=\"removeProduct(this)\">删除</a>";
                    productInfoVM.operation = checkrow + " " + editrow + " " + deleterow;

                    #region 商品上下架状态
                    var operationStatus = item.Status == 0 ? "切换为上架" : "切换为下架";
                    var currentStatus = item.Status == 0 ? "已下架" : "已上架";
                    productInfoVM.status = string.Format("{0}     <a href=\"#\" class=\"easyui-linkbutton\" iconCls=\"icon-search\" onclick=\"switchProductStatus()\">{1}</a>"
                        , currentStatus, operationStatus);
                    #endregion
                    result.Add(productInfoVM);
                }
            }

            return Json(result);
        }


        /// <summary>
        /// 新增编辑界面
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNewPage(string productid)
        {
            var dmProduct = new CreateNewProductViewModel();
            if (productid != null)
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efProduct = dbContext.Tproduct.Find(productid.ToString());
                    dmProduct.productname = efProduct.Name;
                    dmProduct.class1 = efProduct.Class1;
                    dmProduct.class2 = efProduct.Class2;

                }
            }
            return View(dmProduct);
        }

        public ActionResult SaveProduct(CreateNewProductViewModel saveDto)
        {
            try
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efProduct = new Tproduct();
                    efProduct.Id = UniqueGenerator.UniId();
                    efProduct.Name = saveDto.productname;
                    efProduct.Title = saveDto.title;
                    efProduct.Class1 = saveDto.class1;
                    efProduct.Class2 = saveDto.class2;
                    efProduct.DeliveryArea = saveDto.deliveryarea;
                    efProduct.SupplierId = saveDto.supplier;
                    efProduct.Cost = saveDto.cost;
                    efProduct.SalePrice = saveDto.saleprice;
                    efProduct.AvailableStock = saveDto.avaliablestock;
                    efProduct.Description = saveDto.description;
                    dbContext.Tproduct.Add(efProduct);
                    dbContext.SaveChanges();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.ToString() });
            }

        }

        public ActionResult DeleteProduct(string productid)
        {
            try
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    dbContext.Tproduct.Remove(dbContext.Tproduct.Find(productid));
                    dbContext.SaveChanges();
                }
                return Json(new { success = true, message = "delete success" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.ToString() });
            }
        }

        public ActionResult SwitchProductStatus(string productid)
        {
            try
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efProduct = dbContext.Tproduct.Find(productid);
                    if (efProduct != null)
                    {
                        efProduct.Status = efProduct.Status == 1 ? 0 : 1;
                    }
                    dbContext.Tproduct.Update(efProduct);
                    dbContext.SaveChanges();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.ToString() });
            }
        }

        #region 下拉框
        public ActionResult GetSupplier()
        {
            var ret = new List<object>();
            using (var dbContext = new TicketCodeTestDBContext())
            {
                var efSupplier = dbContext.Tsupplier.ToList();
                foreach (var item in efSupplier.Distinct())
                {

                }
            }


            return Json("");
        }

        public ActionResult GetProductStatus()
        {
            var items = new List<ProductStatus>();
            items.Add(new ProductStatus() { status = 0, name = "已下架" });
            items.Add(new ProductStatus() { status = 1, name = "已上架" });
 
            return Json(items);
        }


        public ActionResult GetFirstClass()
        {
            var ret = new object();

            return Json(ret);
        }


        public ActionResult GetSecondClass()
        {
            var ret = new object();

            return Json(ret);
        }

        /// <summary>
        /// 获取配送区域
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSendArea()
        {
            return Json("");
        }

        #endregion

        public void sqlconcat()
        {
            //StringBuilder sbr = new StringBuilder();
            //if (queryModel.productname != null)
            //{
            //    sbr.Append(" productname=" + "'" + queryModel.productname + "'" + " and");
            //}
            //if (queryModel.productid != null)
            //{
            //    sbr.Append(" productid=" + queryModel.productid + " and");
            //}
            //if (queryModel.supplier != null)
            //{
            //    sbr.Append(" supplier=" + queryModel.supplier + " and");
            //}
            //if (queryModel.status != null)
            //{
            //    sbr.Append(" status=" + queryModel.status + " and");
            //}
            //if (queryModel != null)
            //{
            //    sbr.Append(" firstclass=" + queryModel.firstclass + " and");
            //}
            //if (queryModel.secondclass != null)
            //{
            //    sbr.Append(" secondclass=" + queryModel.secondclass + " and");
            //}
            //var condition = sbr.ToString();
            //var sql = "select * from dbo.productinfo";
            //if (!string.IsNullOrEmpty(condition))
            //{
            //    sql += " where ";
            //    sql += condition;
            //    if (sql.Contains("and"))
            //    {
            //        var charArray = new char[] { 'a', 'n', 'd' };
            //        sql = sql.TrimEnd(charArray);
            //    }
            //}
        }

    }
}