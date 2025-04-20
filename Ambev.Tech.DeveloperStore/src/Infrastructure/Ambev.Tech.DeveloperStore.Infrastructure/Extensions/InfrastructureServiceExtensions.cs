using Ambev.Tech.DeveloperStore.Application.Interface;
using Ambev.Tech.DeveloperStore.Infrastructure.Data;
using Ambev.Tech.DeveloperStore.Infrastructure.Repository;
using Ambev.Tech.DeveloperStore.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.Tech.DeveloperStore.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // Registrar os repositórios
            services.AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICartRepository, CartRepository>()
            .AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<JwtService>();
        }
    }
}
