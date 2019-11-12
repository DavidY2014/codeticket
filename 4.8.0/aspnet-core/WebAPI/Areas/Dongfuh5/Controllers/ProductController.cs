using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ORM.GiftCardModels;

namespace WebAPI.Areas.Dongfuh5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GiftCardDBContext _context;

        public ProductController(GiftCardDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取类别下的所有商品
        /// </summary>
        /// <param name="class1Id"></param>
        /// <param name="class2Id"></param>
        /// <returns></returns>
        [HttpGet("GetAllProductsByClass")]
        public ActionResult<List<Tproduct>> GetAllProductsByClass(int class1Id,int class2Id)
        {
            var products = _context.Tproduct.Where(item => item.Class1 == class1Id && item.Class2 == class2Id).ToList();
            return products;
        }



        /// <summary>
        /// 获取对应类别下的第一个商品
        /// </summary>
        /// <param name="class1Id"></param>
        /// <param name="class2Id"></param>
        /// <returns></returns>
        [HttpGet("GetAllProductsByClassFirst")]
        public ActionResult<Tproduct> GetAllProductsByClassFirst(int class1Id, int class2Id)
        {
            var products = _context.Tproduct.Where(item => item.Class1 == class1Id && item.Class2 == class2Id).ToList();
            if (products == null)
                return null;
            return products.FirstOrDefault();
        }




    }
}
