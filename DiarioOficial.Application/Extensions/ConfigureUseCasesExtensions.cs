﻿using DiarioOficial.Application.UseCases.Login;
using DiarioOficial.Application.UseCases.OfficialElectronicDiary;
using DiarioOficial.Application.UseCases.OfficialStateDiary;
using DiarioOficial.Application.UseCases.Person;
using DiarioOficial.Application.UseCases.SaveAndNotify;
using DiarioOficial.Application.UseCases.SendEmail;
using DiarioOficial.Domain.Interface.UseCases.Login;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.Person;
using DiarioOficial.Domain.Interface.UseCases.SaveAndNotify;
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
            services.AddScoped<IPersonUseCase, PersonUseCase>();
            services.AddScoped<IGetIdPersonUseCase, GetIdPersonUseCase>();
            services.AddScoped<IRemovePersonUseCase, RemovePersonUseCase>();
            services.AddScoped<ISaveAndNotifyUseCase, SaveAndNotifyUseCase>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();

            return services;
        }
    }
}
