using Abp.Authorization;
using TicketCode.Authorization.Roles;
using TicketCode.Authorization.Users;

namespace TicketCode.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
