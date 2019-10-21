using System.Threading.Tasks;
using TicketCode.Configuration.Dto;

namespace TicketCode.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
