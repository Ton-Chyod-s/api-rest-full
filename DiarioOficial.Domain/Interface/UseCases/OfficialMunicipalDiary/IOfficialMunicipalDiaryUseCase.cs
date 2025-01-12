using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary
{
    public interface IOfficialMunicipalDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialDiaryDTO>, BaseError>> GetOfficialMunicipalDiary(string cpf, string year);
    }
}
