using DiarioOficial.Domain.Interface.DatabaseAccessor.Base;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using DiarioOficial.Domain.Interface.Services.Token;
using DiarioOficial.Domain.Interface.UnitOfWork;
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
            services.AddTransient<IOfficialStateDiaryService, OfficialStateDiaryService>();
            services.AddTransient<IOfficialElectronicDiaryService, OfficialElectronicDiaryService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            services.AddTransient<ITokenService, TokenService>();
            #endregion

            services.AddScoped<INpgsqlService, NpgsqlService>();

            return services;
        }
    }
}
