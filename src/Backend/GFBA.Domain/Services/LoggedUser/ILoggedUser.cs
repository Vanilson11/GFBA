using GFBA.Domain.Entities;

namespace GFBA.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<Usuario> Get();
}
