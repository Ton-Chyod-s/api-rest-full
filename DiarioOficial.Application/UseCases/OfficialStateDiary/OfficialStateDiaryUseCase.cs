using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using OneOf;

namespace DiarioOficial.Application.UseCases.OfficialElectronicDiary
{
    internal class OfficialStateDiaryUseCase
        (
            IOfficialStateDiaryService officialElectronicDiaryService
        ) : IOfficialStateDiaryUseCase
    {
        private readonly IOfficialStateDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;

        public async Task<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>> GetOfficialStateDiaryRecords(string name, string year)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            return await _officialElectronicDiaryService.GetOfficialStateDiaryResponse(name, year);
        }
            
    }
}
