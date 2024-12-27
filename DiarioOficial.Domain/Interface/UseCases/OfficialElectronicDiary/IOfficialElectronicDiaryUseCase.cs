using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary
{
    public interface IOfficialElectronicDiaryUseCase
    {
        Task<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>> GetElectronicDiaryRecords(string name, string year);
    }
}
