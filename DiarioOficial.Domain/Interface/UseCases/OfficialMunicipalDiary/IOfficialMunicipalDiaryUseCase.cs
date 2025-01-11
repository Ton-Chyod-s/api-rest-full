using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary
{
    public interface IOfficialMunicipalDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>> GetStateDiaryRecords(string cpf, string year);
    }
}
