using System;
using System.Collections.Generic;
using System.Text;

namespace DebitosTributarios.Domain.Errors.Common
{
    public record BaseError(string Message, string ErrorClass, int HttpErrorCode, Dictionary<string, string>? ValidationErros = null);
}
