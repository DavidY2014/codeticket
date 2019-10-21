using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TicketCode.MultiTenancy.Dto;

namespace TicketCode.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

