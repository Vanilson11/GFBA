using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Entities;
using GFBA.Domain.Repositories;
using GFBA.Domain.Repositories.FichaBA;
using GFBA.Domain.Services.LoggedUser;
using GFBA.Exception.Exceptions;
using Mapster;

namespace GFBA.Application.UseCases.FichasBA.Registrar;
public class RegistrarFichaBAUseCase : IRegistrarFichaBAUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IWriteOnlyFichaBaRepository _writeOnlyFichaBaRepository;
    private readonly IUnitOffWork _unitOffWork;

    public RegistrarFichaBAUseCase(ILoggedUser loggedUser, IWriteOnlyFichaBaRepository writeOnlyFichaBaRepository, IUnitOffWork unitOffWork)
    {
        _loggedUser = loggedUser;
        _writeOnlyFichaBaRepository = writeOnlyFichaBaRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task<ResponseRegistrarFichaBAJson> Executar(RequestFichaBAJson request)
    {
        ValidarRequest(request);

        var orientador = await _loggedUser.Get();

        var fichaBA = request.Adapt<FichaBA>();

        fichaBA.IdOrientador = orientador.Id;

        await _writeOnlyFichaBaRepository.Add(fichaBA);

        await _unitOffWork.Commit();

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
