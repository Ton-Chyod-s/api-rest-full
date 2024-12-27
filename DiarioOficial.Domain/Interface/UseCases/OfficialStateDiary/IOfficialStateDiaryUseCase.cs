using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary
{
    public interface IOfficialStateDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> GetStateDiaryRecords(string cpf, string year);
    }
}
