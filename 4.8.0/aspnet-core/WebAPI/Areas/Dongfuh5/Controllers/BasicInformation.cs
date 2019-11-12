using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ORM.GiftCardModels;

namespace WebAPI.Areas.Dongfuh5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInformation : ControllerBase
    {
        private readonly GiftCardDBContext _context;

        public BasicInformation(GiftCardDBContext context)
        {
            _context = context;
        }

        #region h5 interface 

        /// <summary>
        /// 通过批次获取banner 
        /// 1,获取banner
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBannerByBatchId")]
        public async Task<ActionResult<IEnumerable<Tcustomer>>> GetBannerByBatchId(int batchId)
        {
            return await _context.Tcustomer.ToListAsync();
        }

        /// <summary>
        /// 3 , 兑换
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetExchangeRetunrInfo")]
        public ActionResult<string> GetExchangeRetunrInfo()
        {
            return null;
        }
        





        #endregion







    }
}
