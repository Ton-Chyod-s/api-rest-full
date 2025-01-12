using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary
{
    public interface IOfficialStateDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialDiaryDTO>, BaseError>> GetOfficialStateDiary(string name, string year);
    }
}
