using GFBA.Domain.Entities;

namespace GFBA.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(Usuario user);
}
