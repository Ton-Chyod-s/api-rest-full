using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface ICreateLoginUseCase
    {
        Task<OneOf<bool, BaseError>> CreateLogin(ResquestAddOrUpdateLoginDTO content);
    }
}
