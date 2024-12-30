using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
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

        public async Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> GetStateDiaryRecords(string name, string year)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            return await _officialStateDiaryService.GetOfficialStateDiaryResponse(name, yearValid.GetValue());
        }
    }
}

