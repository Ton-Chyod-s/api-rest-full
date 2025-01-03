using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface IUpdateTokenUseCase
    {
        Task<OneOf<bool, BaseError>> UpdateToken(long authToken, string token, long userId);
    }
}
