using AcessaCity.Business.Interfaces;
using AcessaCity.Business.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace AcessaCity.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
        
    }
}