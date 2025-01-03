using DiarioOficial.CrossCutting.DTOs.Token;
using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login.CreateOrUpdateLogin
{
    public record CreateOrUpdateLoginDTO
    (
        string Username,
        string PasswordHash,
        string Email,
        bool IsActive,
        UserEnum? Roles,
        string? BearerToken
    );

}