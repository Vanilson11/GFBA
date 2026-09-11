using FluentValidation;
using GFBA.Communication.Requests;
using GFBA.Exception;

namespace GFBA.Application.UseCases.DoLogin;
public class DoLoginUseCaseValidator : AbstractValidator<RequestDoLoginJson>
{
    public DoLoginUseCaseValidator()
    {
        RuleFor(request => request.Email)
            .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_OBRIGATORIO)
            .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALIDO)
            .When(request => string.IsNullOrWhiteSpace(request.Email) is false, ApplyConditionTo.CurrentValidator);
        RuleFor(request => request.Senha).SetValidator(new SenhaValidator<RequestDoLoginJson>());
    }
}
