using System.Text.Json;
using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.Domain.Interface.Services.OfficialStateDiary;
using RestSharp;

namespace DiarioOficial.Infraestructure.Services
{
    public class OfficialStateDiaryService() : IOfficialStateDiaryService
    {


        private string QueryBody(string of, string to)
        {
            var queryObject = new
            {
                action = "edicoes_json",
                palavra = " ",
                numero = "",
                de = of, 
                ate = to, 
                _0 = 0.5278609866886916,
                draw = 1,
                start = 0,
                length = 10,
                order = new[]
                {
                    new { column = 0, dir = "desc" }
                },
                search = new { value = "", regex = false }
            };

            return JsonSerializer.Serialize(queryObject);
        }
    }
}
