using System.Security.Cryptography;
using System.Text;

namespace PasswordTheBest;

public class PasswordHashMD5Salt : PasswordHasherAbstract
{
    private readonly int SaltSize = 16; // 128-bit salt

    public PasswordHashMD5Salt()
    {
        Algorithms = HashAlgorithmName.MD5;
    }

    public PasswordHashMD5Salt(int saltSize)
    {
        SaltSize = saltSize;
    }

    /// <summary>
    /// Hashes password with MD5 (INSECURE - FOR LEGACY USE ONLY)
    /// </summary>
    private string HashWithMD5(string input)
    {
        using (var md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    /// <inheritdoc />
    public override string Hash(string password, out string salt)
    {
        byte[] saltBytes = new byte[SaltSize];
        RandomNumberGenerator.Fill(saltBytes);
        salt = Convert.ToBase64String(saltBytes);

        return HashPassword(password, saltBytes);
    }

    private string HashPassword(string password, byte[] salt)
    {
        // Combine password + salt
        string saltedPassword = password + Convert.ToBase64String(salt);
        return HashWithMD5(saltedPassword);
    }

    /// <inheritdoc />
    public override bool Verify(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        string computedHash = HashPassword(password, saltBytes);
        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(computedHash),
            Encoding.UTF8.GetBytes(hash));
    }

    /// <inheritdoc />
    public override bool Verify(string password, string hash)
    {
        throw new NotSupportedException("Salt is required for MD5 verification");
    }

    /// <inheritdoc />
    public override string Hash(string password)
    {
        throw new NotSupportedException("Salted version must be used for MD5");
    }
}