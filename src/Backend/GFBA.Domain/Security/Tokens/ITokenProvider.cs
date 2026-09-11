namespace GFBA.Domain.Security.Tokens;
public interface ITokenProvider
{
    string GetTokenOnRequest();
}
