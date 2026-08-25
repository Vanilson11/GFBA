using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Entities;
using GFBA.Domain.Security.Tokens;
using GFBA.Exception.Exceptions;
using Mapster;

namespace GFBA.Application.UseCases.Usuarios.Registrar;
public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
{
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public RegistrarUsuarioUseCase(IAccessTokenGenerator accessTokenGenerator)
    {
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request)
    {
        ValidarRequest(request);

        var user = request.Adapt<User>();

        //Hashear a senha do usuário usando o ArgonId

        return new ResponseRegistrarUsuarioJson
        {
            Nome = request.Nome,
            Matricula = request.Matricula,
            Token = _accessTokenGenerator.Generate(user)
        };
    }

    private void ValidarRequest(RequestRegistrarUsuarioJson request)
    {
        var resultado = new UsuarioUseCaseValidator().Validate(request);

        if (resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(mensagensErro);
        }
    }
}
