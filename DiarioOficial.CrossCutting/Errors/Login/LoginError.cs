using Microsoft.AspNetCore.Http;

namespace DiarioOficial.CrossCutting.Errors.Login
{
    public record UserNotSaved() : BaseError("Usuário não foi salvo.", nameof(UserNotSaved), StatusCodes.Status400BadRequest);
    public record TokenNotSaved() : BaseError("Token não foi salvo.", nameof(TokenNotSaved), StatusCodes.Status400BadRequest);
    public record UserNotFound() : BaseError("Usuário não foi encontrado.", nameof(UserNotFound), StatusCodes.Status404NotFound);

}
