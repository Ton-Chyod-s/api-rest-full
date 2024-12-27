using DiarioOficial.Application.UseCases.OfficialElectronicDiary;
using DiarioOficial.Application.UseCases.OfficialStateDiary;
using DiarioOficial.Application.UseCases.SendEmail;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.SendEmail;
using Microsoft.Extensions.DependencyInjection;

namespace DiarioOficial.Application.Extensions
{
    public static class ConfigureUseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IOfficialStateDiaryUseCase, OfficialStateDiaryUseCase>();
            services.AddScoped<IOfficialElectronicDiaryUseCase, OfficialElectronicDiaryUseCase>();
            services.AddScoped<ISendEmailUseCase, SendEmailUseCase>();

            return services;
        }
    }
}
