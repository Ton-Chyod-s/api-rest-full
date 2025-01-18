using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface IUpdateLoginUseCase
    {
        Task<OneOf<bool, BaseError>> UpdateLogin(RequestUpdateLoginDTO requestUpdateLoginDTO);
    }
}
