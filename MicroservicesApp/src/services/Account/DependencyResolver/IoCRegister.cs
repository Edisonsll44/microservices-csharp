using Account.Command.Service.Handlers;
using Account.Command.Service.Handlers.Account;
using Account.PersistenceDatabase.Repositories;
using Account.Query.Service;
using Account.Query.Service.Account;
using Account.Service.Proxies;
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
            AddRegisterProxies(services);
            return services;
        }
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountQueryService, AccountQueryService>();
            services.AddTransient<IAccountCommandService, AccountCommandService>();
            services.AddTransient<IAccountClientCreateEventHandlerService, AccountClientCreateEventHandlerService>();
            services.AddTransient<IAccountUpdateEventHandlerService, AccountUpdateEventHandlerService>();
            services.AddTransient<IAccountCreateEventHandlerService, AccountCreateEventHandlerService>();
            services.AddTransient<IAccountCreateEventHandlerService, AccountCreateEventHandlerService>();
            services.AddTransient<IAccountClientQueryService, AccountClientQueryService>();
            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountClientRepository, AccountClientRepository>();
            return services;
        }

        public static IServiceCollection AddRegisterProxies(this IServiceCollection services)
        {
            services.AddTransient<IAccountProxy, AccountProxy>();
            services.AddTransient<IClientProxy, ClientProxy>();
            return services;
        }
    }

}
