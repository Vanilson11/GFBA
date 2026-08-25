using FluentValidation;
using GFBA.Communication.Requests;
using GFBA.Exception;

namespace GFBA.Application.UseCases.Usuarios;
public class UsuarioUseCaseValidator : AbstractValidator<RequestRegistrarUsuarioJson>
{
    public UsuarioUseCaseValidator()
    {
        RuleFor(request => request.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_DOIS_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Nome) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_CEM_CARACTERES);
        RuleFor(request => request.Matricula).NotEmpty().WithMessage(ResourceErrorMessages.MATRICULA_OBRIGATORIA)
            .MinimumLength(10).WithMessage(ResourceErrorMessages.MATRICULA_DEZ_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Matricula) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(12).WithMessage(ResourceErrorMessages.MATRICULA_MAIOR_DOZE_CARACTERES);
        RuleFor(request => request.Cargo).IsInEnum().WithMessage(ResourceErrorMessages.CARGO_INVALIDO);
        RuleFor(request => request.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_OBRIGATORIO)
            .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALIDO)
            .When(request => string.IsNullOrWhiteSpace(request.Email) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.EMAIL_MAIOR_CEM_CARACTERES);
        RuleFor(request => request.Senha).SetValidator(new SenhaValidator<RequestRegistrarUsuarioJson>());
    }
}
