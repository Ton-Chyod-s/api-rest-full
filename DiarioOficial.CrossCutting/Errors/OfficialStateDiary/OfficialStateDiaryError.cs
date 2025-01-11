using Microsoft.AspNetCore.Http;

namespace DiarioOficial.CrossCutting.Errors.OfficialStateDiary
{
    public record NotFoundOfficialStateDiary()
        : BaseError("Nenhum Diário Oficial relacionado foi encontrado!", nameof(NotFoundOfficialStateDiary), StatusCodes.Status404NotFound);
    public record InvalidResponseContent()
        : BaseError("O corpo da requisição não pode ser nulo ou vazio.", nameof(InvalidResponseContent), StatusCodes.Status400BadRequest);
    public record InvalidYear()
        : BaseError("O parâmetro 'year' deve ser um ano válido..", nameof(InvalidYear), StatusCodes.Status400BadRequest);
    public record InvalidName()
        : BaseError("O parâmetro 'name' não pode ser nulo ou vazio.", nameof(InvalidName), StatusCodes.Status400BadRequest);
    public record OfficialDiaryNotSaved()
        : BaseError("O Diário Oficial não foi salvo.", nameof(OfficialDiaryNotSaved), StatusCodes.Status500InternalServerError);
}
