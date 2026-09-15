namespace GFBA.Domain.Repositories.FichaBA;
public interface IWriteOnlyFichaBaRepository
{
    Task Add(Entities.FichaBA fichaBA);
}
