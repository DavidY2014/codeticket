using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using TickCode.ORM;
using TickCode.ORM.DBModels;

namespace MVC.Controllers
{
    public class TicketInfosController : Controller
    {
        // GET: TicketInfos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QueryTicketList(TicketQueryVM queryModel)
        {
            var results = new List<TicketViewModel>();
            StringBuilder sbr = new StringBuilder();
            if (queryModel.customername != null)
            {
                sbr.Append(" customername=" + queryModel.customername + " and");
            }
            if (queryModel.batchnumber != null)
            {
                sbr.Append(" batchnumber=" + queryModel.batchnumber + " and");
            }
            if (queryModel.ticketnumber != null)
            {
                sbr.Append(" ticketnumber=" + "'" + queryModel.ticketnumber + "'" + " and");
            }
            if (queryModel.ticketstatus != null)
            {
                sbr.Append(" ticketstatus=" + "'" + queryModel.ticketstatus + "'" + " and");
            }
            var condition = sbr.ToString();
            var sql = "select * from dbo.ticketinfo";
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
            var dbTickets = DapperWrapper.GetAll<Tticket>(sql);
            foreach (var item in dbTickets)
            {
                var orderVM = new TicketViewModel();
                #region convert db to viewmodel
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efCustom = dbContext.Tcustomer.ToList().FirstOrDefault(n => n.Code == item.CustomerCode);
                    orderVM.customername = efCustom.Name;
                    orderVM.saleman = efCustom.SaleMan;
                    orderVM.batchnumber = item.Batch;
                    orderVM.salecount = efCustom.SaleCount.ToString();
                    orderVM.price = efCustom.Price.ToString();
                    orderVM.amount = efCustom.SaleAmount.ToString();
                }
                orderVM.ordertime = item.CreateTime.ToString();
                orderVM.validitytime = item.ValidityStartTime.ToString() + item.ValidityEndTime.ToString();
                orderVM.ticketnumbers = item.CouponRange;
                orderVM.ticketstatus = MapTicketStatus(item.Status);
                orderVM.operatorname = item.Operator;
                var checkrow = "<a href=\"#\" onclick=\"checkTicket(this)\">查看</a>";
                var editrow = "<a href=\"#\" onclick=\"editTicket(this)\">编辑</a>";
                var managerow = "<a href=\"#\" onclick=\"manageTicket(this)\">管理劵码</a>";
                orderVM.operation = checkrow + " " + editrow + " " + managerow;
                #endregion
                results.Add(orderVM);
            }
            return Json(results);
        }

        /// <summary>
        /// 新增编辑页面
        /// </summary>
        /// <param name="saledticketid"></param>
        /// <returns></returns>
        public ActionResult CreateNewSaleTicket(int saledticketid)
        {
            var model = new TicketCreateVM();
            if (saledticketid > 0)
            {
                //编辑界面
                var sql = "select * from dbo.ticketinfo where saledticketid=" + saledticketid;
                //var dbTicket = DapperWrapper.GetSingle<dbTicket>(sql);
            }

            return View(model);
        }

        /// <summary>
        /// 查看界面，只读页面
        /// </summary>
        /// <param name="saledticketid"></param>
        /// <returns></returns>
        public ActionResult CheckSaleTicketInfo(int saledticketid)
        {
            return View();
        }

        /// <summary>
        /// 管理劵码页面
        /// </summary>
        /// <param name="saledticketid"></param>
        /// <returns></returns>
        public ActionResult ManageTicketInfo(int saledticketid)
        {
            return View();
        }

        public ActionResult QueryComponList(int saledticketid)
        {
            var componList = new List<ComponListVewModel>();
            return Json(componList);
        }





        public ActionResult SaveNewTicket(TicketCreateVM createModel)
        {
            try
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var dbTicket = new Tticket();
                    var dbCustom = new Tcustomer();
                    var dbBill = new Tbill();
                    dbCustom.Name = createModel.custormername;
                    dbCustom.SaleMan = createModel.saleman;
                    dbCustom.SaleCount = createModel.salecount;
                    dbCustom.SaleAmount = createModel.saleamount;



                    dbContext.Tcustomer.Add(dbCustom);
     


                }


                    StringBuilder sbr = new StringBuilder();
                DapperWrapper.Insert(sbr.ToString());
                return Json(new { success = true, msg = "保存成功" });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    msg = ex.ToString()
                });
            }

        }


        public string MapTicketStatus(int? status)
        {
            if (status == null)
            { return ""; }

            var ret = string.Empty;
            if (status == 0)
            {
                ret = "带激活";
            }
            if (status == 1)
            {
                ret = "已激活";
            }
            if (status == 2)
            {
                ret = "已冻结";
            }
            return ret;
        }

    }
}