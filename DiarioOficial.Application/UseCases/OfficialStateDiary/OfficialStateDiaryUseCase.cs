using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using OneOf;

namespace DiarioOficial.Application.UseCases.OfficialStateDiary
{
    internal class OfficialStateDiaryUseCase
        (
            IOfficialStateDiaryService officialStateDiaryService
        ) : IOfficialStateDiaryUseCase
    {
        private readonly IOfficialStateDiaryService _officialStateDiaryService = officialStateDiaryService;

        public async Task<OneOf<ResponseOfficialStateDiaryDTO, BaseError>> Execute(string name)
        {
            var officialStateDiary = await _officialStateDiaryService.ResponseOfficialStateDiaryService(name);

            // Implementation
            throw new NotImplementedException();
        }
    }
}
