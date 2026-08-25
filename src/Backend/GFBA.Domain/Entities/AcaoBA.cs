using GFBA.Domain.Enums;

namespace GFBA.Domain.Entities;
public class AcaoBA
{
    public TipoAcaoBA Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Observacao { get; set; } = string.Empty;
}
