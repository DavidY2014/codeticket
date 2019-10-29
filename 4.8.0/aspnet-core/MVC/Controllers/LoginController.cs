using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;
using MVC.Models;
using TickCode.ORM.DBModels;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestPhoneRecap(string phoneNumber)
        {
            //send sms messge


            return Json("");
        }


        public ActionResult Register(string username,string password)
        {
            using (var dbContext = new TicketCodeTestDBContext())
            {

            }


                return Json("");
        }
        

        public ActionResult LoginRequest(string username,string password)
        {
            var ret = new LoginResultVM();
            ret.Success = false;
            ret.msg = "failed";
            //跳转到内部界面，否则跳转回去
            using (var dbContext = new TicketCodeTestDBContext())
            {
                var efUser = dbContext.Tlogin.Where(item => item.UserName == username && item.Password == password);
                if (efUser != null)
                {
                    ret.Success = true;
                    return Json(ret);
                }
            }
            return Json(ret);
        }



    }
}