using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.Login;
using DiarioOficial.Domain.Interface.UseCases.SendEmail;
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

            root.MapGet("/generate-token", async ([FromServices] ILoginUseCase loginUseCase, [FromQuery] string userName, [FromQuery] string passwordHash) =>
            {
                var requestLoginDTO = new RequestLoginDTO ( userName, passwordHash );

                var result = await loginUseCase.LoginGenerateToken(requestLoginDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Generate Token")
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<ResponseTokenDTO, BaseError>>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
