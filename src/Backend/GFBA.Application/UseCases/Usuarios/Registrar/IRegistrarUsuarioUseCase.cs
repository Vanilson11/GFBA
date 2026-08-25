using GFBA.Communication.Requests;
using GFBA.Communication.Responses;

namespace GFBA.Application.UseCases.Usuarios.Registrar;
public interface IRegistrarUsuarioUseCase
{
    Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request);
}
