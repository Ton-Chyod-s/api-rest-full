using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Helpers;
using Newtonsoft.Json.Linq;
using OneOf;
using RestSharp;

namespace DiarioOficial.Infraestructure.Services.OfficialStateDiary
{
    public class OfficialStateDiaryService() : IOfficialStateDiaryService
    {

        public async Task<OneOf<RestResponse, BaseError>> ResponseOfficialStateDiaryService(string name)
        {
            var dateTime = DateTime.Now;

            var year = dateTime.Year;

            var queryBody = QueryBody(name, year.ToString());

            var response = await RestClientHelpers.FetchQueryAsync(queryBody);

            return response;
        }

        internal object QueryBody(string name, string year)
        {
            return new
            {
                action = "edicoes_json",
                palavra = name,
                de = $"01/01/{year}",
                ate = $"21/12/{year}"
            };
        }
    }
}
