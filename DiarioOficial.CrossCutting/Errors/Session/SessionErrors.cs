using Microsoft.AspNetCore.Http;

namespace DiarioOficial.CrossCutting.Errors.Session
{
    public record class SessionErrors() 
        : BaseError("Erro ao adicionar a sessão!", nameof(SessionErrors), StatusCodes.Status500InternalServerError);

}
