using Microsoft.Extensions.DependencyInjection;
using Movement.Command.Service;
using Movement.PersistenceDatabase;
using Movement.Query.Service;

namespace Movement.DependencyResolver
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterServices(services);

            return services;
        }
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMovementCommandService, MovementCommandService>();
            services.AddTransient<IMovementQueryService, MovementQueryService>();
            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMovementRepository, MovementRepository>();
            return services;
        }
    }
}
