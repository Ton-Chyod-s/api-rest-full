using DiarioOficial.CrossCutting.DTOs.CreateOrUpdateLogin;
using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface ICreateOrUpdateLoginUseCase
    {
        Task<OneOf<bool, BaseError>> AddOrUpdateLogin(ResquestAddOrUpdateLoginDTO resquestAddOrUpdateLoginDTO);

    }
}
