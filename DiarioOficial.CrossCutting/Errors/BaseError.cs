using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioOficial.CrossCutting.Errors
{
    public record BaseError(string Message, string ErrorClass, int HttpErrorCode, Dictionary<string, string>? ValidationErros = null);

}
