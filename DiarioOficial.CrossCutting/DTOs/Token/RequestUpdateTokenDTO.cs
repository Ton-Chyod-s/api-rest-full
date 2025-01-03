namespace DiarioOficial.CrossCutting.DTOs.Token
{
    public record RequestUpdateTokenDTO
        (
            long AuthToken,
            string Token,
            long userId
        );
}
