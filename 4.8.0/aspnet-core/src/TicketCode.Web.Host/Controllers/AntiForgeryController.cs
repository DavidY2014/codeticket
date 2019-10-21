using Microsoft.AspNetCore.Antiforgery;
using TicketCode.Controllers;

namespace TicketCode.Web.Host.Controllers
{
    public class AntiForgeryController : TicketCodeControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
