using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin
{
    public record AddOrUpdateLoginDTO
    (
        string Username,
        string PasswordHash,
        bool? IsActive,
        UserEnum? Roles
    );

}