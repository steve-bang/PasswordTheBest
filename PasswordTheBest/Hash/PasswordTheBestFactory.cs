
using System.Security.Cryptography;

namespace PasswordTheBest
{
    public class PasswordTheBestFactory
    {
        public static PasswordHasherAbstract Create(HashAlgorithmName algorithms)
        {
            return algorithms.Name switch
            {
                nameof(HashAlgorithmName.MD5) => new PasswordHashMD5Salt(),
                nameof(HashAlgorithmName.SHA1) => new PasswordHashSHA1Salt(),
                nameof(HashAlgorithmName.SHA256) => new PasswordHashSHA256Salt(),
                nameof(HashAlgorithmName.SHA512) => new PasswordHashSHA512Salt(),
                _ => throw new NotImplementedException("The algorithm is not supported")
            };
        }
    }
}