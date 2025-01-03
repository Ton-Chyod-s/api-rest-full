﻿using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.CrossCutting.Errors.OfficialStateDiary;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using DiarioOficial.Infraestructure.Constants;
using DiarioOficial.Infraestructure.Helpers.RestClientHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneOf;
using RestSharp;

namespace DiarioOficial.Infraestructure.Services.OfficialStateDiary
{
    public class OfficialMunicipalDiaryService() : IOfficialMunicipalDiaryService
    {
        public async Task<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>> GetOfficialMunicipalDiaryResponse(string name, string year)
        {
            var requestQuery = CreateRequestQuery(name, year);

            var url = UrlConstants.OFFICIAL_DIARY_URL;

            var response = await RestClientQueryHelpers.GetOfficialMunicipalDiary(requestQuery, url);

            if (response is null)
                return new InvalidResponseContent();

            return DeserializeDiary(response);
        }

        internal Dictionary<string, string> CreateRequestQuery(string name, string year)
        {
            return new Dictionary<string, string>
            {
                { "action", "edicoes_json" },
                { "palavra", name },
                { "de", $"01/01/{year}" },
                { "ate", $"31/12/{year}" }
            };
        }

        internal OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError> DeserializeDiary(RestResponse restResponse)
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
                .Select(jsonItem => new ResponseOfficialMunicipalDiaryDTO(
                    jsonItem["numero"]?.ToString() ?? string.Empty,
                    jsonItem["dia"]?.ToString() ?? string.Empty,
                    jsonItem["arquivo"]?.ToString() ?? string.Empty,
                    jsonItem["desctpd"]?.ToString() ?? string.Empty,
                    TypeDiaryEnum.OfficialStateDiary
                ))
                .ToList();

            return diary;
        }

    }
}