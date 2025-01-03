using Microsoft.AspNetCore.Http;

namespace DiarioOficial.CrossCutting.Errors.Login
{
    public record LoginError() : BaseError("Erro ao tentar logar!", nameof(LoginError), StatusCodes.Status400BadRequest);
    public record InvalidUsernameOrPassword() : BaseError("Usuário ou senha inválidos.", nameof(InvalidUsernameOrPassword), StatusCodes.Status400BadRequest);
    public record UserNotSaved() : BaseError("Usuário não foi salvo.", nameof(UserNotSaved), StatusCodes.Status400BadRequest);
    public record TokenNotSaved() : BaseError("Token não foi salvo.", nameof(TokenNotSaved), StatusCodes.Status400BadRequest);

}
