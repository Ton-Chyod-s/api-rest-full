using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DiarioOficial.API.Endpoints
{
    public static class OfficialDiaryEndpoints
    {
        public static WebApplication MapOfficialDiaryEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/diary")
                .WithTags("Diary")
                .WithDescription("Endpoints related to the Official Diary!!!")
                .WithOpenApi();

            root.MapGet("/official-electronic-diary", async ([FromServices] IOfficialElectronicDiaryUseCase officialElectronicDiaryUseCase, [FromQuery] string name, [FromQuery] string year) =>
            {
                var result = await officialElectronicDiaryUseCase.GetElectronicDiaryRecords(name, year);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official Electronic Diary")
            .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapGet("/official-state-diary", async ([FromServices] IOfficialStateDiaryUseCase officialStateDiary, [FromQuery] string name, [FromQuery] string year) =>
            {
                var result = await officialStateDiary.GetStateDiaryRecords(name, year);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official State Diary")
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
