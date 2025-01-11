using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.OfficialStateDiary;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.OfficialElectronicDiary;
using DiarioOficial.Domain.Interface.UseCases.OfficialStateDiary;
using DiarioOficial.Domain.Interface.UseCases.SaveAndNotify;
using Microsoft.AspNetCore.Authorization;
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


           root.MapGet("/official-electronic-diary", async ([FromServices] IOfficialStateDiaryUseCase officialElectronicDiaryUseCase, [FromQuery] string name, [FromQuery] string year) =>
            {
                var result = await officialElectronicDiaryUseCase.GetOfficialStateDiaryRecords(name, year);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official Electronic Diary")
            .RequireAuthorization(policy => policy.RequireRole(UserEnum.User.ToString(), UserEnum.Admin.ToString()))
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);
          
            root.MapGet("/official-state-diary", async ([FromServices] IOfficialMunicipalDiaryUseCase officialStateDiary, [FromQuery] string name, [FromQuery] string year) =>
            {
                var result = await officialStateDiary.GetStateDiaryRecords(name, year);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Official State Diary")
            .RequireAuthorization(policy => policy.RequireRole(UserEnum.User.ToString(), UserEnum.Admin.ToString()))
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<List<ResponseOfficialMunicipalDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapPost("/save-and-notify", async ([FromServices] ISaveAndNotifyUseCase saveAndNotifyUseCase) =>
            {
                var result = await saveAndNotifyUseCase.SaveAndNotify();

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
            .WithName("Save And Notify")
            .Produces<OneOf<bool, BaseError>>(StatusCodes.Status200OK)
            .Produces<OneOf<bool, BaseError>>(StatusCodes.Status404NotFound)
            .Produces<OneOf<bool, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
