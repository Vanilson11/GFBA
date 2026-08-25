using GFBA.Domain.Enums;

namespace GFBA.Domain.Entities;
public class FichaBA
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Estudante { get; set; } = string.Empty;
    public Turma Turma { get; set; } 
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string ContatoResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public Status Status { get; set; } 
    public string Observacoes { get; set; } = string.Empty;
    public Cargo Orientador { get; set; } = Cargo.ORIENTADOR;
    public IList<AcaoBA> AcoesBA { get; set; } = [];
}
