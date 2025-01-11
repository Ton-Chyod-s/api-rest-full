using DiarioOficial.CrossCutting.DTOs.Login;
using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.Domain.Entities.User;

namespace DiarioOficial.Domain.Interface.Services.Token
{
    public interface ITokenService
    {
        ResponseTokenDTO GenerateToken(User user);
    }
}
