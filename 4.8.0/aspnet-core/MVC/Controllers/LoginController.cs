using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Filters;

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

        public ActionResult Register(string username,string password,string phonetoken)
        {
            return Json("");
        }
        

        public ActionResult LoginRequest()
        {

            //跳转到内部界面，否则跳转回去
            return Json("");
        }



    }
}