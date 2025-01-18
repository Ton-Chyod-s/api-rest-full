using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface IDeleteLoginUseCase
    {
        Task<OneOf<bool, BaseError>> DeleteUser(long userId);
    }
}
