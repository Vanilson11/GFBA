using System.Net;

namespace GFBA.Exception.Exceptions;
public class ErrorsOnValidationException : GFBAException
{
    private readonly List<string> _errors;

    public ErrorsOnValidationException(List<string> errors) : base(string.Empty)
    {
        _errors = errors;
    }
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors() => _errors;
}
