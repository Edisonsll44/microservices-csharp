using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovementPersistenceDatabase;

namespace Movement.DependencyResolver
{
    public static class IoCRegisterDataContext
    {
        public static IServiceCollection AddRegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IApplicationMovementDbContext, ApplicationMovementDbContext>();
            services.AddDbContext<ApplicationMovementDbContext>(option => option.UseSqlServer(connectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationHystory", "movement")));
            return services;
        }
    }
}