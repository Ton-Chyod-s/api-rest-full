using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using OneOf;

namespace DiarioOficial.Application.UseCases.OfficialElectronicDiary
{
    internal class OfficialElectronicDiaryUseCase
        (
            IOfficialElectronicDiaryService officialElectronicDiaryService
        ) : IOfficialElectronicDiaryUseCase
    {
        private readonly IOfficialElectronicDiaryService _officialElectronicDiaryService = officialElectronicDiaryService;

        public async Task<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>> GetElectronicDiaryRecords(string name, string year) => 
            await _officialElectronicDiaryService.GetOfficialElectronicDiaryresponse(name, year);
    }
}
