using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Exception.Exceptions;

namespace GFBA.Application.UseCases.AcaoBA.Registrar;
public class RegistrarAcaoBaUseCase : IRegistrarAcaoBaUseCase
{
    public async Task<ResponseRegistrarAcaoBaJson> Executar(RequestRegistrarAcaoBaJson request)
    {
        ValidarRequest(request);

        return new ResponseRegistrarAcaoBaJson()
        {
            Id = Guid.CreateVersion7(),
            Data = request.Data
        };
    }

    private void ValidarRequest(RequestRegistrarAcaoBaJson request)
    {
        var resultado = new AcaoBAValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var errorMessages = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(errorMessages);
        }
    }
}
