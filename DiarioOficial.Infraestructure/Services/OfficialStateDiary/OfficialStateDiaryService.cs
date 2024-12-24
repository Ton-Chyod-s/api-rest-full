using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Helpers;
using Newtonsoft.Json;
using OneOf;
using RestSharp;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiarioOficial.Infraestructure.Services.OfficialStateDiary
{
    public class OfficialStateDiaryService() : IOfficialStateDiaryService
    {

        public async Task<OneOf<ResponseOfficialStateDiaryDTO, BaseError>> ResponseOfficialStateDiaryService(string name, string year)
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

        internal OneOf<ResponseOfficialStateDiaryDTO, BaseError> DeserializeOfficialStateDiary(RestResponse restResponse)
        {
            var diaryContent = restResponse.Content;

            if (diaryContent is null)
                return new DatabaseError();

            var diaryObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(diaryContent);

            if (diaryObject is null || diaryObject.ContainsKey("erro"))
                return new DatabaseError();

            var diary = new List<ResponseOfficialStateDiaryDTO>();

            foreach (var item in diaryObject)
            {
                diary.Add(new ResponseOfficialStateDiaryDTO
                {
                    Number = item["numero"],
                    Day = item["dia"],
                    File = item["arquivo"],
                    Description = item["desctpd"],
                    DayCode = item["codigodia"]
                });
            }

            throw new NotImplementedException();
        }
    }
}
