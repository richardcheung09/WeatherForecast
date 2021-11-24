using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsourcing.SportChamps.Weather.Model.Others;

namespace Microsourcing.SportChamps.Weather.App.Infrastractures.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Register Identity Service using custom user and role entities
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_configuration"></param>
        public static void AddAppConfigurationServices(this IServiceCollection services, IConfiguration _configuration)
        {
            services.Configure<AppConfig>(_configuration.GetSection("AppConfig"));
        }
    }
}
