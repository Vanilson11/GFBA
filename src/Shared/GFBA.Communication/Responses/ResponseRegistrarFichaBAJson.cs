using GFBA.Communication.Enums;

namespace GFBA.Communication.Responses;
public class ResponseRegistrarFichaBAJson
{
    public string Estudante { get; set; } = string.Empty;
    public Turma Turma { get; set; }
}
