﻿using DiarioOficial.CrossCutting.DTOs.OfficialElectronicDiary;
using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.UseCases.SendEmail;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace DiarioOficial.API.Endpoints
{
    public static class MailEndpoints
    {
        public static WebApplication MapMailEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/mail")
                .WithTags("Mail")
                .WithDescription("This group contains endpoints for managing email-related operations.")
                .WithOpenApi();

            root.MapPost("/send-email", async ([FromServices] ISendEmailUseCase sendEmailUseCase, [FromBody] RequestSendEmailDTO requestSendEmailDTO) =>
            {
                var result = await sendEmailUseCase.SendAsyncEmail(requestSendEmailDTO);

                return result.Match(
                    response => Results.Ok(response),
                    error => Results.Json(error, statusCode: error.HttpErrorCode));
            })
           .WithName("Send e-mail")
           .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status200OK)
           .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status404NotFound)
           .Produces<OneOf<List<ResponseOfficialElectronicDiaryDTO>, BaseError>>(StatusCodes.Status500InternalServerError);


            return app;
        }
    }
}