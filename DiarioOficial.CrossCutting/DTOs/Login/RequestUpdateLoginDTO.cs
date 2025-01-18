using DiarioOficial.CrossCutting.Enums.User;

namespace DiarioOficial.CrossCutting.DTOs.Login
{
    public record RequestUpdateLoginDTO
        (
            string Name,
            UserEnum? Type
        );

}
