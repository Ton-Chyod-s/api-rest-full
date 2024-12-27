using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Services.OfficialElectronicDiary;
using DiarioOficial.Infraestructure.Constants;
using DiarioOficial.Infraestructure.Helpers.RestClientHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneOf;
using RestSharp;

namespace DiarioOficial.Infraestructure.Services.OfficialElectronicDiary
{
    public class OfficialElectronicDiaryService : IOfficialElectronicDiaryService
    {
        public async Task<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>> GetOfficialElectronicDiaryresponse(string name, string year)
        {
            var requestQuery = CreateRequestBody(name, year);

            var url = UrlConstants.OFFICIAL_DIARY_ELECTRONIC_URL;

            var response = await RestClientBodyHelpers.GetOfficialStateDiary(requestQuery, url);

            if (response is null)
                return new InvalidResponseContent();

            return DeserializeOfficialStateDiary(response);
        }

        internal Dictionary<string, string> CreateRequestBody(string name, string year)
        {
            return new Dictionary<string, string>
            {
                { "Filter.DataInicial", $"01/01/{year}" },
                { "Filter.DataFinal", $"31/12/{year}" },
                { "Filter.Texto", name },
                { "Filter.TipoBuscaEnum", "1"}
            };
        }

        internal OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError> DeserializeOfficialStateDiary(RestResponse restResponse)
        {
            var diaryContent = restResponse.Content;

            if (string.IsNullOrWhiteSpace(diaryContent))
                return default;

            var diaryObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(diaryContent);

            if (diaryObject is null || diaryObject.ContainsKey("erro"))
                return new InvalidResponseContent();

            if (!diaryObject.TryGetValue("data", out var data) || data is not JArray dataArray)
                return new NotFoundOfficialStateDiary();

            var diary = dataArray
                .Select(jsonItem => new ResponseOfficialElectronicDiaryDTO(
                    //jsonItem["numero"]?.ToString() ?? string.Empty
                ))
                .ToList();

            return diary;
        }

    }
}
