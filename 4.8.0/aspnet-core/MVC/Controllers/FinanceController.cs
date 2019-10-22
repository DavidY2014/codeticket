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
    public class FinanceController : Controller
    {
        // GET: Finance
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult QueryFinanceList(FinanceQueryViewModel queryModel)
        {
            var results = new List<FinanceViewModel>();
            StringBuilder sbr = new StringBuilder();
            if (queryModel.customname != null)
            {
                sbr.Append(" customname=" + queryModel.customname + " and");
            }
            if (queryModel.batchnumber != null)
            {
                sbr.Append(" batchnumber=" + queryModel.batchnumber + " and");
            }
            if (queryModel.returnpaystatus >0)
            {
                sbr.Append(" returnpaystatus=" + "'" + queryModel.returnpaystatus + "'" + " and");
            }
            if (queryModel.billstatus >0)
            {
                sbr.Append(" billstatus=" + "'" + queryModel.billstatus + "'" + " and");
            }
            var condition = sbr.ToString();
            var sql = "select * from dbo.financeinfo";
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
            var dbFinances = DapperWrapper.GetAll<dbFinance>(sql);
            foreach (var item in dbFinances)
            {
                var financeVM = new FinanceViewModel();
                #region convert db to viewmodel
                var checkrow = "<a href=\"#\" onclick=\"checkFinance(this)\">查看</a>";
                var editrow = "<a href=\"#\" onclick=\"editFinance(this)\">编辑</a>";
                financeVM.operation = checkrow + " " + editrow;
                #endregion
                results.Add(financeVM);
            }
            return Json(results);

        }


        /// <summary>
        /// 付款单编辑页面
        /// </summary>
        /// <param name="financeId"></param>
        /// <returns></returns>
        public ActionResult EditView(int financeId)
        {
            return View();
        }


        /// <summary>
        /// 付款单查看界面
        /// </summary>
        /// <param name="financeId"></param>
        /// <returns></returns>
        public ActionResult CheckView(int financeId)
        {
            return View();
        }


        #region 下拉框

        public ActionResult GetReturnPayStatus()
        {
            var ret = new List<object>();
            ret.Add(new { id = 0, name = "已开票" });
            ret.Add(new { id = 1, name = "未开票" });
            return Json(ret);
        }

        public ActionResult GetBillStatus()
        {
            var ret = new List<object>();
            ret.Add(new { id = 0, name = "已支付" });
            ret.Add(new { id = 1, name = "未支付" });
            return Json(ret);
        }

        #endregion






    }
}