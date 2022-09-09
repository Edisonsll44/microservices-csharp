using Client.Service.Queries.Contracts;
using Client.Service.Queries.Services;
using ClientPersistenceDatabase.Contract.Repositories;
using ClientPersistenceDatabase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyResolver
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
            services.AddTransient<IClientQueryService, ClientQueryService>();
            return services;
        }

        public static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            return services;
        }
    }
}