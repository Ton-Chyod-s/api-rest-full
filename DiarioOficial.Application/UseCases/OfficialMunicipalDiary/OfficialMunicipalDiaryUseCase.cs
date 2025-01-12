using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.CrossCutting.Extensions;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using OneOf;

namespace DiarioOficial.Application.UseCases.OfficialStateDiary
{
    internal class OfficialMunicipalDiaryUseCase
        (
            IOfficialMunicipalDiaryService officialStateDiaryService
        ) : IOfficialMunicipalDiaryUseCase
    {
        private readonly IOfficialMunicipalDiaryService _officialStateDiaryService = officialStateDiaryService;

        public async Task<OneOf<List<ResponseOfficialDiaryDTO>, BaseError>> GetOfficialMunicipalDiary(string name, string year)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                return new InvalidName();

            var yearValid = year.EnsureValidYear();

            if (yearValid.IsError())
                return yearValid.GetError();

            return await _officialStateDiaryService.GetOfficialMunicipalDiaryResponse(name, yearValid.GetValue());
        }
    }
}

