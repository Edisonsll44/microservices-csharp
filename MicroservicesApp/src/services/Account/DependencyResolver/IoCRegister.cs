using Account.Command.Service.Handlers;
using Account.Query.Service;
using AccountPersistenceDatabase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Account.DependencyResolver
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
            services.AddTransient<IAccountQueryService, AccountQueryService>();
            services.AddTransient<IAccountCommandService, AccountCommandService>();
            services.AddTransient<IAccountUpdateEventHandlerService, AccountUpdateEventHandlerService>();
            services.AddTransient<IAccountCreateEventHandlerService, AccountCreateEventHandlerService>();
            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            return services;
        }
    }

}
