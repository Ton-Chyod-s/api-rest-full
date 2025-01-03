using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UnitOfWork;
using DiarioOficial.Domain.Interface.UseCases.SaveAndNotify;
using OneOf;

namespace DiarioOficial.Application.UseCases.SaveAndNotify
{
    internal class SaveAndNotifyUseCase 
        (
            IUnitOfWork unitOfWork,
            IOfficialMunicipalDiaryService officialStateDiaryService,
            IOfficialStateDiaryService officialElectronicDiaryService

        ) : ISaveAndNotifyUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOfficialMunicipalDiaryService _officialStateDiaryService = officialStateDiaryService;
        private readonly IOfficialStateDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;

        public async Task<OneOf<bool, BaseError>> SaveAndNotify()
        {
            var name = "Klayton Chrysthian";

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
