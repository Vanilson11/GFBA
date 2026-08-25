using GFBA.Domain.Enums;

namespace GFBA.Domain.Entities;
public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public Cargo Cargo { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
