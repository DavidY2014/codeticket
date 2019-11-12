using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ORM.GiftCardModels;

namespace WebAPI.Areas.Dongfuh5.Controllers
{
    /// <summary>
    ///卷码信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CouponInformationController : ControllerBase
    {
        private readonly GiftCardDBContext _context;

        public CouponInformationController(GiftCardDBContext context)
        {
            _context = context;
        }



        /// <summary>
        /// 返回用户的所有礼品卡信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("GetMyAllGiftCards")]
        public ActionResult<List<Tcoupon>> GetMyAllGiftCards(int customerId)
        {
            var customer = new Tcustomer();
            customer = _context.Tcustomer.Find(customerId);
            return customer.Tcoupon.ToList();
        }
        





    }
}
