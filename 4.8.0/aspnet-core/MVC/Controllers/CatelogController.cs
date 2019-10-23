using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using TickCode.ORM;

namespace MVC.Controllers
{
    public class CatelogController : Controller
    {
        // GET: Catelog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTreeData()
        {
            var items = new List<object>();
            //var sql = "select * from dbo.catelog where parentid=0";
            //var allsql = "select * from dbo.catelog";
            //var parentIds = DapperWrapper.GetAll<int>(sql);
            //var catelogs = DapperWrapper.GetAll<>(allsql);
            //foreach (var parentId in parentIds)
            //{
            //    var parentSql = "select * from dbo.catelog where id=" + parentId + " and parentid=0";
            //    var dbParent = DapperWrapper.GetSingle<dbCatelog>(parentSql);
            //    var childList = new List<CatelogViewModel>();
            //    var getChildSql = "select * from dbo.catelog where parentid=" + parentId;
            //    var dbChildItems = DapperWrapper.GetAll<dbCatelog>(getChildSql);
            //    foreach (var item in dbChildItems)
            //    {
            //        childList.Add(new CatelogViewModel() { id = item.id, name = item.name, parentid = item.parentid });
            //    }
            //    items.Add(new { id = dbParent.id, name = dbParent.name, children = childList.Select(n => new { id = n.id, name = n.name, parentId = n.parentid }) });

            //}
            return Json(items);
        }


    }
}