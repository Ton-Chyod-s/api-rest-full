using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.Services.SendEmail
{
    public interface ISendEmailService
    {
        Task<OneOf<bool, BaseError>> SendAsyncEmail(RequestSendEmailDTO requestSendEmailDTO);
    }
}
