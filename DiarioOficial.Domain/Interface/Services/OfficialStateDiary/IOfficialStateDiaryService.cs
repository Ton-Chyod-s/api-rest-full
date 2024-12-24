using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;
using RestSharp;

namespace DiarioOficial.Domain.Interface.Services.OfficialStateDiary
{
    public interface IOfficialStateDiaryService
    {
        Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> ResponseOfficialStateDiaryService(string name, string year);
    }
}
