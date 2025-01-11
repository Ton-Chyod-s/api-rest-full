using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.Login;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DiarioOficial.API.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/login")
                .WithTags("Login")
                .WithDescription("This endpoint allows users to authenticate themselves by providing valid credentials.")
                .WithOpenApi();

            root.MapPost("/", async ([FromServices] ICreateOrUpdateLoginUseCase addOrUpdateLogin, [FromBody] ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO) =>
            {
                var result = await addOrUpdateLogin.AddOrUpdateLogin(resquestAddOrUpdateLoginDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Create or Update Login")
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapGet("/generate-token", async ([FromServices] IGenerateTokenUseCase loginUseCase, [FromQuery] string userName, [FromQuery] string passwordHash) =>
            {
                var requestLoginDTO = new RequestLoginDTO ( userName, passwordHash );

                var result = await loginUseCase.GenerateToken(requestLoginDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Generate Token")
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            root.MapPost("/update-token", async ([FromServices] IUpdateTokenUseCase updateTokenUseCase, [FromBody] RequestUpdateTokenDTO requestUpdateTokenDTO) =>
            {
                var result = await updateTokenUseCase.UpdateToken(requestUpdateTokenDTO.AuthToken, requestUpdateTokenDTO.Token, requestUpdateTokenDTO.userId);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Update Token")
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<bool, BaseError>>(StatusCodes.Status500InternalServerError);


            return app;
        }
    }
}
