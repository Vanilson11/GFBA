using GFBA.Communication.Enums;

namespace GFBA.Communication.Requests;
public class RequestRegistrarAcaoBaJson
{
    public TipoAcaoBA Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Observacao { get; set; } = string.Empty;
}
