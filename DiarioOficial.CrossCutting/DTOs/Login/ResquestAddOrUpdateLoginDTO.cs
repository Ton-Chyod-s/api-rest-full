using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login
{
    public record ResquestAddOrUpdateLoginDTO
        (
            string UserName,
            string PasswordHash,
            string Email,
            UserEnum role
        );
}
