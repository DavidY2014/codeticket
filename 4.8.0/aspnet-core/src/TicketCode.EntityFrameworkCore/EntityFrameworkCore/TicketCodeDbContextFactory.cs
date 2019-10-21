using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TicketCode.Configuration;
using TicketCode.Web;

namespace TicketCode.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TicketCodeDbContextFactory : IDesignTimeDbContextFactory<TicketCodeDbContext>
    {
        public TicketCodeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TicketCodeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TicketCodeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TicketCodeConsts.ConnectionStringName));

            return new TicketCodeDbContext(builder.Options);
        }
    }
}
