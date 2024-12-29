using DiarioOficial.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiarioOficial.Infraestructure.Extensions
{
    public static class ConfigureRepositoriesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONTEXT_DATA_SOURCE");

            if (!string.IsNullOrEmpty(connectionString))
                services.AddDbContext<OfficialDiaryDbContext>(options => options.UseNpgsql(connectionString));
            else
                services.AddDbContext<OfficialDiaryDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("OfficialDiaryDb")));

            return services;
        }
    }
}
