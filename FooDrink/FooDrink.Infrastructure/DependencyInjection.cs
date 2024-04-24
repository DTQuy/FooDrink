using FooDrink.Database;
using FooDrink.Repository.Interface;
using FooDrink.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FooDrink.Infrastructure
{
    public static class DependencyInjection
    {
        public static void ConfigureServiceManager(this IServiceCollection services)
        {

            services.AddHttpContextAccessor();
            services.AddScoped<IUserRepository, UserRepository>();

        }
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            _ = services.AddDbContext<FooDrinkDbContext>(opts =>
                opts.UseSqlServer(connectionString));
        }
    }
}
