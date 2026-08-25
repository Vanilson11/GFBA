using GFBA.Communication.Enums;
using GFBA.Domain.Entities;

namespace GFBA.Communication.Requests;
public class RequestFichaBAJson
{
    public string Estudante { get; set; } = string.Empty;
    public Turma Turma { get; set; } 
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string ContatoResponsavel { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public Motivo Motivo { get; set; }
    public Status Status { get; set; }
    public string Observacoes { get; set; } = string.Empty;
    public IList<AcaoBA> AcoesBA { get; set; } = [];
}
