using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Interfaces.Repository;
using AcessaCity.Business.Notifications;
using AcessaCity.Data.Context;
using AcessaCity.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AcessaCity.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
        
    }
}