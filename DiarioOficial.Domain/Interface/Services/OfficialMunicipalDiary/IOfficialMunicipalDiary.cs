using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using OneOf;
using RestSharp;

namespace DiarioOficial.Domain.Interface.Services.OfficialStateDiary
{
    public interface IOfficialMunicipalDiaryService
    {
        Task<OneOf<List<ResponseOfficialDiaryDTO>, BaseError>> GetOfficialMunicipalDiaryResponse(string name, string year);
    }
}
