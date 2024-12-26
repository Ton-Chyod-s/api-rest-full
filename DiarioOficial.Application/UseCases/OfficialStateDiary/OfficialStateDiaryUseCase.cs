using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
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

        public async Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> Execute(string name, string year)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new InvalidName();

            if (string.IsNullOrWhiteSpace(year) || !int.TryParse(year, out _))
                return new InvalidYear();

            return await _officialStateDiaryService.GetOfficialStateDiaryResponse(name, year);
        }
    }
}

