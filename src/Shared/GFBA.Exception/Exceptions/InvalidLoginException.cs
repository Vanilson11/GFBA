using System.Net;

namespace GFBA.Exception.Exceptions;
public class InvalidLoginException : GFBAException
{
    public InvalidLoginException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
