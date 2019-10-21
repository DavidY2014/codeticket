using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CatelogController : Controller
    {
        // GET: Catelog
        public ActionResult Index()
        {
            return View();
        }


    }
}