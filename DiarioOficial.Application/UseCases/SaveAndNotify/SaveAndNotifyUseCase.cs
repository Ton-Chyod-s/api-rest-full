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
            IOfficialStateDiaryService officialStateDiaryService,
            IOfficialElectronicDiaryService officialElectronicDiaryService

        ) : ISaveAndNotifyUseCase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOfficialStateDiaryService _officialStateDiaryService = officialStateDiaryService;
        private readonly IOfficialElectronicDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;

        public async Task<OneOf<bool, BaseError>> SaveAndNotify(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var year = DateTime.Now.Year.ToString();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            var stateDiaryData = await _officialStateDiaryService.GetOfficialStateDiaryResponse(name, yearValid.GetValue());

            if (stateDiaryData.IsError())
                return stateDiaryData.GetError();

            var electronicDiaryData = await _officialElectronicDiaryService.GetOfficialElectronicDiaryresponse(name, yearValid.GetValue());

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
