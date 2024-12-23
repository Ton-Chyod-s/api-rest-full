namespace DiarioOficial.API.Endpoints
{
    public static class OfficialDiaryEndpoints
    {
        public static WebApplication MapOfficialDiaryEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/official-diary")
                .WithTags("Official Diary")
                .WithDescription("Endpoints related to the Official Diary!!!")
                .WithOpenApi();


            return app;
        }
    }
}
