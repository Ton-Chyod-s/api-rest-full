using DiarioOficial.CrossCutting.DTOs.SendEmail;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.SendEmail
{
    public interface ISendEmailUseCase
    {
        Task<OneOf<bool, BaseError>> SendAsyncEmail(RequestSendEmailDTO requestSendEmailDTO);
    }
}
