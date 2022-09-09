using ClientPersistenceDatabase;
using ClientPersistenceDatabase.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyResolver
{
    public static class IoCRegisterDataContext
    {
        public static IServiceCollection AddRegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationHystory", "client")));
            return services;
        }
    }
}
