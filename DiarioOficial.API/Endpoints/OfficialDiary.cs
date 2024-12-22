using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;

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
