using System.Text.Json;
using DiarioOficial.CrossCutting.DTOs.Session;
using DiarioOficial.Infraestructure.Constants;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DiarioOficial.Infraestructure.Helpers
{
    internal static class RestClientHelpers
    {
        internal static async Task<JObject> Fetch(object queryBody, List<SessionCookieDTO> cookies)
        {
            var request = GetHttpRequestMessage(queryBody);

            var cookieHeader = GetCookieHeader(cookies);
            request.AddHeader("Cookie", cookieHeader);

            var response = await SendEsusRequest(request);
            var jsonResponseContent = GetReponseContent(response);

            return jsonResponseContent;
        }

        internal static string GetCookieHeader(List<SessionCookieDTO> cookies)
            => string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}"));

        internal static RestRequest GetHttpRequestMessage(object queryBody)
        {
            var jsonContent = JsonSerializer.Serialize(queryBody);

            var request = new RestRequest(UrlConstants.OFFICIAL_DIARY_URL)
            {
                RequestFormat = DataFormat.Json,
                Method = Method.Post
            };

            request.AddJsonBody(jsonContent);

            return request;
        }

        internal static async Task<RestResponse> SendEsusRequest(RestRequest request)
        {
            var client = new RestClient();

            var response = await client.ExecuteAsync(request);

            return response;
        }

        internal static JObject GetReponseContent(RestResponse response)
        {
            var responseContent = response.Content;

            if (string.IsNullOrWhiteSpace(responseContent))
                return [];

            return JObject.Parse(responseContent);
        }
    }
}
