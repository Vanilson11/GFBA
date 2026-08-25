using GFBA.Communication.Enums;

namespace GFBA.Communication.Requests;
public class RequestRegistrarUsuarioJson
{
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public Cargo Cargo { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
