using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login
{
    public record ResquestAddOrLoginDTO
        (
            string UserName,
            string Password
        );
}
