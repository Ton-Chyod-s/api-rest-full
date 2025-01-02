using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Enums.Person;
using DiarioOficial.CrossCutting.Enums.User;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Repository;
using DiarioOficial.Domain.Interface.UseCases.Person;
using DiarioOficial.Domain.Interface.UseCases.SendEmail;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DiarioOficial.API.Endpoints
{
    public static class PersonEndpoints
    {
        public static WebApplication MapPersonEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/person")
                .WithTags("Person")
                .WithDescription("This group contains endpoints for managing person-related operations, including creation, updates, and retrieval of person details.")
                .WithOpenApi();

            root.MapPost("", async ([FromServices] IPersonUseCase personUseCase, [FromBody] PersonEnum personEnum) =>
            {
                var result = await personUseCase.AddOrUpdatePerson(personEnum);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Person")
           .RequireAuthorization(policy => policy.RequireRole(UserEnum.Admin.ToString()))
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapDelete("/remove-person", async ([FromServices] IRemovePersonUseCase removePersonUseCase, [FromQuery] long personId) =>
            {
                var result = await removePersonUseCase.RemovePerson(personId);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("RemovePerson")
           .RequireAuthorization(policy => policy.RequireRole(UserEnum.Admin.ToString()))
           .Produces<OneOf<long, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<long, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<long, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
