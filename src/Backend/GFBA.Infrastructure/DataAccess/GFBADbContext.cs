using GFBA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GFBA.Infrastructure.DataAccess;
internal class GFBADbContext : DbContext
{
    public GFBADbContext(DbContextOptions options) : base(options){}

    public DbSet<Usuario> Usuarios { get; set; }
}
