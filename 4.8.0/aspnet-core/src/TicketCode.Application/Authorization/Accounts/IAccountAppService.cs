using System.Threading.Tasks;
using Abp.Application.Services;
using TicketCode.Authorization.Accounts.Dto;

namespace TicketCode.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
