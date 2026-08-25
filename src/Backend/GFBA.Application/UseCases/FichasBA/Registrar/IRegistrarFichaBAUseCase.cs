using GFBA.Communication.Requests;
using GFBA.Communication.Responses;

namespace GFBA.Application.UseCases.FichasBA.Registrar;
public interface IRegistrarFichaBAUseCase
{
    Task<ResponseRegistrarFichaBAJson> Executar(RequestFichaBAJson request);
}
