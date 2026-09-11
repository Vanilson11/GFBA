using GFBA.Domain.Entities;

namespace GFBA.Domain.Repositories.Usuarios;
public interface IWriteOnlyUsuariosRepository
{
    Task Add(Usuario usuario);
}
