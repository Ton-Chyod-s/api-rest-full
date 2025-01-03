using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary
{
    public interface IOfficialStateDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> GetOfficialStateDiaryRecords(string name, string year);
    }
}
