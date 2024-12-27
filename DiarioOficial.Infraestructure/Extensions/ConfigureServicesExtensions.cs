using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using DiarioOficial.Infraestructure.Services.OfficialElectronicDiary;
using DiarioOficial.Infraestructure.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Services.SendEmail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiarioOficial.Infraestructure.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOfficialStateDiaryService, OfficialStateDiaryService>();
            services.AddTransient<IOfficialElectronicDiaryService, OfficialElectronicDiaryService>();
            services.AddTransient<ISendEmailService, SendEmailService>();

            return services;
        }
    }
}
