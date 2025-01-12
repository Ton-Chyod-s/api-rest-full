using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface IAddOrUpdateLoginUseCase
    {
        Task<OneOf<bool, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO);

    }
}
