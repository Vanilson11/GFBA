using GFBA.Domain.Security.Cripitography;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace GFBA.Infrastructure.Security.Criptography;
internal sealed class PasswordHashing : IPasswordHasher
{
    private const int DEGREE_OF_PARALLELISM = 3;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 20 * 1024;
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    public string HashPassword(string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
        var hashedAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            Iterations = ITERATIONS,
            MemorySize = MEMORY_SIZE,
            Salt = salt
        };

        var hash = hashedAlgorithm.GetBytes(32);
        var combinedBytes = new byte[salt.Length + hash.Length];

        salt.CopyTo(combinedBytes, 0);
        hash.CopyTo(combinedBytes, salt.Length);

        return Convert.ToBase64String(combinedBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var combinedBytes = Convert.FromBase64String(hashedPassword);

        var salt = new byte[SALT_SIZE];
        var hash = new byte[HASH_SIZE];

        Array.Copy(combinedBytes, salt, SALT_SIZE);
        Array.Copy(combinedBytes, SALT_SIZE, hash, 0, HASH_SIZE);

        var newHash = HashPassword(password, salt);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }

    private byte[] HashPassword(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashedAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALLELISM,
            Iterations = ITERATIONS,
            MemorySize = MEMORY_SIZE,
            Salt = salt
        };

        return hashedAlgorithm.GetBytes(HASH_SIZE);
    }
}
