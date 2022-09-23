using Microsoft.Extensions.DependencyInjection;
using Movement.Command.Service;
using Movement.Command.Service.Contracts;
using Movement.PersistenceDatabase;
using Movement.Query.Service;
using Movement.Rules.Business;
using Movement.Service.Proxies;

namespace Movement.DependencyResolver
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterServices(services);
            AddRegisterValidations(services);
            AddRegisterProxies(services);
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

        public static IServiceCollection AddRegisterValidations(this IServiceCollection services)
        {
            services.AddTransient<IBalanceValidator, BalanceValidator>();
            return services;
        }
        public static IServiceCollection AddRegisterProxies(this IServiceCollection services)
        {
            services.AddTransient<IMovementAccountProxy, MovementAccountProxy>();
            services.AddTransient<IMovementClientProxy, MovementClientProxy>();
            return services;
        }
    }
}
