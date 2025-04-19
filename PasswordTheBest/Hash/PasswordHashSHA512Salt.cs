using System.Security.Cryptography;

namespace PasswordTheBest;
public class PasswordHashSHA512Salt : PasswordHasherAbstract
{
    private readonly int HashSize = 128;  // SHA512 produces 512-bit (64-byte) hash, but we can use 128 bytes for derived key
    private readonly int SaltSize = 256;   // Larger salt size for SHA512
    private readonly int Iterations = 100000;  // Iteration count can be adjusted based on performance requirements

    public PasswordHashSHA512Salt()
    {
        Algorithms = HashAlgorithmName.SHA512;
    }

    public PasswordHashSHA512Salt(
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
    /// <param name="password">The password to hash</param>
    /// <param name="salt">The salt to use</param>
    /// <returns>The hashed password as a base64 string</returns>
    public string HashPassword(string password, byte[] salt)
    {
        // Hash the password and encode the parameters
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
        // Generate a random salt
        byte[] saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Fill(saltBytes);

        return HashPassword(password, saltBytes);
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