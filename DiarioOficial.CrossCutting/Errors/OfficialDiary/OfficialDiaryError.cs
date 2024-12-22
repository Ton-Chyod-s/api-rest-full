namespace DiarioOficial.CrossCutting.Errors.OfficialDiary
{
    public record OfficialDiaryUnexpectedError()
        : BaseError("Erro inesperado ao tentar acessar o Diário Oficial!", nameof(OfficialDiaryUnexpectedError), StatusCodes.Status500InternalServerError);
}
