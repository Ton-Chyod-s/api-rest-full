namespace DiarioOficial.CrossCutting.DTOs.Login
{
    public record RequestLoginDTO
        (
            string Username,
            string PasswordHash
        );

}
