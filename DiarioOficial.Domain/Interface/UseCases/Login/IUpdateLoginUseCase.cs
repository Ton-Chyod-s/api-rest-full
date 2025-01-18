using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Errors;
using OneOf;

namespace DiarioOficial.Domain.Interface.UseCases.Login
{
    public interface IUpdateLoginUseCase
    {
        Task<OneOf<ResponseTokenDTO, BaseError>> UpdateLogin(RequestUpdateLoginDTO requestUpdateLoginDTO);
    }
}
