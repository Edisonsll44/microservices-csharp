using AccountPersistenceDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.DependencyResolver
{
    public static class IoCRegisterDataContext
    {
        public static IServiceCollection AddRegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IApplicationAccountDbContext, ApplicationAccountDbContext>();
            services.AddDbContext<ApplicationAccountDbContext>(option => option.UseSqlServer(connectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationHystory", "account")));
            return services;
        }
    }
}
