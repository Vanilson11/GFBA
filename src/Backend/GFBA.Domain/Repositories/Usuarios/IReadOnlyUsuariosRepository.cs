using GFBA.Domain.Entities;

namespace GFBA.Domain.Repositories.Usuarios;
public interface IReadOnlyUsuariosRepository
{
    Task<bool> ExisteUsuarioComMatricula(string matricula);
    Task<Usuario?> ExisteUsuarioComEmail(string email);
}
