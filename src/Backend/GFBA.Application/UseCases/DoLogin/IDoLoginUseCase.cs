using GFBA.Communication.Requests;
using GFBA.Communication.Responses;

namespace GFBA.Application.UseCases.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseDoLoginJson> Executar(RequestDoLoginJson request);
}
