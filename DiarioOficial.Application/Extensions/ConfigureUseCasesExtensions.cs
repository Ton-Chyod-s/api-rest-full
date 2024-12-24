using DiarioOficial.Application.UseCases.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using Microsoft.Extensions.DependencyInjection;

namespace DiarioOficial.Application.Extensions
{
    public static class ConfigureUseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IOfficialStateDiaryUseCase, OfficialStateDiaryUseCase>();

            return services;
        }
    }
}
