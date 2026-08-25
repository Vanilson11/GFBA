namespace GFBA.Domain.Security.Cripitography;
public interface IPasswordHasher
{
    string HashPassword(string password);
}
