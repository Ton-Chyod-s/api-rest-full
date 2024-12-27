using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary
{
    public interface IOfficialElectronicDiaryService
    {
        Task<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>> GetOfficialElectronicDiaryresponse(string name, string year);
    }
}
