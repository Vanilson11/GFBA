using GFBA.Communication.Requests;
using GFBA.Communication.Responses;

namespace GFBA.Application.UseCases.AcaoBA.Registrar;
public interface IRegistrarAcaoBaUseCase
{
    Task<ResponseRegistrarAcaoBaJson> Executar(RequestRegistrarAcaoBaJson request);
}
