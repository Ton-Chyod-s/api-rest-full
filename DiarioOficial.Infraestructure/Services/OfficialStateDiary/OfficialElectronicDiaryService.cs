﻿using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Enums.OfficialStateDiaries;
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
    public class OfficialElectronicDiaryService : IOfficialStateDiaryService
    {
        public async Task<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>> GetOfficialStateDiaryResponse(string name, string year)
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

        internal OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError> DeserializeOfficialStateDiary(RestResponse restResponse)
        {
            var diaryContent = restResponse.Content;

            if (string.IsNullOrWhiteSpace(diaryContent))
                return default;

            var diaryObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(diaryContent);

            if (diaryObject is null || diaryObject.ContainsKey("erro"))
                return new InvalidResponseContent();

            if (!diaryObject.TryGetValue("dataElastic", out var data) || data is not JArray dataArray)
                return new NotFoundOfficialStateDiary();

            var diary = dataArray
                .Select(jsonItem => new ResponseOfficialMunicipalDiaryDTO(
                    jsonItem["Source"]?["Numero"]?.ToString() ?? string.Empty,
                    jsonItem["Source"]?["DataInicioPublicacaoArquivo"]?.ToString() ?? string.Empty,
                    jsonItem["Source"]?["NomeArquivo"]?.ToString() ?? string.Empty,
                    jsonItem["Source"]?["Descricao"]?.ToString() ?? string.Empty,
                    TypeDiaryEnum.OfficialElectronicDiary,
                    null,
                    null
                ))

                .ToList();

            return diary;
        }

    }
}
