using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login
{
    public record ResquestAddOrUpdateLoginDTO
        (
            string UserName,
            string PasswordHash,
            UserEnum? role
        );
}
