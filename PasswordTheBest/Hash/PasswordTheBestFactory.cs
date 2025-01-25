
using System.Security.Cryptography;

namespace PasswordTheBest
{
    public class PasswordTheBestFactory
    {
        public static PasswordHasherAbstract Create(HashAlgorithmName algorithms)
        {
            return algorithms.Name switch
            {
                nameof(HashAlgorithmName.SHA256) => new PasswordHash256Salt(),
                _ => throw new NotImplementedException("The algorithm is not supported")
            };
        }
    }
}