using DiarioOficial.CrossCutting.DTOs;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases;
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

            root.MapGet("/official-electronic-diary", async ([FromServices] IOfficialElectronicDiaryUseCase officialElectronicDiaryUseCase, [FromQuery] string cpf) =>
            {
                var result = await officialElectronicDiaryUseCase.Execute(cpf);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official Electronic Diary")
            .Produces<OneOf<OfficialElectronicDiaryDTO, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<OfficialElectronicDiaryDTO, BaseError>>(StatusCodes.Status401Unauthorized)
            .Produces<OneOf<OfficialElectronicDiaryDTO, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<OfficialElectronicDiaryDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapGet("/official-state-diary", async ([FromServices] IOfficialStateDiaryUseCase officialStateDiary, [FromQuery] string name, string year) =>
            {
                var result = await officialStateDiary.Execute(name, year);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official State Diary")
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status401Unauthorized)
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<List<ResponseOfficialStateDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
