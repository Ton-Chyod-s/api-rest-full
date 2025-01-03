using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.SaveAndNotify;
using Microsoft.AspNetCore.Http;
using OneOf;

namespace DiarioOficial.Application.UseCases.SaveAndNotify
{
    internal class SaveAndNotifyUseCase 
        (
            IOfficialMunicipalDiaryService officialStateDiaryService,
            IOfficialStateDiaryService officialElectronicDiaryService,
            IHttpContextAccessor httpContextAccessor

        ) : ISaveAndNotifyUseCase
    {
        private readonly IOfficialMunicipalDiaryService _officialStateDiaryService = officialStateDiaryService;
        private readonly IOfficialStateDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<OneOf<bool, BaseError>> SaveAndNotify()
        {
            var name = _httpContextAccessor.HttpContext.GetSystemIdentifierIdByContext();

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var year = DateTime.Now.Year.ToString();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            var stateDiaryData = await _officialStateDiaryService.GetOfficialMunicipalDiaryResponse(name, yearValid.GetValue());

            if (stateDiaryData.IsError())
                return stateDiaryData.GetError();

            var electronicDiaryData = await _officialElectronicDiaryService.GetOfficialStateDiaryResponse(name, yearValid.GetValue());

            if (electronicDiaryData.IsError())
                return electronicDiaryData.GetError();

            // TODO: Descobrir id token

            // TODO: procurar no banco de dados o email e nome do id do token

            // TODO: Salvar no banco

            // TODO: Enviar email

            return true;
        }
        
    }
}
