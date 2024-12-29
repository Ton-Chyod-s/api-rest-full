using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Infraestructure.Context;
using DiarioOficial.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkClass = DiarioOficial.Infraestructure.UnitOfWork.UnitOfWork;

namespace DiarioOficial.Infraestructure.Extensions
{
    public static class ConfigureRepositoriesExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            #region [Database Context Setup OfficialDiaryDbContext]
            var connectionString = Environment.GetEnvironmentVariable("CONTEXT_DATA_SOURCE");

            if (!string.IsNullOrEmpty(connectionString))
                services.AddDbContext<OfficialDiaryDbContext>(options => options.UseNpgsql(connectionString));
            else
                services.AddDbContext<OfficialDiaryDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("OfficialDiaryDb")));
            #endregion

            #region [Dependency Injection Setup]
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWorkClass>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            #endregion

            return services;
        }
    }
}
