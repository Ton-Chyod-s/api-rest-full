using DiarioOficial.CrossCutting.Errors;
using OneOf;
using RestSharp;

namespace DiarioOficial.Domain.Interface.Services.OfficialStateDiary
{
    public interface IOfficialStateDiaryService
    {
        Task<OneOf<RestResponse, BaseError>> ResponseOfficialStateDiaryService(string name);
    }
}
