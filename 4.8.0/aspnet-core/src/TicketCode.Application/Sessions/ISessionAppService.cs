using System.Threading.Tasks;
using Abp.Application.Services;
using TicketCode.Sessions.Dto;

namespace TicketCode.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
