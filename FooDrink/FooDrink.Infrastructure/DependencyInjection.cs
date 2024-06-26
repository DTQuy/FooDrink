﻿using FooDrink.BusinessService.Interface;
using FooDrink.BusinessService.Service;
using FooDrink.BussinessService.Interface;
using FooDrink.BussinessService.Service;
using FooDrink.Database;
using FooDrink.Database.Models;
using FooDrink.Infrastructure.Authentication;
using FooDrink.Repository;
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
            _ = services.AddHttpContextAccessor();
            _ = services.AddScoped<IUserRepository, UserRepository>();
            _ = services.AddScoped<IProductRepository, ProductRepository>();
            _ = services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            _ = services.AddScoped<IAuthenticationService, AuthenticationService>();
            _ = services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            _ = services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            _ = services.AddScoped<IRestaurantService, RestaurantService>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FooDrinkDbContext>(opts =>
                opts.UseSqlServer(connectionString), ServiceLifetime.Transient); 
            
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<FooDrinkDbContext>();
            dbContext.Database.EnsureCreated();
        }
    }
}
