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
            var dbTickets = DapperWrapper.GetAll<dbTicket>(sql);
            foreach (var item in dbTickets)
            {
                var orderVM = new TicketViewModel();
                #region convert db to viewmodel
                orderVM.customername = item.customername;
                orderVM.saleman = item.saleman;
                orderVM.batchnumber = item.batchnumber;
                orderVM.salecount = item.salecount.ToString();
                orderVM.price = item.price.ToString();
                orderVM.amount = item.amount.ToString();
                orderVM.ordertime = item.ordertime.ToString();
                orderVM.validitytime = item.validitytime.ToString();
                orderVM.ticketnumbers = item.ticketnumbers;
                orderVM.ticketstatus = MapTicketStatus(item.ticketstatus);
                orderVM.operatorname = item.operatorname;
                orderVM.saledticketid = item.saledticketid;
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
                var dbTicket = DapperWrapper.GetSingle<dbTicket>(sql);
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
                StringBuilder sbr = new StringBuilder();
                //sbr.Append("insert into dbo.supplier(name,id,suppliertype,financecontacter,financephone,deliveryname,deliveryphone,companyname," +
                //    "companyaddress,servicename,servicephone,taxpayernumber,billheader,openbank,bankaccount) values(");
                //sbr.AppendLine("'");
                //sbr.AppendLine(createModel.suppliername == null ? "" : createModel.suppliername + "',");
                //sbr.AppendLine(new Random().Next(0, 1000) + ",");
                //sbr.AppendLine(createModel.suppliertype + ",");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.financecontacter + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.financephone + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.deliveryname + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.deliveryphone + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.companyname + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.companyaddress + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.servicename + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.servicephone + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.taxpayernumber + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.billheader + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.openbank + "',");
                //sbr.Append("'");
                //sbr.AppendLine(createModel.bankaccount + "'");
                //sbr.AppendLine(")");
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


        public string MapTicketStatus(int status)
        {
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