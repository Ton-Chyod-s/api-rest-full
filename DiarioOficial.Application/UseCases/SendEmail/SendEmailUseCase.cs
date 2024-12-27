using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using DiarioOficial.Domain.Interface.Services.SendEmail;
using DiarioOficial.Domain.Interface.UseCases.SendEmail;
using OneOf;

namespace DiarioOficial.Application.UseCases.SendEmail
{
    internal class SendEmailUseCase
        (
            ISendEmailService sendEmailService
        ) : ISendEmailUseCase
    {
        private readonly ISendEmailService _sendEmailService;   

        public async Task<OneOf<bool, BaseError>> SendAsyncEmail(RequestSendEmailDTO requestSendEmailDTO)
        {
            var lol = await _sendEmailService.SendAsyncEmail(requestSendEmailDTO);

            throw new NotImplementedException();
        }
    }
}
