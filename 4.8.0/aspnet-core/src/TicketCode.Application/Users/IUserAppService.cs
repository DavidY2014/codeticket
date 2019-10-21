using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TicketCode.Roles.Dto;
using TicketCode.Users.Dto;

namespace TicketCode.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
