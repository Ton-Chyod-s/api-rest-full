using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.CreateOrUpdateLogin
{
    public record CreateOrUpdateLoginDTO
    (
        string Username,
        string PasswordHash,
        string Email,
        bool IsActive,
        UserEnum Roles,
        long BearerToken
    );

} 