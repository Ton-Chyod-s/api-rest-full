using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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

            root.MapGet("", async ([FromServices] IOfficialStateDiary officialStateDiary, [FromQuery] string cpf) =>
            {
                var result = await officialStateDiary();

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("GetCitizenInfos")
            .Produces<OneOf<officialStateDiaryDTO, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<officialStateDiaryDTO, BaseError>>(StatusCodes.Status401Unauthorized)
            .Produces<OneOf<officialStateDiaryDTO, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<officialStateDiaryDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
