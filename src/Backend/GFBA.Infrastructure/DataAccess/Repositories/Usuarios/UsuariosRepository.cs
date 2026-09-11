using GFBA.Domain.Entities;
using GFBA.Domain.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace GFBA.Infrastructure.DataAccess.Repositories.Usuarios;
internal class UsuariosRepository : IWriteOnlyUsuariosRepository, IReadOnlyUsuariosRepository
{
    private readonly GFBADbContext _context;

    public UsuariosRepository(GFBADbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task Add(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task<Usuario?> ExisteUsuarioComEmail(string email) => await _context.Usuarios
        .FirstOrDefaultAsync(usuario => usuario.Ativo && usuario.Email.Equals(email));

    public async Task<bool> ExisteUsuarioComMatricula(string matricula) => await _context.Usuarios.AnyAsync(usuario => usuario.Ativo && usuario.Matricula.Equals(matricula));
}
