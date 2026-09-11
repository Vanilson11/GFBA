using FluentValidation.Results;
using GFBA.Communication.Requests;
using GFBA.Communication.Responses;
using GFBA.Domain.Entities;
using GFBA.Domain.Repositories;
using GFBA.Domain.Repositories.Usuarios;
using GFBA.Domain.Security.Cripitography;
using GFBA.Domain.Security.Tokens;
using GFBA.Exception;
using GFBA.Exception.Exceptions;
using Mapster;

namespace GFBA.Application.UseCases.Usuarios.Registrar;
public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
{
    private readonly IUnitOffWork _unitOffWork;
    private readonly IWriteOnlyUsuariosRepository _writeOnlyUsuariosRepository;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IReadOnlyUsuariosRepository _readOnlyUsuariosRepository;

    public RegistrarUsuarioUseCase(
        IUnitOffWork unitOffWork,
        IAccessTokenGenerator accessTokenGenerator, 
        IPasswordHasher passwordHasher,
        IWriteOnlyUsuariosRepository writeOnlyUsuariosRepository,
        IReadOnlyUsuariosRepository readOnlyUsuariosRepository)
    {
        _unitOffWork = unitOffWork;
        _writeOnlyUsuariosRepository = writeOnlyUsuariosRepository;
        _accessTokenGenerator = accessTokenGenerator;
        _passwordHasher = passwordHasher;
        _readOnlyUsuariosRepository = readOnlyUsuariosRepository;
    }
    public async Task<ResponseRegistrarUsuarioJson> Executar(RequestRegistrarUsuarioJson request)
    {
        await ValidarRequest(request);

        var usuario = request.Adapt<Usuario>();

        usuario.Senha = _passwordHasher.HashPassword(request.Senha);
        
        await _writeOnlyUsuariosRepository.Add(usuario);

        await _unitOffWork.Commit();

        return new ResponseRegistrarUsuarioJson
        {
            Nome = request.Nome,
            Matricula = request.Matricula,
            Token = _accessTokenGenerator.Generate(usuario)
        };
    }

    private async Task ValidarRequest(RequestRegistrarUsuarioJson request)
    {
        var resultado = new UsuarioUseCaseValidator().Validate(request);

        var usuarioComEmailExiste = await _readOnlyUsuariosRepository.ExisteUsuarioComEmail(request.Email);
        if(usuarioComEmailExiste is null)
        {
            resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_COM_EMAIL_REGISTRADO));
        }

        var usuarioComMatriculaExiste = await _readOnlyUsuariosRepository.ExisteUsuarioComMatricula(request.Matricula);
        if(usuarioComMatriculaExiste)
        {
            resultado.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.USUARIO_COM_MATRICULA_REGISTRADO));
        }

        if (resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrorsOnValidationException(mensagensErro);
        }
    }
}
