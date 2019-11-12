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
    public class OrderController : ControllerBase
    {
        private readonly GiftCardDBContext _context;

        public OrderController(GiftCardDBContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllOrdersByCustomerId")]
        public ActionResult<List<TsoOrder>> GetAllOrdersByCustomerId(int customerId)
        {
            var customer = new Tcustomer();
            customer = _context.Tcustomer.Find(customerId);
            return customer.TsoOrder.ToList();
        }



        [HttpGet("GetAllOrderProductsByOrderId")]
        public ActionResult<List<TorderProduct>> GetAllOrderProductsByOrderId(int orderId)
        {
            var order = new TsoOrder();
            order = _context.TsoOrder.Find(orderId);
            return order.TorderProduct.ToList();
        }




    }
}
