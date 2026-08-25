using FluentValidation;
using GFBA.Domain.Entities;
using GFBA.Exception;

namespace GFBA.Application.UseCases.FichasBA;
public class AcaoBAValidator : AbstractValidator<AcaoBA>
{
    public AcaoBAValidator()
    {
        RuleFor(acao => acao.Tipo).IsInEnum().WithMessage(ResourceErrorMessages.TIPO_ACAO_BA_INVALIDO);
        RuleFor(acao => acao.Data).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_ACAO_BA_INVALIDA);
        RuleFor(acao => acao.Observacao).MaximumLength(500).WithMessage(ResourceErrorMessages.OBSERVACOES_MAXIMO_QUINHENTOS_CARACTERES);
    }
}
