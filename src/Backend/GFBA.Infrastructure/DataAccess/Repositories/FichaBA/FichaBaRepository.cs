using GFBA.Domain.Repositories.FichaBA;

namespace GFBA.Infrastructure.DataAccess.Repositories.FichaBA;
internal class FichaBaRepository : IWriteOnlyFichaBaRepository
{
    private readonly GFBADbContext _context;

    public FichaBaRepository(GFBADbContext context)
    {
        _context = context;
    }
    public async Task Add(Domain.Entities.FichaBA fichaBA)
    {
        await _context.Fichaba.AddAsync(fichaBA);
    }
}
