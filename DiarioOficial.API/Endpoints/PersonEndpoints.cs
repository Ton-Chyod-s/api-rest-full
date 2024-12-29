using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
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

            root.MapGet("", async ([FromServices] IPersonUseCase personUseCase, [FromQuery] string name) =>
            {
                var result = await personUseCase.AddOrUpdatePerson(name);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Person")
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status500InternalServerError);


            return app;
        }
    }
}
