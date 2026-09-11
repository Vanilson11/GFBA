using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Entities;
using GFBA.Domain.Services.LoggedUser;
using GFBA.Exception.Exceptions;
using Mapster;

namespace GFBA.Application.UseCases.FichasBA.Registrar;
public class RegistrarFichaBAUseCase : IRegistrarFichaBAUseCase
{
    private readonly ILoggedUser _loggedUser;

    public RegistrarFichaBAUseCase(ILoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }
    public async Task<ResponseRegistrarFichaBAJson> Executar(RequestFichaBAJson request)
    {
        ValidarRequest(request);

        var orientador = await _loggedUser.Get();

        var fichaBA = request.Adapt<FichaBA>();

        //recuperar o id do orientador logado e o atribuir à fichaBA

        return new ResponseRegistrarFichaBAJson()
        {
            Estudante = fichaBA.Estudante,
            Turma = (Communication.Enums.Turma)fichaBA.Turma
        };
    }

    private void ValidarRequest(RequestFichaBAJson request)
    {
        var result = new RegistrarFichasBAValidator().Validate(request);

        if(result.IsValid is false)
        {
            var errorsMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorsOnValidationException(errorsMessages);
        }
    }
}
