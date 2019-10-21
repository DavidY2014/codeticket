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
    public class OrderInfoController : Controller
    {
        // GET: OrderInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryOrderList(OrderQueryVM queryModel)
        {
            var results = new List<OrderListViewModel>();
            StringBuilder sbr = new StringBuilder();
            if (queryModel.orderid != null)
            {
                sbr.Append(" orderid=" + queryModel.orderid  + " and");
            }
            if (queryModel.productid != null)
            {
                sbr.Append(" productid=" + queryModel.productid + " and");
            }
            if (queryModel.supplierid != null)
            {
                sbr.Append(" supplierid=" +"'"+ queryModel.supplierid +"'"+ " and");
            }
            if (queryModel.contact != null)
            {
                sbr.Append(" contact=" + queryModel.contact + " and");
            }
            if (queryModel.ticketnumber != null)
            {
                sbr.Append(" ticketnumber=" + queryModel.ticketnumber + " and");
            }
            if (queryModel.batchnumber != null)
            {
                sbr.Append(" batchnumber=" + queryModel.batchnumber + " and");
            }
            //if (queryModel.createtime != null)
            //{
            //    sbr.Append(" createtime=" + queryModel.createtime + " and");
            //}
            if (queryModel.logisticsnumber != null)
            {
                sbr.Append(" logisticsnumber=" + queryModel.logisticsnumber + " and");
            }
            if (queryModel.orderstatus!=null)
            {
                sbr.Append(" orderstatus=" + int.Parse(queryModel.orderstatus) + " and");
            }
            var condition = sbr.ToString();
            var sql = "select * from dbo.orderinfo";
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
            var dbOrders = DapperWrapper.GetAll<dbOrder>(sql);
            foreach (var item in dbOrders)
            {
                var orderVM = new OrderListViewModel();
                #region convert db to viewmodel
                orderVM.orderid = item.orderid;
                orderVM.productname = DapperWrapper.GetSingle<string>("select productname from dbo.productinfo where productid=" + "'"+item.productid+"'");
                orderVM.productid = item.productid;
                orderVM.supplier = DapperWrapper.GetSingle<string>("select name from dbo.supplier where id=" + "'"+item.supplierid+"'");
                orderVM.buycount = item.buycount;
                orderVM.ticketnumber = item.ticketnumber;
                orderVM.batchnumber = item.batchnumber;
                orderVM.createtime = item.createtime;
                orderVM.orderstatus = item.orderstatus;
                orderVM.contact = item.contact;
                orderVM.receiver = item.receiver;
                orderVM.receiveraddress = item.receiveraddress;
                orderVM.logisticsnumber = item.logisticsnumber;
                #endregion
                results.Add(orderVM);
            }
            return Json(results);
        }

        public ActionResult GetSupplierName()
        {
            var ret = new List<object>();
            var sql = "select * from dbo.supplier";
            var dbSuppliers = DapperWrapper.GetAll<dbSupplier>(sql);
            foreach (var item in dbSuppliers)
            {
                ret.Add(new { id = item.id, name = item.name });
            }
            return Json(ret);
        }

        public ActionResult GetOrderStatus()
        {
            var ret = new List<object>();
            var sql = "select distinct(orderstatus) from dbo.orderinfo";
            var orderStatus = DapperWrapper.GetAll<int>(sql);
            foreach (var item in orderStatus)
            {
                ret.Add(new { id = item, name = item });
            }
            return Json(ret);
        }

    }
}