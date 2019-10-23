using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using TickCode.ORM;

namespace MVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuerySupplierList(SupplierQueryVM queryModel)
        {
            var result = new List<SupplierInfoViewModel>();
            StringBuilder sbr = new StringBuilder();
            if (queryModel.suppliername != null)
            {
                sbr.Append(" name=" + "'" + queryModel.suppliername + "'" + " and");
            }
            if (queryModel.suppliertype != null)
            {
                sbr.Append(" suppliertype=" + queryModel.suppliertype + " and");
            }
            var condition = sbr.ToString();
            var sql = "select * from dbo.supplier";
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
            //var efSuppliers = DapperWrapper.GetAll<dbSupplier>(sql);
            //foreach (var item in efSuppliers)
            //{
            //    var supplierVM = new SupplierInfoViewModel();
            //    #region convert db to viewmodel
            //    supplierVM.supplierid = item.id;
            //    supplierVM.suppliername = item.name;
            //    supplierVM.financecontacter = item.financecontacter;
            //    supplierVM.financephone = item.financephone;
            //    supplierVM.deliveryname = item.deliveryname;
            //    supplierVM.deliveryphone = item.deliveryphone;
            //    #endregion
            //    var editrow = "<a href=\"#\" onclick=\"editSupplier()\">编辑</a>";
            //    var deleterow = "<a href=\"#\" onclick=\"removeSupplier()\">删除</a>";
            //    supplierVM.operation =  editrow + " " + deleterow;
            //    result.Add(supplierVM);
            //}
            return Json(result);
        }

        /// <summary>
        /// 编辑和新增页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateNewSupplier(int id)
        {
            var model = new SupplierCreateNewVM();
            //获取supplier的信息
            if (id > 0)
            {
                var sql = "select * from dbo.supplier where id=" + id;
                //var dbSupplier = DapperWrapper.GetSingle<dbSupplier>(sql);
                ////convert
                //model.suppliername = dbSupplier.name;
                //model.suppliertype = dbSupplier.suppliertype;
                //model.companyname = dbSupplier.companyname;
                //model.companyaddress = dbSupplier.companyaddress;
                //model.financecontacter = dbSupplier.financecontacter;
                //model.financephone = dbSupplier.financephone;
                //model.deliveryname = dbSupplier.deliveryname;
                //model.deliveryphone = dbSupplier.deliveryphone;
                //model.servicename = dbSupplier.servicename;
                //model.servicephone = dbSupplier.servicephone;
                //model.taxpayernumber = dbSupplier.taxpayernumber;
                //model.billheader = dbSupplier.billheader;
                //model.openbank = dbSupplier.openbank;
                //model.bankaccount = dbSupplier.bankaccount;
            }
            return View(model);
        }

        public ActionResult SaveNewSupplier(SupplierCreateNewVM createModel)
        {
            try
            {
                StringBuilder sbr = new StringBuilder();
                sbr.Append("insert into dbo.supplier(name,id,suppliertype,financecontacter,financephone,deliveryname,deliveryphone,companyname," +
                    "companyaddress,servicename,servicephone,taxpayernumber,billheader,openbank,bankaccount) values(");
                sbr.AppendLine("'");
                sbr.AppendLine(createModel.suppliername==null?"":createModel.suppliername + "',");
                sbr.AppendLine(new Random().Next(0, 1000) + ",");
                sbr.AppendLine(createModel.suppliertype+",");
                sbr.Append("'");
                sbr.AppendLine(createModel.financecontacter + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.financephone + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.deliveryname + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.deliveryphone + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.companyname + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.companyaddress + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.servicename + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.servicephone + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.taxpayernumber + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.billheader + "',");
                sbr.Append("'");
                sbr.AppendLine( createModel.openbank + "',");
                sbr.Append("'");
                sbr.AppendLine(createModel.bankaccount+"'");
                sbr.AppendLine(")");
                DapperWrapper.Insert(sbr.ToString());
                return Json(new { success = true ,msg="保存成功"});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.ToString() });
            }
        }



        public ActionResult RemoveSupplier(string supplierid)
        {
            try
            {
                var sql = "delete from dbo.supplier where id=" + supplierid;
                DapperWrapper.Delete(sql);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false , msg = ex.ToString() });
            }
     
        }


        public ActionResult GetSupplierType()
        {
            var ret = new List<object>();
            var sql = "select distinct(suppliertype) from dbo.supplier";
            var dbSupplierTypes = DapperWrapper.GetAll<int>(sql);
            foreach(var type in dbSupplierTypes)
            {
                ret.Add(new { id = type, name = type });
            }
            return Json(ret);
        }



    }
}