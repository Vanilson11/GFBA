using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Repositories.Usuarios;
using GFBA.Domain.Security.Cripitography;
using GFBA.Domain.Security.Tokens;
using GFBA.Exception;
using GFBA.Exception.Exceptions;

namespace GFBA.Application.UseCases.DoLogin;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IReadOnlyUsuariosRepository _readOnlyUsuarioRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IReadOnlyUsuariosRepository readOnlyUsuariosRepository,
        IPasswordHasher passwordHasher,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _readOnlyUsuarioRepository = readOnlyUsuariosRepository;
        _passwordHasher = passwordHasher;
        _accessTokenGenerator = accessTokenGenerator;
    }
    public async Task<ResponseDoLoginJson> Executar(RequestDoLoginJson request)
    {
        ValidarRequest(request);

        var usuario = await _readOnlyUsuarioRepository.ExisteUsuarioComEmail(request.Email);

        if (usuario is null) throw new InvalidLoginException(ResourceErrorMessages.LOGIN_INVALIDO);

        var senhaValida = _passwordHasher.VerifyPassword(request.Senha, usuario.Senha);

        if (senhaValida is false) throw new InvalidLoginException(ResourceErrorMessages.LOGIN_INVALIDO);

        return new ResponseDoLoginJson
        {
            Nome = usuario.Nome,
            Token = _accessTokenGenerator.Generate(usuario)
        };
    }

    private void ValidarRequest(RequestDoLoginJson request)
    {
        var resultado = new DoLoginUseCaseValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var errorsMessages = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(errorsMessages);
        }
    }
}
