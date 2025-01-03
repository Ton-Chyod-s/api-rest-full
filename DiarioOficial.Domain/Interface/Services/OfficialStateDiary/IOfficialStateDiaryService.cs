using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary
{
    public interface IOfficialStateDiaryService
    {
        Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> GetOfficialStateDiaryResponse(string name, string year);
    }
}
