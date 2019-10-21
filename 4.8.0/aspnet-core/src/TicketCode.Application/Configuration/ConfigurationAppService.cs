using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TicketCode.Configuration.Dto;

namespace TicketCode.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TicketCodeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
