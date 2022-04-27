using Felix.WebService.Common.ConfigurationOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Felix.WebService.WS.Extensions
{
    public static class AddDependenciesExtensions
    {
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));

            return services;
        }
    }
}
