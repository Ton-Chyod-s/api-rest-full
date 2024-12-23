using Microsoft.AspNetCore.Http;

namespace DiarioOficial.CrossCutting.Errors.Common
{
    public record InvalidPayload(string Message)
            : BaseError(Message, nameof(InvalidPayload), StatusCodes.Status400BadRequest);

    public record InvalidEnteredInformations(Dictionary<string, string> ValidationErros)
            : BaseError("Alguns campos foram preenchidos de forma inconsistente!", nameof(InvalidEnteredInformations), StatusCodes.Status400BadRequest, ValidationErros);

    public record UnexpectedError(string Message)
            : BaseError(Message, nameof(UnexpectedError), StatusCodes.Status500InternalServerError);

    public record DatabaseError()
            : BaseError("Erro ao atualizar o banco de dados!", nameof(DatabaseError), StatusCodes.Status500InternalServerError);
}
