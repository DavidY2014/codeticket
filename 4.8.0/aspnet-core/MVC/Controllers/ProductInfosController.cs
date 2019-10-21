using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using TickCode.ORM;
using TickCode.ORM.DBModel;

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
            StringBuilder sbr = new StringBuilder();
            if (queryModel.productname!=null)
            {
                sbr.Append(" productname=" + "'"+queryModel.productname+"'"+" and");
            }
            if (queryModel.productid!=null)
            {
                sbr.Append(" productid=" + queryModel.productid+" and");
            }
            if (queryModel.supplier != null)
            {
                sbr.Append(" supplier=" +queryModel.supplier +" and");
            }
            if (queryModel.status!=null)
            {
                sbr.Append(" status=" + queryModel.status+" and");
            }
            if (queryModel.firstclass!=null)
            {
                sbr.Append(" firstclass=" + queryModel.firstclass+" and");
            }
            if (queryModel.secondclass!=null)
            {
                sbr.Append(" secondclass=" + queryModel.secondclass+" and");
            }
            var condition = sbr.ToString();
            var sql = "select * from dbo.productinfo";
            if (!string.IsNullOrEmpty(condition))
            {
                sql += " where ";
                sql += condition;
                if (sql.Contains("and"))
                {
                    var charArray = new char[] { 'a', 'n', 'd' };
                    sql = sql.TrimEnd(charArray);
                }
            }
            var efProductInfos = DapperWrapper.GetAll<dbProductInfo>(sql);
            foreach (var item in efProductInfos)
            {
                var productInfoVM = new ProductInfoViewModel();
                #region convert db to viewmodel
                productInfoVM.productname = item.productname;
                productInfoVM.title = item.title;
                productInfoVM.productid = item.productid;
                productInfoVM.supplier = DapperWrapper.GetSingle<dbSupplier>("select * from dbo.supplier where id=" + item.supplier).name;
                productInfoVM.firstclass = item.firstclass;
                productInfoVM.secondclass = item.secondclass;
                productInfoVM.price = item.price;
                productInfoVM.totalremain = item.totalremain;
                productInfoVM.totalsaled = item.totalsaled;
                productInfoVM.currentremain = item.currentremain;
                productInfoVM.productstatus = item.status;
                #endregion


                var checkrow = "<a href=\"#\" onclick=\"checkProduct(this)\">查看</a>";
                var editrow = "<a href=\"#\" onclick=\"editProduct(this)\">编辑</a>";
                var deleterow = "<a href=\"#\" onclick=\"removeProduct(this)\">删除</a>";
                productInfoVM.operation = checkrow+" "+editrow+" "+deleterow;

                #region 商品上下架状态
                var operationStatus =item.status== 0?"切换为上架":"切换为下架";
                var currentStatus = item.status == 0 ? "已下架" : "已上架";
                productInfoVM.status =string.Format("{0}     <a href=\"#\" class=\"easyui-linkbutton\" iconCls=\"icon-search\" onclick=\"switchProductStatus()\">{1}</a>"
                    , currentStatus,operationStatus);
                #endregion
                result.Add(productInfoVM);
            }
            return Json(result);
        }

        public void CreateNewProduct(CreateNewProductViewModel saveDto)
        {
            var sql = "insert into ";
        }

        public void EditProduct(string productid)
        {

        }

        public void DeleteProduct(string productid)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        public ActionResult SwitchProductStatus(string productid)
        {
            try
            {
                var selectSql = "select * from dbo.productinfo where productid = " + productid;
                var efProductInfo = DapperWrapper.GetSingle<dbProductInfo>(selectSql);
                var status = efProductInfo.status == 1 ? 0 : 1;
                var updateSql = "update dbo.productinfo set status=" + status + " where productid=" + productid;
                DapperWrapper.Update(updateSql);
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
            string sql = "select * from dbo.supplier";
            var json = DapperWrapper.GetAll<dbSupplier>(sql);
            return Json(json);
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



    }
}