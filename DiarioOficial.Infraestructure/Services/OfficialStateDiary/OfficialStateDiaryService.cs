using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneOf;
using RestSharp;

namespace DiarioOficial.Infraestructure.Services.OfficialStateDiary
{
    public class OfficialStateDiaryService() : IOfficialStateDiaryService
    {

        public async Task<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>> ResponseOfficialStateDiaryService(string name, string year)
        {
            var queryBody = QueryBody(name, year);

            var response = await RestClientHelpers.FetchQueryAsync(queryBody);

            return DeserializeOfficialStateDiary(response);
        }

        internal Dictionary<string, string> QueryBody(string name, string year)
        {
            return new Dictionary<string, string>
            {
                { "action", "edicoes_json" },
                { "palavra", name },
                { "de", $"01/01/{year}" },
                { "ate", $"21/12/{year}" }
            };
        }

        internal OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError> DeserializeOfficialStateDiary(RestResponse restResponse)
        {
            var diaryContent = restResponse.Content;

            if (string.IsNullOrWhiteSpace(diaryContent))
                return new DatabaseError();

            var diaryObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(diaryContent);

            if (diaryObject is null || diaryObject.ContainsKey("erro"))
                return new DatabaseError();

            if (!diaryObject.TryGetValue("data", out var data) || data is not JArray dataArray)
                return new DatabaseError();

            var diary = dataArray
                .Select(jsonItem => new ResponseOfficialStateDiaryDTO(
                    jsonItem["numero"]?.ToString() ?? string.Empty,
                    jsonItem["dia"]?.ToString() ?? string.Empty,
                    jsonItem["arquivo"]?.ToString() ?? string.Empty,
                    jsonItem["desctpd"]?.ToString() ?? string.Empty,
                    jsonItem["codigodia"]?.ToString() ?? string.Empty
                ))
                .ToList();

            return diary;
        }

    }
}
