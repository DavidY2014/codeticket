using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TicketCode.EntityFrameworkCore
{
    public static class TicketCodeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TicketCodeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TicketCodeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
