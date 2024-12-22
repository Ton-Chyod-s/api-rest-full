using DiarioOficial.CrossCutting.Errors.Common;
using DiarioOficial.CrossCutting.Errors.OfficialDiary;

namespace DiarioOficial.API.Middlewares
{
    public class ExceptionMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleUnexpectedException(httpContext, ex);
            }
        }

        private static async Task HandleUnexpectedException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(new OfficialDiaryUnexpectedError());
        }
    }
}
