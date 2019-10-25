using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using TickCode.ORM;
using TickCode.ORM.DBModels;

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
            var efOrders = new List<Torder>();
            using (var dbContext = new TicketCodeTestDBContext())
            {
                efOrders = dbContext.Torder.ToList();
            }
            if (queryModel.orderid != null)
            {
                efOrders = efOrders.Where(item=>item.Id == queryModel.orderid).ToList();
            }
            if (queryModel.productid != null)
            {
                efOrders = efOrders.Where(item => item.ProductId == queryModel.productid).ToList();
            }
            if (queryModel.supplierid != null)
            {
                efOrders = efOrders.Where(item => item.SupplierId == queryModel.supplierid).ToList();
            }
            if (queryModel.contact != null)
            {
                efOrders = efOrders.Where(item => item.Phone == queryModel.contact).ToList();
            }
            if (queryModel.couponnumber!=null)
            {
                efOrders = efOrders.Where(item => item.CouponNumber == queryModel.couponnumber).ToList();
            }
            if (queryModel.batchnumber!=null)
            {
                efOrders = efOrders.Where(item => item.Batch == queryModel.batchnumber).ToList();
            }
            if (queryModel.logisticsnumber != null)
            {
                efOrders = efOrders.Where(item => item.DeliveryNumber == queryModel.logisticsnumber).ToList();
            }
            if (queryModel.orderstatus!=null)
            {
                efOrders = efOrders.Where(item => item.Status == queryModel.orderstatus).ToList();
            }
            foreach (var item in efOrders)
            {
                var orderVM = new OrderListViewModel();
                #region convert db to viewmodel
                orderVM.orderid = item.Id;
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efProduct = dbContext.Tproduct.Find(item.ProductId);
                    orderVM.productname = efProduct.Name;
                    orderVM.productid = efProduct.Id;
                    var efSupplier = dbContext.Tsupplier.Find(item.SupplierId);
                    orderVM.suppliername = efSupplier.Name;
                }
                orderVM.buycount = item.BuyCount;
                orderVM.ticketnumber = item.CouponNumber;
                orderVM.batchnumber = item.Batch;
                orderVM.createtime = item.Createtime;
                orderVM.orderstatusDisplay =  MapOrderStatus(item.Status); 
                orderVM.contact = item.Phone;
                orderVM.receiver = item.Receiver;
                orderVM.receiveraddress = item.ReceiverAddress;
                orderVM.logisticsnumber = item.DeliveryNumber;
                #endregion
                results.Add(orderVM);
            }
            return Json(results);
        }

        public ActionResult GetSupplierName()
        {
            var ret = new List<object>();
            var sql = "select distinct(orderstatus) from dbo.TSupplier";
            var orderStatus = DapperWrapper.GetAll<int>(sql);
            foreach (var item in orderStatus)
            {
                ret.Add(new { id = item, name = MapOrderStatus(item) });
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
                ret.Add(new { id = item, name = MapOrderStatus(item) });
            }
            return Json(ret);
        }

        public string MapOrderStatus(int status)
        {
            var ret = string.Empty;
            if (status == 0)
            {
                ret = "未发货";
            }
            if (status == 1)
            {
                ret = "已发货";
            }
            if (status ==2 )
            {
                ret = "已完成";
            }
            return ret;
        }

    }
}