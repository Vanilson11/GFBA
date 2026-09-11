using GFBA.Domain.Repositories;

namespace GFBA.Infrastructure.DataAccess.Repositories;
internal class UnitOffWork : IUnitOffWork
{
    private readonly GFBADbContext _dbContext;

    public UnitOffWork(GFBADbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
