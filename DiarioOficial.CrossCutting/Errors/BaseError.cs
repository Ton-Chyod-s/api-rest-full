namespace DiarioOficial.CrossCutting.Errors
{
    public record BaseError(string Message, string ErrorClass, int HttpErrorCode, Dictionary<string, string>? ValidationErros = null);
}
