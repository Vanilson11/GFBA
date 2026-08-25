using FluentValidation;
using GFBA.Communication.Requests;

using GFBA.Exception;

namespace GFBA.Application.UseCases.FichasBA.Registrar;
public class RegistrarFichasBAValidator : AbstractValidator<RequestFichaBAJson>
{
    public RegistrarFichasBAValidator()
    {
        RuleFor(request => request.Estudante).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_DOIS_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Estudante) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_CEM_CARACTERES);
        RuleFor(request => request.Turma).IsInEnum().WithMessage(ResourceErrorMessages.TURMA_INVALIDA);
        RuleFor(request => request.Turno).IsInEnum().WithMessage(ResourceErrorMessages.TURNO_INVALIDO);
        RuleFor(request => request.DataNascimento).LessThan(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_NASCIMENTO_INVALIDA);
        RuleFor(request => request.Responsavel).NotEmpty().WithMessage(ResourceErrorMessages.NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ResourceErrorMessages.NOME_DOIS_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.Responsavel) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(100).WithMessage(ResourceErrorMessages.NOME_MAIOR_CEM_CARACTERES);
        RuleFor(request => request.ContatoResponsavel).NotEmpty().WithMessage(ResourceErrorMessages.CONTATO_RESPONSAVEL_OBRIGATORIO)
            .MinimumLength(10).WithMessage(ResourceErrorMessages.CONTATO_RESPONSAVEL_MINIMO_DEZ_CARACTERES)
            .When(request => string.IsNullOrWhiteSpace(request.ContatoResponsavel) == false, ApplyConditionTo.CurrentValidator)
            .MaximumLength(45).WithMessage(ResourceErrorMessages.CONTATO_RESPONSAVEL_MAXIMO_QUARENTA_CINCO_CARACTERES);
        RuleFor(request => request.DataAbertura).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.DATA_ABERTURA_INVALIDA);
        RuleFor(request => request.Motivo).IsInEnum().WithMessage(ResourceErrorMessages.MOTIVO_INVALIDO);
        RuleFor(request => request.Status).IsInEnum().WithMessage(ResourceErrorMessages.STATUS_INVALIDO);
        RuleFor(request => request.Observacoes).MaximumLength(500).WithMessage(ResourceErrorMessages.OBSERVACOES_MAXIMO_QUINHENTOS_CARACTERES);
        RuleForEach(request => request.AcoesBA).SetValidator(new AcaoBAValidator());
        //como AcoesBA é uma lista, deve-se usar RuleForEach, pois RuleFor é só para um único objeto
        //RuleForEach itera sobre cada elemento da coleção e aplica as regras de validação em cada um separadamente
        //O SetValidator serve pra dizer: "para cada item dessa coleção (ou pra uma propriedade específica), use este outro AbstractValidator<T> pra validar"
    }
}
