

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Identity;
using StackExchange.Redis;

namespace Persistence
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Service, IConfiguration configuration)
        {
            Service.AddDbContext<StoreDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            Service.AddScoped<IDataSeeding, DataSeeding>();

            Service.AddScoped<IUnitOfWork, UnitOfWork>();
            Service.AddScoped<IBasketRepository, BasketRepository>();
            Service.AddSingleton<IConnectionMultiplexer>((_) =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnectionString"));
            });

            Service.AddDbContext<StoreIdentityDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            return Service;


        }
    }
}
