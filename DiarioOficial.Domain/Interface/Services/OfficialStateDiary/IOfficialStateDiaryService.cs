using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary
{
    public interface IOfficialStateDiaryService
    {
        Task<OneOf<List<ResponseOfficialDiaryDTO>, BaseError>> GetOfficialStateDiaryResponse(string name, string year);
    }
}
