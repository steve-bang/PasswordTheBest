
using System.Security.Cryptography;

namespace PasswordTheBest;

public class PasswordHashSHA256Salt : PasswordHasherAbstract
{
    private readonly int HashSize = 64;

    private readonly int SaltSize = 128;

    private readonly int Iterations = 350000;

    public PasswordHashSHA256Salt()
    {
        Algorithms = HashAlgorithmName.SHA256;
    }

    public PasswordHashSHA256Salt(
        int hashSize,
        int saltSize,
        int iterations
    )
    {
        HashSize = hashSize;
        SaltSize = saltSize;
        Iterations = iterations;
    }


    /// <inheritdoc />
    public string HashPassword(string password, byte[] salt)
    {
        // Hash the password and encode the parameters
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithms, HashSize);

        return Convert.ToBase64String(hash);
    }

    /// <inheritdoc />
    public override string Hash(string password, out string salt)
    {
        // Generate a random salt
        byte[] saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Fill(saltBytes);

        salt = Convert.ToBase64String(saltBytes);

        return HashPassword(password, saltBytes);
    }

    public override bool Verify(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        string newHash = HashPassword(password, saltBytes);

        return newHash == hash;
    }
}