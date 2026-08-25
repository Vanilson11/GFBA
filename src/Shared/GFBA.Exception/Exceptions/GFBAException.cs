namespace GFBA.Exception.Exceptions;
public abstract class GFBAException : System.Exception
{
    protected GFBAException(string message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
