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
            using (var dbContext = new TicketCodeTestDBContext())
            {
                var efSuppliers = dbContext.Tsupplier.ToList();
                if (queryModel.suppliername != null)
                {
                    efSuppliers = efSuppliers.Where(item => item.Name == queryModel.suppliername).ToList();
                }
                if (queryModel.suppliertype != null)
                {
                    efSuppliers = efSuppliers.Where(item => item.Type == queryModel.suppliertype).ToList();
                }
                foreach (var item in efSuppliers)
                {
                    var supplierVM = new SupplierInfoViewModel();
                    supplierVM.Id = item.Id;
                    supplierVM.name = item.Name;
                    supplierVM.financecontacter = item.FinanceContactor;
                    supplierVM.financephone = item.FinancePhone;
                    supplierVM.sender = item.Sender;
                    supplierVM.senderphone = item.SenderPhone;
                    var editrow = "<a href=\"#\" onclick=\"editSupplier()\">编辑</a>";
                    var deleterow = "<a href=\"#\" onclick=\"removeSupplier()\">删除</a>";
                    supplierVM.operation = editrow + " " + deleterow;
                    result.Add(supplierVM);
                }
            }
            return Json(result);
        }

        /// <summary>
        /// 编辑和新增页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateNewSupplier(string supplierid)
        {
            var model = new SupplierCreateNewVM();
            //获取supplier的信息
            if (supplierid != null)
            {
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efSupplier = dbContext.Tsupplier.Find(supplierid);
                    model.suppliername = efSupplier.Name;
                    model.suppliertype = efSupplier.Type;
                    model.companyname = efSupplier.CompanyName;
                    model.companyaddress = efSupplier.CompanyAddress;
                    model.financecontacter = efSupplier.FinanceContactor;
                    model.financephone = efSupplier.FinancePhone;
                    model.deliveryname = efSupplier.Sender;
                    model.deliveryphone = efSupplier.SenderPhone;
                    model.servicename = efSupplier.AfterMarketer;
                    model.servicephone = efSupplier.AfterMarketPhone;
                    var efBill = dbContext.Tbill.FirstOrDefault(item => item.SupplierId == efSupplier.Id);
                    if (efBill != null)
                    {
                        model.taxpayernumber = efBill.TaxNumber;
                        model.billheader = efBill.BillHeader;
                        model.openbank = efBill.Openbank;
                        model.bankaccount = efBill.BankAccount;
                    }
                }
            }
            return View(model);
        }

        public ActionResult SaveNewSupplier(SupplierCreateNewVM createModel)
        {
            try
            {
                var efSupplier = new Tsupplier();
                var efBill = new Tbill();
                efSupplier.Name = createModel.suppliername;
                efSupplier.Type = createModel.suppliertype;
                efSupplier.FinanceContactor = createModel.financecontacter;
                efSupplier.FinancePhone = createModel.financephone;
                efSupplier.Sender = createModel.deliveryname;
                efSupplier.SenderPhone = createModel.deliveryphone;
                efSupplier.CompanyName = createModel.companyname;
                efSupplier.CompanyAddress = createModel.companyaddress;
                efSupplier.AfterMarketer = createModel.servicename;
                efSupplier.AfterMarketPhone = createModel.servicephone;
                efBill.Id = UniqueGenerator.UniId();
                efBill.TaxNumber = createModel.taxpayernumber;
                efBill.BillHeader = createModel.billheader;
                efBill.Openbank = createModel.openbank;
                efBill.BankAccount = createModel.bankaccount;
                efBill.Name = "供应商开票";
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    dbContext.Database.BeginTransaction();
                    dbContext.Tbill.Add(efBill);
                    dbContext.Tsupplier.Add(efSupplier);
                    dbContext.SaveChanges();
                    dbContext.Database.CommitTransaction();
                }
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
                using (var dbContext = new TicketCodeTestDBContext())
                {
                    var efSupplier = dbContext.Tsupplier.Find(supplierid);
                    dbContext.Tsupplier.Remove(efSupplier);
                    dbContext.SaveChanges();
                }
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