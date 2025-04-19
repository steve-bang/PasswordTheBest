using System.Security.Cryptography;

namespace PasswordTheBest;

public class PasswordHashSHA1Salt : PasswordHasherAbstract
{
    private readonly int HashSize = 20;  // SHA-1 produces 160-bit (20-byte) hash
    private readonly int SaltSize = 32;   // Salt size
    private readonly int Iterations = 10000;  // Lower iterations due to SHA-1 weakness

    public PasswordHashSHA1Salt()
    {
        Algorithms = HashAlgorithmName.SHA1;
    }

    public PasswordHashSHA1Salt(
        int hashSize,
        int saltSize,
        int iterations
    )
    {
        HashSize = hashSize;
        SaltSize = saltSize;
        Iterations = iterations;
    }

    /// <summary>
    /// Hashes the password with the provided salt
    /// </summary>
    public string HashPassword(string password, byte[] salt)
    {
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithms,
            HashSize);

        return Convert.ToBase64String(hash);
    }

    /// <inheritdoc />
    public override string Hash(string password)
    {
        byte[] saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Fill(saltBytes);
        return HashPassword(password, saltBytes);
    }

    /// <inheritdoc />
    public override string Hash(string password, out string salt)
    {
        byte[] saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Fill(saltBytes);

        salt = Convert.ToBase64String(saltBytes);
        return HashPassword(password, saltBytes);
    }

    /// <inheritdoc />
    public override bool Verify(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        string newHash = HashPassword(password, saltBytes);
        return CryptographicOperations.FixedTimeEquals(
            Convert.FromBase64String(newHash),
            Convert.FromBase64String(hash));
    }

    /// <inheritdoc />
    public override bool Verify(string password, string hash)
    {
        throw new System.NotSupportedException("Salt is required for verification with this implementation");
    }
}