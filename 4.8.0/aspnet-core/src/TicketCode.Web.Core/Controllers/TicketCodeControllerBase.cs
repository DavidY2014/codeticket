using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TicketCode.Controllers
{
    public abstract class TicketCodeControllerBase: AbpController
    {
        protected TicketCodeControllerBase()
        {
            LocalizationSourceName = TicketCodeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
