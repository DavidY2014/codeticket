using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TicketCode.Authorization.Roles;
using TicketCode.Authorization.Users;
using TicketCode.MultiTenancy;

namespace TicketCode.EntityFrameworkCore
{
    public class TicketCodeDbContext : AbpZeroDbContext<Tenant, Role, User, TicketCodeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TicketCodeDbContext(DbContextOptions<TicketCodeDbContext> options)
            : base(options)
        {
        }
    }
}
