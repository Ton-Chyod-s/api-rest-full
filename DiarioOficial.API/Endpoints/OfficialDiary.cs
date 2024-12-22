using DiarioOficial.CrossCutting.Errors;
using DocumentFormat.OpenXml.EMMA;

namespace DiarioOficial.API.Endpoints
{
    public static class OfficialDiary
    {
        public static WebApplication MapOfficialDiary(this WebApplication app)
        {
            var root = app.MapGroup("/official-diary")
                .WithTags("Official Diary")
                .WithDescription("Endpoints for the Official Diary")
                .WithOpenApi();

           


            return app;
        }
    }
}
