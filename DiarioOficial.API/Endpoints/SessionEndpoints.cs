using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.Login;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DiarioOficial.API.Endpoints
{
    public static class SessionEndpoints
    {
        public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/login")
                .WithTags("Login")
                .WithDescription("This endpoint allows users to authenticate themselves by providing valid credentials.")
                .WithOpenApi();

            root.MapPost("/", async ([FromServices] ILoginUseCase addOrUpdateLogin, [FromBody] ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO) =>
            {
                var result = await addOrUpdateLogin.LoginWithApp(resquestAddOrUpdateLoginDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Login With App")
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapPost("/AddLogin", async ([FromServices] ICreateLoginUseCase createLoginUseCase, [FromBody] ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO) =>
            {
                var result = await createLoginUseCase.CreateLogin(resquestAddOrUpdateLoginDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Create Login With App")
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
