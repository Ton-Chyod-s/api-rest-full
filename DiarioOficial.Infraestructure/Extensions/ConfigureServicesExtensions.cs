using DiarioOficial.Domain.Interface.DatabaseAccessor.Base;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Infraestructure.DatabaseAccessor.Base;
using DiarioOficial.Infraestructure.Services.OfficialElectronicDiary;
using DiarioOficial.Infraestructure.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Services.SendEmail;
using DiarioOficial.Infraestructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiarioOficial.Infraestructure.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region [Services]
            services.AddTransient<IOfficialMunicipalDiaryService, OfficialMunicipalDiaryService>();
            services.AddTransient<IOfficialStateDiaryService, OfficialStateDiaryService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<ITokenService, TokenService>();
            #endregion

            services.AddScoped<INpgsqlService, NpgsqlService>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("OfficialDiaryDb");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'OfficialDiaryDb' not found.");
                }

                return new NpgsqlService(connectionString);
            });

            return services;
        }
    }
}
